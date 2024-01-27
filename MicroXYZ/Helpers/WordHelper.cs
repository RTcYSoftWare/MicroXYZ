using System;
using System.Security.Cryptography;
using System.Text;

namespace MicroXYZ.Helpers
{
    public class WordHelper : IWordHelper
    {
        public string CreateSixDigitCode()
        {
            Random random = new Random();

            string randomCode = random.Next(0, 1000000).ToString("D6");

            return randomCode;
        }

        public string HashToText(string text, string key)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToString();
        }
    }
}
