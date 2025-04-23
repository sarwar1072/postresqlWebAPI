using Framework.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services
{
    public class ProductServices: IProductServices
    {
        private IProjectUnitOfWork _unitOfWork;
        public ProductServices(IProjectUnitOfWork projectUnitOf)
        {
            _unitOfWork = projectUnitOf;
        }

        public void AddProduct(Product product)
        {
            if(product == null) {
                throw new InvalidOperationException("product is null ");
            }

            _unitOfWork.ProductRepository.Add(product);
            _unitOfWork.Save();

        }
    }
}
