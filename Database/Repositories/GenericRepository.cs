using HardwareStock.Core.Application.Interfaces.Repositories;
using HardwareStock.Core.Domain.Entities;
using HardwareStock.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace HardwareStock.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity>: IGenericRepository<Entity> where Entity : class
    {
        private readonly HardwareContext _db;

        public GenericRepository(HardwareContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Entity entity)
        {
            await _db.Set<Entity>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateAsync(Entity entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        public async Task DeleteAsync(Entity entity)
        {
            _db.Set<Entity>().Remove(entity);
            await _db.SaveChangesAsync();
        }
        public async Task<List<Entity>> GetAllAsync()
        {
            return await _db.Set<Entity>().ToListAsync();//Deferred execution
        }
        public async Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = _db.Set<Entity>().AsQueryable();
            foreach(string property in properties)
            {
                query = query.Include(property);
            }
            return await query.ToListAsync();
        }
        //Returns all the products saved in the Products table
        public async Task<Entity> GetByIdAsync(int id)
        {
            return await _db.Set<Entity>().FindAsync(id);
        }
    }
}
