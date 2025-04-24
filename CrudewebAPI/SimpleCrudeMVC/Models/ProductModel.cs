using Autofac;
using Framework.LibraryMVC.Entites;
using Framework.LibraryMVC.Services;

namespace SimpleCrudeMVC.Models
{
    public class ProductModel:BaseModel
    {
        public IProductServices _productServices;
        public int  Id{ get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public double Price { get; set; }
        public ProductModel() { }
        
        public ProductModel(IProductServices productServices)
        {
            _productServices = productServices;
        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _productServices = _lifetimeScope.Resolve<IProductServices>();
            base.ResolveDependency(_lifetimeScope);
        }
        public void AddProduct()
        {
            var data = new Product
            {
                Name = Name,
                Type = Type,
                Price = Price,
            };
            _productServices.AddProduct(data);
        }

        public void RemoveProduct(int id) 
        {
            _productServices.DeleteProduct(id); 
            
        }

    }
}
