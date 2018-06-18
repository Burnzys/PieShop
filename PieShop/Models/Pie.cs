using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class Pie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        [Display(Name = "Description")]
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public Category Category { get; set; }

    }
}
