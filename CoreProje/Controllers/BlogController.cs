using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProje.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GelBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var values=bm.GetListWithCategoryByWriterBm(1);
            return View(values);
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.GetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }



        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryvalue = (from x in cm.GetList() select new SelectListItem { Text =x.CategoryName,Value=x.CategoryID.ToString()}).ToList();
            ViewBag.cv = categoryvalue;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {

            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = 1;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(); ;
        }


        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogValue = bm.GetById(id);
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryvalue = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.cv = categoryvalue;
            return View(blogValue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            p.WriterID = 1;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);

            return RedirectToAction("BlogListByWriter");
        }


    }
}
