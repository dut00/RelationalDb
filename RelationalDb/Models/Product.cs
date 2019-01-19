using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RelationalDb.Models
{
    public class Product
    {
        // This attribute lets you enter the primary key for the course rather than having the database generate it.
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Desctription { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
