using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.ViewModels.Manage
{
    public class AddPhoneNumberViewModel
    {
       
        [Phone]
        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Enter phone number.")]
        [MinLength(10, ErrorMessage = "Enter 10 digit valid mobile number.")]
        public string PhoneNumber { get; set; }
    }
}
