using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.ViewModels
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
    }
}
