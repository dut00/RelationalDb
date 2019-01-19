using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RelationalDb.Models;
using RelationalDb.Services;

namespace RelationalDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ITData<Product> _productData;

        public ProductsController(ITData<Product> productData)
        {
            _productData = productData;
        }

        // GET api/products
        [HttpGet]
        public IEnumerable<Product> Get()
        //public ActionResult<IEnumerable<Product>> Get()
        {
            return _productData.GetAll();
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productData.Get(id);
        }

        // POST api/products
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
