using JikanAPI.Controllers;
using JikanAPI.Exceptions;
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
            if (toAdd == null)
                throw new ArgumentNullException("Cannot create a null watch.");
            if (toAdd.Name == null)
                throw new ArgumentNullException("Cannot create a watch with a null name.");
            if (toAdd.Name == "" || toAdd.Name.Length > 50 || toAdd.Name.Trim().Length == 0)
                throw new InvalidNameException("Invalid name, cannot be empty, white spaces, or too long.");

            return _watchRepo.AddWatch(toAdd);
        }

        public Watch GetWatchById(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Invalid Id, cannot be <= 0.");

            return _watchRepo.GetWatchById(id);
        }

        public Watch GetWatchByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException("Cannot search by null name.");
            if (name == "" || name.Length > 50 || name.Trim().Length == 0)
                throw new InvalidNameException("Invalid name, cannot be empty, white spaces, or too long.");
            
            return _watchRepo.GetWatchByName(name);
        }

        public List<Watch> GetAllWatches()
        {
            return _watchRepo.GetAllWatches();
        }

        public List<Watch> GetWatchesByType(string type)
        {
            if (type == null)
                throw new ArgumentNullException("Cannot search by null type.");
            if (type == "" || type.Length > 50 || type.Trim().Length == 0)
                throw new InvalidNameException("Invalid type, cannot be empty, white spaces, or too long.");

            return _watchRepo.GetWatchesByType(type);
        }

        public List<Watch> GetWatchesByPrice(decimal max)
        {
            return _watchRepo.GetWatchesByPrice(max);
        }

        public void EditWatch(Watch toEdit)
        {
            if (toEdit == null)
                throw new ArgumentNullException("Cannot edit a null watch.");

            _watchRepo.EditWatch(toEdit);
        }

        public void DeleteWatch(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Invalid Id, cannot be <= 0.");

            _watchRepo.DeleteWatch(id);
        }

        public int AddOrder(Order toAdd)
        {
            if (toAdd == null)
                throw new ArgumentNullException("Cannot add a null order.");
            foreach(OrderDetail od in toAdd.OrderDetails)
            {
                if (od.WatchId <= 0)
                    throw new InvalidIdException("Invalid Id, cannot be <= 0.");
                if (od.Quantity <= 0)
                    throw new InvalidQuantityException("Invalid quantity, cannot be <= 0.");
            }

           return _orderRepo.AddOrder(toAdd);
        }

        public Order GetOrderById(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Invalid Id, cannot be <= 0.");

            return _orderRepo.GetOrderById(id);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepo.GetAllOrders();
        }

        public void DeleteOrder(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Invalid Id, cannot be <= 0.");

            _orderRepo.DeleteOrder(id);
        }

    }
}
