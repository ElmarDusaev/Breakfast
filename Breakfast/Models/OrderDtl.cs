using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Models
{
    public class OrderDtl:Order
    {
        public int? OrderHdrId { get; set; }
        public OrderHdr OrderHdr { get; set; }
        public OrderDtlStatus Status { get; set; }
    }

}
