using System.Web.Mvc;
using System.Net.Mail;
using System.Text;

namespace loudclothes.net.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Send(string contact_name, string contact_email, string contact_phone, string contact_message)
        {
            //MailMessage mail = new MailMessage("", "");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
           // client.Credentials = new System.Net.NetworkCredential();
           // client.Host = "";  //write Your smtp serwer 
            mail.Subject = "Contact";
            mail.Body = "Mail from : " + contact_name +" E-mail : "+ contact_email + " Phone Number : " + contact_phone+ " Message : "+ contact_message;
            mail.BodyEncoding = UTF8Encoding.UTF8;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mail);

            return View("Index");
        }
    }
}