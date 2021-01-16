using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Website.DAL.Contacts.Entities;
using Website.DAL.Implementations;
using Website.Domain.Contracts;
using Website.Domain.Contracts.Models;

namespace Website.Domain.Implementations
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly UserManager<EntityUser> _userManager;
        private readonly SignInManager<EntityUser> _signInManager;

        public AuthorizeService(Context aContext, IMapper aMapper, UserManager<EntityUser> aUserManager,
            SignInManager<EntityUser> aSignInManager)
        {
            _context = aContext;
            _mapper = aMapper;
            _userManager = aUserManager;
            _signInManager = aSignInManager;
        }

        public async Task RegisterUserAsync(RegisterForm aRegisterViewModel)
        {
            var user = _mapper.Map<RegisterForm, EntityUser>(aRegisterViewModel);
            await _userManager.CreateAsync(user, aRegisterViewModel.Password);
            await _context.SaveChangesAsync();
        }

        public async Task<EntityUser> FindUser(LoginForm aLoginViewModel)
        {
            return await _userManager.FindByNameAsync(aLoginViewModel.Name);
        }

        public async Task<SignInResult> SignInUserAsync(EntityUser aEntityUser, LoginForm aLoginViewModel)
        {
            return await _signInManager.PasswordSignInAsync(aEntityUser, aLoginViewModel.Password,
                aLoginViewModel.RememberMe, false);
        }

        public async Task SignOutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}