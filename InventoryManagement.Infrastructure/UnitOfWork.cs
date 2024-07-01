using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;
using InventoryManagement.Infrastructure.Data;
using InventoryManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure
{
    /// <summary>
    /// Unit of Work implementation.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public UnitOfWork(InventoryDbContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Users = new UserRepository(_context);
        }

        /// <inheritdoc />
        public IProductRepository Products { get; private set; }

        /// <inheritdoc />
        public IUserRepository Users { get; private set; }

        /// <inheritdoc />
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
