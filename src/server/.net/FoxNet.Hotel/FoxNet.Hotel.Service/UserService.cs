using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxNet.Hotel.BO;
using FoxNet.Hotel.Common;
using FoxNet.Hotel.Service.DTO;

namespace FoxNet.Hotel.Service
{
    public class UserService
    {
        private DbStorage db;

        public UserService(DbStorage db)
        {
            this.db = db;
        }

        public int AddUser(UserData userData)
        {
            var u = new User()
            {
                Name = userData.Name,
                Surname = userData.Surname,
                Birth = userData.Birth,
                Phone = userData.Phone,
                Email = userData.Email,
                AccountType = (Type)userData.AccountType,
                Password = userData.Password,
                Money = userData.Money,
            };

            var userId = db.Users.Add(u);
            db.SaveChanges();

            return userId.Entity.Id;
        }

        public void EditUser(UserData userData)
        {
            var user = db.Users.Single(u => u.Id == userData.Id);

            user.Name = userData.Name;
            user.Surname = userData.Surname;
            user.Password = userData.Password;
            user.Phone = userData.Phone;
            user.Email = userData.Email;

            db.SaveChanges();
        }

        public UserData GetUser(int userId)
        {
            var user = db.Users.Single(u => u.Id == userId);

            return new UserData()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Birth = user.Birth,
                Phone = user.Phone,
                Email = user.Email,
                AccountType = (DTO.Type)user.AccountType,
                Password = user.Password,
                Money = user.Money
            };
        }

        public IList<UserData> GetUsers() 
        {
            return db.Users.Select(u => new UserData()
            {
                Id = u.Id,
                Name = u.Name,
                Surname = u.Surname,
                Birth = u.Birth,
                AccountType = (DTO.Type)u.AccountType,
                Password = u.Password,
                Money = u.Money,
                Phone = u.Phone
            }).ToList();
        }

        public void ManageMoney(UserData userData) 
        {
            var user = db.Users.SingleOrDefault(u => u.Id == userData.Id);

            if (user != null)
            {
                user.Money = userData.Money;
                db.SaveChanges();
            }
        }

        public void DeleteUser(int userId) 
        {
            var user = db.Users.Single(u => u.Id == userId);

            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}