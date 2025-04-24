using Framework.LibraryMVC.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.LibraryMVC.Services
{
    public interface IProductServices
    {
        void AddProduct(Product product);
        (IList<Product> products, int total, int totalDisplay) ProductList(int pageIndex, int pageSize, string OrderBy, string searchText);
        Product getById(int Id);
        void DeleteProduct(int id);

        void UpdateProduct(Product product);

    }
}
