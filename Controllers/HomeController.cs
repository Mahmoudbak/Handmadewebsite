﻿using Microsoft.AspNetCore.Mvc;
using Handmade.Models;
using System.Collections.Generic;
using System.Linq;
using Handmade.ViewModel;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly DataDbContext _context;

    public HomeController(DataDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        List<Product> Products = _context.Products.ToList();
   
        foreach (var product in Products) 
        {
            _context.Products.Include(p => p.User).ToList();
            product.Name = product.Name ?? "No Name Available";
            product.Description = product.Description ?? "No Description Available";
            product.ImageUrl = product.ImageUrl ?? "/images/default.jpg"; // صورة افتراضية إذا كانت الصورة null
        }

return View(Products);
    }

    public IActionResult Details(int id)//5
    {
        var product = _context.Products.FirstOrDefault(p => p.ID == id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

}