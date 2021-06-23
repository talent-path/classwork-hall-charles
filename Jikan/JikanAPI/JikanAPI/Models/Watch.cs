using System;
namespace JikanAPI.Models
{
    public class Watch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
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
