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
        [Required(ErrorMessage = "Заполните поле Наименование")]
        public string Name { get; set; }
        [Display(Name="Комментариии")]
        public string Description { get; set; }
        [Display(Name="Рейтинг")]
        [Range(1, 5)]
        [Required(ErrorMessage = "Заполните поле Рейтинг")]
        public double Stars { get; set; }
        [Display(Name="Цена")]
        [Range(1, 100000)]
        [Required(ErrorMessage = "Заполните поле Цена")]
        public double Price { get; set; }
        public bool IsHit { get; set; }
        [StringLength(550)]
        [Display(Name="Изображение (URL)")]
        [Required(ErrorMessage = "Заполните поле Изображение")]
        public string Image { get; set; }
        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Укажите категорию")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Display(Name = "Статус")]
        [Required(ErrorMessage = "Укажите статус")]
        public ProductStatus Status { get; set; }
    }
}
