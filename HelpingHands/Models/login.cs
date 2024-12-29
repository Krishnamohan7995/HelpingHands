using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace HelpingHands.Models
{
    public class login
    {
        [Required(ErrorMessage ="Email Required")]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})", ErrorMessage = "Invalid Email-ID")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password Required")]
        [StringLength(20,ErrorMessage = "Only 20 Characters")]
        public string Password { get; set; }
    }
}