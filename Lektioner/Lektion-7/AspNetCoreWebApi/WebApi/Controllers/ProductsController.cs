using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                DataStore.Products.Add(model);
                return Created("", null);
            }

            return BadRequest();
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var products = DataStore.Products;
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var product = DataStore.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }




        [HttpPut("{id}")]
        public IActionResult UpdateOne(int id, Product model)
        {
            if (ModelState.IsValid && id > 0)
            {
                var product = DataStore.Products.FirstOrDefault(x => x.Id == id);
                if (product != null)
                {
                    product.Id = model.Id;
                    product.Name = model.Name;
                    product.Price = model.Price;
                    product.ProductImage = model.ProductImage;

                    return Ok(product);
                }

                return NotFound();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOne(int id)
        {
            var product = DataStore.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                DataStore.Products.Remove(product);
                return Ok(new ApiResult
                {
                    Successed = true,
                    StatusCode = 200,
                    Message = "Object was deleted"
                });
            }

            return NotFound();
        }

    }

    public class ApiResult
    {
        public bool Successed { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public object? Content { get; set; }
    }
}