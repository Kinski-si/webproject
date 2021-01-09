using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Website.DAL.Contacts.Entities;
using Website.Domain.Contracts.Models;

namespace Website.Domain.Contracts
{
    public interface IAuthorizeService
    {
        Task RegisterUserAsync(RegisterViewModel aRegisterViewModel); 
        Task LogoutUserAsync();
        Task<EntityUser> FindByNameAsync(LoginViewModel aLoginViewModel);
        Task<SignInResult> LogInUserAsync(EntityUser aEntityUser, LoginViewModel aLoginViewModel);
    }
}