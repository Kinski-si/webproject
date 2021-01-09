using System.ComponentModel.DataAnnotations;

namespace Website.Domain.Contracts.Models
{
    public class RegisterViewModel
    {
        [EmailAddress] public string Email { get; set; }

        [Required(ErrorMessage = "Укажите ваше имя")]
        [StringLength(14, ErrorMessage = "Максимальное количество символов не должно превышать 14")]
        public string UserName { get; set; }

        [StringLength(14, MinimumLength = 6, ErrorMessage = "Пароль должен содержать от 6 до 14 символов")]
        [Compare(nameof(ConfirmPassword), ErrorMessage = "Пароли не совпадают")]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}