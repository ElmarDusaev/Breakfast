using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.ViewModels
{
    public class DashboardViewModel
    {
        public int OrdersTotal { get; set; }
        public int OrdersToday { get; set; }
        public int RejectedTotal { get; set; }
        public int RejectedToday { get; set; }
        public int CompleteTotal { get; set; }
        public int CompleteToday { get; set; }
        public int DeliveryTotal { get; set; }
        public int DeliveryToday { get; set; }
    }
}
