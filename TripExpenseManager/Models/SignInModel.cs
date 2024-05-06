using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripExpenseManager.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Proszę wpisać email"), MaxLength(20)]
        public string UserName { get; set; }

        [Required, MaxLength(20)]
        public string Password { get; set; }

    }
}
