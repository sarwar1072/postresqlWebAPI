using Framework.LibraryMVC.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.LibraryMVC.Services
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
            if(product == null) 
            {
                throw new InvalidOperationException("Product is not exist!");
            }
            var count=_unitOfWork.ProductRepository.GetCount(c=>c.Name==product.Name);

            if (count > 0)
                throw new DuplicateWaitObjectException("same product exist");

            _unitOfWork.ProductRepository.Add(product);
            _unitOfWork.Save();
        }
        public void UpdateProduct(Product product)
        {
            var count = _unitOfWork.ProductRepository.GetCount(c => c.Name == product.Name);

            if (count > 0)
                throw new DuplicateWaitObjectException("same product found");

           var entity=_unitOfWork.ProductRepository.GetById(product.Id); 
             entity.Name=product.Name; 
            entity.Type=product.Type;   
            entity.Price=product.Price;
            _unitOfWork.ProductRepository.Edit(entity); 
            _unitOfWork.Save();
        }
        public void DeleteProduct(int id)
        {
            var data = _unitOfWork.ProductRepository.GetById(id);
            if (data == null)
                throw new InvalidOperationException("Data is not in here");
            
            _unitOfWork.ProductRepository.Remove(data);
            _unitOfWork.Save();
        }
        public Product getById(int Id)
        {
            return _unitOfWork.ProductRepository.GetById(Id);
        }
       public (IList<Product> products,int total,int totalDisplay)ProductList(int pageIndex,int pageSize,string OrderBy,string searchText)
        {
            var data = _unitOfWork.ProductRepository.Get(null,null,null,pageIndex, pageSize, true);
            return(data.data,data.total,data.totalDisplay); 
        }

    }
}
