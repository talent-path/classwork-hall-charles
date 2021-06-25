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
        public int AddWatch(Watch watch)
        {
            return _watchRepo.AddWatch(watch);
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

        public void EditWatch(Watch watch)
        {
            _watchRepo.EditWatch(watch);
        }
    }
}
