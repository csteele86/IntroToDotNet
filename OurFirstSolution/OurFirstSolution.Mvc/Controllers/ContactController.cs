using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OurFirstSolution.Models;
using OurFirstSolution.Services;

namespace OurFirstSolution.Mvc.Controllers
{
    public class ContactController : Controller
    {
        private IEmailService _emailService;

        public ContactController()
        {
            _emailService = new EmailService();
        }

        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactMeViewModel contactMeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(contactMeViewModel);
            }

            bool isSuccess = _emailService.Send(contactMeViewModel.FromEmail, contactMeViewModel.Subject,
                contactMeViewModel.Message);

            return View(contactMeViewModel);
        }
    }
}
