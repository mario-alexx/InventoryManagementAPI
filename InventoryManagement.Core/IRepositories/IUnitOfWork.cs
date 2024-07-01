using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Repositories
{
    /// <summary>
    /// Unit of Work interface for managing repositories.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the product repository.
        /// </summary>
        IProductRepository Products { get; }

        /// <summary>
        /// Gets the user repository.
        /// </summary>
        IUserRepository Users { get; }

        /// <summary>
        /// Saves all changes.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        Task<int> SaveChangesAsync();
    }
}
