using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Models
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Stars { get; set; }
        public double Price { get; set; }
        public bool IsHit { get; set; }
        [StringLength(150)]
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ProductStatus Status { get; set; }
    }
}
