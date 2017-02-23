using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using GeekPeeked.Helpers;

namespace GeekPeeked.Services
{
    public static class EmailService
    {
        public static bool SendEmail(string to, string subject, string body)
        {
            try
            {
                MailMessage email = new MailMessage();
                SmtpClient smtpServer = new SmtpClient(CoreConfiguration.MailHost, CoreConfiguration.MailPort);

                email.From = new MailAddress(CoreConfiguration.MailFromEmail, CoreConfiguration.MailFromName);

                email.To.Add(to);

                email.Subject = subject;
                email.IsBodyHtml = true;
                email.Body = body;

                smtpServer.UseDefaultCredentials = false;
                smtpServer.EnableSsl = CoreConfiguration.MailTLS;
                smtpServer.Credentials = new NetworkCredential(CoreConfiguration.MailUserName, CoreConfiguration.MailPassword);

                smtpServer.Send(email);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool SendEmail(string to, string subject, string body, Attachment attachment)
        {
            try
            {
                MailMessage email = new MailMessage();
                SmtpClient smtpServer = new SmtpClient(CoreConfiguration.MailHost, CoreConfiguration.MailPort);

                email.From = new MailAddress(CoreConfiguration.MailFromEmail, CoreConfiguration.MailFromName);

                email.To.Add(to);

                email.Subject = subject;
                email.IsBodyHtml = true;
                email.Body = body;

                ContentDisposition disposition = attachment.ContentDisposition;
                disposition.CreationDate = DateTime.Now;
                disposition.ModificationDate = DateTime.Now;
                disposition.DispositionType = DispositionTypeNames.Attachment;
                email.Attachments.Add(attachment);

                smtpServer.UseDefaultCredentials = false;
                smtpServer.EnableSsl = CoreConfiguration.MailTLS;
                smtpServer.Credentials = new NetworkCredential(CoreConfiguration.MailUserName, CoreConfiguration.MailPassword);

                smtpServer.Send(email);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}