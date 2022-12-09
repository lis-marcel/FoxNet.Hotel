using FoxNet.Hotel.Service.DTO;

namespace FoxNet.Hotel.Service.ClassConverter
{
    public class ConvertUser
    {
        public static User UserDataToUser(UserData userData)
        {
            return new User()
            {
                UserName = userData.UserName,
                UserSurname = userData.UserSurname,
                Birth = userData.Birth,
                Phone = userData.Phone,
                Email = userData.Email,
                AccountType = (Type)userData.AccountType,
                Password = userData.Password,
                Money = userData.Money,
            };
        }

        public static UserData UserToUserData(User user)
        {
            return new UserData()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserSurname = user.UserSurname,
                Birth = user.Birth,
                Phone = user.Phone,
                Email = user.Email,
                AccountType = (DTO.Type)user.AccountType,
                Password = user.Password,
                Money = user.Money
            };
        }
    }
}
