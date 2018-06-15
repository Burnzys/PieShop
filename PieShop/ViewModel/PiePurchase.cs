using PieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.ViewModel
{
    public class PiePurchase
    {
        public Pie Pie { get; set; }
        public Customer Customer { get; set; }
    }
}
