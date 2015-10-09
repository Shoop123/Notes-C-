using System.Drawing;
using System.Windows.Forms;

namespace Notes
{
    sealed class ThemeManager
    {
        public static Color chosenTheme = Notes.Properties.Settings.Default.UserTheme;

        public static Color black = Color.Black;
        public static Color blue = Color.Blue;
        public static Color white = Color.White;
        public static Color red = Color.Red;
        public static Color yellow = Color.Yellow;
        public static Color brown = Color.Brown;
        public static Color green = Color.Green;

        public static Color Light()
        {
            if (chosenTheme.Equals(black))
                return Color.DarkGray;
            else if (chosenTheme.Equals(blue))
                return Color.FromArgb(0, 102, 204);
            else if (chosenTheme.Equals(white))
                return Color.White;
            else if (chosenTheme.Equals(red))
                return Color.Red;
            else if (chosenTheme.Equals(yellow))
                return Color.FromArgb(255, 255, 0);
            else if (chosenTheme.Equals(brown))
                return Color.FromArgb(153, 76, 0);
            else if (chosenTheme.Equals(green))
                return Color.FromArgb(0, 204, 0);
            return Color.FromArgb(0, 204, 0);
        }

        public static Color Dark()
        {
            if (chosenTheme.Equals(black))
                return Color.Black;
            else if (chosenTheme.Equals(blue))
                return Color.FromArgb(0, 51, 102);
            else if (chosenTheme.Equals(white))
                return Color.Silver;
            else if (chosenTheme.Equals(red))
                return Color.FromArgb(153, 0, 0);
            else if (chosenTheme.Equals(yellow))
                return Color.FromArgb(153, 153, 0);
            else if (chosenTheme.Equals(brown))
                return Color.FromArgb(51, 25, 0);
            else if (chosenTheme.Equals(green))
                return Color.FromArgb(0, 102, 0);
            return Color.FromArgb(0, 102, 0);
        }

        public static Color Default()
        {
            if (chosenTheme.Equals(black))
                return Color.DimGray;
            else if (chosenTheme.Equals(blue))
                return Color.FromArgb(0, 76, 153);
            else if (chosenTheme.Equals(white))
                return Color.Gainsboro;
            else if (chosenTheme.Equals(red))
                return Color.FromArgb(180, 0, 0);
            else if (chosenTheme.Equals(yellow))
                return Color.FromArgb(204, 204, 0);
            else if (chosenTheme.Equals(brown))
                return Color.FromArgb(102, 51, 0);
            else if (chosenTheme.Equals(green))
                return Color.FromArgb(0, 153, 0);
            return Color.FromArgb(0, 153, 0);
        }

        public static Color Theme()
        {
            return Color.Transparent;
        }

        public static void SyncTheme()
        {
            foreach (Panel p in NotesOrganizer.area)
            {
                foreach (Control c in p.Controls)
                {
                    if (c is TextBox)
                        c.BackColor = Default();
                    if (c is CheckBox)
                        c.ForeColor = Default();
                }
                if (ControlManager.IsChecked(p))
                    p.BackColor = Dark();
            }
        }
    }
}
