namespace Notes
{
    partial class TopNote
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnProp = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
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
            this.btnClose.Location = new System.Drawing.Point(250, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // btnProp
            // 
            this.btnProp.BackColor = System.Drawing.Color.Transparent;
            this.btnProp.FlatAppearance.BorderSize = 0;
            this.btnProp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnProp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnProp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProp.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProp.Location = new System.Drawing.Point(0, 0);
            this.btnProp.Name = "btnProp";
            this.btnProp.Size = new System.Drawing.Size(75, 30);
            this.btnProp.TabIndex = 6;
            this.btnProp.TabStop = false;
            this.btnProp.Text = "Properties";
            this.btnProp.UseVisualStyleBackColor = false;
            this.btnProp.Click += new System.EventHandler(this.button1_Click);
            this.btnProp.MouseEnter += new System.EventHandler(this.Common_MouseEnter);
            this.btnProp.MouseLeave += new System.EventHandler(this.Common_MouseLeave);
            // 
            // txtNote
            // 
            this.txtNote.AcceptsReturn = true;
            this.txtNote.AcceptsTab = true;
            this.txtNote.BackColor = System.Drawing.Color.Green;
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNote.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(0, 30);
            this.txtNote.MaximumSize = new System.Drawing.Size(280, 50);
            this.txtNote.MaxLength = 5000;
            this.txtNote.MinimumSize = new System.Drawing.Size(280, 50);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNote.Size = new System.Drawing.Size(280, 50);
            this.txtNote.TabIndex = 7;
            // 
            // TopNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(280, 80);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.btnProp);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TopNote";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.LocationChanged += new System.EventHandler(this.TopNote_LocationChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PermaNotes_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnProp;
        private System.Windows.Forms.TextBox txtNote;
    }
}