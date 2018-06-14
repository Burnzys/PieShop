using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class PieService : IPieRepository
    {
        private List<Pie> _pies;

        public PieService()
        {
            if (_pies == null)
            {
                InitializePies();
            }
        }

        private void InitializePies()
        {
            _pies = new List<Pie>
            {
                new Pie{Id = 1, Name = "Apple Pie", Price = 7.99M, ShortDescription = "Granma's Apple Pie", LongDescription = "Spicy jalapeno bacon ipsum dolor amet cow nisi esse, jerky tri-tip consequat irure do duis consectetur voluptate capicola brisket. Deserunt chicken jerky dolore commodo. Cow non pariatur shankle. Venison id sed, in pancetta kevin anim tenderloin culpa boudin occaecat spare ribs. Mollit aute drumstick landjaeger in aliqua kevin dolore reprehenderit pastrami alcatra fugiat enim.", ImageUrl = "", ThumbnailUrl = "apple-pie.jpg", IsPieOfTheWeek = false},
                new Pie{Id = 2, Name = "Toffee Cheese Cake", Price = 10.99M, ShortDescription = "Sweet and tasty ", LongDescription = "Spicy jalapeno bacon ipsum dolor amet laborum sirloin beef ribs, voluptate minim doner strip steak turducken est reprehenderit mollit veniam. In burgdoggen sed ut aliqua occaecat nostrud eu ut short ribs. Pork belly jerky velit non. Picanha labore flank deserunt leberkas burgdoggen chuck. Bresaola tempor ribeye veniam.", ImageUrl = "", ThumbnailUrl = "toffee-cheesecake.jpg", IsPieOfTheWeek = true},
                new Pie{Id = 3, Name = "Blueberry Crumble", Price = 5.99M, ShortDescription = "A classic taste", LongDescription = "Spicy jalapeno bacon ipsum dolor amet cupim duis beef corned beef. Ullamco magna cillum, dolore pork loin leberkas hamburger chicken sint et proident eiusmod aute voluptate. Rump ipsum in adipisicing esse bacon ut occaecat nulla biltong shoulder beef cow ex. Officia proident non kevin nisi brisket drumstick short ribs incididunt est doner.", ImageUrl = "", ThumbnailUrl = "blueberry-pie.jpg", IsPieOfTheWeek = false},
                new Pie{Id = 4, Name = "Red Velvet Muffins", Price = 5.99M, ShortDescription = "A great combination", LongDescription = "Spicy jalapeno bacon ipsum dolor amet magna incididunt strip steak shoulder ground round prosciutto pariatur ham hock fatback. Irure do laborum, strip steak non rump nisi eu jerky consectetur proident reprehenderit flank bresaola. Ball tip irure quis brisket. Cow in sausage tri-tip, sunt eiusmod non officia jerky tempor short loin filet mignon meatloaf laboris.", ImageUrl = "", ThumbnailUrl = "red-velvet.jpg", IsPieOfTheWeek = true},
                new Pie{Id = 5, Name = "Cherry Pie", Price = 8.50M, ShortDescription = "Mmmm nice", LongDescription = "Spicy jalapeno bacon ipsum dolor amet kevin excepteur frankfurter id doner ullamco sed non commodo pariatur swine aute. Non tongue eiusmod est. Corned beef kielbasa mollit shank, commodo lorem turkey veniam tail occaecat ad magna flank exercitation culpa. Pork loin nostrud sed, quis ham hock spare ribs kielbasa beef ribs picanha strip steak ut.", ImageUrl = "", ThumbnailUrl = "cherry-pie.jpg", IsPieOfTheWeek = false}
            };
        }

        public IEnumerable<Pie> GetAllPies()
        {
            return _pies;
        }

        public Pie GetPieById(int Id)
        {
            return _pies.FirstOrDefault(p => p.Id == Id);
        }
    }
}
