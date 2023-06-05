using FoxNet.Hotel.Service;
using FoxNet.Hotel.BO;
using System;
using FoxNet.Hotel.Common;
using FoxNet.Hotel.Service.DTO;

namespace FoxNet.Hotel.Service.Test
{
    [TestClass]
    public class UserServiceTest
    {
        #region Test objects
        UserData testUserObject1 = new UserData()
        {
            UserName = "Jan",
            UserSurname = "Kowalski",
            Birth = new DateOnly(1920, 1, 14),
            AccountType = DTO.Type.Worker,
            Password = "123",
            Phone = "123456689"
        };

        UserData testUserObject2 = new UserData()
        {
            UserName = "Pat",
            UserSurname = "Czech",
            Birth = new DateOnly(1999, 11, 19),
            AccountType = DTO.Type.Client,
            Password = "412",
            Phone = "765456689"
        };

        #endregion

        #region Test methods
        [TestMethod]
        public void AddUserTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var userService = new UserService(db);

                userService.AddUser(testUserObject1);

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

                var user = userService.AddUser(testUserObject1);

                var foundUser = userService.GetUser(user);

                Assert.AreEqual("Jan", foundUser.UserName);
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
                userService.AddUser(testUserObject1);
                userService.AddUser(testUserObject2);

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

                var basicUser = userService.AddUser(testUserObject1);
                var user = userService.GetUser(basicUser);

                user.UserName = "Marcel";
                var userId = userService.EditUser(user);

                var editedUser = userService.GetUser(userId);

                Assert.AreEqual("Marcel", editedUser.UserName);
            }
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var userService = new UserService(db);

                db.Database.EnsureCreated();

                var userId1 = userService.AddUser(testUserObject1);
                var userId2 = userService.AddUser(testUserObject2);

                var users = userService.GetUsers();

                Assert.AreEqual(2, users.Count);

                userService.DeleteUser(userId1);

                users = userService.GetUsers();

                Assert.AreEqual(1, users.Count);
            }
        }

        #endregion
    }
}