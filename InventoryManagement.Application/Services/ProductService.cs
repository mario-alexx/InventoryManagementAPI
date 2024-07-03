using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services
{
    /// <summary>
    /// Service implementation for managing products.
    /// </summary>
    public class ProductService : IProductService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        /// <inheritdoc />
        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        /// <inheritdoc />
        public async Task<ProductDTO> AddProductAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        /// <inheritdoc />
        public async Task<ProductDTO> UpdateProductAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        /// <inheritdoc />
        public async Task DeleteProductAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            _unitOfWork.Products.Remove(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
