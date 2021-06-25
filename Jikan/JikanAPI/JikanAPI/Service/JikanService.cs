using JikanAPI.Controllers;
using JikanAPI.Models;
using JikanAPI.Repos;
using System;
using System.Collections.Generic;

namespace JikanAPI.Service
{
    public class JikanService
    {
        WatchRepo _watchRepo;
        OrderRepo _orderRepo;
        public JikanService(JikanDbContext context)
        {
            _watchRepo = new WatchRepo(context);
            _orderRepo = new OrderRepo(context);
        }
        public int AddWatch(Watch toAdd)
        {
            return _watchRepo.AddWatch(toAdd);
        }

        public Watch GetWatchById(int id)
        {
            return _watchRepo.GetWatchById(id);
        }

        public Watch GetWatchByName(string name)
        {
            return _watchRepo.GetWatchByName(name);
        }

        public List<Watch> GetAllWatches()
        {
            return _watchRepo.GetAllWatches();
        }

        public List<Watch> GetWatchesByType(string type)
        {
            return _watchRepo.GetWatchesByType(type);
        }

        public List<Watch> GetWatchesByPrice(decimal min, decimal max)
        {
            return _watchRepo.GetWatchesByPrice(min, max);
        }

        public void EditWatch(Watch toEdit)
        {
            _watchRepo.EditWatch(toEdit);
        }

        public void DeleteWatch(int id)
        {
            _watchRepo.DeleteWatch(id);
        }

        public int AddOrder(Order toAdd)
        {
           return _orderRepo.AddOrder(toAdd);
        }

        public Order GetOrderById(int id)
        {
            return _orderRepo.GetOrderById(id);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepo.GetAllOrders();
        }

        public void DeleteOrder(int id)
        {
            _orderRepo.DeleteOrder(id);
        }

    }
}
