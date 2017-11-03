using System;
using System.Text;
using System.Security.Cryptography;

namespace Bayview_Demo
{
    class Coder
    {
        /// take any string and encrypt it using SHA1
        public static string GetHash(string data)
        {
            //create new instance of sha1
            SHA1 sha1 = SHA1.Create();

            //convert input text to array of bytes
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));

            //create a StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();
        }
    }
}
