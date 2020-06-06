using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant_Management.Models;
namespace Restaurant_Management.ViewModel
{
    public class OrderC
    {
        public Customer Customer { get; set; }
        public Order Order { get; set; }

        public Staff Staff { get; set; }
    }
}