using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Wordschatz.Common.Entities;

namespace Wordschatz.Domain.Models.ValueObjects
{
    public class Password : ValueObject
    {
        public byte[] Salt { get; private set; }
        public string Hash { get; private set; }
        public static readonly int SaltLength = 256;
        public static readonly int HashLength = 256;
        private Password()
        {

        }

        public static implicit operator Password(string pass) => new Password(pass);

        public Password(string pass)
        {
            if (string.IsNullOrWhiteSpace(pass))
                throw new ArgumentException("Password must be in a human-readable format");

            Salt = GenerateSalt();
            Hash = GenerateHash(pass);
        }

        private byte[] GenerateSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltLength]);
            return salt;
        }

        private string GenerateHash(string pass)
        {
            var pbkfd2 = new Rfc2898DeriveBytes(pass, Salt, 10000);
            byte[] hash = pbkfd2.GetBytes(HashLength);

            byte[] hashArr = new byte[HashLength + SaltLength];

            Array.Copy(Salt, 0, hashArr, 0, SaltLength);
            Array.Copy(hash, 0, hashArr, SaltLength, HashLength);

            return Convert.ToBase64String(hashArr);
        }

        public bool ValidatePassword(string password)
        {
            byte[] passHash = Convert.FromBase64String(Hash);
            byte[] hashArr = Convert.FromBase64String(GenerateHash(password));

            for (int i = 0; i < HashLength; i++)
            {
                if (hashArr[i + SaltLength] != passHash[i + SaltLength])
                {
                    return false;
                }
            }

            return true;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Salt;
            yield return Hash;
        }
    }
}