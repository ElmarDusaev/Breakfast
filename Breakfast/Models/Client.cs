using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Breakfast.Models
{
    public class Client
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string ClientToken { get; set; }
        public ICollection<OrderHdr> Orders { get; set; }
    }
}