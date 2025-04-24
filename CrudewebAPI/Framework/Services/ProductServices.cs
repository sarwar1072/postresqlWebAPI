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

        public void AddProduct(Product model)
        {
            if(model == null) {
                throw new InvalidOperationException("product is null ");
            }


            _unitOfWork.ProductRepository.Add(model);
            _unitOfWork.Save();

        }
        public void UpdateProduct(Product product)
        {
            
            
            _unitOfWork.ProductRepository.Edit(product);
            _unitOfWork.Save();
        }

        public IList<Product> GetAllProduct() 
          { 
             return _unitOfWork.ProductRepository.GetAll();
         }
        public Product GetById(int id)
        {
            return _unitOfWork.ProductRepository.GetById(id);
        }
        public void Removeproduct(int id)
        {
            if(id == 0)
            {
                throw new InvalidOperationException("ID is null ");

            }
            _unitOfWork.ProductRepository.Remove(id); 
            _unitOfWork.Save();
        }

    }
}
