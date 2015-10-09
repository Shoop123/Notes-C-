using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Notes
{
    sealed class NotesOrganizer
    {
        public static int TextToCheckReferenceNumber = 0;

        public static List<Panel> area = new List<Panel>();

        private static Point _originalLocation = Point.Empty;

        public static Font chosenFont = Notes.Properties.Settings.Default.UserFont;
        public static Color chosenColor = Notes.Properties.Settings.Default.UserColor;

        public static bool checkUpdate = false;
        public static bool justCreated = false;
        public static bool scrollControlIntoView = false;

        public static Point topNoteFutureLocation = Point.Empty;

        #region Movement Animation
        private static int _xSpeed = 0;
        private static int _ySpeed = 0;
        public static int ANIMATION_SPEED = 10;
        public static bool creating = true;
        public static Panel fakePane = null;
        private static int _xDistance = 0;
        private static int _yDistance = 0;
        private static int _hyp = 0;
        private static Point _newLocation = Point.Empty;
        private static Point _currentLocation = Point.Empty;
        private static Point _firstStartLocation = Point.Empty;
        public static bool resetLocations = false;
        public static bool moved = false;
        public static bool updateTextBoxSize = true;
        private static bool resized = false;
        #endregion

        public static void SetFont(Font font)
        {
            chosenFont = font;
            foreach (Panel pane in area)
                foreach (Control c in pane.Controls)
                    if (c is TextBox)
                    {
                        TextBox textBox = c as TextBox;
                        textBox.Font = font;
                    }
            updateTextBoxSize = true;
        }

        public static void SetColor(Color color)
        {
            chosenColor = color;
            foreach (Panel pane in area)
                foreach (Control c in pane.Controls)
                {
                    if (c is TextBox)
                        c.ForeColor = color;
                    else if (c is Label)
                        c.ForeColor = color;
                }
        }

        public static void SelectAll(bool deSelect)
        {
            foreach(Panel pane in area)
                foreach(Control c in pane.Controls)
                    if(c is CheckBox)
                    {
                        CheckBox checkBox = (CheckBox)c;
                        if (deSelect) checkBox.Checked = false;
                        else checkBox.Checked = true;
                    }
        }

        public static String GetAndFormatSelectedNotes()
        {
            string concatNotes = null;

            foreach(Panel pane in area)
                foreach(Control c in pane.Controls)
                    if(c is CheckBox)
                    {
                        CheckBox cb = (CheckBox)c;
                        if(cb.Checked)
                            foreach(Control newC in pane.Controls)
                                if(newC is TextBox)
                                {
                                    TextBox r = (TextBox)newC;
                                    concatNotes += "• " + r.Text + "\r\n";
                                }
                    }
            return concatNotes;
        }

        public static bool IsExtendedView()
        {
            int sum = 0;
            foreach(Panel pane in area)
                sum += ControlManager.areaStartLocation.Y + pane.Height;

            if (sum <= NotesProgram.pnlSize.Height) return false;
            else return true;
        }

        public static Point Align(Point currentLocation)
        {
            Point allignLocation = Point.Empty;
            for (int i = 0; i < area.Count; i++)
            {
                ControlManager.position = i;
                if (currentLocation.Y <= area[i].Location.Y)
                {
                    if (i == 0)
                    {
                        allignLocation = ControlManager.areaStartLocation;
                        break;
                    }
                    int prevY = area[i - 1].Location.Y;
                    allignLocation = new Point(ControlManager.areaStartLocation.X, prevY + ControlManager.areaStartSize.Height + ControlManager.areaStartLocation.Y);
                    break;
                }
                else if (i == area.Count - 1)
                    allignLocation = LastLocation();
            }

            return allignLocation;
        }

        private static Point GetSpeed(double hyp, double xd, double yd)
        {
            Point xySpeed = Point.Empty;
            int xSpeed = 0;
            int ySpeed = 0;
            if (hyp != 0)
            {
                xSpeed = (int)((xd / hyp) * ANIMATION_SPEED);
                ySpeed = (int)((yd / hyp) * ANIMATION_SPEED);

                if (Math.Abs(yd) < ANIMATION_SPEED)
                    ySpeed = (int)yd;
                if (Math.Abs(xd) < ANIMATION_SPEED)
                    xSpeed = (int)xd;
            }
            xySpeed = new Point((int)xSpeed, (int)ySpeed);
            return xySpeed;
        }

        private static Point LastLocation()
        {
            Point lastLocation = area[area.Count - 1].Location;

            lastLocation.X = ControlManager.areaStartLocation.X;
            lastLocation.Y += ControlManager.areaStartSize.Height + ControlManager.areaStartLocation.Y;

            return lastLocation;
        }

        public static void SetFocusToLastTextBox()
        {
            foreach(Control c in area[area.Count - 1].Controls)
                if(c is TextBox)
                {
                    TextBox txtFocus = c as TextBox;
                    txtFocus.Focus();
                }
        }

        private static void PanelSize(Panel pane)
        {
            ControlManager.areaStartSize = new Size(NotesProgram.pnlSize.Width - 30, 50);
            ControlManager.textSize = new Size(ControlManager.areaStartSize.Width - 2, 25);

            if (pane.Size != ControlManager.areaStartSize)
            {
                if (pane.Width < ControlManager.areaStartSize.Width)
                {
                    if (pane.Width + ANIMATION_SPEED > ControlManager.areaStartSize.Width)
                        pane.Width += ControlManager.areaStartSize.Width - pane.Width;
                    else pane.Width += ANIMATION_SPEED;
                }
                else if (pane.Width > ControlManager.areaStartSize.Width)
                {
                    if (pane.Width - ANIMATION_SPEED < ControlManager.areaStartSize.Width)
                        pane.Width += ControlManager.areaStartSize.Width - pane.Width;
                    else pane.Width -= ANIMATION_SPEED;
                }
            }
        }

        private static void TextBoxSize(Panel pane)
        {
            foreach (Control c in pane.Controls)
                if (c is TextBox)
                {
                    TextBox f = (TextBox)c;
                    if(updateTextBoxSize)
                    {
                        int correctSize = ControlManager.UpdateSize(f.Text, f.Font, f.Lines, f.Width);
                        int correctPaneSize = pane.Height - f.Height;

                        if (correctSize > f.Height)
                        {
                            if (f.Height + ANIMATION_SPEED <= correctSize)
                                f.Height += ANIMATION_SPEED;
                            else f.Height++;
                            resized = true;
                        }
                        else if (correctSize < f.Height)
                        {
                            if (f.Height - ANIMATION_SPEED >= correctSize)
                                f.Height -= ANIMATION_SPEED;
                            else f.Height--;
                            resized = true;
                        }

                        if (correctPaneSize < ControlManager.textSize.Height)
                        {
                            if (pane.Height + ANIMATION_SPEED <= correctSize)
                                pane.Height += ANIMATION_SPEED;
                            else pane.Height++;
                            resized = true;
                        }
                        else if (correctPaneSize > ControlManager.textSize.Height)
                        {
                            if (pane.Height - ANIMATION_SPEED >= correctSize)
                                pane.Height -= ANIMATION_SPEED;
                            else pane.Height--;
                            resized = true;
                        }
                    }

                    if(f.Size != ControlManager.textSize)
                    {
                        if (f.Width < ControlManager.textSize.Width)
                        {
                            if (f.Width + ANIMATION_SPEED > ControlManager.textSize.Width)
                                f.Width += ControlManager.textSize.Width - f.Width;
                            else f.Width += ANIMATION_SPEED;
                        }
                        else if (f.Width > ControlManager.textSize.Width)
                        {
                            if (f.Width - ANIMATION_SPEED < ControlManager.textSize.Width)
                                f.Width += ControlManager.textSize.Width - f.Width;
                            else f.Width -= ANIMATION_SPEED;
                        }
                    }
                }
        }

        public static void UpdateLocations()
        {
            _firstStartLocation = ControlManager.areaStartLocation;
            if (IsExtendedView() && !resetLocations) _firstStartLocation.Offset(NotesProgram.scroll);
            moved = false;
            resized = false;

            for (int i = 0; i < area.Count; i++)
            {
                Panel pane = area[i];
                ControlManager.ManageDragPane();

                if (fakePane == pane) continue;

                if (i == 0) 
                    _currentLocation = _firstStartLocation;
                else
                    _currentLocation = new Point(ControlManager.areaStartLocation.X, area[i - 1].Location.Y + area[i - 1].Size.Height + ControlManager.areaStartLocation.Y);

                if (pane.Location != _currentLocation)
                {
                    _xDistance = pane.Location.X - _currentLocation.X;
                    _yDistance = pane.Location.Y - _currentLocation.Y;
                    _hyp = (int)Math.Sqrt((Math.Pow((double)_xDistance, 2) + Math.Pow((double)_yDistance, 2)));

                    _xSpeed = -GetSpeed(_hyp, _xDistance, _yDistance).X;
                    _ySpeed = GetSpeed(_hyp, _xDistance, _yDistance).Y;

                    _newLocation = new Point(pane.Location.X + _xSpeed, pane.Location.Y - _ySpeed);
                    pane.Location = _newLocation;
                    moved = true;
                }
                else if (justCreated && i == area.Count - 1)
                {
                    scrollControlIntoView = true;
                    justCreated = false;
                    SetFocusToLastTextBox();
                }

                PanelSize(pane);
                TextBoxSize(pane);
                
                if (!moved) resetLocations = false;

                area[i] = pane;
            }
            if (!resized) updateTextBoxSize = false;
        }
    }
}
