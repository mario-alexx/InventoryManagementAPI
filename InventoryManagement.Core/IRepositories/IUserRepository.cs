using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Repositories
{
    /// <summary>
    /// Repository interface for User entity.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        // Add specific methods for user
    }
}
