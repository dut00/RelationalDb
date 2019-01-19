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
    public class OrdersController : ControllerBase
    {
        private ITData<Order> _orderData;

        public OrdersController(ITData<Order> orderData)
        {
            _orderData = orderData;
        }

        // GET api/orders
        [HttpGet]
        public IEnumerable<Order> Get()
        //public ActionResult<IEnumerable<Customer>> Get()
        {
            return _orderData.GetAll();
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _orderData.Get(id);
        }

        // POST api/orders
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/orders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
