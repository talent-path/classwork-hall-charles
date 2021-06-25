using System;
using System.ComponentModel.DataAnnotations;

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
        public decimal Price { get; set; }
        public Watch(Watch that)
        {
            Id = that.Id;
            Name = that.Name;
            Type = that.Type;
            Price = that.Price;
        }
    }
}
