using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OurFirstSolution.Models
{
    public class ContactMeViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "From")]
        public string FromEmail { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}