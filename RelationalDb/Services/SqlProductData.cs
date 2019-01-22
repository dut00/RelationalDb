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
    public class SqlProductData : IData<Product, ProductDTO>
    {
        private RelationalDbContext _context;

        public SqlProductData(RelationalDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetAll(QueryParameters queryParameters)
        {
            IQueryable<Product> result;

            result = _context.Products
                .OrderBy(string.IsNullOrEmpty(queryParameters.SortBy) ? "productid" : queryParameters.SortBy
                            + (queryParameters.IsDescending() ? " desc" : String.Empty));                       // Linq.Dynamic.Core

            if (queryParameters.Details)
            {
                result = result.Include(c => c.Orders);
            }

            return result;
        }

        public Product Get(QueryParameters queryParameters, int id)
        {
            IQueryable<Product> result = _context.Products.Where(c => c.ProductID == id);

            if (queryParameters.Details)
            {
                result = result.Include(c => c.Orders);
            }

            return result.FirstOrDefault();
        }

        public Product Add(ProductDTO productDTO)
        {
            var product = new Product
            {
                Name = productDTO.Name,
                Desctription = productDTO.Desctription,
                Price = productDTO.Price,
                Quantity = productDTO.Quantity
            };

            if (!string.IsNullOrEmpty(product.Name) &&
                !string.IsNullOrEmpty(product.Desctription))
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }

            return product;
        }

        public Product Update(int id, ProductDTO productDTO)
        {
            var product = new Product
            {
                ProductID = id,
                Name = productDTO.Name,
                Desctription = productDTO.Desctription,
                Price = productDTO.Price,
                Quantity = productDTO.Quantity
            };

            if (!string.IsNullOrEmpty(product.Name) &&
                !string.IsNullOrEmpty(product.Desctription))
            {
                _context.Attach(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return product;
        }

        public void Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(r => r.ProductID == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            else
            {
                Debug.WriteLine($"Produkt o ID={id} nie istnieje.");
            }
        }
    }
}
