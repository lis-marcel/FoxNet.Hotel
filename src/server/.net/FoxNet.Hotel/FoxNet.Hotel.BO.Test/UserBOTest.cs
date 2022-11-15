using FoxNet.Hotel.BO;

namespace FoxNet.Hotel.BO.Test
{
    [TestClass]
    public class UserBOTest
    {
        #region Test Obejcts
        User firstUser = new User()
        {
            Id = 1,
            Name = "Jan",
            Surname = "Kowalski",
            Birth = new DateOnly(1970, 2, 15),
            AccountType = Type.Admin,
            Phone = "123456789",
            Password = "okok123",
            Money = "345.01D"
        };

        User secondUser = new User()
        {
            Id = 1,
            Name = "Jan",
            Surname = "Kowalski",
            Birth = new DateOnly(1970, 2, 15),
            AccountType = Type.Admin,
            Phone = "123456789",
            Password = "okok123",
            Money = "345.01D"
        };
        #endregion

        #region Test Methods
        [TestMethod]
        public void AssertNameIsCorrectTest()
        {
            Assert.AreEqual("Jan", firstUser.Name);
        }

        [TestMethod]
        public void CheckChangeUserTypeTest()
        {
            firstUser.AccountType = Type.Client;

            Assert.AreNotEqual(Type.Admin, firstUser.AccountType);
        }

        [TestMethod]
        public void ChangeMoneyValueTest()
        {
            var value = 100.50F;
            var expectedValue = value + firstUser.Money;
            firstUser.Money += value;

            Assert.AreEqual(expectedValue, firstUser.Money);
        }

        /*[TestMethod]
        [ExpectedException(typeof()]
        public void CheckIfObejctsDiffers() 
        { 
            Assert.AreSame(firstUser, secondUser);
        }
        */
        #endregion
    }
}