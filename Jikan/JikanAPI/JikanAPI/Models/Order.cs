using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Models
{
    public class Order
    {
        int Id { get; set; }
        decimal Total { get; set; }
        DateTime Date { get; set; }
        public Order(Order that)
        {
            Id = that.Id;
            Total = that.Total;
            Date = that.Date;
        }
    }
}
