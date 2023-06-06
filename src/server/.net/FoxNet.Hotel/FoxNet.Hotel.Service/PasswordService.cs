using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FoxNet.Hotel.Service
{
    public class PasswordService
    {
        public static string EncryptPassword(string password)
        {
            using MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                stringBuilder.Append(hashBytes[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        public static bool ComparePasswords(string passwordHash, string givenPassword)
        {
            string givenPasswordHash = EncryptPassword(givenPassword);

            if (passwordHash == givenPasswordHash)
            {
                return true;
            }

            return false;
        }
    }
}
