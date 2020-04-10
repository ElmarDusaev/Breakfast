namespace Breakfast.ViewModels
{
    class MainViewVodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Stars { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public int InBasket { get; set; }
    }
}