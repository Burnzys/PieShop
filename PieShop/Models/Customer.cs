using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Address")]
        [StringLength(50, MinimumLength = 3)]
        public string AddressLine1 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        [Display(Name = "EirCode")]
        public string PostCode { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public override string ToString()
        {
            return "Customer: " + Id + " " + "Name: " + Name;
        }
    }
}
