using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace Notes
{
    class ContactsPane : DataGridView
    {
        string savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string saveFolder = "\\Noter";
        string saveFile = "\\contacts.xml";

        public ContactsPane()
        {
            CheckDirectory();
        }

        private void CheckDirectory()
        {
            if (!Directory.Exists(savePath + saveFolder))
                Directory.CreateDirectory(savePath + saveFolder);
            if (!File.Exists(savePath + saveFolder + saveFile))
            {
                XmlTextWriter xw = new XmlTextWriter(savePath + saveFolder + saveFile, Encoding.UTF8);
                xw.WriteStartElement("Information");
                xw.WriteStartElement("Contacts");
                xw.WriteEndElement();
                xw.WriteStartElement("Columns");
                xw.WriteEndElement();
                xw.WriteEndElement();
                xw.Close();
            }
        }

        private void Initialize()
        {
            this.Size = new Size(460, 300);
            this.BackgroundColor = Color.FromArgb(64, 64, 64);
            this.Columns.Add("FullName", "Full Name");
            this.Columns.Add("Email", "Email");
            this.Columns.Add("Address", "Address");
            this.Columns.Add("Phone", "Phone");
        }

        public void Save()
        {
            CheckDirectory();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(savePath + saveFolder + saveFile);
            XmlNode xNode = xDoc.SelectSingleNode("Information/Contacts");
            xNode.RemoveAll();
            XmlNode xNode2 = xDoc.SelectSingleNode("Information/Columns");
            xNode2.RemoveAll();

            for (int i = 0; i < this.Columns.Count; i++)
            {
                XmlNode column = xDoc.CreateElement("Column");
                column.InnerText = this.Columns[i].HeaderText;
                xDoc.DocumentElement.SelectSingleNode("Columns").AppendChild(column);
            }

            foreach(DataGridViewRow row in this.Rows)
            {
                XmlNode xTop = xDoc.CreateElement("Person");
                List<XmlNode> otherNodes = new List<XmlNode>();


                for(int i = 0; i < row.Cells.Count; i++)
                {
                    string name = Regex.Replace(this.Columns[i].HeaderText, @"\s+", "");
                    XmlNode node = xDoc.CreateElement(name);
                    node.InnerText = (row.Cells[i].Value == null) ? "" : row.Cells[i].Value.ToString();
                    otherNodes.Add(node);
                }

                foreach (XmlNode node in otherNodes)
                    xTop.AppendChild(node);

                xDoc.DocumentElement.SelectSingleNode("Contacts").AppendChild(xTop);
            }
            xDoc.Save(savePath + saveFolder + saveFile);
        }

        public void Load()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(savePath + saveFolder + saveFile);

            foreach(XmlNode xNode in xDoc.SelectNodes("Information/Columns/Column"))
            {
                bool exists = false;
                foreach(DataGridViewColumn col in this.Columns)
                {
                    if (col.HeaderText.Equals(xNode.InnerText))
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                    this.Columns.Add(xNode.InnerText, xNode.InnerText);
            }

            foreach (XmlNode xNode in xDoc.SelectNodes("Information/Contacts/Person"))
            {
                List<string> info = new List<string>();

                if(xNode.HasChildNodes)
                    foreach(XmlNode node in xNode.ChildNodes)
                        info.Add(node.InnerText);

                bool isEmpty = true;

                foreach(string s in info)
                    if(!String.IsNullOrEmpty(s))
                    {
                        isEmpty = false;
                        break;
                    }

                string[] array = info.ToArray();
                if(!isEmpty)
                    this.Rows.Add(array);
            }
        }

        public void SyncWithOutlook()
        {
            this.Parent.Enabled = false;
            string[] info = new string[4];

            if(Interpolation.outlookContacts.Count > 0)
                foreach (ContactItem c in Interpolation.outlookContacts)
                {
                    info[0] = ((c.FirstName != null) ? c.FirstName : "") + " " + ((c.LastName != null) ? c.LastName : "");
                    info[1] = (c.Email1Address != null ? c.Email1Address : "");
                    info[2] = (c.HomeAddress != null ? c.HomeAddress : "");
                    info[3] = (c.HomeTelephoneNumber != null ? c.HomeTelephoneNumber : "");

                    bool exists = false;

                    foreach (DataGridViewRow row in this.Rows)
                    {
                        string name = ((row.Cells[0].Value) == null) ? "" : row.Cells[0].Value.ToString();
                        string email = ((row.Cells[1].Value) == null) ? "" : row.Cells[1].Value.ToString();
                        string address = ((row.Cells[2].Value) == null) ? "" : row.Cells[2].Value.ToString();
                        string phone = ((row.Cells[3].Value) == null) ? "" : row.Cells[3].Value.ToString();

                        if (info[0] == name && info[1] == email && info[2] == address && info[3] == phone)
                        {
                            exists = true;
                            break;
                        }
                    }
                    if(!exists)
                        this.Rows.Add(info);
                }
            else
                InformationBox.Show("Either you don't have Outlook installed, or you don't have any contacts", "No Outlook Contacts Found");
            this.Parent.Enabled = true;
        }
    }
}
