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
        public ActionResult ContactUs([Bind(Include = "FirstName,LastName,Email,Content")]LoginViewModel loginViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(loginViewModel);
            }

            using (SmtpClient smtpClient = new SmtpClient())
            {
                try
                {
                    //Configuring webMail class to send emails  
                    //gmail smtp server  
                    WebMail.SmtpServer = "smtp.gmail.com";
                    //gmail port to send emails  
                    WebMail.SmtpPort = 587;
                    WebMail.SmtpUseDefaultCredentials = true;
                    //sending emails with secure protocol  
                    WebMail.EnableSsl = true;
                    //EmailId used to send emails from application  
                    WebMail.UserName = "buckzful@gmail.com";
                    WebMail.Password = "JOHNYBRAVO941216";

                    //Sender email address.  
                    WebMail.From = loginViewModel.Email;

                    //Send email  
                    WebMail.Send(to: "buckzful@gmail.com", subject: "ContactUs", body: loginViewModel.Content, isBodyHtml: true);
                    ViewBag.Status = "Email Sent Successfully.";
                }
                catch (Exception)
                {
                    return this.View(loginViewModel);
                }
            }


            return this.Redirect("/home");
        }
    }
}