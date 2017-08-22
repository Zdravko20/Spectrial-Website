using System.Configuration;
using System.Net;
using System.Net.Configuration;

namespace SpectrialWebsite.Controllers
{
    using System;
    using System.Net.Mail;
    using System.Web.Mvc;
    using Models;
    using System.Web.Helpers;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WhoAreWe()
        {
            return View();
        }

        public ActionResult Consulting()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Security()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(
            [Bind(Include = "FirstName,LastName,Email,Content")] LoginViewModel loginViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(loginViewModel);
            }

            var section = (SmtpSection)ConfigurationManager.GetSection("MyMailSettings/smtp");
            using (SmtpClient client = new SmtpClient(section.Network.Host))
            {
                client.Port = section.Network.Port;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential credentials =
                    new System.Net.NetworkCredential(section.Network.UserName, section.Network.Password);
                client.EnableSsl = section.Network.EnableSsl;
                client.Credentials = credentials;

                try
                {
                    var mail = new MailMessage(section.Network.UserName.Trim(), "buckzful@gmail.com".Trim());
                    mail.Subject = "Spectrial";
                    mail.Body = loginViewModel.Content;
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return this.Redirect("/home");
        }
    }
}