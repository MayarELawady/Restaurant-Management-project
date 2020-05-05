using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant_Management.Models
{
    public class Meal
    {
        [Key]
        public int MealID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public float Price { get; set; }
        public IList<Order> Order { get; set; }
    }
}