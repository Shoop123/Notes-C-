using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace Notes
{
    public partial class Update : Form
    {
        WebClient wb;
        const string file = "http://smart-notes.webs.com/update.xml";
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Noter\\update.xml";
        string fileLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Noter";
        const string FILE = "update.xml";
        XmlDocument doc;
        
        string description;
        string features;
        string version;
        string host;

        public Update()
        {
            InitializeComponent();
            CheckLocation();

            wb = new WebClient();
            wb.DownloadFileCompleted += wb_DownloadFileCompleted;
            
            doc = new XmlDocument();
        }

        private void CheckLocation()
        {
            if (!Directory.Exists(fileLocation))
                Directory.CreateDirectory(fileLocation);
            if (!File.Exists(fileLocation + "\\" + FILE))
                File.Create(fileLocation + "\\" + FILE);
        }

        void wb_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                doc.Load(file);
                if (doc != null)
                {
                    if (IsNewerVersion())
                    {
                        description = doc.SelectSingleNode("update/info/description").InnerText;
                        features = doc.SelectSingleNode("update/info/features").InnerText;
                        version = doc.SelectSingleNode("update/version").InnerText;
                        host = doc.SelectSingleNode("update/link").InnerText;
                        this.Show();
                    }
                    else
                        if (NotesOrganizer.checkUpdate)
                        {
                            NotesOrganizer.checkUpdate = false;
                            InformationBox.Show("Your program is Up-To-Date", "Update");
                        }
                }
            }
            catch { InformationBox.Show("Error retrieving update data", "Error"); }
        }

        public void Check()
        {
            wb.DownloadFileAsync(new Uri(file), filePath);
        }

        private void btnYes_Click_1(object sender, EventArgs e)
        {
            InformationBox.Show("All application processes will be closed\r\n", "Update");
            System.Diagnostics.Process.Start(host);
            NotesProgram.exit = true;
        }

        private void btnNo_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetails_Click_1(object sender, EventArgs e)
        {
            InformationBox.Show(description + "\r\n" + "\r\nNew Version: " + version + "\r\n" + "\r\nFeatures:" + features, "Update Details");
        }

        private void lblMessage_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);
            }
        }

        private void Update_MouseDown(object sender, MouseEventArgs e)
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

        private void Common_MosueLeave(object sender, EventArgs e)
        {
            ((Button)sender).ForeColor = ThemeManager.black;
        }

        private bool IsNewerVersion()
        {
            String newVersion = doc.SelectSingleNode("update/version").InnerText;
            String currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            String[] newNum = newVersion.Split('.');
            String[] currentNums = currentVersion.Split('.');
            
            short[] newIndivNums = new short[newNum.Length];
            short[] currentIndivNums = new short[currentNums.Length];

            for(int i = 0; i < newNum.Length; i++)
                newIndivNums[i] = short.Parse(newNum[i]);

            for (int i = 0; i < currentNums.Length; i++)
                currentIndivNums[i] = short.Parse(currentNums[i]);

            for(int i = 0; i < newIndivNums.Length; i++)
                if (newIndivNums[i] > currentIndivNums[i]) return true;

            return false;
        }
    }
}
