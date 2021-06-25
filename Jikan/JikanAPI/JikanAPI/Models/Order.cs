using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Models
{
    public class Order
    {
        int Id { get; set; }
        [Required]
        decimal Total { get; set; }
        [Required]
        DateTime Date { get; set; }
        [Required]
        List<Watch> Items { get; set; }
        public Order(Order that)
        {
            Id = that.Id;
            Total = that.Total;
            Date = that.Date;
        }
    }
}
