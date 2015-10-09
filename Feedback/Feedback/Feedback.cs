using System;
using System.Net;
using System.Net.Mail;

namespace SendFeedback
{
    public class Send
    {
        private string reciever = "danieldaniber@gmail.com";
        private string[] sender = { "ragequitmania@gmail.com", "iaminhell" };

        public string body
        {
            get;
            set;
        }

        public string subject
        {
            get;
            set;
        }

        public void SendMessage()
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(sender[0]);
            message.Subject = subject;
            message.Body = body;
            message.To.Add(reciever);
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential(sender[0], sender[1]);
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.SendAsync(message, this);
        }
    }
}
