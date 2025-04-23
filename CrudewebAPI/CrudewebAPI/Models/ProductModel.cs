using Autofac;
using Framework.Entites;
using Framework.Services;

namespace CrudewebAPI.Models
{
    public class ProductModel:BaseModel
    {
        public IProductServices _productServices;
        public string? Name { get; set; }
        public string? Type { get; set; }
        public double Price { get; set; }
        public ProductModel()
        {
                
        }
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

    }
}
