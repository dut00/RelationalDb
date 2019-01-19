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
    public class CustomersController : ControllerBase
    {
        private ITData<Customer> _customerData;

        public CustomersController(ITData<Customer> customerData)
        {
            _customerData = customerData;
        }


        // GET api/customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        //public ActionResult<IEnumerable<Customer>> Get()
        {
            return _customerData.GetAll();
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _customerData.Get(id);
        }

        #region  Sprawdziłem. Działa. Przesyła JSONa z zagnieżdżonym obiektem.
        //public class Faktura
        //{
        //    public int IdFAktury { get; set; }
        //    public string NrFaktury { get; set; }
        //    public Customer customer { get; set; }
        //}

        //[HttpGet("{id}")]
        //public Faktura Get(int id)
        //{
        //    var fak = new Faktura();
        //    fak.IdFAktury = 111;
        //    fak.NrFaktury = "R12/4567/00012";
        //    fak.customer = _customerData.Get(id);
        //    return fak;
        //}
        #endregion

        // POST api/customers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
