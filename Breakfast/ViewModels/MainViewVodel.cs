using Breakfast.Models;
using System.Collections.Generic;

namespace Breakfast.ViewModels
{
    class MainViewVodel
    {
        public List<Category> categories { get; set; }
        public List<ProductListViewModel> products { get; set; }
    }

    class ProductListViewModel
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