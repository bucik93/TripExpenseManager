using System.ComponentModel.DataAnnotations;

namespace TripExpenseManager.Models
{
    public class SignUpModel
    {
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(20)]
        public string UserName { get; set; }

        [Required, MaxLength(20)]
        public string Password { get; set; }
    }
}
