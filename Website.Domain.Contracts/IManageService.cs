using System.Collections.Generic;
using System.Threading.Tasks;
using Website.Domain.Contracts.Models;

namespace Website.Domain.Contracts
{
    public interface IManageService
    {
        Task AddCategory(Category aCategory);
        IEnumerable<Category> GetCategories();
    }
}