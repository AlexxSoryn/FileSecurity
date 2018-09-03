using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSecurity
{
    public class KeyExchange
    {
      
        public static byte[] ProcessPassword(byte[] password)
        {
            var hashService = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var s1 = hashService.ComputeHash(password, 0, password.Length);
            var s2 = hashService.ComputeHash(Encoding.ASCII.GetBytes(String.Concat(s1, s1)));
            var sresult = String.Concat(ASCIIEncoding.Default.GetString(s1), ASCIIEncoding.Default.GetString(s2));

            return ASCIIEncoding.Default.GetBytes(sresult);
        }
    }
}
