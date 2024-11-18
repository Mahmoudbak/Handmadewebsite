﻿using Handmade.ViewModel;
using Handmade.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Handmade.Controllers
{
    public class CategorieController : Controller
    {
        private readonly DataDbContext _context;

        public CategorieController(DataDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult categorie(int id)
        {
            var categories = _context.Categories.ToList();


            List<Product> products = new List<Product>();
            if (id != null)
            {
                products = _context.Products.Where(p => p.Category_ID == id).ToList();
            }

            var model = new CategorieAndProductViewmodel
            {
                Categories = categories,
                Products = products,
                SelectedCategoryID = id
            };

            return View(model);
        }

        // ADD
        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }
        public IActionResult Addcategory(Category category)
        {
            if (category.Name != null)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("listcategore", "Dashboard");
            }
            return View("Add", category);
        }

        public IActionResult Edit(int id)
        {
            Category category = _context.Categories.FirstOrDefault(d => d.ID == id);
            return View("Edit", category);
        }
       
        public IActionResult Editca(int id, Category catfromrequist)
        {
            if (catfromrequist.Name != null)
            {
                Category categorfromdb = _context.Categories.FirstOrDefault(d => d.ID == id);
                categorfromdb.Name = catfromrequist.Name;
                categorfromdb.Description = catfromrequist.Description;
                _context.SaveChanges();
                return RedirectToAction("listcategore", "Dashboard");
            }
            return View("Edit", catfromrequist);
        }
        public IActionResult Delete(int id)
        {
            Category category =_context.Categories.FirstOrDefault(d => d.ID == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("listcategore", "Dashboard");
        }
        public IActionResult viewcate()
        {
            var cat=_context.Categories.Include(_c => _c.Products).ToList();
            return View(cat);
        }
        public IActionResult ProductsByCategory(int id)
        {
            var category = _context.Categories.Include(c => c.Products)
                                              .FirstOrDefault(c => c.ID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category.Products); // Assuming 'Products' is the collection of products
        }
    }
}
