using System.ComponentModel.DataAnnotations;

namespace Website.Areas.Welcome.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Имя не может быть пустым")]
        public string Name { get; set; }

        [StringLength(14, MinimumLength = 6, ErrorMessage =
            "Пароль должен содержать от 6 до 14 символов")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}