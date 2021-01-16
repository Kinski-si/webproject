using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Website.DAL.Contacts;
using Website.DAL.Contacts.Entities;
using Website.Domain.Contracts;
using Website.Domain.Contracts.Models;

namespace Website.Domain.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public ProductService(IDbRepository aDbRepository, IMapper aMapper)
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

        public async Task RemoveCategory(Guid aCategoryId)
        {
            await _dbRepository.Remove<EntityCategory>(aCategoryId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _mapper.Map<IEnumerable<EntityCategory>, IEnumerable<Category>>(
                _dbRepository.GetAll<EntityCategory>());
        }

        public async Task AddProduct(Guid aCategoryId, Product aProduct)
        {
            var category = await _dbRepository.Get<EntityCategory>(aCategoryId);
            category.Product.Add(_mapper.Map<Product, EntityProduct>(aProduct));
            await _dbRepository.Update(category);
            await _dbRepository.SaveChangesAsync();
        }

        public async Task RemoveProduct(Guid aCategoryId, Product aProduct)
        {
            var category = await _dbRepository.Get<EntityCategory>(aCategoryId);
            category.Product.Remove(_mapper.Map<Product, EntityProduct>(aProduct));
            await _dbRepository.Update(category);
            await _dbRepository.SaveChangesAsync();
        }
    }
}