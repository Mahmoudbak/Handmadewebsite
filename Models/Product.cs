using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Handmade.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Handmade.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(70)]
        [MinLength(10)]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        [MaxLength(200)]
        [MinLength(10)]
        public string Description { get; set; }
        [Required]


        public int User_ID { get; set; }
        public int Category_ID { get; set; }

        public decimal Price { get;  set; }
        public string ImageUrl { get;  set; }

        public Category Category { get; set; }
        public User User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public int? SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier? Supplier { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }

}
