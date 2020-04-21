using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.ViewModels
{
    public class PrintInvoceViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string ClientName { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public double Sum { get; set; }
        public List<ProductInfoViewModel> Products { get; set; }
    }

    public class ProductInfoViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
    }

}
