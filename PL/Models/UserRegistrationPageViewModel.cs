using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class UserRegistrationPageVM
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        [RegularExpression("[a-zA-Z0-9_-]+", ErrorMessage = "Use symbols A-Z, a-z, 0-9, _ and -")]
        public string Login { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        [RegularExpression("[a-zA-Z0-9_-]+", ErrorMessage = "Use symbols A-Z, a-z, 0-9, _ and -")]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}
