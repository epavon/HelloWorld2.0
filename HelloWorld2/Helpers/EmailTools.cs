using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld2.Helpers
{
    public class EmailTools
    {
        public Task SendEmail(string subject, string body)
        {
            var tcs = new TaskCompletionSource<object>();
            string emailSender = ConfigurationManager.AppSettings["EmailSender"];
            string emailRecipient = ConfigurationManager.AppSettings["EmailRecipient"];
            string emailPass = ConfigurationManager.AppSettings["EmailPass"];
            string emailHost = ConfigurationManager.AppSettings["EmailClientHost"];

            SmtpClient client = new SmtpClient
            {
                Port = 587,
                Host = emailHost,
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(emailSender, emailPass)
            };

            MailMessage msg = new MailMessage(emailSender, emailRecipient)
            {
                Subject = subject,
                Body = body,
                BodyEncoding = UTF8Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };

            //client.Send(msg);            
            SendCompletedEventHandler sch = null;
            sch = (s, e) =>
            {
                client.SendCompleted -= sch;
                if(e.Cancelled)
                {
                    tcs.SetCanceled();
                }
                else if(e.Error != null)
                {
                    tcs.SetException(e.Error);
                }
            };
            client.SendCompleted += sch;
            client.SendAsync(msg, new object());

            return tcs.Task;
        }
    }
}
