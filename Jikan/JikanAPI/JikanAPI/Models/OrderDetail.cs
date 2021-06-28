using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Models
{
    [Keyless]
    public class OrderDetail
    {
        [Required]
        public Order Order { get; set; }
        [Required]
        public Watch Watch { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
