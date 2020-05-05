using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant_Management.Models
{
    public class Bill
    {
        [Key]
        public int BillNo { get; set; }
        public float TotalPrice { get; set; }
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Order")]
        public int OrderNo { get; set; }
        public Order Order { get; set; }

    }
}