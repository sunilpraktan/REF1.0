using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Presentation.Services
{
    public static class MailMessenger
    {
        public static async Task SendMailAsync(MailAccount MailAccount, string To, string CC, string BCC, string Subject, string MessageBody, string AttachmentsFiles)
        {
            SmtpClient client = new SmtpClient(MailAccount.Host);
            client.Port = MailAccount.Port;
            client.EnableSsl = MailAccount.EnableSSL;
            client.Timeout = MailAccount.TimeOut;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = MailAccount.DefaultCredentials;
            client.Credentials = new NetworkCredential(MailAccount.MailID, MailAccount.Password);
            MailMessage msg = new MailMessage();
            
            if (To != "" && To != null)
            {
                foreach (var addressTo in To.Split(new[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    msg.To.Add(addressTo);
                }
            }
            if (CC != "" && CC != null)
            {
                foreach (var addressCC in CC.Split(new[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    msg.CC.Add(addressCC);
                }
            }
            if (BCC != "" && BCC != null)
            {
                foreach (var addressBCC in BCC.Split(new[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    msg.Bcc.Add(addressBCC);
                }
            }
            if (AttachmentsFiles != "" && AttachmentsFiles != null)
            {
                foreach (var attachement in AttachmentsFiles.Split(new[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    msg.Attachments.Add(new Attachment(attachement));
                }
            }
            msg.From = new MailAddress(MailAccount.MailID, MailAccount.DisplayName);
            msg.Subject = Subject;
            msg.Body = MessageBody;
            msg.IsBodyHtml = true;
            msg.BodyEncoding = UTF8Encoding.UTF8;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            //client.Send(msg);
            await client.SendMailAsync(msg);
        }
        public static string SendMail(MailAccount MailAccount, string To, string CC, string BCC, string Subject, string MessageBody, string AttachmentsFiles)
        {
            SmtpClient client = new SmtpClient(MailAccount.Host);
            client.Port = MailAccount.Port;
            client.EnableSsl = MailAccount.EnableSSL;
            client.Timeout = MailAccount.TimeOut;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = MailAccount.DefaultCredentials;
            client.Credentials = new NetworkCredential(MailAccount.MailID, MailAccount.Password);
            MailMessage msg = new MailMessage();

            if (To != "" && To != null)
            {
                foreach (var addressTo in To.Split(new[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    msg.To.Add(addressTo);
                }
            }
            if (CC != "" && CC != null)
            {
                foreach (var addressCC in CC.Split(new[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    msg.CC.Add(addressCC);
                }
            }
            if (BCC != "" && BCC != null)
            {
                foreach (var addressBCC in BCC.Split(new[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    msg.Bcc.Add(addressBCC);
                }
            }
            if (AttachmentsFiles != "" && AttachmentsFiles != null)
            {
                foreach (var attachement in AttachmentsFiles.Split(new[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    msg.Attachments.Add(new Attachment(attachement));
                }
            }
            msg.From = new MailAddress(MailAccount.MailID, MailAccount.DisplayName);
            msg.Subject = Subject;
            msg.Body = MessageBody;
            msg.IsBodyHtml = true;
            msg.BodyEncoding = UTF8Encoding.UTF8;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(msg);
            return "";
        }

        public static string FormatMessageBody(string MessageBodyString, List<KeyValuePair<string, string>> KeyValuePair)
        {
            string body = string.Empty;
            foreach (KeyValuePair<string, string> kvp in KeyValuePair)
            {
                //VarData.subject = VarData.subject.Replace(kvp.Key, kvp.Value);
                body = MessageBodyString.Replace(kvp.Key, kvp.Value);
            }
            return body;
        }
    }
}
