using JikanAPI.Models;
using JikanAPI.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private JikanDbContext context;

        public OrderRepo(JikanDbContext context)
        {
            this.context = context;
        }

        public int AddOrder(Order toAdd)
        {
            throw new NotImplementedException();
        }
        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }
        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

    }
}
