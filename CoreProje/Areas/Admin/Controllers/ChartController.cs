using CoreProje.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryname = "deneme",
                categorycount = 10
            });
            list.Add(new CategoryClass
            {
                categoryname = "deneme2",
                categorycount = 5
            });
            list.Add(new CategoryClass
            {
                categoryname = "gkhan",
                categorycount = 9
            });
            return Json(new { jsonlist = list });
        }
    }
}
