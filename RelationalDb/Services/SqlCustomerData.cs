using Microsoft.EntityFrameworkCore;
using RelationalDb.Data;
using RelationalDb.DTOs;
using RelationalDb.Helpers;
using RelationalDb.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace RelationalDb.Services
{
    public class SqlCustomerData : IData<Customer, CustomerDTO>
    {
        private RelationalDbContext _context;

        public SqlCustomerData(RelationalDbContext context)
        {
            _context = context;
        }

        public IQueryable<Customer> GetAll(QueryParameters queryParameters)
        {
            IQueryable<Customer> result;

            result = _context.Customers
                .OrderBy(String.IsNullOrEmpty(queryParameters.SortBy) ? "customerid" : queryParameters.SortBy
                            + (queryParameters.IsDescending() ? " desc" : String.Empty));                       // Linq.Dynamic.Core

            if (queryParameters.Details)
            {
                result = result.Include(c => c.Orders);
            }

            //result = from c in _context.Customers
            //         //orderby c.CustomerID descending
            //         orderby c.LastName descending
            //         select c;

            return result;

            //return _context.Customers
            //    .OrderBy(r => r.CustomerID)
            //    .Include(c => c.Orders);
        }

        public Customer Get(QueryParameters queryParameters, int id)
        {
            IQueryable<Customer> result = _context.Customers.Where(c => c.CustomerID == id);

            if (queryParameters.Details)
            {
                result = result.Include(c => c.Orders);
            }

            return result.FirstOrDefault();

            //return _context.Customers
            //    .Where(c => c.CustomerID == id)
            //    .Include(c => c.Orders)
            //    //.ThenInclude(c => c.Product)
            //    .FirstOrDefault();
            ////.Select(x => new {
            ////    customerID = x.CustomerID,
            ////    firstName = x.FirstName,
            ////    orders = x.Orders.Select(z => new
            ////    {
            ////        orderID = z.OrderID,
            ////        date = z.Date,
            ////        productID = z.ProductID
            ////    })
            ////});
        }

        public Customer Add(CustomerDTO customerDTO)
        {
            var customer = new Customer();

            customer.FirstName = customerDTO.FirstName;
            customer.LastName = customerDTO.LastName;

            if (!string.IsNullOrEmpty(customer.FirstName) &&
                !string.IsNullOrEmpty(customer.LastName))
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }

            return customer;
        }

        //Dodaj możliwość edycji tylko jednego parametru, np. samego Imienia
        public Customer Update(int id, CustomerDTO customerDTO)
        {
            var customer = new Customer
            {
                CustomerID = id,
                FirstName = customerDTO.FirstName, // ?? "Imie", 
                LastName = customerDTO.LastName
            };

            if (!string.IsNullOrEmpty(customer.FirstName) &&
                !string.IsNullOrEmpty(customer.LastName))
            {
                _context.Attach(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return customer;
        }

        public void Delete(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(r => r.CustomerID == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            else
            {
                Debug.WriteLine($"Klient o ID={id} nie istnieje.");
            }
        }
    }
}
