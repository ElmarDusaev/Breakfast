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
        [Display(Name="Наименование")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name="Рейтинг")]
        public double Stars { get; set; }
        [Display(Name="Цена")]
        public double Price { get; set; }
        public bool IsHit { get; set; }
        [StringLength(550)]
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Display(Name="Статус")]
        public ProductStatus Status { get; set; }
    }
}
