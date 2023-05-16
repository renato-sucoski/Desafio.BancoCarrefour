using System.Security.Cryptography;
using System.Text;
using System;

namespace Desafio.BancoCarrefour.Authentication.Helper
{
    public static class PassHelper
    {
        public static byte[] GenerateSalt(int length)
        {
            byte[] salt = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        public static byte[] GeneratePasswordHash(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(32); // Retorna um hash de 256 bits (32 bytes)
            }
        }
        public static string ByteArrayToHexString(byte[] byteArray)
        {
            StringBuilder hex = new StringBuilder(byteArray.Length * 2);
            foreach (byte b in byteArray)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
        public static byte[] HexStringToByteArray(string hexString)
        {
            if (string.IsNullOrEmpty(hexString))
                throw new ArgumentException("A string hexadecimal não pode ser nula ou vazia.");

            if (hexString.Length % 2 != 0)
                throw new ArgumentException("A string hexadecimal deve ter um número par de caracteres.");

            byte[] byteArray = new byte[hexString.Length / 2];

            for (int i = 0; i < byteArray.Length; i++)
            {
                string byteString = hexString.Substring(i * 2, 2);
                byteArray[i] = Convert.ToByte(byteString, 16);
            }

            return byteArray;
        }
    }
}
