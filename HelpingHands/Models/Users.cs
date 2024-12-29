using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpingHands.Models
{
    public class Users
    {
       
        [Required(ErrorMessage ="User-ID Required")]
        public int Uid { get; set; }
        [Required(ErrorMessage = "UserName Required")]
        [RegularExpression(@"\D{1,40}",ErrorMessage ="Only Alphabets")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [StringLength(20,ErrorMessage ="Only 20 Characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword Required")]
        [Compare("Password",ErrorMessage ="Pwd & Cpwd Not Matched")]
        [StringLength(20,ErrorMessage = "Only 20 Characters")]
         
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Select Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Select Any One")]
        public string Languages { get; set; }
        [Required(ErrorMessage = "Select State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Select City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Select BloodGroup")]
        public string BloodGroup { get; set; }
        [Required(ErrorMessage = "Phone Required")]
        //[RegularExpression("@([6-9][0-9]{9})",ErrorMessage ="Number Should be 10 Digits")]
        public long Phone { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})", ErrorMessage ="Invalid Email-ID")]
        public string Email { get; set; }
    }
}