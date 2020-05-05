using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant_Management.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }
        public IList<Order> Order { get; set; }
        public IList<Bill> Bill { get; set; }
    }
}