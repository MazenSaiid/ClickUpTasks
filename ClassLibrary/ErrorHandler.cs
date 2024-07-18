using System;
using System.Net;
using System.Net.Mail;

namespace ClassLibrary.ErrorHandler
{
    public class ErrorEmail
    {
        public static void SendEmail(string to, string Subject, string Body, string AddEmail = null)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("UpToDateTechSolutionErrors@gmail.com", "HCS Errors");
                    mail.To.Add(to);
                    if (AddEmail != null)
                    {
                        mail.To.Add(AddEmail);
                    }
                    mail.Subject = Subject;
                    mail.Body = "Hi Admin," + Environment.NewLine + Environment.NewLine + Body;
                    //+ Environment.NewLine + Environment.NewLine + System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    //mail.CC.Add("Moshe@UpToDateTeam.com");

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential("UpToDateTechSolutionErrors@gmail.com", "qktnrxdyqdwgfeno");
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}