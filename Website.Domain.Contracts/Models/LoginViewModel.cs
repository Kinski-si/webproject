using System.ComponentModel.DataAnnotations;

namespace Website.Domain.Contracts.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Имя не может быть пустым")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пароль не может быть пустым")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}