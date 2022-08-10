using FoxNet.Hotel.Service.DTO;
using FoxNet.Hotel.Service;
using FoxNet.Hotel.Common;

namespace FoxNet.Hotel.WebAPI.Test
{
    [TestClass]
    public class UserControllerTest
    {
        private UserData user = new UserData()
        {
            Name = "Jan",
            Surname = "Kowalski",
            Birth = new DateTime(1920, 1, 14),
            AccountType = Service.DTO.Type.Worker,
            Money = 700.89F,
            Password = "123",
            Phone = 123456689
        };

        [TestMethod]
        public void ControllerAddUserTest()
        {
            using (var db = DbStorage.GetDefault())
            {
                var service = new UserService(db);
            }
        }
    }
}