﻿using Microsoft.EntityFrameworkCore;
namespace Handmade.Models
{
    public class Category
    {
        public int ID { get; set; } // Primary Key
        public string Name { get; set; }
        public string Description { get; set; }
        public string CateImage { get; set; }

        // Navigation properties
        public ICollection<Product> Products { get; set; }
    }

}
