using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Notes
{
    public partial class ThemeDialog : Form
    {
        public Color theme = Notes.Properties.Settings.Default.UserTheme;

        public ThemeDialog()
        {
            InitializeComponent();
            StartSelectedIndex();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            theme = SelectedTheme();
            this.Close();
        }

        private Color SelectedFinalTheme()
        {
            switch(cbThemeSelect.SelectedIndex)
            {
                case 0:
                    return Color.DimGray;
                case 1:
                    return Color.FromArgb(0, 76, 153);
                case 2:
                    return Color.FromArgb(0, 153, 0);
                case 3:
                    return Color.Gainsboro;
                case 4:
                    return Color.FromArgb(204, 204, 0);
                case 5:
                    return Color.FromArgb(102, 51, 0);
                case 6:
                    return Color.FromArgb(204, 0, 0);
                default:
                    return ThemeManager.green;
            }
        }

        private Color SelectedTheme()
        {
            switch (cbThemeSelect.SelectedIndex)
            {
                case 0:
                    return ThemeManager.black;
                case 1:
                    return ThemeManager.blue;
                case 2:
                    return ThemeManager.green;
                case 3:
                    return ThemeManager.white;
                case 4:
                    return ThemeManager.yellow;
                case 5:
                    return ThemeManager.brown;
                case 6:
                    return ThemeManager.red;
                default:
                    return ThemeManager.green;
            }
        }

        private void StartSelectedIndex()
        {
            if (ThemeManager.chosenTheme == ThemeManager.black)
            {
                cbThemeSelect.SelectedIndex = 0;
                cbThemeSelect.Text = cbThemeSelect.Items[0].ToString();
            }
            else if (ThemeManager.chosenTheme == ThemeManager.blue)
            {
                cbThemeSelect.SelectedIndex = 1;
                cbThemeSelect.Text = cbThemeSelect.Items[1].ToString();
            }
            else if (ThemeManager.chosenTheme == ThemeManager.green)
            {
                cbThemeSelect.SelectedIndex = 2;
                cbThemeSelect.Text = cbThemeSelect.Items[2].ToString();
            }
            else if (ThemeManager.chosenTheme == ThemeManager.white)
            {
                cbThemeSelect.SelectedIndex = 3;
                cbThemeSelect.Text = cbThemeSelect.Items[3].ToString();
            }
            else if (ThemeManager.chosenTheme == ThemeManager.yellow)
            {
                cbThemeSelect.SelectedIndex = 4;
                cbThemeSelect.Text = cbThemeSelect.Items[4].ToString();
            }
            else if (ThemeManager.chosenTheme == ThemeManager.brown)
            {
                cbThemeSelect.SelectedIndex = 5;
                cbThemeSelect.Text = cbThemeSelect.Items[5].ToString();
            }
            else if (ThemeManager.chosenTheme == ThemeManager.red)
            {
                cbThemeSelect.SelectedIndex = 6;
                cbThemeSelect.Text = cbThemeSelect.Items[6].ToString();
            }
        }

        private void ThemeDialog_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);
            }
        }

        private void cbThemeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbThemeSelect.ForeColor = SelectedFinalTheme();
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
