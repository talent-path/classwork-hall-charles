﻿using JikanAPI.Models;
using JikanAPI.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private JikanDbContext _context;

        public OrderRepo(JikanDbContext context)
        {
            _context = context;
        }

        public int AddOrder(Order toAdd)
        {
            _context.Orders.Add(toAdd);
            _context.SaveChanges();

            foreach (OrderDetail od in toAdd.OrderDetails)
            {
                od.OrderId = toAdd.Id;
                _context.OrderDetails.Add(od);
            }

            return toAdd.Id;
        }
        public Order GetOrderById(int id)
        {
            Order toReturn = _context.Orders.Find(id);
            toReturn.OrderDetails = _context.OrderDetails.Where(od => od.OrderId == id).ToList();

            return toReturn;
        }
        public List<Order> GetAllOrders()
        {
            List<Order> toReturn = _context.Orders.ToList();
            foreach(Order o in toReturn)
            {
                o.OrderDetails = _context.OrderDetails.Where(od => od.OrderId == o.Id).ToList();
            }

            return toReturn;
        }

        public void DeleteOrder(int id)
        {
            Order toDelete = _context.Orders.Find(id);
            _context.Attach(toDelete);
            _context.Remove(toDelete);
            _context.SaveChanges();
        }

        public List<Order> GetOrdersByUserId(int curUserId)
        {
            return _context.Orders.Where(o => o.Purchaser.Id == curUserId).ToList();
        }
    }
}
