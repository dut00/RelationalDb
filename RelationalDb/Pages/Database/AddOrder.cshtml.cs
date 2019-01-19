using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RelationalDb.Data;
using RelationalDb.Models;

namespace RelationalDb.Pages.Database
{
    public class AddOrderModel : PageModel
    {
        private RelationalDbContext _context;

        public AddOrderModel(RelationalDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            var random = new Random();

            var customerIDs = _context.Customers.AsEnumerable().Select(r => (int)r.CustomerID).ToArray();
            var productIDs = _context.Products.AsEnumerable().Select(r => (int)r.ProductID).ToArray();

            var cID = customerIDs[random.Next(0, customerIDs.Length)];
            var pID = productIDs[random.Next(0, productIDs.Length)];

            var orders = new List<Order>
            {
                new Order
                {
                    Date = DateTime.Now,
                    //CustomerID = cID,
                    //ProductID = pID,

                    Customer = _context.Customers.FirstOrDefault(r => r.CustomerID == cID),
                    Product = _context.Products.FirstOrDefault(r => r.ProductID == pID)
        }
            };


            _context.Orders.AddRange(orders);
            _context.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}