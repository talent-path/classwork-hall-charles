﻿using JikanAPI.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Repos.Interfaces
{
    public interface IUserRepo
    {
        List<User> GetAllUsers();

        User GetUserById(int id);
        Role GetRoleByName(string role);

        User GetUserByUsername(string username);

    }
}
