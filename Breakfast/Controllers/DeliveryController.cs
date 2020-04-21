using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Controllers
{
    public class DeliveryController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
