using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant_Management.Models
{
    public class Order
    {
        [Key]
        public int OrderNo { get; set; }
        public string ORDERTest { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int Num_Of_Items { get; set; }
        public float price { get; set; }
        public IList<Meal> Meal { get; set; }
        [ForeignKey("Staff")]
        public int? StaffId { get; set; }
        public Staff Staff { get; set; }
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}