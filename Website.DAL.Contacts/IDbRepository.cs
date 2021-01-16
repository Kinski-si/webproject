using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.DAL.Contacts.Entities;

namespace Website.DAL.Contacts
{
    public interface IDbRepository
    {
        Task<T> Get<T>(Guid aId) where T : class, IEntity;

        Task<Guid> Add<T>(T newEntity) where T : class, IEntity;

        Task AddRange<T>(IEnumerable<T> newEntities) where T : class, IEntity;

        Task Remove<T>(Guid id) where T : class, IEntity;

        Task Remove<T>(T entity) where T : class, IEntity;

        Task RemoveRange<T>(IEnumerable<T> entities) where T : class, IEntity;

        Task Update<T>(T entity) where T : class, IEntity;

        Task UpdateRange<T>(IEnumerable<T> entities) where T : class, IEntity;

        Task<int> SaveChangesAsync();

        IQueryable<T> GetAll<T>() where T : class, IEntity;
    }
}