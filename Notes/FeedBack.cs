using System;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SendFeedback;

namespace Notes
{
    public partial class FeedBack : Form
    {
        Send feedback = new Send();

        public FeedBack()
        {
            InitializeComponent();
            txtBody.BackColor = ThemeManager.Default();
            txtSubject.BackColor = ThemeManager.Default();
        }

        #region Animations
        public void FadeIn()
        {
            long current = Environment.TickCount;
            long lastUpdate = current;
            double fadeSpeed = 0.1;

            while (this.Opacity < 1)
            {
                current = Environment.TickCount;
                if (current - lastUpdate >= 10)
                {
                    this.Opacity += fadeSpeed;
                    lastUpdate = current;
                }
            }
        }

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
        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {
            if (!String.IsNullOrEmpty(txtBody.Text))
            {
                btnSend.Enabled = false;
                try
                {
                    lblInform.Text = "Sending";
                    feedback.subject = txtSubject.Text;
                    feedback.body = txtBody.Text;
                    feedback.SendMessage();
                    SendCompleted();
                }
                catch
                {
                    lblInform.Text = "Error";
                    btnSend.Enabled = true;
                    InformationBox.Show("Error sending feedback", "Error");
                }
            }
            else InformationBox.Show("Make sure you have written a description in the body area", "No Body Found");
        }

        void SendCompleted()
        {
            btnSend.Enabled = true;
            lblInform.Text = "Sent";
        }

        public static void CreateFeedback()
        {
            FeedBack fb = new FeedBack();
            fb.Show();
            fb.FadeIn();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FadeOut();
            Close();
        }

        private void FeedBack_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
               NativeMethods.ReleaseCapture();
               NativeMethods.SendMessage(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);
            }
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
