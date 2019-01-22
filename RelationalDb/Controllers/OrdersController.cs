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
    public class OrdersController : ControllerBase, IController<Order, OrderDTO>
    {
        private IData<Order, OrderDTO> _orderData;

        public OrdersController(IData<Order, OrderDTO> orderData)
        {
            _orderData = orderData;
        }

        // GET api/orders
        [HttpGet]
        public IQueryable<Order> GetAll([FromQuery] QueryParameters queryParameters)
        //public ActionResult<IEnumerable<Customer>> Get()
        {
            return _orderData.GetAll(queryParameters);
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public Order Get([FromQuery] QueryParameters queryParameters, int id)
        {
            return _orderData.Get(queryParameters, id);
        }

        // POST api/orders
        [HttpPost]
        [AuthorizationTokenFilter]
        public void Post([FromBody] OrderDTO orderDTO)
        {
            _orderData.Add(orderDTO);
        }

        // PUT api/orders/5
        [HttpPut("{id}")]
        [AuthorizationTokenFilter]
        public void Put(int id, [FromBody] OrderDTO orderDTO)
        {
            _orderData.Update(id, orderDTO);
        }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        [AuthorizationTokenFilter]
        public void Delete(int id)
        {
            _orderData.Delete(id);
        }
    }
}
