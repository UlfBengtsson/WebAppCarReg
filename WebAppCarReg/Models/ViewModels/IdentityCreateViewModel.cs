using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models.ViewModels
{
    public class IdentityCreateViewModel
    {
        [Required]
        [StringLength(18, MinimumLength = 4)]
        public string UserName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password must be 6 long and atleast contain a uppercase letter and a lowercase letter and one digit and a symbol.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ControlPassword { get; set; }

    }
}
