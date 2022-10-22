using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Hashing
{
    public class HashingHandler
    {
        public string CreatePasswordHash(string password) {

            using SHA256 chSha256 = SHA256.Create();
            byte[] passwordHash = chSha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            
                StringBuilder sp = new StringBuilder();
                for (int i = 0; i < passwordHash.Length; i++)
                {
                    sp.Append(passwordHash[i].ToString("x2"));
                }
                return sp.ToString();
              
            

        }
    }
}
