using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Breakfast.Models;
using Microsoft.AspNetCore.Mvc;

namespace Breakfast.Controllers
{
    public class CategoryController : Controller
    {

        BreakfastDbContext context;

        public CategoryController(BreakfastDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            context.Entry<Category>(category).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();

            var category = context.Categories.FirstOrDefault(a => a.Id == id);

            if (category == null) return NotFound();


            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            context.Entry<Category>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

    }
}