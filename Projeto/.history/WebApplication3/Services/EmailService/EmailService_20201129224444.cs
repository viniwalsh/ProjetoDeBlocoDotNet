using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Net.Mail;
using System;
using System.ComponentModel;

namespace WebApplication3.Services.EmailService
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            client.Credentials = new System.Net.NetworkCredential("horkutalicas@gmail.com", "##11##12##");

            MailMessage mail = new MailMessage("horkutalicas@gmail.com", message.Destination);

            mail.Subject = message.Subject;

            mail.Body = message.Body;

            mail.IsBodyHtml = true;

            client.SendCompleted += new
            SendCompletedEventHandler(SendCompletedCallback);

            client.EnableSsl = true;

            client.Send(mail);
        }

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
        }
    }
}
