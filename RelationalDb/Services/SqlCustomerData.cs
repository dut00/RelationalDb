using Microsoft.EntityFrameworkCore;
using RelationalDb.Data;
using RelationalDb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace RelationalDb.Services
{
    public class SqlCustomerData : ITData<Customer>
    {
        private RelationalDbContext _context;

        public SqlCustomerData(RelationalDbContext context)
        {
            _context = context;
        }

        public Customer Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public void Delete(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(r => r.CustomerID == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public Customer Get(int id)
        {
            return _context.Customers
                .Where(c => c.CustomerID == id)
                .Include(c => c.Orders)
                //.ThenInclude(c => c.Product)
                .FirstOrDefault();
                //.Select(x => new {
                //    customerID = x.CustomerID,
                //    firstName = x.FirstName,
                //    orders = x.Orders.Select(z => new
                //    {
                //        orderID = z.OrderID,
                //        date = z.Date,
                //        productID = z.ProductID
                //    })
                //});
        }

        public IEnumerable<Customer> GetAll()
        //public IQueryable<Movie> GetAll()
        {
            return _context.Customers
                .OrderBy(r => r.CustomerID)
                .Include(c => c.Orders);
        }

        public Customer Update(Customer customer)
        {
            _context.Attach(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return customer;
        }
    }
}
