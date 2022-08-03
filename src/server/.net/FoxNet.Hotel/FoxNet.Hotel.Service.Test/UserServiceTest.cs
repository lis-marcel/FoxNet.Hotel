using FoxNet.Hotel.Service;
using FoxNet.Hotel.BO;
using System;
using FoxNet.Hotel.Common;

namespace FoxNet.Hotel.Service.Test
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void AddUserTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var userService = new UserService(db);

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
            }
        }

        [TestMethod]
        public void GetUserTest() 
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var userService = new UserService(db);

                var user = userService.AddUser(new DTO.UserData()
                {
                    Name = "Jan",
                    Surname = "Kowalski",
                    Birth = new DateTime(1920, 1, 14),
                    AccountType = DTO.Type.Worker,
                    Money = 700.89F,
                    Password = "123",
                    Phone = 123456689
                });

                var foundUser = userService.GetUser(user);

                Assert.AreEqual("Jan", foundUser.Name);
            }
        }

        [TestMethod]
        public void GetUsersTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var userService = new UserService(db);

                db.Database.EnsureCreated();

                // Adding diffrent users
                userService.AddUser(new DTO.UserData()
                {
                    Name = "Pat",
                    Surname = "Czech",
                    Birth = new DateTime(1999, 11, 19),
                    AccountType = DTO.Type.Client,
                    Money = 11.89F,
                    Password = "412",
                    Phone = 765456689
                });
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

                db.SaveChanges();

                var users = userService.GetUsers();

                Assert.AreEqual(2, users.Count);
            }
        }

        [TestMethod]
        public void EditUserTest() 
        {
            using (var db = DbStorage.GetTestInstance())
            {
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
            }
        }

        [TestMethod]
        public void ManageMoneyTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
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
            }
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
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
            }
        }
    }
}