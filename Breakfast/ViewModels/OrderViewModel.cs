using Breakfast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.ViewModels
{
    public class OrderViewModel
    {
        public string Date { get; set; }
        public IEnumerable<OrderHdr> OrderHdrs { get; set; }
    }

    

}
