using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNet.Hotel.Service.Test
{
    [TestClass]
    public class PasswordServiceTest
    {
        #region Test variables
        private string password1 = "kokosek123";
        private string password2 = "migdal123";
        private string password3 = "kokosek123";
        #endregion

        #region Test methods
        [TestMethod]
        public void EncryptPasswordTest()
        {
            var hasehdPassword1 = PasswordService.EncryptPassword(password1);

            Assert.AreNotEqual(password1, hasehdPassword1);
        }

        [TestMethod]
        public void ComparePasswordTestTrue()
        {
            var passwordHash1 = PasswordService.EncryptPassword(password1);

            var equal = PasswordService.ComparePasswords(passwordHash1, password3);

            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void ComparePasswordTestFalse()
        {
            var passwordHash1 = PasswordService.EncryptPassword(password1);

            var equal = PasswordService.ComparePasswords(passwordHash1, password2);

            Assert.IsFalse(equal);
        }
        #endregion
    }
}
