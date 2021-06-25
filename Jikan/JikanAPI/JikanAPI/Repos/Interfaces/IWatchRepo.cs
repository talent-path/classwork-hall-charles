﻿using JikanAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Repos
{
    interface IWatchRepo
    {
        int AddWatch(Watch watch);
        Watch GetWatchById(int value);
        Watch GetWatchByName(string name);
        List<Watch> GetAllWatches();
        List<Watch> GetWatchesByType(string type);
        List<Watch> GetWatchesByPrice(decimal min, decimal max);
        void EditWatch(Watch watch);
        void DeleteWatch(int id);
    }
}
