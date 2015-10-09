using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;

namespace Setup
{
    public partial class Setup : Form
    {
        string executingAssembly;
        string[] localDirectories;
        string appdata;
        string noter;
        string noterPath;
        string installPath;
        string installLocation;
        string app = "Application";
        bool isInstalled = false;

        public Setup()
        {
            InitializeComponent();
            executingAssembly = Assembly.GetExecutingAssembly().Location;
            appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            noter = "Noter";
            noterPath = Path.Combine(appdata, noter);
            localDirectories = executingAssembly.Split('\\');
            GetInstallPath();
            GetInstallLocation();
            DeleteProcess();
        }

        private void DeleteProcess()
        {
            foreach (Process p in Process.GetProcesses())
                if (p.ProcessName == "Noter")
                    p.Kill();
        }

        private void GetInstallLocation()
        {
            if (!Directory.Exists(Path.Combine(noterPath, app)))
                Directory.CreateDirectory(Path.Combine(noterPath, app));
            installLocation = Path.Combine(noterPath, app);
        }

        private void GetInstallPath()
        {
            string path = "";

            for(int i = 0; i < localDirectories.Length; i++)
            {
                if (i < localDirectories.Length - 1)
                    path += localDirectories[i] + "//";
            }
            string fileFolder = "ApplicationFiles";
            installPath = Path.Combine(path, fileFolder);
        }

        private void CreateShortcut(string fileName, string fileLocation)
        {
            IShellLink link = (IShellLink)new ShellLink();

            // setup shortcut information
            link.SetDescription(fileName);
            link.SetPath(fileLocation);

            // save it
            IPersistFile file = (IPersistFile)link;
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            file.Save(Path.Combine(desktopPath, fileName + ".lnk"), false);
        }

        [ComImport]
        [Guid("00021401-0000-0000-C000-000000000046")]
        internal class ShellLink
        {
        }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000214F9-0000-0000-C000-000000000046")]
        internal interface IShellLink
        {
            void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out IntPtr pfd, int fFlags);
            void GetIDList(out IntPtr ppidl);
            void SetIDList(IntPtr pidl);
            void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
            void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
            void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
            void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
            void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
            void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
            void GetHotkey(out short pwHotkey);
            void SetHotkey(short wHotkey);
            void GetShowCmd(out int piShowCmd);
            void SetShowCmd(int iShowCmd);
            void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);
            void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
            void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
            void Resolve(IntPtr hwnd, int fFlags);
            void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            try
            {
                Uninstall();
                string[] files = Directory.GetFiles(installPath);
                bool installSuccessful = false;

                if(files.Length > 2)
                {
                    foreach (string file in files)
                    {
                        string name = Path.GetFileName(file);
                        File.Delete(Path.Combine(installLocation, name));
                        if (Path.GetExtension(file) == ".exe")
                        {
                            File.Copy(file, Path.Combine(installLocation, name));
                            Process.Start(Path.Combine(installLocation, name));
                            CreateShortcut(noter, Path.Combine(installLocation, name));
                        }
                        else File.Copy(file, Path.Combine(installLocation, name));
                    }
                    installSuccessful = true;
                }
                else MessageBox.Show("Install Files Missing");

                if (installSuccessful)
                    this.Close();
                else MessageBox.Show("Install Failed");
            }
            catch { MessageBox.Show("Install Failed"); }
        }

        private void Uninstall()
        {
            string[] files = Directory.GetFiles(installLocation);

            if (files.Length > 0)
            {
                foreach (string file in files)
                    File.Delete(file);
                isInstalled = true;
            }
            else return;
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            try
            {
                Uninstall();
                if (isInstalled)
                    MessageBox.Show("Uninstalled Successfully");
                else MessageBox.Show("Program not installed");
            }
            catch { MessageBox.Show("Uninstall Failed"); }
        }
    }
}
