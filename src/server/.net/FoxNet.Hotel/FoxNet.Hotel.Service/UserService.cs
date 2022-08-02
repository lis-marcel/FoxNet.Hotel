using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxNet.Hotel.BO;
using FoxNet.Hotel.Service.DTO;

namespace FoxNet.Hotel.Service
{
    public class UserService
    {
        public UserService()
        {
        }

        public UserService(DbStorage.DbStorage db)
        {
        }

        public int AddUser(UserData userData)
        {
            var u = new User() { Name = userData.Name,
                Surname = userData.Surname,
                Birth = userData.Birth,
                AccountType = (Type)userData.AccountType,
                Password = userData.Password,
                Money = userData.Money,
                Phone = userData.Phone 
            };

            var db = new DbStorage.DbStorage();

            db.Database.EnsureCreated();
            var userId = db.Users.Add(u);
            db.SaveChanges();

            db.Dispose();

            return userId.Entity.Id;
        }

        public UserData GetUser(int userId)
        {
            var db = new DbStorage.DbStorage();
            var user = db.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                var u = new UserData()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname= user.Surname,
                    Birth = user.Birth,
                    Phone = user.Phone,
                    AccountType = (DTO.Type)user.AccountType,
                    Password = user.Password,
                    Money= user.Money
                };

                db.Dispose();
                return u;
            }

            else
            {
                db.Dispose();
                return null;
            }
        }

        public IList<UserData> GetUsers() 
        {
            var db = new DbStorage.DbStorage();
            var users = new List<UserData>();

            foreach (var u in db.Users) 
            {
                var user = new UserData() { 
                    Id = u.Id,
                    Name = u.Name,
                    Surname = u.Surname,
                    Birth = u.Birth,
                    AccountType = (DTO.Type)u.AccountType,
                    Password = u.Password,
                    Money = u.Money,
                    Phone = u.Phone
                };

                users.Add(user);
            }

            return users;
        }

        public void EditUser(UserData userData)
        {
            var db = new DbStorage.DbStorage();
            var user = db.Users.SingleOrDefault(u => u.Id == userData.Id);

            if (user != null)
            {
                user.Name = userData.Name;
                user.Surname = userData.Surname;
                user.Password = userData.Password;

                db.SaveChanges();
            }

            else db.SaveChanges();

            db.Dispose();
        }

        public void ManageMoney(UserData userData) 
        { 
            var db = new DbStorage.DbStorage();
            var user = db.Users.SingleOrDefault(u => u.Id == userData.Id);

            if (user != null)
            {
                user.Money = userData.Money;

                db.SaveChanges();
            }

            else db.SaveChanges();

            db.Dispose();
        }

        public void DeleteUser(int userId) 
        {
            var db = new DbStorage.DbStorage();
            var user = db.Users.Single(u => u.Id == userId);

            if (user != null) 
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }

            else db.SaveChanges();

            db.Dispose();
        }
    }
}