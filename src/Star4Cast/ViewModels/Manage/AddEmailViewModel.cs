using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.ViewModels.Manage
{
    public class AddEmailViewModel
    {
        [EmailAddress]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Enter a valid email id.")]
        public string Email { get; set; }
    }
}
