using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Models
{
    public class OrderHdr
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public string Phone { get; set; }
        [StringLength(50)]
        public string ClientName { get; set; }
        public double Sum { get; set; }
        public OrderHdrStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public ICollection<OrderDtl> OrderDtls { get; set; }

    }
}
