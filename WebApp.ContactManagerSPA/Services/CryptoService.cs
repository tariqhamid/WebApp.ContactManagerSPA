using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApp.ContactManagerSPA.Services
{
    public class CryptoService:ICryptoService
    {
        private const string _alg = "HmacSHA256";
        private const string _salt = "rz8LuOtFBXphj9WQfvFh"; // Generated at https://www.random.org/strings

        public string GenerateSalt(int saltLength)
        {
            var salt = new byte[saltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public string CreateSHAHash(string password, string salt)
        {
            string saltAndPwd = String.Concat(password, salt);
            SHA256 algorithm = SHA256.Create();
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(saltAndPwd));
            string sh1 = "";
            for (int i = 0; i < data.Length; i++)
            {
                sh1 += data[i].ToString("x2");
            }
            return sh1;
        }
    }
}