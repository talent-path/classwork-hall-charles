using JikanAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Repos.Interfaces
{
    interface IOrderRepo
    {
        int AddOrder(Order toAdd);
        Order GetOrderById(int id);
        List<Order> GetAllOrders();
        void DeleteOrder(int id);
    }
}
