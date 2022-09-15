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
            Name = "Jan",
            Surname = "Kowalski",
            Birth = new DateTime(1920, 1, 14),
            AccountType = DTO.Type.Worker,
            Money = "700.89D",
            Password = "123",
            Phone = "123456689"
        };

        UserData testUserObject2 = new UserData()
        {
            Name = "Pat",
            Surname = "Czech",
            Birth = new DateTime(1999, 11, 19),
            AccountType = DTO.Type.Client,
            Money = "11.89D",
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

                user.Name = "Marcel";
                userService.EditUser(user);

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
                    Money = "11.89D",
                });
                db.SaveChanges();

                var pickedUser = userService.GetUser(user);
                var parsedMoneyValue = double.Parse(pickedUser.Money);

                Assert.AreEqual(11.89F, parsedMoneyValue);

                var modifyiedParsedMoneyValue = parsedMoneyValue + 30.48D;
                
                testUserObject1.Money = modifyiedParsedMoneyValue.ToString();

                userService.ManageMoney(testUserObject1);

                testUserObject1 = userService.GetUser(user);

                var fetchedUserMoneyValue = double.Parse(pickedUser.Money);
                Assert.AreEqual(42.37F, fetchedUserMoneyValue);
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