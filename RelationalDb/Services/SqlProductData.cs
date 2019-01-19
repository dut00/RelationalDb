using Microsoft.EntityFrameworkCore;
using RelationalDb.Data;
using RelationalDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RelationalDb.Services
{
    public class SqlProductData : ITData<Product>
    {
        private RelationalDbContext _context;

        public SqlProductData(RelationalDbContext context)
        {
            _context = context;
        }

        public Product Add(Product product)
        {
            //_context.Add<Product>(product);
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(r => r.ProductID == id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product Get(int id)
        {
            return _context.Products
                .Where(c => c.ProductID == id)
                .Include(c => c.Orders)
                .FirstOrDefault();

        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products
                .OrderBy(r => r.ProductID)
                .Include(c => c.Orders);
        }

        public Product Update(Product product)
        {
            _context.Attach(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return product;
        }
    }
}
