using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Interview.Models.AuthenticationModels
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Имейла  е задължителен")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Паролата е задължителна")]
        [StringLength(15, ErrorMessage = "Паролата трябва да е между 3 и 15 символа", MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
