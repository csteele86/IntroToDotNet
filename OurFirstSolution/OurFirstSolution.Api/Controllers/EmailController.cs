using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OurFirstSolution.Services;
using OurFirstSolution.Models;

namespace OurFirstSolution.Api.Controllers
{
    /// <summary>
    /// API for sending emails
    /// </summary>
    public class EmailController : ApiController
    {
        private IEmailService _emailService;

        public EmailController()
        {
            _emailService = new EmailService();
        }

        // POST api/<controller>
        /// <summary>
        ///  Sends an email
        /// </summary>
        /// <param name="contactMeViewModel">Model for sending email</param>
        /// <returns>True if successful</returns>
        [ResponseType(typeof(bool))]
        public IHttpActionResult Post(ContactMeViewModel contactMeViewModel)
        {
            if (contactMeViewModel == null)
            {
                return BadRequest();
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isSuccess =_emailService.Send(contactMeViewModel.FromEmail, contactMeViewModel.Subject, contactMeViewModel.Message);

            //return StatusCode(HttpStatusCode.NoContent);
            return Ok(isSuccess);
        }
    }
}