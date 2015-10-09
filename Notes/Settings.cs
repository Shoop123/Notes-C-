using System;
using System.Drawing;
using System.Windows.Forms;

namespace Notes
{
    public partial class Settings : Form
    {
        private Button btnClose;
        private CheckBox cbStartOnStartUp;
        private CheckBox cbExitOnClose;
        private CheckBox cbSaveNotes;
        private CheckBox cbSaveContacts;
        private CheckBox cbCheckForUpdatesOnStartUp;
        private bool initializing = true;

        public Settings()
        {
            InitializeComponent();
            InitializeCheckboxes();

            initializing = false;
        }

        private void InitializeCheckboxes()
        {
            cbStartOnStartUp.Checked = Properties.Settings.Default.StartOnWindowsStartUp;
            cbExitOnClose.Checked = Properties.Settings.Default.ExitOnClose;
            cbSaveNotes.Checked = Properties.Settings.Default.SaveNotesAutomatically;
            cbSaveContacts.Checked = Properties.Settings.Default.SaveContactsAutomatically;
            cbCheckForUpdatesOnStartUp.Checked = Properties.Settings.Default.CheckForUpdatesOnStartUp;
        }

        private void Common_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).ForeColor = ThemeManager.black;
        }

        private void Common_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).ForeColor = ThemeManager.red;
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (initializing) return;
            Properties.Settings.Default.StartOnWindowsStartUp = cbStartOnStartUp.Checked;
            Properties.Settings.Default.SaveNotesAutomatically = cbSaveNotes.Checked;
            Properties.Settings.Default.SaveContactsAutomatically = cbSaveContacts.Checked;
            Properties.Settings.Default.CheckForUpdatesOnStartUp = cbCheckForUpdatesOnStartUp.Checked;
            Properties.Settings.Default.ExitOnClose = cbExitOnClose.Checked;
        }

        public void FadeOut()
        {
            long current = Environment.TickCount;
            long lastUpdate = current;
            double opacity = 1;
            double fadeSpeed = 0.1;

            while (opacity > 0)
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

        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.cbStartOnStartUp = new System.Windows.Forms.CheckBox();
            this.cbExitOnClose = new System.Windows.Forms.CheckBox();
            this.cbSaveNotes = new System.Windows.Forms.CheckBox();
            this.cbSaveContacts = new System.Windows.Forms.CheckBox();
            this.cbCheckForUpdatesOnStartUp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(237, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 20;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // cbStartOnStartUp
            // 
            this.cbStartOnStartUp.AutoSize = true;
            this.cbStartOnStartUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbStartOnStartUp.Location = new System.Drawing.Point(12, 14);
            this.cbStartOnStartUp.Name = "cbStartOnStartUp";
            this.cbStartOnStartUp.Size = new System.Drawing.Size(168, 17);
            this.cbStartOnStartUp.TabIndex = 21;
            this.cbStartOnStartUp.Text = "Start Noter on windows startup";
            this.cbStartOnStartUp.UseVisualStyleBackColor = true;
            this.cbStartOnStartUp.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cbExitOnClose
            // 
            this.cbExitOnClose.AutoSize = true;
            this.cbExitOnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbExitOnClose.Location = new System.Drawing.Point(12, 37);
            this.cbExitOnClose.Name = "cbExitOnClose";
            this.cbExitOnClose.Size = new System.Drawing.Size(224, 17);
            this.cbExitOnClose.TabIndex = 22;
            this.cbExitOnClose.Text = "Exit Noter when the close button is clicked";
            this.cbExitOnClose.UseVisualStyleBackColor = true;
            this.cbExitOnClose.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cbSaveNotes
            // 
            this.cbSaveNotes.AutoSize = true;
            this.cbSaveNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSaveNotes.Location = new System.Drawing.Point(12, 60);
            this.cbSaveNotes.Name = "cbSaveNotes";
            this.cbSaveNotes.Size = new System.Drawing.Size(141, 17);
            this.cbSaveNotes.TabIndex = 23;
            this.cbSaveNotes.Text = "Save notes automatically";
            this.cbSaveNotes.UseVisualStyleBackColor = true;
            this.cbSaveNotes.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cbSaveContacts
            // 
            this.cbSaveContacts.AutoSize = true;
            this.cbSaveContacts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSaveContacts.Location = new System.Drawing.Point(12, 83);
            this.cbSaveContacts.Name = "cbSaveContacts";
            this.cbSaveContacts.Size = new System.Drawing.Size(156, 17);
            this.cbSaveContacts.TabIndex = 24;
            this.cbSaveContacts.Text = "Save contacts automatically";
            this.cbSaveContacts.UseVisualStyleBackColor = true;
            this.cbSaveContacts.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cbCheckForUpdatesOnStartUp
            // 
            this.cbCheckForUpdatesOnStartUp.AutoSize = true;
            this.cbCheckForUpdatesOnStartUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCheckForUpdatesOnStartUp.Location = new System.Drawing.Point(12, 106);
            this.cbCheckForUpdatesOnStartUp.Name = "cbCheckForUpdatesOnStartUp";
            this.cbCheckForUpdatesOnStartUp.Size = new System.Drawing.Size(148, 17);
            this.cbCheckForUpdatesOnStartUp.TabIndex = 25;
            this.cbCheckForUpdatesOnStartUp.Text = "Check for updates on start";
            this.cbCheckForUpdatesOnStartUp.UseVisualStyleBackColor = true;
            this.cbCheckForUpdatesOnStartUp.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // Settings
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(268, 140);
            this.Controls.Add(this.cbCheckForUpdatesOnStartUp);
            this.Controls.Add(this.cbSaveContacts);
            this.Controls.Add(this.cbSaveNotes);
            this.Controls.Add(this.cbExitOnClose);
            this.Controls.Add(this.cbStartOnStartUp);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnClose_Click(object sender, MouseEventArgs e)
        {
            Properties.Settings.Default.Save();
            FadeOut();
            this.Close();
        }
    }
}
