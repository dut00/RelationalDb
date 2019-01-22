using Microsoft.EntityFrameworkCore;
using RelationalDb.Data;
using RelationalDb.DTOs;
using RelationalDb.Helpers;
using RelationalDb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;


namespace RelationalDb.Services
{
    public class SqlOrderData : IData<Order, OrderDTO>
    {
        private RelationalDbContext _context;

        public SqlOrderData(RelationalDbContext context)
        {
            _context = context;
        }

        public IQueryable<Order> GetAll(QueryParameters queryParameters)
        {
            IQueryable<Order> result;

            result = _context.Orders
                .OrderBy(string.IsNullOrEmpty(queryParameters.SortBy) ? "orderid" : queryParameters.SortBy
                            + (queryParameters.IsDescending() ? " desc" : String.Empty));                       // Linq.Dynamic.Core

            // Napraw to, bo źle zwraca
            //if (queryParameters.Details)
            //{
            //    result = result.Include(c => c.Customer);
            //}

            return result;
        }

        public Order Get(QueryParameters queryParameters, int id)
        {
            IQueryable<Order> result = _context.Orders.Where(c => c.OrderID == id);

            //if (queryParameters.Details)
            //{
            //    result = result.Include(c => c.Orders);
            //}

            return result.FirstOrDefault();
        }

        public Order Add(OrderDTO orderDTO)
        {
            var order = new Order
            {
                Date = DateTime.Now,  // niezależnie od wprowadzonej daty ustawia aktualną - popraw to
                CustomerID = orderDTO.CustomerID,
                ProductID = orderDTO.ProductID
            };

            if ((order.CustomerID > 0) && (order.ProductID > 0)) // a co jeśli dane Id nie istnieje??
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
            }

            return order;
        }

        public Order Update(int id, OrderDTO orderDTO)
        {
            var dateResult = new DateTime();
            var isCorrectDate = DateTime.TryParse(orderDTO.Date, out dateResult);

            var order = new Order
            {
                OrderID = id,
                Date = isCorrectDate ? dateResult : DateTime.Now,  // jeżeli nie sparsuje ustawia aktualną - popraw to
                CustomerID = orderDTO.CustomerID,
                ProductID = orderDTO.ProductID
            };

            if ((order.CustomerID > 0) && (order.ProductID > 0)) // a co jeśli dane Id nie istnieje??
            {
                _context.Attach(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return order;
        }

        public void Delete(int id)
        {
            Order order = _context.Orders.FirstOrDefault(r => r.OrderID == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
            else
            {
                Debug.WriteLine($"Zamówienie o ID={id} nie istnieje.");
            }
        }
    }
}
