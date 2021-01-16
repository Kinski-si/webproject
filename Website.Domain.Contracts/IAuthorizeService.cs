using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Website.DAL.Contacts.Entities;
using Website.Domain.Contracts.Models;

namespace Website.Domain.Contracts
{
    public interface IAuthorizeService
    {
        Task RegisterUserAsync(RegisterForm aRegisterViewModel); 
        Task SignOutUserAsync();
        Task<EntityUser> FindUser(LoginForm aLoginViewModel);
        Task<SignInResult> SignInUserAsync(EntityUser aEntityUser, LoginForm aLoginViewModel);
    }
}