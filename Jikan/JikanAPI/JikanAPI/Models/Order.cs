﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Total { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string City { get; set; }


        public List<OrderDetail> OrderDetails { get; set; }
    }
}
