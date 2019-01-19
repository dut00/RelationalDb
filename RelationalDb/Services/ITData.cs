using RelationalDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationalDb.Services
{
    public interface ITData<T>
    {
        IEnumerable<T> GetAll();
        //IQueryable<T> GetAll();
        T Get(int id);
        T Add(T entity);
        void Delete(int id);
        T Update(T entity);
    }
}
