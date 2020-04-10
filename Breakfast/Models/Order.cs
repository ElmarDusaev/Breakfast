namespace Breakfast.Models
{
    public abstract class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Qty { get; set; } = 1;
        public double Price { get; set; }

    }

}
