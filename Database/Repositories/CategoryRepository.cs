using HardwareStock.Core.Application.Interfaces.Repositories;
using HardwareStock.Core.Domain.Entities;
using HardwareStock.Infrastructure.Persistence.Contexts;


namespace HardwareStock.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository:GenericRepository<Category>, ICategoryRepository
    {
        private readonly HardwareContext _db;

        public CategoryRepository(HardwareContext db) : base(db)
        {
            _db = db;
        }
    }
}
