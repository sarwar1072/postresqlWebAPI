using Framework.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services
{
    public interface IProductServices
    {
        void AddProduct(Product product);
        IList<Product> GetAllProduct();
        Product GetById(int id);
        void Removeproduct(int id);

        void UpdateProduct(Product product);

    }
}
