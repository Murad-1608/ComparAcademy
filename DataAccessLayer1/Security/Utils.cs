using System;
using System.Text;
using Tweetinvi.Security;

namespace DataAccessLayer.Security
{
    public class Utils
    {
        public static string PasswordHash(string Password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] password_bytes = Encoding.ASCII.GetBytes(Password);
            byte[] encrypted_bytes = sha1.ComputeHash(password_bytes);
            return Convert.ToBase64String(encrypted_bytes);
        }
    }
}
