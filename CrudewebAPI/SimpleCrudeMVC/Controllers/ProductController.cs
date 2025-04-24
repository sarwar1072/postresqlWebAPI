using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SimpleCrudeMVC.Models;

namespace SimpleCrudeMVC.Controllers
{
    public class ProductController : Controller
    {
        public ILifetimeScope _lifetimeScope;
        private readonly ILogger<HomeController> _logger;

        public ProductController(ILifetimeScope lifetimeScope, ILogger<HomeController> logger)
        {
            _lifetimeScope = lifetimeScope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model=_lifetimeScope.Resolve<ProductListModel>();   
            return View(model);
        }
        public IActionResult GetProduct()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = _lifetimeScope.Resolve<ProductListModel>();
            var data = model.GetProduct(tableModel);
            return Json(data);
        }
        public IActionResult AddProduct()
        {
            var model=new ProductModel();
            return View(model);  
        }
        [HttpPost]
        public IActionResult AddProduct( ProductModel model)
        {
            model.ResolveDependency(_lifetimeScope);
            if(ModelState.IsValid)
            {
                try
                {
                    model.AddProduct();
                    return RedirectToAction("Index");
                }
               catch(Exception ex) 
                {
                    _logger.LogError($"{ex.Message}");
                 }
            }
            return View();
        }
        public IActionResult EditProduct(int id) 
        {
            var model=_lifetimeScope.Resolve<EditModel>();
            model.LoadData(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditProduct(EditModel model)
        {
           model.ResolveDependency(_lifetimeScope);
            if(ModelState.IsValid)
            {
                try
                {
                    model.EditProductMethod();
                    return RedirectToAction("Index");
                }
                catch(Exception ex) 
                {
                    _logger.LogError($"{ex.Message}");
                }
               
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteProduct(int id) 
        {
            var model = _lifetimeScope.Resolve<ProductModel>();
            model.RemoveProduct(id);
            return RedirectToAction("Index");
        }

    }
}
