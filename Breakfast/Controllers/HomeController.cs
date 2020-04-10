using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Breakfast.Models;
using Breakfast.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Breakfast.Controllers
{
    public class HomeController : Controller
    {

        BreakfastDbContext context;

        public HomeController(BreakfastDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {


            return View();
        }
    }
}