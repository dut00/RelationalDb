using RelationalDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationalDb.DTOs
{
    public class OrderDTO
    {
        //public DateTime Date { get; set; }
        public string Date { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }

        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
