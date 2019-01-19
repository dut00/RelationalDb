using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RelationalDb.Models
{
    public class Customer
    {
        // By default, the Entity Framework interprets a property that's named ID or classname ID as the primary key.
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Order> Orders { get; set; }
        // Navigation properties are typically defined as virtual so that they can take advantage of certain Entity Framework functionality such as lazy loading.
        //public virtual ICollection<Order> Orders { get; set; }
    }
}
