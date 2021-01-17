namespace Website.Domain.Contracts.Models
{
    public class AuthorizeForm
    {
        public RegisterForm RegisterForm { get; set; }
        public LoginForm LoginForm { get; set; }
    }
}