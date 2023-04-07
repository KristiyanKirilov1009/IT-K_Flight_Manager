using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;

namespace FlightManager.EmailService
{
    public class EmailSender : IEmailSender
    {
        public string SendGridSecret { get; set; }
        public EmailSender(IConfiguration _config)
        {
            SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            //var client = new SendGridClient(SendGridSecret);
            //var from = new EmailAddress("kick.2004@abv.bg", "Flight Manager Admins");
            //var to = new EmailAddress(email);
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
            //var result = await client.SendEmailAsync(msg);
            //return result;
            //return Task.CompletedTask;


            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("k.vladimirov2004@gmail.com", "yeguhegwguktcyjl"),
                EnableSsl = true,
            };

            MailMessage mailMessage = new MailMessage("k.vladimirov2004@gmail.com", email, subject, htmlMessage);
            mailMessage.IsBodyHtml = true;
            smtpClient.Send(mailMessage);

            //var emailToSend = new MimeMessage();
            //emailToSend.From.Add(MailboxAddress.Parse("test@gmail.com"));
            //emailToSend.To.Add(MailboxAddress.Parse(email));
            //emailToSend.Subject = subject;
            //emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            //{ Text = htmlMessage};

            //using (var emailClient = new SmtpClient())
            //{
            //    emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            //    emailClient.Authenticate("k.vladimirov2004@gmail.com", "Kirilov2004");
            //    emailClient.Send(emailToSend);
            //    emailClient.Disconnect(true);
            //}
            //return Task.CompletedTask;
        }
    }
}
