using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace KlassyCafePostgreSql.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Send(string receiverName, string receiverMail, string subject, string body)
        {
            var mailNickname="Klassy Cafe";
            var mailName="Mail Adresiniz";
            var mailPassword="Mail Şifreniz";
            var mailHost="smtp.office365.com";
            var mailPort=587;
            var mailSsl=false;


            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxSenderAddress = new MailboxAddress(mailNickname, mailName);
            mimeMessage.From.Add(mailboxSenderAddress);
            MailboxAddress mailboxReceiverAddress = new MailboxAddress(receiverName, receiverMail);
            mimeMessage.To.Add(mailboxReceiverAddress);
            mimeMessage.Subject = subject;
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            SmtpClient smtpClient = new SmtpClient();

            try
            { 
                smtpClient.Connect(mailHost, mailPort, mailSsl);
                smtpClient.Authenticate(mailName, mailPassword);
                var sonuc = smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
                TempData["icon"] = "success";
                TempData["text"] = "Mail Gönderildi.";
                return RedirectToAction("List", "Reservation");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mail gönderme işlemi başarısız oldu: " + ex.Message);
                return RedirectToAction("List", "Reservation");
            }
            
        }
    }
}