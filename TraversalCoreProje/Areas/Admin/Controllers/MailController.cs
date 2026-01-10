using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest p)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "traversalcore07@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressFromTo = new MailboxAddress("User", p.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressFromTo);

            mimeMessage.Subject = p.Subject;
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = p.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;

            client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            client.Authenticate("traversalcore07@gmail.com", "phosugacglkuxtjo");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
