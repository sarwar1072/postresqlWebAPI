using Autofac;
using Azure;
using CrudewebAPI.Models;
using Framework.Entites;
using Framework.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CrudewebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            var data = _productServices.GetAllProduct();
            if (data == null) {
                return BadRequest();
            }
            var model = new List<ProductModel>();
            foreach (var item in data)
            {
                model.Add(new ProductModel
                {
                    Id=item.Id, 
                    Name = item.Name,
                    Type = item.Type,
                    Price = item.Price,
                });

            }

            return Ok(model);
        }

        [HttpGet("getBtId")]
        public IActionResult GetById(int id)
        {
            var data = _productServices.GetById(id);
            if (data == null) {
                return BadRequest();
            }
            var model = new ProductModel {
                Id=data.Id,  
                Name = data.Name,
                Type = data.Type,
                Price = data.Price
            };
            return Ok(model);
        }

        [HttpDelete("deleteProduct")]
        public IActionResult DeleteById(int id)
        {
            var delete = _productServices.GetById(id);
            if (delete == null)
            {
                return NotFound();
            }
            _productServices.Removeproduct(id);
            return Ok("Deleted successfully");
        }

        [HttpPost("CreatePrduct")]
        public IActionResult CreatePrduct([FromBody] ProductModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var data = new Product
            {
                Name = model.Name,
                Type = model.Type,
                Price = model.Price,
            };
            _productServices.AddProduct(data);
            return Ok("Product created successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct( int id,[FromBody]ProductModel model)
        {
            if(model.Id != id) {
                return BadRequest("missMatch");
            }

            var data=_productServices.GetById(id);
            if(data == null)
            {
                return NotFound("no data found");
            }

            data.Name = model.Name;
            data.Price = model.Price;
            data.Type = model.Type;
            _productServices.UpdateProduct(data);

            return Ok("Product updated successfully");
        }
       
    }
}
