using Microsoft.AspNetCore.Mvc;
using RelationalDb.Helpers;
using RelationalDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationalDb.Controllers
{
    interface IController<T,D>
    {
        //[HttpGet]
        IQueryable<T> GetAll([FromQuery] QueryParameters queryParameters);

        //[HttpGet("{id}")]
        T Get([FromQuery] QueryParameters queryParameters, int id);

        //[HttpPost]
        void Post([FromBody] D entityDTO);

        //[HttpPut("{id}")]
        void Put(int id, [FromBody] D entityDTO);

        //[HttpDelete("{id}")]
        void Delete(int id);
    }
}
