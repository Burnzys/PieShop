using PieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.ViewModel
{
    public class PiePurchase
    {
        /*
         This classed is used to bring together two models,
         it is just for a view allow the user to view the data only.
         The class can contain single object references or list of
         referenced objects
             */
        public Pie Pie { get; set; }
        public Customer Customer { get; set; }
    }
}
