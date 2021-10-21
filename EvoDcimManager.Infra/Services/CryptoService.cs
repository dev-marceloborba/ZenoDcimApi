using EvoDcimManager.Domain.UserContext.Services;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace EvoDcimManager.Infra.Services
{
    public class CryptoService : ICryptoService
    {
        public string EncryptPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }


            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }
    }
}