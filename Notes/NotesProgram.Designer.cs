namespace Notes
{
    partial class NotesProgram
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                save.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotesProgram));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlNoteHolder = new System.Windows.Forms.Panel();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTopNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.UpdateUI = new System.Windows.Forms.Timer(this.components);
            this.ttBtnTopNote = new System.Windows.Forms.ToolTip(this.components);
            this.btnColor = new System.Windows.Forms.Button();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnFeedback = new System.Windows.Forms.Button();
            this.btnTheme = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnContacts = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSyncOutlook = new System.Windows.Forms.Button();
            this.btnAddColumn = new System.Windows.Forms.Button();
            this.btnRemoveColumn = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.options = new System.Windows.Forms.Panel();
            this.cmsContactClicked = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToOutlookContactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContacts = new System.Windows.Forms.Panel();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.lblSyncWith = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnShowOptions = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.contactsPane = new Notes.ContactsPane();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsMenu.SuspendLayout();
            this.options.SuspendLayout();
            this.cmsContactClicked.SuspendLayout();
            this.pnlContacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactsPane)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNoteHolder
            // 
            this.pnlNoteHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNoteHolder.AutoScroll = true;
            this.pnlNoteHolder.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.pnlNoteHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlNoteHolder.Location = new System.Drawing.Point(0, 81);
            this.pnlNoteHolder.Name = "pnlNoteHolder";
            this.pnlNoteHolder.Size = new System.Drawing.Size(500, 405);
            this.pnlNoteHolder.TabIndex = 1;
            this.pnlNoteHolder.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pnlNoteHolder_Scroll);
            this.pnlNoteHolder.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlNoteHolder_Paint);
            this.pnlNoteHolder.MouseLeave += new System.EventHandler(this.pnlNoteHolder_MouseLeave);
            // 
            // cmsMenu
            // 
            this.cmsMenu.BackColor = System.Drawing.SystemColors.Control;
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.minimizeToolStripMenuItem,
            this.hideToolStripMenuItem,
            this.addTopNoteToolStripMenuItem});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(157, 114);
            this.cmsMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMenu_Opening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.openToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openToolStripMenuItem.Image = global::Notes.Properties.Resources.open;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.closeToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeToolStripMenuItem.Image = global::Notes.Properties.Resources.close;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.closeToolStripMenuItem.Text = "Exit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.minimizeToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeToolStripMenuItem.Image = global::Notes.Properties.Resources.minimize;
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hideToolStripMenuItem.Image = global::Notes.Properties.Resources.delete;
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // addTopNoteToolStripMenuItem
            // 
            this.addTopNoteToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTopNoteToolStripMenuItem.Image = global::Notes.Properties.Resources.add;
            this.addTopNoteToolStripMenuItem.Name = "addTopNoteToolStripMenuItem";
            this.addTopNoteToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addTopNoteToolStripMenuItem.Text = "Add Top-Note";
            this.addTopNoteToolStripMenuItem.Click += new System.EventHandler(this.addTopNoteToolStripMenuItem_Click);
            // 
            // notIcon
            // 
            this.notIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notIcon.ContextMenuStrip = this.cmsMenu;
            this.notIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notIcon.Icon")));
            this.notIcon.Text = "Notes";
            this.notIcon.Visible = true;
            this.notIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notIcon_MouseClick);
            // 
            // UpdateUI
            // 
            this.UpdateUI.Enabled = true;
            this.UpdateUI.Interval = 12;
            this.UpdateUI.Tick += new System.EventHandler(this.UpdateUI_Tick);
            // 
            // ttBtnTopNote
            // 
            this.ttBtnTopNote.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Transparent;
            this.btnColor.FlatAppearance.BorderSize = 0;
            this.btnColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColor.Location = new System.Drawing.Point(13, 36);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 25);
            this.btnColor.TabIndex = 3;
            this.btnColor.Text = "Color";
            this.ttBtnTopNote.SetToolTip(this.btnColor, "Set the text color for all of your notes");
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            this.btnColor.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnColor.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnFont
            // 
            this.btnFont.BackColor = System.Drawing.Color.Transparent;
            this.btnFont.FlatAppearance.BorderSize = 0;
            this.btnFont.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFont.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFont.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFont.Location = new System.Drawing.Point(13, 1);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(75, 25);
            this.btnFont.TabIndex = 2;
            this.btnFont.Text = "Font";
            this.ttBtnTopNote.SetToolTip(this.btnFont, "Set the font for all of the text in your notes");
            this.btnFont.UseVisualStyleBackColor = false;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            this.btnFont.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnFont.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnFeedback
            // 
            this.btnFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFeedback.BackColor = System.Drawing.Color.Transparent;
            this.btnFeedback.FlatAppearance.BorderSize = 0;
            this.btnFeedback.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFeedback.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeedback.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeedback.Location = new System.Drawing.Point(13, 400);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.Size = new System.Drawing.Size(75, 25);
            this.btnFeedback.TabIndex = 4;
            this.btnFeedback.Text = "Feedback";
            this.ttBtnTopNote.SetToolTip(this.btnFeedback, "Send some helpful feedback about this program");
            this.btnFeedback.UseVisualStyleBackColor = false;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);
            this.btnFeedback.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnFeedback.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnTheme
            // 
            this.btnTheme.BackColor = System.Drawing.Color.Transparent;
            this.btnTheme.FlatAppearance.BorderSize = 0;
            this.btnTheme.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTheme.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTheme.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTheme.Location = new System.Drawing.Point(13, 71);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(75, 25);
            this.btnTheme.TabIndex = 5;
            this.btnTheme.Text = "Theme";
            this.ttBtnTopNote.SetToolTip(this.btnTheme, "Set the theme for the entire program\r\n");
            this.btnTheme.UseVisualStyleBackColor = false;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
            this.btnTheme.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnTheme.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.Transparent;
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(13, 106);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 25);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "Updates";
            this.ttBtnTopNote.SetToolTip(this.btnCheck, "Check for a newer version of your program");
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            this.btnCheck.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnCheck.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(13, 141);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 25);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.ttBtnTopNote.SetToolTip(this.btnExport, "Export selected notes into a Word Document");
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            this.btnExport.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnExport.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnContacts
            // 
            this.btnContacts.BackColor = System.Drawing.Color.Transparent;
            this.btnContacts.FlatAppearance.BorderSize = 0;
            this.btnContacts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnContacts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnContacts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContacts.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContacts.Location = new System.Drawing.Point(13, 211);
            this.btnContacts.Name = "btnContacts";
            this.btnContacts.Size = new System.Drawing.Size(75, 25);
            this.btnContacts.TabIndex = 8;
            this.btnContacts.Text = "Contacts";
            this.ttBtnTopNote.SetToolTip(this.btnContacts, "View your Contacts");
            this.btnContacts.UseVisualStyleBackColor = false;
            this.btnContacts.Click += new System.EventHandler(this.btnContacts_Click);
            this.btnContacts.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnContacts.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(3, 352);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.ttBtnTopNote.SetToolTip(this.btnSave, "Save you contacts");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            this.btnSave.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnSyncOutlook
            // 
            this.btnSyncOutlook.BackColor = System.Drawing.Color.Transparent;
            this.btnSyncOutlook.FlatAppearance.BorderSize = 0;
            this.btnSyncOutlook.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSyncOutlook.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSyncOutlook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSyncOutlook.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSyncOutlook.Location = new System.Drawing.Point(193, 338);
            this.btnSyncOutlook.Name = "btnSyncOutlook";
            this.btnSyncOutlook.Size = new System.Drawing.Size(75, 25);
            this.btnSyncOutlook.TabIndex = 4;
            this.btnSyncOutlook.Text = "Outlook";
            this.ttBtnTopNote.SetToolTip(this.btnSyncOutlook, "Add you Outlook contacts");
            this.btnSyncOutlook.UseVisualStyleBackColor = false;
            this.btnSyncOutlook.Click += new System.EventHandler(this.btnSyncOutlook_Click);
            this.btnSyncOutlook.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnSyncOutlook.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnAddColumn
            // 
            this.btnAddColumn.BackColor = System.Drawing.Color.Transparent;
            this.btnAddColumn.FlatAppearance.BorderSize = 0;
            this.btnAddColumn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddColumn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddColumn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddColumn.Location = new System.Drawing.Point(3, 321);
            this.btnAddColumn.Name = "btnAddColumn";
            this.btnAddColumn.Size = new System.Drawing.Size(75, 25);
            this.btnAddColumn.TabIndex = 6;
            this.btnAddColumn.Text = "Column";
            this.ttBtnTopNote.SetToolTip(this.btnAddColumn, "Add another column");
            this.btnAddColumn.UseVisualStyleBackColor = false;
            this.btnAddColumn.Click += new System.EventHandler(this.btnAddColumn_Click);
            this.btnAddColumn.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnAddColumn.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnRemoveColumn
            // 
            this.btnRemoveColumn.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveColumn.FlatAppearance.BorderSize = 0;
            this.btnRemoveColumn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRemoveColumn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRemoveColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveColumn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveColumn.Location = new System.Drawing.Point(84, 352);
            this.btnRemoveColumn.Name = "btnRemoveColumn";
            this.btnRemoveColumn.Size = new System.Drawing.Size(75, 25);
            this.btnRemoveColumn.TabIndex = 8;
            this.btnRemoveColumn.Text = "Remove";
            this.ttBtnTopNote.SetToolTip(this.btnRemoveColumn, "Remove a column");
            this.btnRemoveColumn.UseVisualStyleBackColor = false;
            this.btnRemoveColumn.Click += new System.EventHandler(this.btnRemoveColumn_Click);
            this.btnRemoveColumn.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnRemoveColumn.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(13, 176);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 25);
            this.btnSettings.TabIndex = 9;
            this.btnSettings.Text = "Settings";
            this.ttBtnTopNote.SetToolTip(this.btnSettings, "Export selected notes into a Word Document");
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            this.btnSettings.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnSettings.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // options
            // 
            this.options.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.options.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.options.Controls.Add(this.btnSettings);
            this.options.Controls.Add(this.btnContacts);
            this.options.Controls.Add(this.btnExport);
            this.options.Controls.Add(this.btnCheck);
            this.options.Controls.Add(this.btnTheme);
            this.options.Controls.Add(this.btnFeedback);
            this.options.Controls.Add(this.btnColor);
            this.options.Controls.Add(this.btnFont);
            this.options.Location = new System.Drawing.Point(-100, 75);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(100, 425);
            this.options.TabIndex = 2;
            // 
            // cmsContactClicked
            // 
            this.cmsContactClicked.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToOutlookContactsToolStripMenuItem,
            this.removeColumnToolStripMenuItem,
            this.emailToolStripMenuItem});
            this.cmsContactClicked.Name = "cmsContactClicked";
            this.cmsContactClicked.Size = new System.Drawing.Size(207, 70);
            this.cmsContactClicked.Text = "Options";
            this.cmsContactClicked.Opening += new System.ComponentModel.CancelEventHandler(this.cmsContactClicked_Opening);
            // 
            // addToOutlookContactsToolStripMenuItem
            // 
            this.addToOutlookContactsToolStripMenuItem.Image = global::Notes.Properties.Resources.add;
            this.addToOutlookContactsToolStripMenuItem.Name = "addToOutlookContactsToolStripMenuItem";
            this.addToOutlookContactsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.addToOutlookContactsToolStripMenuItem.Text = "Add to Outlook Contacts";
            this.addToOutlookContactsToolStripMenuItem.Click += new System.EventHandler(this.addToOutlookContactsToolStripMenuItem_Click);
            // 
            // removeColumnToolStripMenuItem
            // 
            this.removeColumnToolStripMenuItem.Image = global::Notes.Properties.Resources.delete;
            this.removeColumnToolStripMenuItem.Name = "removeColumnToolStripMenuItem";
            this.removeColumnToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.removeColumnToolStripMenuItem.Text = "Remove Column";
            this.removeColumnToolStripMenuItem.Click += new System.EventHandler(this.removeColumnToolStripMenuItem_Click);
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.Image = global::Notes.Properties.Resources.open;
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.emailToolStripMenuItem.Text = "Email";
            this.emailToolStripMenuItem.Click += new System.EventHandler(this.emailToolStripMenuItem_Click);
            // 
            // pnlContacts
            // 
            this.pnlContacts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlContacts.Controls.Add(this.btnRemoveColumn);
            this.pnlContacts.Controls.Add(this.txtColumnName);
            this.pnlContacts.Controls.Add(this.btnAddColumn);
            this.pnlContacts.Controls.Add(this.lblSyncWith);
            this.pnlContacts.Controls.Add(this.btnSyncOutlook);
            this.pnlContacts.Controls.Add(this.btnSave);
            this.pnlContacts.Controls.Add(this.contactsPane);
            this.pnlContacts.Location = new System.Drawing.Point(500, 81);
            this.pnlContacts.Name = "pnlContacts";
            this.pnlContacts.Size = new System.Drawing.Size(460, 409);
            this.pnlContacts.TabIndex = 3;
            // 
            // txtColumnName
            // 
            this.txtColumnName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtColumnName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColumnName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnName.Location = new System.Drawing.Point(84, 324);
            this.txtColumnName.MaxLength = 100;
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(100, 26);
            this.txtColumnName.TabIndex = 7;
            this.txtColumnName.Visible = false;
            this.txtColumnName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtColumnName_KeyDown);
            // 
            // lblSyncWith
            // 
            this.lblSyncWith.AutoSize = true;
            this.lblSyncWith.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSyncWith.Location = new System.Drawing.Point(202, 322);
            this.lblSyncWith.Name = "lblSyncWith";
            this.lblSyncWith.Size = new System.Drawing.Size(59, 12);
            this.lblSyncWith.TabIndex = 5;
            this.lblSyncWith.Text = "Sync With";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Full Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Email";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Address";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Phone";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnAdd.Location = new System.Drawing.Point(425, 50);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnAdd_Click);
            this.btnAdd.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnAdd.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectAll.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectAll.FlatAppearance.BorderSize = 0;
            this.btnSelectAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnSelectAll.Location = new System.Drawing.Point(288, 50);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 25);
            this.btnSelectAll.TabIndex = 24;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSelectAll_Click);
            this.btnSelectAll.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnSelectAll.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnDelete.Location = new System.Drawing.Point(213, 50);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnDelete_Click);
            this.btnDelete.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnDelete.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnNew.Location = new System.Drawing.Point(138, 50);
            this.btnNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 22;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnNew_Click);
            this.btnNew.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnNew.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnShowOptions
            // 
            this.btnShowOptions.BackColor = System.Drawing.Color.Transparent;
            this.btnShowOptions.FlatAppearance.BorderSize = 0;
            this.btnShowOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnShowOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnShowOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowOptions.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnShowOptions.Location = new System.Drawing.Point(0, 50);
            this.btnShowOptions.Margin = new System.Windows.Forms.Padding(0);
            this.btnShowOptions.Name = "btnShowOptions";
            this.btnShowOptions.Size = new System.Drawing.Size(75, 25);
            this.btnShowOptions.TabIndex = 21;
            this.btnShowOptions.Text = "Options";
            this.btnShowOptions.UseVisualStyleBackColor = false;
            this.btnShowOptions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnShowOptions_Click);
            this.btnShowOptions.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnShowOptions.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.Location = new System.Drawing.Point(431, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 20;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMinimize_Click);
            this.btnMinimize.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnMinimize.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(467, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 19;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // contactsPane
            // 
            this.contactsPane.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.contactsPane.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contactsPane.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.contactsPane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contactsPane.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.contactsPane.ContextMenuStrip = this.cmsContactClicked;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.contactsPane.DefaultCellStyle = dataGridViewCellStyle1;
            this.contactsPane.Location = new System.Drawing.Point(0, 0);
            this.contactsPane.Name = "contactsPane";
            this.contactsPane.Size = new System.Drawing.Size(460, 300);
            this.contactsPane.TabIndex = 0;
            this.contactsPane.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.contactsPane_CellMouseClick);
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Full Name";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Email";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Address";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Phone";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // NotesProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnShowOptions);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlContacts);
            this.Controls.Add(this.options);
            this.Controls.Add(this.pnlNoteHolder);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(375, 360);
            this.Name = "NotesProgram";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Notes_FormClosing);
            this.Load += new System.EventHandler(this.NotesProgram_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NotesProgram_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NotesProgram_MouseDown);
            this.Resize += new System.EventHandler(this.NotesProgram_Resize);
            this.cmsMenu.ResumeLayout(false);
            this.options.ResumeLayout(false);
            this.cmsContactClicked.ResumeLayout(false);
            this.pnlContacts.ResumeLayout(false);
            this.pnlContacts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactsPane)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNoteHolder;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.NotifyIcon notIcon;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.Timer UpdateUI;
        private System.Windows.Forms.ToolTip ttBtnTopNote;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTopNoteToolStripMenuItem;
        private System.Windows.Forms.Panel options;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Button btnFeedback;
        private System.Windows.Forms.Button btnTheme;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnContacts;
        private System.Windows.Forms.ContextMenuStrip cmsContactClicked;
        private System.Windows.Forms.ToolStripMenuItem addToOutlookContactsToolStripMenuItem;
        private System.Windows.Forms.Panel pnlContacts;
        private ContactsPane contactsPane;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSyncOutlook;
        private System.Windows.Forms.Label lblSyncWith;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btnAddColumn;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.Button btnRemoveColumn;
        private System.Windows.Forms.ToolStripMenuItem removeColumnToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnShowOptions;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.Button btnSettings;
    }
}

