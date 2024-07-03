using InventoryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.IServices
{
    /// <summary>
    /// Service interface for managing products.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>A list of products.</returns>
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();

        /// <summary>
        /// Gets a product by its identifier.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>The product.</returns>
        Task<ProductDTO> GetProductByIdAsync(int id);

        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="productDto">The product DTO.</param>
        /// <returns>The added product.</returns>
        Task<ProductDTO> AddProductAsync(ProductDTO productDTO);

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="productDto">The product DTO.</param>
        /// <returns>The updated product.</returns>
        Task<ProductDTO> UpdateProductAsync(ProductDTO productDTO);

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteProductAsync(int id);
    }
}
