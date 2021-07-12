using JikanAPI.Exceptions;
using JikanAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Repos
{
    public class WatchRepo : IWatchRepo
    {
        private JikanDbContext _context;

        public WatchRepo(JikanDbContext context)
        {
            _context = context;
        }

        public int AddWatch(Watch toAdd)
        {
            _context.Watches.Add(toAdd);
            _context.SaveChanges();
            return toAdd.Id;
        }

        public List<Watch> GetAllWatches()
        {
            return _context.Watches.ToList();
        }

        public Watch GetWatchById(int id)
        {
            Watch toReturn = _context.Watches.Find(id);

            if (toReturn == null)
                throw new WatchNotFoundException("Could not find watch with that Id.");

            return toReturn;
        }

        public Watch GetWatchByName(string name)
        {
            Watch toReturn = _context.Watches.Where(w => w.Name == name).SingleOrDefault();
            return toReturn;
        }

        public List<Watch> GetWatchesByType(string type)
        {
            List<Watch> toReturn = _context.Watches.Where(w => w.Type == type).ToList();
            return toReturn;
        }

        public List<Watch> GetWatchesByOrderId(int id)
        {
            List<OrderDetail> ordersList = _context.OrderDetails.Where(od => od.OrderId == id).ToList();
            List<Watch> toReturn = new List<Watch>();
            foreach(OrderDetail od in ordersList)
            {
                Watch toAdd = _context.Watches.Find(od.WatchId);
                toReturn.Add(toAdd);
            }

            return toReturn;
        }

        public List<Watch> GetWatchesByPrice(decimal max)
        {
            List<Watch> toReturn = _context.Watches.Where(w => w.Price <= max).ToList();
            return toReturn;
        }

        public void EditWatch(Watch toEdit)
        {
            _context.Attach(toEdit);
            _context.Entry(toEdit).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteWatch(int id)
        {
            Watch toDelete = _context.Watches.Find(id);

            if (toDelete == null)
                throw new WatchNotFoundException("Could not find watch with that Id.");

            _context.Attach(toDelete);
            _context.Remove(toDelete);
            _context.SaveChanges();
        }

        public List<int> GetWatchQuantityByOrderId(int id)
        {
            List<OrderDetail> ordersList = _context.OrderDetails.Where(od => od.OrderId == id).ToList();
            List<int> toReturn = new List<int>();
            foreach (OrderDetail od in ordersList)
            {
                int toAdd = od.Quantity;
                toReturn.Add(toAdd);
            }

            return toReturn;
        }
    }
}
