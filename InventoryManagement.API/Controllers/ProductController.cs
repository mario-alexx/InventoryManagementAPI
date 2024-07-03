using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    /// <summary>
    /// Controller for managing products.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productService">The product service.</param>
        public ProductController(IProductService productService) 
        { 
            _productService = productService;
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>A list of products.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);    
        }

        /// <summary>
        /// Gets a product by its identifier.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>The product.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="productDto">The product DTO.</param>
        /// <returns>The added product.</returns>
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> AddProduct([FromBody] ProductDTO productDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <param name="productDto">The product DTO.</param>
        /// <returns>The updated product.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct([FromBody] ProductDTO productDto, int id)
        {
            if(id != productDto.Id)
            {
                return BadRequest("Product ID mismatch");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedProduct = await _productService.UpdateProductAsync(productDto);
            return Ok(updatedProduct);
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) 
            { 
                return NotFound(); 
            }

            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
