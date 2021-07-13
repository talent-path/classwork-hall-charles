using JikanAPI.Exceptions;
using JikanAPI.Models;
using JikanAPI.Models.Auth;
using JikanAPI.Models.ViewModels.Requests;
using JikanAPI.Repos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JikanAPI.Service
{
    public class JikanService
    {
        WatchRepo _watchRepo;
        OrderRepo _orderRepo;
        UserRepo _userRepo;
        public JikanService(JikanDbContext context)
        {
            _watchRepo = new WatchRepo(context);
            _orderRepo = new OrderRepo(context);
            _userRepo = new UserRepo(context);
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

        public string Login(LoginViewModel vm)
        {
            User curUser = _userRepo.GetUserByUsername(vm.Username);
            bool valid = ValidatePassword(vm.Password, curUser.PasswordSalt, curUser.PasswordHash);
            if (!valid)
            {
                throw new InvalidPasswordException("Invalid Password");
            }
            string token = GenerateToken(curUser);

            return token;
        }

        private string GenerateToken(User curUser)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    curUser.UserRoles.Select(r => new Claim(ClaimTypes.Role, r.SelectedRole.Name))
                    .Append(new Claim(ClaimTypes.NameIdentifier, curUser.Id.ToString()))
                ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(descriptor);
            string tokenStr = tokenHandler.WriteToken(token);

            return tokenStr;
        }

        public User GetUserById(int id)
        {
            return _userRepo.GetUserById(id);
        }

        private bool ValidatePassword(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hMac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                byte[] hashedPass = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < hashedPass.Length; i++)
                {
                    if(hashedPass[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public void RegisterUser(RegisterUserViewModel vm)
        {
            User prevUsed = _userRepo.GetUserByUsername(vm.Username);

            if (prevUsed != null)
                throw new InvalidUsernameException("Username already taken."); 

            Role basicRole = _userRepo.GetRoleByName("user");
            UserRole bridgeRow = new UserRole();
            bridgeRow.RoleId = basicRole.Id;
            bridgeRow.SelectedRole = basicRole;

            User toAdd = new User();
            bridgeRow.EnrolledUser = toAdd;
            toAdd.UserRoles.Add(bridgeRow);
            toAdd.Email = vm.Email;
            toAdd.Name = vm.Name;
            toAdd.Username = vm.Username;

            using (var hMac = new System.Security.Cryptography.HMACSHA512())
            {
                byte[] saltBytes = hMac.Key;
                byte[] hash = hMac.ComputeHash(Encoding.UTF8.GetBytes(vm.Password));
                toAdd.PasswordSalt = saltBytes;
                toAdd.PasswordHash = hash;
            }

            _userRepo.AddUser(toAdd);
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
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

        public List<int> GetWatchQuantityByOrderId(int id)
        {
            return _watchRepo.GetWatchQuantityByOrderId(id);
        }

        public List<Watch> GetWatchesByOrderId(int id)
        {
            return _watchRepo.GetWatchesByOrderId(id);
        }

        public Dictionary<Watch, int> GetWatchQuantityPair(int id)
        {
            List<Watch> watches = GetWatchesByOrderId(id);
            List<int> quantities = GetWatchQuantityByOrderId(id);
            Dictionary<Watch, int> toReturn = new Dictionary<Watch, int>();

            for(int i = 0; i < watches.Count; i++)
            {
                if(!toReturn.ContainsKey(watches[i]))
                {
                    toReturn.Add(watches[i], quantities[i]);
                }
            }

            return toReturn;

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
