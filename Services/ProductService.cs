using Core.Interfaces;
using Core.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        public IUnitOfWork _unitOfwork;

        public ProductService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task<bool> AddProductAsync(ProductDetails productDetails)
        {
            if (productDetails != null)
            {
                await _unitOfwork.Product.AddAsync(productDetails);

                var product = _unitOfwork.Save();

                if (product > 0)
                {
                    return true;
                }
                else return false;
            }
            return false;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            if (id > 0)
            {
                var product = await _unitOfwork.Product.GetByIdAsync(id);
                if (product != null)
                {
                    _unitOfwork.Product.Delete(product);
                    var productDeleted = _unitOfwork.Save();

                    if (productDeleted > 0)
                    {
                        return true;
                    }
                    else return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<ProductDetails>> GetAllProductsAsync()
        {
            var products = await _unitOfwork.Product.GetAllAsync();
            return products;
        }

        public async Task<ProductDetails?> GetProductByIdAsync(int id)
        {
            if (id > 0)
            {
                var product = await _unitOfwork.Product.GetByIdAsync(id);
                if (product != null)
                {
                    return product;
                }
            }
            return null;
        }

        public async Task<bool> UpdateProductAsync(ProductDetails productDetails)
        {
            var product = await _unitOfwork.Product.GetByIdAsync(productDetails.Id);
            if (product != null)
            {
                product.ProductName = productDetails.ProductName;
                product.ProductDescription = productDetails.ProductDescription;
                product.ProductPrice = productDetails.ProductPrice;
                product.ProductStock = productDetails.ProductStock;

                _unitOfwork.Product.Update(product);

                var productUpdated = _unitOfwork.Save();

                if (productUpdated > 0)
                {
                    return true;
                }
                else return false;
            }
            return false;
        }
    }
}
