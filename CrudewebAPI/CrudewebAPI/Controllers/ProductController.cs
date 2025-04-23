using Autofac;
using Azure;
using CrudewebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CrudewebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected readonly ILifetimeScope _lifetimeScope;
        public ProductController(ILifetimeScope lifetimeScope)
        {
                _lifetimeScope = lifetimeScope;
        }
        [HttpGet("get")]   
        public IActionResult Get() { 
          return Ok();  
        }

        [HttpPost]  
        public IActionResult CreatePrduct([FromBody] ProductModel model) 
        {
            model.ResolveDependency(_lifetimeScope);
            if (model == null)
            {
                return BadRequest();
            }
            model.AddProduct();
            return Ok(model);    
        }
    }
}
