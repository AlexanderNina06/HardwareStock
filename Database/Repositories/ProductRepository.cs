using HardwareStock.Core.Application.Interfaces.Repositories;
using HardwareStock.Core.Domain.Entities;
using HardwareStock.Infrastructure.Persistence.Contexts;
using HardwareStock.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ProductRepository:GenericRepository<Product>, IProductRepository
    {
        private readonly HardwareContext _db;

        public ProductRepository(HardwareContext db): base(db)
        {
            _db = db;
        }

    }
}
