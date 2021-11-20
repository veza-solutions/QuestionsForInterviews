using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Models.AuthenticationModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Името  е задължително")]
        [StringLength(15, ErrorMessage = "Името трябва да е между 3 и 15 символа", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилията  е задължителна")]
        [StringLength(15, ErrorMessage = "Фамилията трябва да е между 3 и 15 символа", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Имейл е задължителен")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Паролата е задължителна")]
        [StringLength(15, ErrorMessage = "Паролата трябва да е между 3 и 15 символа", MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Потвърждението на паролата е задължително")]        
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RepeatPassword { get; set; }
    }
}
