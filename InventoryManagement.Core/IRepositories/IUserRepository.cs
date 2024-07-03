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
    /// Repository interface for User repository.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Gets a user by their email.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <returns>The user entity.</returns>
        Task<User> GetUserByEmailAsync(string email);

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The user entity.</param>
        Task AddUserAsync(User user);
    }
}
