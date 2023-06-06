using FoxNet.Hotel.Common;
using FoxNet.Hotel.Service.DTO;
using FoxNet.Hotel.Service.ClassConverter;

namespace FoxNet.Hotel.Service
{
    public class UserService
    {
        private DbStorage db;

        public UserService(DbStorage db)
        {
            this.db = db;
        }

        public int AddUser(UserData userData)
        {
            var givenPassword = userData.Password;
            var encryptedPassword = PasswordService.EncryptPassword(givenPassword);

            userData.Password = encryptedPassword;

            var u = ConvertUser.UserDataToUser(userData);

            var userId = db.Users.Add(u);
            db.SaveChanges();

            return userId.Entity.UserId;
        }

        public int EditUser(UserData userData)
        {
            var user = db.Users.Single(u => u.UserId == userData.UserId);

            var newUserData = ConvertUser.UserDataToUser(userData);

            user = newUserData;

            db.Users.Update(user);

            db.SaveChanges();

            return user.UserId;
        }

        public UserData GetUser(int userId)
        {
            var user = db.Users.Single(u => u.UserId == userId);

            return ConvertUser.UserToUserData(user);
        }

        public IList<UserData> GetUsers() 
        {
            return db.Users.Select(u => 
                ConvertUser.UserToUserData(u))
                .ToList();
        }

        public void DeleteUser(int userId) 
        {
            var user = db.Users.Single(u => u.UserId == userId);

            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}