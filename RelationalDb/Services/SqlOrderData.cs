using Microsoft.EntityFrameworkCore;
using RelationalDb.Data;
using RelationalDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RelationalDb.Services
{
    public class SqlOrderData : ITData<Order>
    {
        private RelationalDbContext _context;

        public SqlOrderData(RelationalDbContext context)
        {
            _context = context;
        }

        public Order Add(Order order)
        {
            //_context.Add<Product>(product);
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public void Delete(int id)
        {
            Order order = _context.Orders.FirstOrDefault(r => r.OrderID == id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public Order Get(int id)
        {
            return _context.Orders.FirstOrDefault(r => r.OrderID == id);
            //return _context.Orders.Include(x => x.Customers)
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.OrderBy(r => r.OrderID);
        }

        public Order Update(Order order)
        {
            _context.Attach(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return order;
        }
    }
}
