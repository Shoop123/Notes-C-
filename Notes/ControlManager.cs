using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Notes
{
    sealed class ControlManager
    {
        #region Panel Properties
        public static Size areaStartSize = new Size(NotesProgram.pnlSize.Width - 30, 50);
        public static Point areaStartLocation = new Point(10, 10);
        private static bool dragging = false;
        private static int _lastMouseX;
        private static int _lastMouseY;
        private static Panel currentArea;
        public static int position = 0;

        public static Panel CreatePanel()
        {
            areaStartSize = new Size(NotesProgram.pnlSize.Width - 20, 50);
            Panel pane = new Panel();

            pane.BackColor = Color.Transparent;
            pane.BorderStyle = BorderStyle.FixedSingle;
            pane.ForeColor = ThemeManager.Default();
            pane.Size = areaStartSize;
            pane.Location = areaStartLocation;

            pane.Controls.Add(ControlManager.CreateTextField());
            pane.Controls.Add(ControlManager.CreateCheckBox());

            pane.MouseDown += pane_MouseDown;
            pane.MouseEnter += pane_MouseEnter;
            pane.MouseLeave += pane_MouseLeave;
            pane.MouseUp += pane_MouseUp;
            pane.MouseMove += pane_MouseMove;
            pane.Paint += pane_Paint;

            return pane;
        }

        static void pane_Paint(object sender, PaintEventArgs e)
        {
            Panel pane = sender as Panel;
            Font numberFont = new Font("Arial Rounded MT", 8F);
            Font letterFont = new Font("Arial Rounded MT", 7F);
            String indexString = GetIndex(pane).ToString();
            int textWidth = TextRenderer.MeasureText(indexString, numberFont).Width;
            int xLocation = pane.Width / 2 - textWidth / 2;

            Brush color = null;
            if (ThemeManager.chosenTheme != ThemeManager.black)
                color = Brushes.Black;
            else color = Brushes.White;

            if (PanelTextIsBolded(pane)) letterFont = new Font("Arial Rounded MT Bold", 7F);

            e.Graphics.DrawString(indexString, numberFont, color, new PointF(xLocation, 0));
            e.Graphics.DrawString("B", letterFont, color, new PointF(pane.Width - 14, 0));
        }

        private static void pane_MouseMove(object sender, MouseEventArgs e)
        {
            Panel pane = sender as Panel;
            if (dragging)
                Move(pane, e.X, e.Y);
        }

        private static void pane_MouseUp(object sender, MouseEventArgs e)
        {
            Panel pane = sender as Panel;
            if (dragging)
            {
                dragging = false;
                Drop();
            }
            if (!IsChecked(pane)) pane.BackColor = ThemeManager.Light();
            else pane.BackColor = ThemeManager.Default();
        }

        private static void pane_MouseLeave(object sender, EventArgs e)
        {
            Panel pane = sender as Panel;
            if (!IsChecked(pane)) pane.BackColor = Color.Transparent;
        }

        private static void pane_MouseEnter(object sender, EventArgs e)
        {
            Panel pane = sender as Panel;
            if (!IsChecked(pane)) pane.BackColor = ThemeManager.Light();
        }

        private static void pane_MouseDown(object sender, MouseEventArgs e)
        {
            Panel pane = sender as Panel;
            if (e.X > pane.Width - 14 && e.Y < 12)
                BoldText(pane);
            else
            {
                if (!IsChecked(pane)) pane.BackColor = ThemeManager.Dark();
                else pane.BackColor = ThemeManager.Light();
                if (NotesOrganizer.area.Count > 1)
                    Record(pane, e.X, e.Y);
            }
        }
        #endregion

        #region TextBox Properties
        public static Size textSize = new Size(areaStartSize.Width - 2, 25);
        private static Point startingLocation = new Point(0, (areaStartSize.Height / 2) - 2);

        public static TextBox CreateTextField()
        {
            TextBox note = new TextBox();

            note.BorderStyle = BorderStyle.None;
            note.BackColor = ThemeManager.Default();
            note.Multiline = true;
            note.AcceptsTab = true;
            note.WordWrap = true;
            note.Font = NotesOrganizer.chosenFont;
            note.ForeColor = NotesOrganizer.chosenColor;
            note.MinimumSize = new Size(220, 25);

            note.Size = textSize;
            note.Location = startingLocation;

            note.MouseEnter += note_MouseEnter;
            note.TextChanged += note_TextChanged;

            return note;
        }

        private static void note_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxSizeUpdate(sender);
        }

        private static void note_MouseEnter(object sender, EventArgs e)
        {
            foreach (Control c in (sender as TextBox).Parent.Controls)
                if (c is CheckBox)
                {
                    CheckBox cb = c as CheckBox;
                    if (!cb.Checked)
                        (sender as TextBox).Parent.BackColor = ThemeManager.Light();
                }
        }

        public static int UpdateSize(string text, Font font, string[] lines, int width)
        {
            Size textSize = TextRenderer.MeasureText(text, font);
            if (lines.Length > 0) textSize.Height /= lines.Length;
            int amountOfLines = (int)Math.Ceiling((double)(textSize.Width / width)) + lines.Length;
            int height = textSize.Height * amountOfLines;
            return height;
        }

        private static void CheckTextBoxSizeUpdate(object sender)
        {
            TextBox t = sender as TextBox;
            if (t.Height != UpdateSize(t.Text, t.Font, t.Lines, t.Width)) NotesOrganizer.updateTextBoxSize = true;
        }
        #endregion

        #region CheckBox Properties
        private static Point checkLocation = new Point(1, 0);
        private static Size checkSize = new Size(15, 15);

        public static CheckBox CreateCheckBox()
        {
            CheckBox select = new CheckBox();

            select.FlatStyle = FlatStyle.Flat;
            select.ForeColor = ThemeManager.Default();

            select.Size = checkSize;
            select.Location = checkLocation;

            return select;
        }
        #endregion

        #region Panel Movement
        private static void Move(Panel pane, int x, int y)
        {
            pane.Left = x + pane.Left - _lastMouseX;
            pane.Top = y + pane.Top - _lastMouseY;
            currentArea = pane;
            pane.Refresh();
        }

        private static void Record(Panel pane, int x, int y)
        {
            pane.BringToFront();
            _lastMouseX = x;
            _lastMouseY = y;
            dragging = true;
            currentArea = pane;
        }

        private static void Drop()
        {
            NotesOrganizer.area.Remove(NotesOrganizer.fakePane);
            NotesOrganizer.Align(new Point(NotesOrganizer.fakePane.Location.X, NotesOrganizer.fakePane.Location.Y));
            NotesOrganizer.area.Insert(position, NotesOrganizer.fakePane);
            currentArea = null;
            NotesOrganizer.fakePane = null;
        }

        public static void ManageDragPane()
        {
            if (dragging)
            {
                NotesOrganizer.fakePane = currentArea;
                NotesOrganizer.area.Remove(NotesOrganizer.fakePane);
                NotesOrganizer.fakePane.Location = NotesOrganizer.Align(NotesOrganizer.fakePane.Location);
                if (NotesOrganizer.area[position] != NotesOrganizer.fakePane)
                {
                    NotesOrganizer.area.Remove(NotesOrganizer.fakePane);
                    NotesOrganizer.area.Insert(position, NotesOrganizer.fakePane);
                    Clean();
                }
            }
        }
        #endregion

        private static int GetIndex(Panel pane)
        {
            for (int i = 0; i < NotesOrganizer.area.Count; i++)
                if (NotesOrganizer.area[i].Equals(pane))
                    return i + 1;
            return NotesOrganizer.area.Count + 1;
        }

        private static HashSet<Panel> cleanArea;
        private static void Clean()
        {
            cleanArea = new HashSet<Panel>(NotesOrganizer.area);
            NotesOrganizer.area = cleanArea.ToList();
        }

        public static bool IsChecked(Panel pane)
        {
            foreach (Control c in pane.Controls)
                if (c is CheckBox)
                {
                    CheckBox cb = c as CheckBox;
                    if (!cb.Checked)
                        return false;
                }
            return true;
        }

        public static void Refresh()
        {
            foreach (Panel pane in NotesOrganizer.area)
                pane.Refresh();
        }

        public static void Resize()
        {
            foreach(Panel pane in NotesOrganizer.area)
            {
                pane.Size = areaStartSize;
                foreach(Control c in pane.Controls)
                    if(c is TextBox)
                    {
                        TextBox t = c as TextBox;
                        t.Size = textSize;
                        CheckTextBoxSizeUpdate(t);
                    }
            }
        }

        public static void Highlight()
        {
            foreach(Panel pane in NotesOrganizer.area)
                foreach(Control c in pane.Controls)
                    if(c is CheckBox)
                    {
                        CheckBox checkBox = c as CheckBox;
                        if (!checkBox.Checked)
                            pane.BackColor = Color.Transparent;
                    }
        }

        private static bool PanelTextIsBolded(Panel pane)
        {
            foreach(Control c in pane.Controls)
                if(c is TextBox)
                {
                    TextBox t = c as TextBox;
                    if (t.Font.Bold) return true;
                    else return false;
                }
            return false;
        }

        private static void BoldText(Panel pane)
        {
            foreach(Control c in pane.Controls)
                if(c is TextBox)
                {
                    TextBox t = c as TextBox;
                    if(t.Font.Bold)
                        t.Font = new Font(t.Font.Name, t.Font.Size, FontStyle.Regular);
                    else t.Font = new Font(t.Font.Name, t.Font.Size, FontStyle.Bold);
                }
        }
    }
}
