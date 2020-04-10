using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Models
{
    public class OrderBasket: Order
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }

}
