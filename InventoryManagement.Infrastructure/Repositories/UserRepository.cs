using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;
using InventoryManagement.Core.Repository;
using InventoryManagement.Infrastructure.Data;
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
        private readonly InventoryDbContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public UserRepository(InventoryDbContext context) : base(context)
        {  
            _context = context;
        }

        /// <summary>
        /// Gets a user by their email.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <returns>The user entity.</returns>
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The user entity.</param>
        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
