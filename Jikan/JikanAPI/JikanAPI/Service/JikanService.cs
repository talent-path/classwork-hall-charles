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
        public Watch GetWatchById(int value)
        {
            throw new NotImplementedException();
        }

        public Watch GetWatchByName(string name)
        {
            throw new NotImplementedException();
        }

        internal void AddWatch(WatchController watch)
        {
            throw new NotImplementedException();
        }

        public List<Watch> GetAllWatches()
        {
            throw new NotImplementedException();
        }

        public List<Watch> GetWatchesByType(string type)
        {
            throw new NotImplementedException();
        }

        public List<Watch> GetWatchesByPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public void EditWatch()
        {
            throw new NotImplementedException();
        }
    }
}
