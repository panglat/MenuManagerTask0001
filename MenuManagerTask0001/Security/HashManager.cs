using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace Security
{
    // From: https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing

    public static class HashManager
    {
        static string defaultSalt = "Wk+7ygMPCzCruSfz66xKgw==";

        public static byte[] getSalt()
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public static string getHashed(string password, byte[] salt = null)
        {
            if(salt == null)
            {
                salt = Convert.FromBase64String(defaultSalt);
            }

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
