using RelationalDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationalDb.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Desctription { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
