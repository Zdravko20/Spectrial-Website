namespace SpectrialWebsite.Controllers
{
    using System;
    using System.Net.Mail;
    using System.Web.Mvc;
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WhoAreWe()
        {
            ViewBag.Message = "Your expertise page.";

            return View();
        }

        public ActionResult Consulting()
        {
            ViewBag.Message = "Your consulting page.";

            return View();
        }

        public ActionResult ContactUs()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult ContactUs([Bind(Include = "FirstName,LastName,Email,Content")]LoginViewModel loginViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(loginViewModel);
            }

            using (SmtpClient smtpClient = new SmtpClient())
            {
                using (MailMessage message = new MailMessage())
                {
                    message.Subject = "SpectrialMessage";
                    message.Body = $"SenderMail:{loginViewModel.Email}\r\n{loginViewModel.Content}";
                    message.To.Add(new MailAddress("buckzful@gmail.com"));
                    try
                    {
                        smtpClient.Send(message);
                    }
                    catch (Exception)
                    {
                        return this.View(loginViewModel);
                    }
                }
            }

            return this.Redirect("/home");
        }
    }
}