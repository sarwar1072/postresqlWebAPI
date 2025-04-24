using Autofac;
using Framework.Entites;
using Framework.Services;

namespace CrudewebAPI.Models
{
    public class ProductModel
    {
        //public IProductServices _productServicesId;
        public int  Id{ get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public double Price { get; set; }
        public ProductModel()
        {
                
        }
        //public ProductModel()
        //{
        //    //_productServices = productServices;
        //}
        //public override void ResolveDependency(ILifetimeScope lifetimeScope)
        //{
        //    _lifetimeScope = lifetimeScope;
        //    _productServices = _lifetimeScope.Resolve<IProductServices>();
        //    base.ResolveDependency(_lifetimeScope);
        //}
        //public void AddProduct()
        //{
        //    var data = new Product
        //    {
        //        Name = Name,
        //        Type = Type,
        //        Price = Price,
        //    };
        //    _productServices.AddProduct(data);
        //}

    }
}
