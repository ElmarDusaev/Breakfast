using System;
using System.ComponentModel.DataAnnotations;

namespace Breakfast.ViewModels
{
    public class OrderInformation
    {
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string ClientName { get; set; }
        [Required]
        [StringLength(250)]
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public DateTimeOffset DeliveryDateTime { get; set; }
    }
}