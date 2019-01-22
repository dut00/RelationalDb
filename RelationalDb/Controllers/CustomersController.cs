using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RelationalDb.Data;
using RelationalDb.DTOs;
using RelationalDb.Helpers;
using RelationalDb.Middleware;
using RelationalDb.Models;
using RelationalDb.Services;

namespace RelationalDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase, IController<Customer, CustomerDTO>
    {
        private IData<Customer, CustomerDTO> _customerData;

        public CustomersController(IData<Customer, CustomerDTO> customerData)
        {
            _customerData = customerData;
        }

        // GET api/customers
        [HttpGet]
        public IQueryable<Customer> GetAll([FromQuery] QueryParameters queryParameters) // ActionResult<IEnumerable<Customer>>
        {
            return _customerData.GetAll(queryParameters);
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public Customer Get([FromQuery] QueryParameters queryParameters, int id)
        {
            return _customerData.Get(queryParameters, id);
        }

        // POST api/customers
        [HttpPost]
        [AuthorizationTokenFilter]
        public void Post([FromBody] CustomerDTO customerDTO)
        {
            _customerData.Add(customerDTO);
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        [AuthorizationTokenFilter]
        public void Put(int id, [FromBody] CustomerDTO customerDTO)
        {
            _customerData.Update(id, customerDTO);
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        [AuthorizationTokenFilter]
        public void Delete(int id)
        {
            _customerData.Delete(id);
        }
    }
}
