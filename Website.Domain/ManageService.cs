using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Website.DAL.Contacts;
using Website.DAL.Contacts.Entities;
using Website.Domain.Contracts;
using Website.Domain.Contracts.Models;

namespace Website.Domain.Implementations
{
    public class ManageService : IManageService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public ManageService(IDbRepository aDbRepository, IMapper aMapper)
        {
            _dbRepository = aDbRepository;
            _mapper = aMapper;
        }

        public async Task AddCategory(Category aCategory)
        {
            var category = _mapper.Map<Category, EntityCategory>(aCategory);
            await _dbRepository.Add(category);
            await _dbRepository.SaveChangesAsync();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _mapper.Map<IEnumerable<EntityCategory>, IEnumerable<Category>>(
                _dbRepository.GetAll<EntityCategory>());
        }
    }
}