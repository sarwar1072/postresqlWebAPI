using Autofac;
using Framework.LibraryMVC.Services;

namespace SimpleCrudeMVC.Models
{
    public class ProductListModel:BaseModel
    {
        protected IProductServices _productServices;
        public ProductListModel() { }
        
        public ProductListModel(IProductServices productServices)
        {
                _productServices = productServices; 
        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope= lifetimeScope;  
            _productServices=_lifetimeScope.Resolve<IProductServices>();    
            base.ResolveDependency(lifetimeScope);
        }
        internal object GetProduct(DataTablesAjaxRequestModel dataTables)
        {
            var data = _productServices.ProductList(dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] { "Name","Type","Price"}));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.products
                        select new string[]
                        {
                            record.Name,
                            record.Type,
                            record.Price.ToString(),                           
                            record.Id.ToString()
                        }).ToArray()
            };
        }

    }
}
