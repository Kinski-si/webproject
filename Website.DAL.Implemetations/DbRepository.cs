using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Website.DAL.Contacts;
using Website.DAL.Contacts.Entities;

namespace Website.DAL.Implementations
{
    public class DbRepository : IDbRepository
    {
        private readonly Context _context;

        public DbRepository(Context context)
        {
            _context = context;
        }

        public async Task<T> Get<T>(Guid aId) where T : class, IEntity
        {
            return await _context.Set<T>().AsQueryable().SingleAsync(x => x.Id.Equals(aId));
        }

        public async Task<Guid> Add<T>(T newEntity) where T : class, IEntity
        {
            var entity = await _context.Set<T>().AddAsync(newEntity);
            return entity.Entity.Id;
        }

        public async Task AddRange<T>(IEnumerable<T> newEntities) where T : class, IEntity
        {
            await _context.Set<T>().AddRangeAsync(newEntities);
        }

        public async Task Remove<T>(Guid id) where T : class, IEntity
        {
            var objects = _context.Set<T>();
            var activeEntity = await objects.SingleAsync(x => x.Id == id);
            await Task.Run(() => objects.Remove(activeEntity));
        }

        public async Task Remove<T>(T entity) where T : class, IEntity
        {
            await Task.Run(() => _context.Set<T>().Remove(entity));
        }

        public async Task RemoveRange<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            await Task.Run(() => _context.Set<T>().RemoveRange(entities));
        }

        public async Task Update<T>(T entity) where T : class, IEntity
        {
            await Task.Run(() => _context.Set<T>().Update(entity));
        }

        public async Task UpdateRange<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            await Task.Run(() => _context.Set<T>().UpdateRange(entities));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll<T>() where T : class, IEntity
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}