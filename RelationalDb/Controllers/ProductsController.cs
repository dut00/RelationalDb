using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RelationalDb.DTOs;
using RelationalDb.Helpers;
using RelationalDb.Middleware;
using RelationalDb.Models;
using RelationalDb.Services;

namespace RelationalDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase, IController<Product, ProductDTO>
    {
        private IData<Product, ProductDTO> _productData;

        public ProductsController(IData<Product, ProductDTO> productData)
        {
            _productData = productData;
        }

        // GET api/products
        [HttpGet]
        public IQueryable<Product> GetAll([FromQuery] QueryParameters queryParameters)
        //public ActionResult<IEnumerable<Product>> Get()
        {
            return _productData.GetAll(queryParameters);
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public Product Get([FromQuery] QueryParameters queryParameters, int id)
        {
            return _productData.Get(queryParameters, id);
        }

        // POST api/products
        [HttpPost]
        [AuthorizationTokenFilter]
        public void Post([FromBody] ProductDTO productDTO)
        {
            _productData.Add(productDTO);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        [AuthorizationTokenFilter]
        public void Put(int id, [FromBody] ProductDTO productDTO)
        {
            _productData.Update(id, productDTO);
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        [AuthorizationTokenFilter]
        public void Delete(int id)
        {
            _productData.Delete(id);
        }
    }
}
