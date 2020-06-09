using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant_Management.Models;
namespace Restaurant_Management_project.ViewModel
{
    public class OrderMeal
    {
        public ICollection<Order> order { get; set; }
        public ICollection<Meal> meal { get; set; }
    }
}