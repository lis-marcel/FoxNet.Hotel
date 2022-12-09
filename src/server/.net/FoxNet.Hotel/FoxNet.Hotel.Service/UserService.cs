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
            var u = ConvertUser.UserDataToUser(userData);

            var userId = db.Users.Add(u);
            db.SaveChanges();

            return userId.Entity.UserId;
        }

        public void EditUser(UserData userData)
        {
            var user = db.Users.Single(u => u.UserId == userData.UserId);

            var newUserData = ConvertUser.UserDataToUser(userData);

            user = newUserData;

            db.SaveChanges();
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

        public void ManageMoney(UserData userData) 
        {
            var user = db.Users.SingleOrDefault(u => u.UserId == userData.UserId);

            if (user != null)
            {
                user.Money = userData.Money;
                db.SaveChanges();
            }
        }

        public void DeleteUser(int userId) 
        {
            var user = db.Users.Single(u => u.UserId == userId);

            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}