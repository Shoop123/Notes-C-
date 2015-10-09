using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Notes
{
    public partial class InformationBox : Form
    {
        static InformationBox ib;
        public string link = String.Empty;

        public InformationBox()
        {
            InitializeComponent();
            lblTitle.ForeColor = ThemeManager.Default();
        }

        private void FixPositions(bool includeCopy)
        {
            int x = this.Width / 2 - lblText.Width / 2;
            lblText.Location = new Point(x, lblText.Location.Y);
            btnOk.Location = new Point(btnOk.Location.X, lblText.Location.Y + lblText.Height + 1);
            int totalheight = 0;
            foreach (Control c in this.Controls)
                totalheight += c.Height + 1;

            if (!includeCopy)
                totalheight -= btnCopy.Height;

            this.Height = totalheight;
        }

        public static void Show(string text, string title)
        {
            ib = new InformationBox();
            ib.lblText.Text = text;
            ib.lblTitle.Text = title;
            ib.FixPositions(false);
            ib.ShowDialog();
        }

        public static DialogResult Show(string text, string title, string link)
        {
            ib = new InformationBox();
            ib.lblText.Text = text;
            ib.lblTitle.Text = title;
            ib.FixPositions(true);
            ib.btnCopy.Visible = true;
            ib.btnCopy.Enabled = true;
            ib.link = link;
            ib.btnCopy.Location = new Point(0, ib.Size.Height - ib.btnCopy.Size.Height);
            return ib.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ib.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(link);
            btnCopy.Text = "Copied";
            btnCopy.Enabled = false;
        }

        private void Common_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).ForeColor = ThemeManager.Default();
        }

        private void Common_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).ForeColor = ThemeManager.black;
        }

        private void InformationBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);
            }
        }

        private void InformationBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.Error, new Point(0, 0));
        }
    }
}
