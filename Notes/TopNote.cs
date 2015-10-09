using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Notes
{
    public partial class TopNote : Form
    {
        private Size _textSize = new Size(400, 25);
        private Point _startingLocation = new Point(15, 25);

        public TopNote()
        {
            InitializeComponent();
            this.Location = new Point(NotesOrganizer.topNoteFutureLocation.X, NotesOrganizer.topNoteFutureLocation.Y + 50);
            txtNote.BackColor = ThemeManager.Default();
        }

        #region Animations
        private void FadeOut()
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

        private void FadeIn()
        {
            long current = Environment.TickCount;
            long lastUpdate = current;
            double opacity = 0;
            double fadeSpeed = 0.1;

            while (opacity < 1)
            {
                current = Environment.TickCount;
                if (current - lastUpdate >= 10)
                {
                    this.Opacity += fadeSpeed;
                    opacity = this.Opacity;
                    lastUpdate = current;
                }
            }
        }
        #endregion

        public static void CreateNote()
        {
            TopNote pn = new TopNote();
            pn.Show();
            pn.FadeIn();
            Application.Run();
        }

        private void txtNote_MouseEnter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.BackColor = ThemeManager.Default();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FadeOut();
            this.Dispose();
            Application.ExitThread();
        }

        private void PermaNotes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = true;
            fd.MaxSize = 30;
            if(fd.ShowDialog() == DialogResult.OK)
            {
                txtNote.Font = fd.Font;
                txtNote.ForeColor = fd.Color;
            }
        }

        private void TopNote_LocationChanged(object sender, EventArgs e)
        {
            NotesOrganizer.topNoteFutureLocation = this.Location;
        }

        private void Common_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).ForeColor = ThemeManager.Default();
        }

        private void Common_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).ForeColor = ThemeManager.black;
        }
    }
}
