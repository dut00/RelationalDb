using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RelationalDb.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }

        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
