using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant_Management.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public int Role { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int phone { get; set; }
        public float Salary { get; set; }
        public string Daysoff { get; set; }
        public DateTime JoinedDate { get; set; }
        public IList<Order> Order { get; set; }
        public IList<Bill> Bill { get; set; }
    }
}