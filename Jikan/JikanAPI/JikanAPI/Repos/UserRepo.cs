using JikanAPI.Models.Auth;
using JikanAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Repos
{
    public class UserRepo : IUserRepo
    {
        private JikanDbContext _context;

        public UserRepo(JikanDbContext context)
        {
            _context = context;
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public Role GetRoleByName(string role)
        {
            Role toReturn = _context.Roles.SingleOrDefault(r => r.Name.ToLower() == role.ToLower());
            return toReturn;
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public int AddUser(User toAdd)
        {
            _context.Users.Add(toAdd);
            _context.SaveChanges();
            return toAdd.Id;
        }

        public User GetUserByUsername(string username)
        {
            User toReturn = _context.Users
                .Include("UserRoles.SelectedRole")
                .SingleOrDefault(
                u => u.Username.ToLower() == username.ToLower()
                );
            return toReturn;
        }
    }
}
