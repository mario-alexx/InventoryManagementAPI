using InventoryManagement.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    /// <summary>
    /// Generic repository implementation.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public Repository(DbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task AddAsync(T entity)
        {
             await _context.Set<T>().AddAsync(entity);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <inheritdoc />
        public async Task<T>? GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <inheritdoc />
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        /// <inheritdoc />
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
