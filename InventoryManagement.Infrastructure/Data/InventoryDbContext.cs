using InventoryManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Data
{
    /// <summary>
    /// Database context for Inventory Management.
    /// </summary>
    public class InventoryDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {   
        }
      
        /// <summary>
        /// Gets or sets the users in the system.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the products in the inventory.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="DbSet{TEntity}"/> properties on your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
