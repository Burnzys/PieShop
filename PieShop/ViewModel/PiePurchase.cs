using PieShop.Models;

namespace PieShop.ViewModel
{
    public class PiePurchase
    {
        /*
         This classed is used to bring together two models,
         it is just for a View only it will allow the user to view the data only.
         The class can contain single object references or list of
         referenced objects
             */
        public Pie Pie { get; set; }
        public Customer Customer { get; set; }
    }
}
