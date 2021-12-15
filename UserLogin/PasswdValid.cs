using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace UserLogin
{
    class PasswdValid
    {
        // create a hash of a string of chars
       public static int iterator = 10000;
        public static string HashString(string value)
        {
            byte[] salt;

            // generate salt
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // hash and salt password
            var passHash = new Rfc2898DeriveBytes(value, salt, iterator);

            // place string of bytes to store it
            byte[] hash = passHash.GetBytes(20);

            byte[] hashBytes = new byte[36];

            // place hash and salt
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // convert hash to string
            return Convert.ToBase64String(hashBytes);
        }

        public static bool isPassword(string passwordText, string passwordHash)
        {
            // convert password hash to byte
            byte[] hashBytes = Convert.FromBase64String(passwordHash);

            // get salt from string
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // hash password text
            var passText = new Rfc2898DeriveBytes(passwordText, salt, iterator);

            // put hash 
            byte[] hash = passText.GetBytes(20);

            // validate hash
            bool valid = true;

            // go over each byte and check if valid
            for (int i = 0; i < 20; i++) {
                if (hashBytes[i+16] != hash[i])
                {
                    valid = false;
                }
            }

            return valid;
        }

    }
}
