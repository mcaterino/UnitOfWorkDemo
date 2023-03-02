using Core.Interfaces;
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
    }
}
