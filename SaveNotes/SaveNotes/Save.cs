using System;
using System.Collections.Generic;
using System.IO;

namespace SaveNotes
{
    public class Save : IDisposable
    {
        internal string fileLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Noter";
        internal const string FILE = "Notes.dat";
        internal FileStream fs;
        internal StreamWriter sw;
        public List<String> chronologicalNoteContainer = new List<String>();
        public List<Boolean> chronologicalBoldTextAnnouncer = new List<Boolean>();
        internal TextReader tr;

        public Save()
        {
            CheckDirectory();
        }

        public void CheckDirectory()
        {
            if (!Directory.Exists(fileLocation))
                Directory.CreateDirectory(fileLocation);
            if (!File.Exists(fileLocation + "\\" + FILE))
            {
                fs = File.Create(fileLocation + "\\" + FILE);
                fs.Close();
            }
        }

        public void Update(string saveData)
        {
            sw = new StreamWriter(fileLocation + "\\" + FILE);
            sw.Write(saveData);
            sw.Close();
        }
        
        public int LoadNotes()
        {
            int numOfNotes = 0;

            tr = new StreamReader(fileLocation + "\\" + FILE);

            string line = "";
            string temp = "";
            while (!string.IsNullOrWhiteSpace(line = tr.ReadLine()))
            {
                temp = line.Split("\\<:".ToCharArray())[3];
                if (temp.Contains("True"))
                    chronologicalBoldTextAnnouncer.Add(true);
                else chronologicalBoldTextAnnouncer.Add(false);

                chronologicalNoteContainer.Add(line.Split("\\<:".ToCharArray())[0]);
                numOfNotes++;
            }

            tr.Close();
            return numOfNotes;
        }

        internal virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (fs != null) fs.Dispose();
                if (sw != null) sw.Dispose();
                if (tr != null) tr.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
