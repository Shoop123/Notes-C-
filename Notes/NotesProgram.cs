using Microsoft.Win32;
using SaveNotes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Notes
{
    public partial class NotesProgram : Form
    {
        #region Variable Declaration
        private const int cGrip = 16;
        private const int cCaption = 32; 

        Dispatcher UIDispatcher = Dispatcher.CurrentDispatcher;

        private Save save; 
        private Update update;
        private Interpolation office;

        public static Point scroll { get; set; }
        public static Size pnlSize;

        private PointF reminderLocation = new PointF(157.5F, 176);
        Size reminderSize = TextRenderer.MeasureText("No Notes", new Font("Arial Rounded MT Bold", 22));

        public static bool exit = false;
        private bool showOptions = false;
        private bool hideOptions = false;
        private bool showContacts = false;
        private bool hideContacts = false;
        private bool contactsInFocus = false;
        private bool showNoNotes = false;
        #endregion

        #region OnLoad and FormClosing and Constructor
        public NotesProgram()
        {
            InitializeComponent();
            save = new Save();
            update = new Update();
            office = new Interpolation();
        }

        private void NotesProgram_Load(object sender, EventArgs e)
        {
            InitializeTheme();
            LoadNotes();
            if (Properties.Settings.Default.CheckForUpdatesOnStartUp) update.Check();
            contactsPane.Load();
            PositionContacts();
            Startup();
            this.Size = Notes.Properties.Settings.Default.UserSize;
            SetLocations();
            this.Enabled = true;
        }

        private void Notes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exit)
                e.Cancel = true;

            if (contactsInFocus)
                Notes.Properties.Settings.Default.OnContactsPane = true;
            else Notes.Properties.Settings.Default.OnContactsPane = false;
            Notes.Properties.Settings.Default.UserSize = this.Size;
            Notes.Properties.Settings.Default.Save();

            Startup();
            SaveNotes();
            if (Properties.Settings.Default.SaveContactsAutomatically) contactsPane.Save();
        }
        #endregion

        #region Enable Management
        private void Disable()
        {
            pnlNoteHolder.Enabled = false;
            btnNew.Enabled = false;
            btnAdd.Enabled = false;
            btnSelectAll.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void Enable()
        {
            pnlNoteHolder.Enabled = true;
            btnNew.Enabled = true;
            btnAdd.Enabled = true;
            if(NotesOrganizer.area.Count > 0)
            {
                btnDelete.Enabled = true;
                btnSelectAll.Enabled = true;
            }
        }
        #endregion

        #region System Tray Options
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                this.Show();
                this.Opacity = 1;
            }
            ManageUpdater();
        }

        private void addTopNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(TopNote.CreateNote);
            t.Start();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = true;
            SaveNotes();
            FadeOut();
            this.Close();
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                //minimize the form
                //minimizing animation
                FormBorderStyle = FormBorderStyle.FixedSingle;
                WindowState = FormWindowState.Minimized;
            }
            else if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
            ManageUpdater();
        }

        private void notIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.Opacity = 1;
            }
            ManageUpdater();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveNotes();
            FadeOut();
            this.Hide();
            ManageUpdater();
        }

        private void cmsMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.Visible)
            {
                cmsMenu.Items[2].Visible = true;
                cmsMenu.Items[0].Visible = false;
                cmsMenu.Items[3].Visible = true;
                if (WindowState == FormWindowState.Normal)
                {
                    cmsMenu.Items[2].Text = "Minimize";
                    cmsMenu.Items[2].Image = Properties.Resources.minimize;
                }
                else if (WindowState == FormWindowState.Minimized)
                {
                    cmsMenu.Items[2].Text = "Return";
                    cmsMenu.Items[2].Image = Properties.Resources.maximize;
                }
            }
            else
            {
                cmsMenu.Items[3].Visible = false;
                cmsMenu.Items[0].Visible = true;
                cmsMenu.Items[2].Visible = false;
            }
        }
        #endregion

        #region Contacts Management
        private void btnSyncOutlook_Click(object sender, EventArgs e)
        {
            office.GetOutlookContacts();
            contactsPane.SyncWithOutlook();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            contactsPane.Save();
        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            if(btnAddColumn.Text == "Column")
            {
                txtColumnName.Visible = true;
                txtColumnName.Focus();
                btnAddColumn.Text = "Add";
            }
            else
            {
                contactsPane.Columns.Add(txtColumnName.Text, txtColumnName.Text);
                txtColumnName.Text = "";
                txtColumnName.Visible = false;
                btnAddColumn.Text = "Column";
            }
        }

        private void cmsContactClicked_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (contactsPane.SelectedCells.Count > 0)
            {
                int rowIndex = contactsPane.SelectedCells[0].RowIndex;
                string name = contactsPane.Rows[rowIndex].Cells[0].Value == null ? "" : contactsPane.Rows[rowIndex].Cells[0].Value.ToString();
                if (!String.IsNullOrEmpty(name))
                {
                    cmsContactClicked.Items[0].Visible = true;
                    cmsContactClicked.Items[0].Text = "Add " + name + " to Outlook Contacts";
                }
                else cmsContactClicked.Items[0].Visible = false;

                string email = contactsPane.Rows[rowIndex].Cells[1].Value == null ? "" : contactsPane.Rows[rowIndex].Cells[0].Value.ToString();
                if (!String.IsNullOrEmpty(email))
                {
                    cmsContactClicked.Items[2].Visible = true;
                    cmsContactClicked.Items[2].Text = "Email " + email + " using Outlook";
                }
                else cmsContactClicked.Items[2].Visible = false;

                if (contactsPane.SelectedCells[0].ColumnIndex > 3)
                {
                    cmsContactClicked.Items[1].Visible = true;
                    string text = contactsPane.Columns[contactsPane.SelectedCells[0].ColumnIndex].HeaderText;
                    cmsContactClicked.Items[1].Text = "Remove \"" + text + "\" Column";
                }
                else cmsContactClicked.Items[1].Visible = false;
            }
            else e.Cancel = true;
        }

        private void addToOutlookContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = contactsPane.Rows[contactsPane.SelectedCells[0].RowIndex];
            string fName = row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString().Split(' ')[0];
            string lName = row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString().Split(' ').Length > 1 ? row.Cells[0].Value.ToString().Split(' ')[1] : "";
            string email = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            string address = row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString();
            string phone = row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString();

            office.CreateOutlookContact(fName, lName, email, address, phone);
        }

        private void btnRemoveColumn_Click(object sender, EventArgs e)
        {
            RemoveColumn();
        }

        private void contactsPane_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (contactsPane.SelectedCells[0].ColumnIndex > 3)
                btnRemoveColumn.Enabled = true;
            else btnRemoveColumn.Enabled = false;
        }

        private void removeColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveColumn();
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int emailIndex = contactsPane.SelectedCells[0].RowIndex;
            string email = contactsPane.Rows[emailIndex].Cells[1].Value.ToString();
            office.Email(email, NotesOrganizer.GetAndFormatSelectedNotes());
        }

        private void RemoveColumn()
        {
            int removeIndex = contactsPane.SelectedCells[0].ColumnIndex;
            if (removeIndex > 3)
                contactsPane.Columns.RemoveAt(removeIndex);
        }
        #endregion

        #region Painting
        private void NotesProgram_Paint(object sender, PaintEventArgs e)
        {
            Bitmap iconUnscaled = Properties.Resources.select_all;
            Bitmap icon = new Bitmap(iconUnscaled, new Size(25, 25));

            using (Graphics g = e.Graphics)
            {
                g.DrawString("Noter Version: " + Assembly.GetExecutingAssembly().GetName().Version, new Font("Arial Rounded MT Bold", 8F), Brushes.Black, new PointF(30, 0));
                g.DrawImage(icon, new Point(0, 0));

                g.FillRectangle(new SolidBrush(Color.FromArgb(64, 64, 64)), new Rectangle(0, 405, this.Width, this.Height));

                Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
                ControlPaint.DrawSizeGrip(e.Graphics, Color.White, rc);
            }
        }

        private void pnlNoteHolder_Paint(object sender, PaintEventArgs e)
        {
            if(showNoNotes)
                e.Graphics.DrawString("No Notes", new Font("Arial Rounded MT Bold", 22), Brushes.Black, reminderLocation);
        }
        #endregion

        #region Color Properties
        private void btnFont_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
                NotesOrganizer.SetFont(fd.Font);
            Notes.Properties.Settings.Default.UserFont = fd.Font;
            Notes.Properties.Settings.Default.Save();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                NotesOrganizer.SetColor(cd.Color);
            Notes.Properties.Settings.Default.UserColor = cd.Color;
            Notes.Properties.Settings.Default.Save();
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            ThemeDialog td = new ThemeDialog();
            if (td.ShowDialog() == DialogResult.OK)
            {
                ThemeManager.chosenTheme = td.theme;
                Notes.Properties.Settings.Default.UserTheme = td.theme;
                Notes.Properties.Settings.Default.Save();
                InitializeTheme();
                ThemeManager.SyncTheme();
            }
        }
        #endregion

        #region Update User Interface
        new private void Update()
        {
            if (NotesOrganizer.IsExtendedView() && !NotesOrganizer.resetLocations && !pnlNoteHolder.VerticalScroll.Visible)
                scroll = new Point(0, 0);
            if (NotesOrganizer.scrollControlIntoView)
            {
                pnlNoteHolder.ScrollControlIntoView(NotesOrganizer.area[NotesOrganizer.area.Count - 1]);
                scroll = pnlNoteHolder.AutoScrollPosition;
                NotesOrganizer.scrollControlIntoView = false;
            }

            ShowOptions();
            ShowContacts();

            if (exit) Application.Exit();
        }

        private void ShowContacts()
        {
            int endLocation = 500;
            int startLocation = 0;
            int toMove = NotesOrganizer.ANIMATION_SPEED * 5;
            if(showContacts)
            {
                if (pnlContacts.Location.X > startLocation)
                {
                    if (pnlContacts.Location.X - toMove < startLocation)
                        toMove = pnlContacts.Location.X - startLocation;
                    pnlContacts.Location = new Point(pnlContacts.Location.X - toMove, pnlContacts.Location.Y);
                }
                if (pnlContacts.Location.X == startLocation)
                    showContacts = false;
            }
            else if(hideContacts)
            {
                if (pnlContacts.Location.X < endLocation)
                {
                    if (pnlContacts.Location.X + toMove > endLocation)
                        toMove = endLocation - pnlContacts.Location.X;
                    pnlContacts.Location = new Point(pnlContacts.Location.X + toMove, pnlContacts.Location.Y);
                }
                if (pnlContacts.Location.X == endLocation)
                    hideContacts = false;
            }
        }

        private void PositionContacts()
        {
            if(Properties.Settings.Default.OnContactsPane)
            {
                contactsInFocus = true;
                pnlContacts.Location = new Point(0, 81);
                btnContacts.Text = "Notes";
            }
        }

        private void ShowOptions()
        {
            if (showOptions)
            {
                options.Location = new Point(options.Location.X + NotesOrganizer.ANIMATION_SPEED, options.Location.Y);
                if (options.Location.X >= 0)
                    showOptions = false;
            }
            else if (hideOptions)
            {
                options.Location = new Point(options.Location.X - NotesOrganizer.ANIMATION_SPEED, options.Location.Y);
                if (options.Location.X <= -(options.Size.Width))
                    hideOptions = false;
            }
        }

        private void UpdateUI_Tick(object sender, EventArgs e)
        {
            Update();
            NotesOrganizer.UpdateLocations();
        }

        private void ManageUpdater()
        {
            if (!this.Visible) UpdateUI.Stop();
            else UpdateUI.Start();
        }
        #endregion

        #region Saving and Loading Notes
        private void LoadNotes()
        {
            try
            {
                int noteAmount = save.LoadNotes();

                //add and fill in the text boxes
                for (int i = 0; i < noteAmount; i++)
                {
                    AddNotes();

                    Panel pane = NotesOrganizer.area[i];

                    foreach (Control c in pane.Controls)
                        if (c is TextBox)
                        {
                            c.Text = save.chronologicalNoteContainer[i].Trim();
                            if (save.chronologicalBoldTextAnnouncer[i])
                                c.Font = new Font(Notes.Properties.Settings.Default.UserFont.Name, Notes.Properties.Settings.Default.UserFont.Size, FontStyle.Bold);
                        }
                }
            }
            catch { InformationBox.Show("Error loading notes", "Error"); }

            Remind();
        }

        private void SaveNotes()
        {
            if (!Properties.Settings.Default.SaveNotesAutomatically) return;

            save.CheckDirectory();
            string text = string.Empty;
            string newLine = "\r\n";

            //save the notes
            for (int i = 0; i < NotesOrganizer.area.Count; i++)
            {
                Panel pane = NotesOrganizer.area[i];
                foreach (Control c in pane.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox note = (TextBox)c;
                        if (!string.IsNullOrWhiteSpace(note.Text)) text += note.Text + " \\<:" + note.Font.Bold + ":>/" + newLine;
                    }
                }
            }
            save.Update(text);
        }
        #endregion

        #region Form Management
        private void NotesProgram_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);

                if (e.Location.X <= 25 && e.Location.Y <= 25)
                    Process.Start("http://www.smart-notes.webs.com");
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            else if (m.Msg == Notes.NativeMethods.WM_SHOWME)
                SendToTop();

            base.WndProc(ref m);
        }

        private void SendToTop()
        {
            if (!this.Visible)
            {
                this.Opacity = 1;
                this.Show();
            }
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            TopMost = true;
            TopMost = false;
            ManageUpdater();
        }

        private void SetLocations()
        {
            reminderLocation = new PointF((pnlNoteHolder.Width / 2) - (reminderSize.Width / 2), (pnlNoteHolder.Height / 2) - (reminderSize.Height / 2));
            pnlNoteHolder.Size = new Size(this.Width, this.Height - 95);
            pnlContacts.Size = pnlNoteHolder.Size;
            contactsPane.Size = new Size(pnlContacts.Width, pnlContacts.Height - 80);
            btnAddColumn.Location = new Point(btnAddColumn.Location.X, contactsPane.Height + 21);
            btnSave.Location = new Point(3, contactsPane.Height + 52);
            txtColumnName.Location = new Point(84, contactsPane.Height + 24);
            btnSave.Location = new Point(3, contactsPane.Height + 52);
            btnRemoveColumn.Location = new Point(84, contactsPane.Height + 52);
            lblSyncWith.Location = new Point(202, contactsPane.Height + 22);
            btnSyncOutlook.Location = new Point(193, contactsPane.Height + 38);

            options.Size = new Size(100, this.Height - 75);

            pnlSize = pnlNoteHolder.Size;
        }

        private void NotesProgram_Resize(object sender, EventArgs e)
        {
            SetLocations();
            Refresh();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            //open animation(hiding the border)
            if (FormBorderStyle != FormBorderStyle.None)
            {
                UIDispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, (DispatcherOperationCallback)delegate(object unused)
                {
                    FormBorderStyle = FormBorderStyle.None;
                    Size = Properties.Settings.Default.UserSize;
                    return null;
                }
                , null);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        #region Click Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveNotes();
            FadeOut();
            if (Properties.Settings.Default.ExitOnClose)
            {
                exit = true;
                return;
            }
            this.Hide();
            ManageUpdater();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UserSize = this.Size;
            Properties.Settings.Default.Save();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            WindowState = FormWindowState.Minimized;
            ManageUpdater();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddNotes();
            NotesOrganizer.justCreated = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(TopNote.CreateNote);
            t.Start();
        }

        private void btnShowOptions_Click(object sender, EventArgs e)
        {
            options.BringToFront();
            if (btnShowOptions.Text == "Options")
            {
                Disable();
                btnShowOptions.Text = "Hide";
                showOptions = true;
            }
            else
            {
                btnShowOptions.Text = "Options";
                hideOptions = true;
                Enable();
            }
            this.Refresh();
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            FeedBack.CreateFeedback();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            update = new Update();
            NotesOrganizer.checkUpdate = true;
            update.Check();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (NotesOrganizer.GetAndFormatSelectedNotes() != null)
                office.Export(NotesOrganizer.GetAndFormatSelectedNotes());
            else
                InformationBox.Show("Please select at least one note by clicking on the checkbox", "Invalid Text");
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (btnSelectAll.Text == "Select All")
            {
                NotesOrganizer.SelectAll(false);
                btnSelectAll.Text = "Deselect";
                btnDelete.Enabled = true;
            }
            else
            {
                NotesOrganizer.SelectAll(true);
                btnSelectAll.Text = "Select All";
                btnDelete.Enabled = false;
            }
            this.Refresh();
        }

        private void btnContacts_Click(object sender, EventArgs e)
        {
            if (btnContacts.Text == "Contacts")
            {
                showContacts = true;
                contactsInFocus = true;
                btnContacts.Text = "Notes";
            }
            else
            {
                hideContacts = true;
                contactsInFocus = false;
                btnContacts.Text = "Contacts";
            }
            hideOptions = true;
            Enable();
            btnShowOptions.Text = "Options";
            this.Refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool reset = false;
            for (int i = 0; i < NotesOrganizer.area.Count; i++)
            {
                if (reset)
                {
                    i = 0;
                    reset = false;
                }

                Panel pane = NotesOrganizer.area[i];

                foreach (Control c in pane.Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox check = (CheckBox)c;

                        if (check.Checked)
                        {
                            RemoveAtIndex(i);
                            NotesOrganizer.UpdateLocations();
                            //dont delete this, it fixes a bug
                            if (i == 0) i = -1;
                            else i = 0;
                            reset = true;
                        }
                    }
                }
                btnDelete.Enabled = false;
            }
            ControlManager.Refresh();
            Remind();
        }
        #endregion

        private void Startup()
        {
            RegistryKey runRegistryKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

            if(Properties.Settings.Default.StartOnWindowsStartUp)
                if (runRegistryKey != null) runRegistryKey.SetValue("Noter", System.Windows.Forms.Application.ExecutablePath);
            else
                runRegistryKey.DeleteValue("Noter");
        }

        private void Common_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).ForeColor = ThemeManager.black;
        }

        private void Common_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "X") btn.ForeColor = Color.Red;
            else btn.ForeColor = ThemeManager.Default();
        }

        private void AddNotes()
        {
            NotesOrganizer.area.Add(ControlManager.CreatePanel());

            //add note areas
            for (int i = 0; i < NotesOrganizer.area.Count; i++)
            {
                if(!pnlNoteHolder.Controls.Contains(NotesOrganizer.area[i]))
                {
                    pnlNoteHolder.Controls.Add(NotesOrganizer.area[i]);
                    AddHandlers(NotesOrganizer.area[i]);
                }
            }
            Remind();
        }

        private void FadeOut()
        {
            long current = Environment.TickCount;
            long lastUpdate = current;
            double opacity = 1;
            double fadeSpeed = 0.1;
            
            while(opacity > 0)
            {
                current = Environment.TickCount;
                if (current - lastUpdate >= 10)
                {
                    this.Opacity -= fadeSpeed;
                    opacity = this.Opacity;
                    lastUpdate = current;
                }
            }
        }

        private void AddHandlers(Panel pane)
        {
            foreach(Control c in pane.Controls)
                if(c is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)c;
                    checkBox.CheckedChanged += checkBox_CheckedChanged;
                    break;
                }
        }

        private void InitializeTheme()
        {
            contactsPane.DefaultCellStyle.SelectionBackColor =
            ThemeManager.Default();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            bool selected = false;
            bool allSelected = true;
            bool noneSelected = true;

            for (int i = 0; i < NotesOrganizer.area.Count; i++)
            {
                Panel pane = NotesOrganizer.area[i];
                bool currentSelected = false;

                foreach (Control c in pane.Controls)
                    if (c is CheckBox)
                    {
                        CheckBox checkBox = (CheckBox)c;
                        if (checkBox.Checked)
                        {
                            btnDelete.Enabled = true;
                            pane.BackColor = ThemeManager.Default();
                            selected = true;
                            currentSelected = true;
                            noneSelected = false;
                            break;
                        }
                        else
                        {
                            pane.BackColor = Color.Transparent;
                            allSelected = false;
                        }
                        if (!selected) btnDelete.Enabled = false;
                    }
                foreach (Control c in pane.Controls)
                    if (c is TextBox)
                    {
                        TextBox note = (TextBox)c;
                        if (currentSelected) note.Enabled = false;
                        else note.Enabled = true;
                    }
            }
            if (allSelected)
                btnSelectAll.Text = "Deselect";
            else if (noneSelected)
                btnSelectAll.Text = "Select All";
            this.Refresh();
        }

        private void Remind()
        {
            if (NotesOrganizer.area.Count > 0)
            {
                showNoNotes = false;
                pnlNoteHolder.Refresh();
                btnSelectAll.Enabled = true;
            }
            else
            {
                showNoNotes = true;
                pnlNoteHolder.Refresh();
                btnSelectAll.Text = "Select All";
                this.Refresh();
                btnSelectAll.Enabled = false;
            }
        }

        private void RemoveAtIndex(int index)
        {
            pnlNoteHolder.Controls.Remove(NotesOrganizer.area[index]);
            NotesOrganizer.area.Remove(NotesOrganizer.area[index]);
        }

        private void pnlNoteHolder_Scroll(object sender, ScrollEventArgs e)
        {
            scroll = pnlNoteHolder.AutoScrollPosition;
        }

        private void pnlNoteHolder_MouseLeave(object sender, EventArgs e)
        {
            ControlManager.Highlight();
        }

        private void txtColumnName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                contactsPane.Columns.Add(txtColumnName.Text, txtColumnName.Text);
                txtColumnName.Text = "";
                txtColumnName.Visible = false;
                btnAddColumn.Text = "Column";
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }
    }
}
