using Microsoft.AspNetCore.Mvc;
using RelationalDb.DTOs;
using RelationalDb.Helpers;
using RelationalDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationalDb.Services
{
    public interface IData<T,D>
    {
        IQueryable<T> GetAll(QueryParameters queryParameters);
        T Get(QueryParameters queryParameters, int id);
        T Add(D entityDTO);
        T Update(int id, D entityDTO);
        void Delete(int id);
    }
}
