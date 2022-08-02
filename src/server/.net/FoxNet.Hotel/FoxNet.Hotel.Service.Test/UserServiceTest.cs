using FoxNet.Hotel.Service;
using FoxNet.Hotel.BO;
using System;

namespace FoxNet.Hotel.Service.Test
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void AddUserTest()
        {
            var db = new DbStorage.DbStorage();
            var userService = new UserService(db);

            db.Database.EnsureCreated();

            userService.AddUser(new DTO.UserData() 
            { 
                Name = "Jan",
                Surname = "Kowalski",
                Birth = new DateTime(1920, 1, 14),
                AccountType = DTO.Type.Worker,
                Money = 700.89F,
                Password = "123",
                Phone = 123456689
            });

            var users = db.Users.ToList();

            Assert.AreEqual(1, users.Count);

            db.Database.EnsureDeleted();
            db.Dispose();
        }

        [TestMethod]
        public void GetUserTest() 
        {
            var db = new DbStorage.DbStorage();
            var userService = new UserService(db);

            db.Database.EnsureCreated();

            var user1 = userService.AddUser(new DTO.UserData() 
            { 
                Name = "Jan",
                Surname = "Kowalski",
                Birth = new DateTime(1920, 1, 14),
                AccountType = DTO.Type.Worker,
                Money = 700.89F,
                Password = "123",
                Phone = 123456689
            });

            var user = userService.GetUser(user1);

            Assert.AreEqual("Jan", user.Name);

            db.Database.EnsureDeleted();
            db.Dispose();
        }

        [TestMethod]
        public void GetUsersTest()
        {
            var db = new DbStorage.DbStorage();
            var userService = new UserService(db);

            db.Database.EnsureCreated();

            var user1 = userService.AddUser(new DTO.UserData()
            {
                Name = "Pat",
                Surname = "Czech",
                Birth = new DateTime(1999, 11, 19),
                AccountType = DTO.Type.Client,
                Money = 11.89F,
                Password = "412",
                Phone = 765456689
            });
            var user2 = userService.AddUser(new DTO.UserData()
            {
                Name = "Jan",
                Surname = "Kowalski",
                Birth = new DateTime(1920, 1, 14),
                AccountType = DTO.Type.Worker,
                Money = 700.89F,
                Password = "123",
                Phone = 123456689
            });

            db.SaveChanges();

            var users = userService.GetUsers();

            Assert.AreEqual(2, users.Count);

            db.Database.EnsureDeleted();
            db.Dispose();
        }

        [TestMethod]
        public void EditUserTest() 
        {
            var db = new DbStorage.DbStorage();
            var userService = new UserService(db);

            db.Database.EnsureCreated();

            var basicUser = userService.AddUser(new DTO.UserData()
            {
                Name = "Jan",
                Surname = "Kowalski",
                Password = "123",
            });

            db.SaveChanges();

            var user = userService.GetUser(basicUser);

            user.Name = "Marcel";
            userService.EditUser(user);

            db.SaveChanges();

            var editedUser = userService.GetUser(basicUser);

            Assert.AreEqual("Marcel", editedUser.Name);

            db.Database.EnsureDeleted();
            db.Dispose();
        }

        [TestMethod]
        public void ManageMoneyTest()
        {
            var db = new DbStorage.DbStorage();
            var userService = new UserService(db);

            var user = userService.AddUser(new DTO.UserData()
            {
                Name = "Pat",
                Surname = "Czech",
                Money = 11.89F,
            });
            db.SaveChanges();

            var user1 = userService.GetUser(user);

            Assert.AreEqual(11.89F, user1.Money);

            user1.Money += 30.48F;

            userService.ManageMoney(user1);

            db.SaveChanges();

            user1 = userService.GetUser(user);

            Assert.AreEqual(42.37F, user1.Money);

            db.Database.EnsureDeleted();
            db.Dispose();
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            var db = new DbStorage.DbStorage();
            var userService = new UserService(db);

            db.Database.EnsureCreated();

            var user1 = userService.AddUser(new DTO.UserData()
            {
                Name = "Pat",
                Surname = "Czech",
                Birth = new DateTime(1999, 11, 19),
                AccountType = DTO.Type.Client,
                Money = 11.89F,
                Password = "412",
                Phone = 765456689
            });
            var user2 = userService.AddUser(new DTO.UserData()
            {
                Name = "Jan",
                Surname = "Kowalski",
                Birth = new DateTime(1920, 1, 14),
                AccountType = DTO.Type.Worker,
                Money = 700.89F,
                Password = "123",
                Phone = 123456689
            });

            db.SaveChanges();

            var users = userService.GetUsers();
            
            Assert.AreEqual(2, users.Count);

            userService.DeleteUser(user1);
            db.SaveChanges();

            users = userService.GetUsers();

            Assert.AreEqual(1, users.Count);

            db.Database.EnsureDeleted();
            db.Dispose();
        }
    }
}