namespace PieShop.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int PieId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer{ get; set; }
    }
}
