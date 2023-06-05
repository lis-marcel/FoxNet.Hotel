using FoxNet.Hotel.BO;

namespace FoxNet.Hotel.BO.Test
{
    [TestClass]
    public class UserBOTest
    {
        #region Test Obejcts
        User firstUser = new User()
        {
            UserId = 1,
            UserName = "Jan",
            UserSurname = "Kowalski",
            Birth = new DateOnly(1970, 2, 15),
            AccountType = Type.Admin,
            Phone = "123456789",
            Password = "okok123",
        };

        User secondUser = new User()
        {
            UserId = 1,
            UserName = "Jan",
            UserSurname = "Kowalski",
            Birth = new DateOnly(1970, 2, 15),
            AccountType = Type.Admin,
            Phone = "123456789",
            Password = "okok123",
        };
        #endregion

        #region Test Methods
        [TestMethod]
        public void AssertNameIsCorrectTest()
        {
            Assert.AreEqual("Jan", firstUser.UserName);
        }

        [TestMethod]
        public void CheckChangeUserTypeTest()
        {
            firstUser.AccountType = Type.Client;

            Assert.AreNotEqual(Type.Admin, firstUser.AccountType);
        }
        #endregion
    }
}