using JikanAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Repos
{
    public class DBWatchRepo : IWatchRepo
    {
        public void EditWatch()
        {
            throw new NotImplementedException();
        }

        public List<Watch> GetAllWatches()
        {
            throw new NotImplementedException();
        }

        public Watch GetWatchById(int value)
        {
            throw new NotImplementedException();
        }

        public Watch GetWatchByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Watch> GetWatchesByPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public List<Watch> GetWatchesByType(string type)
        {
            throw new NotImplementedException();
        }
    }
}
