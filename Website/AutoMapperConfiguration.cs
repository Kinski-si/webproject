using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Website.DAL.Contacts.Entities;
using Website.Domain.Contracts.Models;

namespace Website
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<RegisterViewModel, EntityUser>();
        }
    }
}