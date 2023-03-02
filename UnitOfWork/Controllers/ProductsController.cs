using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace UnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _service.GetAllProductsAsync();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        /// <summary>
        /// Get a product by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDetails product)
        {
            var isProductAdded = await _service.AddProductAsync(product);

            if (isProductAdded)
            {
                return Ok(product);
            }
            else 
            { 
                return BadRequest();
            }
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDetails product)
        {
            if (product != null)
            {
                var isProductUpdated = await _service.UpdateProductAsync(product);
                if (isProductUpdated)
                {
                    return Ok(isProductUpdated);
                }
               return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete a product by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var isProductDeleted = await _service.DeleteProductAsync(id);
            if (isProductDeleted)
            {
                return Ok(isProductDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
