using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Notes
{
    class Interpolation
    {
        public static List<ContactItem> outlookContacts = new List<ContactItem>();

        public void Export(string notes)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();
                object missing = System.Reflection.Missing.Value;
                object fileName = "normal.dot";
                object newTemplate = false;
                object docType = 0;
                object isVisible = true;
                Document aDoc = WordApp.Documents.Add(ref fileName, ref newTemplate, ref docType, ref isVisible);
                WordApp.Visible = true;
                aDoc.Activate();
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                WordApp.Selection.Font.Bold = (int)Microsoft.Office.Interop.Word.WdConstants.wdToggle;
                WordApp.Selection.TypeText(notes);
            }
            catch
            {
                InformationBox.Show("Your document will be exported to your default text editor", "Microsoft Word not found");
                File.WriteAllText("note_expot.txt", notes);
                Process.Start("note_expot.txt");
            }
             
        }

        public void Email(string email, string mail)
        {
            try
            {
                Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook._MailItem oMailItem = (Microsoft.Office.Interop.Outlook._MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                oMailItem.To = email;
                oMailItem.Body = mail;
                oMailItem.Display(true);
            }
            catch { InformationBox.Show("Error saving Outlook contact", "Outlook Error"); }
        }

        public void CreateOutlookContact(string fName = "", string lName = "", string email = "", string address = "", string phone = "")
        {
            Microsoft.Office.Interop.Outlook.Application outlookObj = new Microsoft.Office.Interop.Outlook.Application();
            ContactItem contact = (ContactItem)outlookObj.CreateItem(OlItemType.olContactItem);
            try
            {
                contact.FirstName = fName;
                contact.LastName = lName;
                contact.Email1Address = email;
                contact.HomeAddress = address;
                contact.HomeTelephoneNumber = phone;
                contact.Save();
            }
            catch { InformationBox.Show("Error saving Outlook contact", "Outlook Error"); }
        }

        public void GetOutlookContacts()
        {
            if (outlookContacts.Count > 0)
                outlookContacts.Clear();
            try
            {
                Items outlookItems;
                Microsoft.Office.Interop.Outlook.Application outlookObj = new Microsoft.Office.Interop.Outlook.Application();
                MAPIFolder folderContacts = (MAPIFolder)outlookObj.Session.GetDefaultFolder(OlDefaultFolders.olFolderContacts);
                outlookItems = folderContacts.Items;
                foreach (ContactItem c in outlookItems)
                {
                    ContactItem contact = (ContactItem)c;
                    outlookContacts.Add(contact);
                }
            }
            catch {}
        }
    }
}
