using Restaurant_Management.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restaurant_Management.Context
{
    public class Resturant : DbContext
    {
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Meal> Meal { get; set; }
    }
}