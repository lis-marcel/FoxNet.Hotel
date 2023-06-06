using FoxNet.Hotel.Service.DTO;

namespace FoxNet.Hotel.Service.ClassConverter
{
    public class ConvertUser
    {
        public static User UserDataToUser(UserData userData)
        {
            var givenPassword = userData.Password;
            var encryptedPassword = PasswordService.EncryptPassword(givenPassword);

            userData.Password = encryptedPassword;

            return new User()
            {
                UserName = userData.UserName,
                UserSurname = userData.UserSurname,
                Birth = userData.Birth,
                Phone = userData.Phone,
                Email = userData.Email,
                AccountType = (Type)userData.AccountType,
                Password = userData.Password,
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
            };
        }
    }
}
