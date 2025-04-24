using Autofac;
using Framework.LibraryMVC.Entites;
using Framework.LibraryMVC.Services;

namespace SimpleCrudeMVC.Models
{
    public class EditModel:BaseModel
    {
        public IProductServices _productServices;
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public double Price { get; set; }
        public EditModel() { }

        public EditModel(IProductServices productServices)
        {
            _productServices = productServices;
        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _productServices = _lifetimeScope.Resolve<IProductServices>();
            base.ResolveDependency(_lifetimeScope);
        }
        public void EditProductMethod()
        {
            var data = new Product
            {
                Id = Id,    
                Name = Name,
                Type = Type,
                Price = Price,
            };
            _productServices.UpdateProduct(data);
        }

        public void LoadData(int id)
        {
            var data=_productServices.getById(id);

            if(data != null) 
            {
                Id=data.Id; Name=data.Name; Type=data.Type; Price=data.Price;   
            }

        }
    }
}
