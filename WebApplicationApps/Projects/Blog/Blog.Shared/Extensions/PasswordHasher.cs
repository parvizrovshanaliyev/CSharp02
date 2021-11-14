using System;
using System.Security.Cryptography;
using System.Text;

namespace Blog.Shared.Extensions
{
    public static class PasswordHasher
    {
        // admin1234s@1t 1aqw1jbuaihsabausuasbuavs
        public static string HashPassword(this string password)
        {
            if (password == null)
            { return null; }
            password += "s@1t";

            byte[] bytes = Encoding.UTF8.GetBytes(password);
            
            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);

            return HexStringFromBytes(hashBytes);
        }

        private static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}
