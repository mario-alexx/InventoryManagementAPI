using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;
using InventoryManagement.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    /// <summary>
    /// User repository implementation.
    /// </summary>
    public class UserRepository : Repository<User>, IUserRepository
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public UserRepository(DbContext context) : base(context)
        {  
        }

        // Add specific methods for User
    }
}
