using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductService
    {
        Task<bool> AddProductAsync(ProductDetails productDetails);

        Task<IEnumerable<ProductDetails>> GetAllProductsAsync();

        Task<ProductDetails> GetProductByIdAsync(int Id);

        Task<bool> UpdateProductAsync(ProductDetails productDetails);

        Task<bool> DeleteProductAsync(int Id);
    }
}
