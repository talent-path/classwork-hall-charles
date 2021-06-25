using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JikanAPI.Models
{
    public class Watch
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public Watch(int id, string name, string type, decimal price, string imageUrl)
        {
            Id = id;
            Name = name;
            Type = type;
            Price = price;
            ImageUrl = imageUrl;
        }
    }
}
