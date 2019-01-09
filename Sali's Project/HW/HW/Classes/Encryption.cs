﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace HW.Classes
{
    public class Encryption
    {
        public const int SALT_SIZE = 24;
        public const int HASH_SIZE = 24;
        public const int PBKDF2_ITT = 500;


        public string CreateHash(string pass)
        {
            //generate random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_SIZE];
            csprng.GetBytes(salt);


            //generate the passwordhash

            byte[] hash = PBKDF2(pass, salt, PBKDF2_ITT, HASH_SIZE);
            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }

        private byte[] PBKDF2(string pass, byte[] salt, int pBKDF2_ITT, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(pass, salt);
            pbkdf2.IterationCount = pBKDF2_ITT;
            return pbkdf2.GetBytes(outputBytes);
        }

        private bool SlowEquals(byte[] dbHash, byte[] passHash)
        {
            uint diff = (uint)dbHash.Length ^ (uint)passHash.Length; // ^: xor
            for (int i = 0; i < dbHash.Length && i < passHash.Length; i++)
            {
                diff |= (uint)dbHash[i] ^ (uint)passHash[i];
            }
            return (diff == 0);
        }

        public bool ValidatePassword(string pass, string dbHash)
        {
            char[] delimiter = { ':' };
            string[] split = dbHash.Split(delimiter);

            byte[] salt = Convert.FromBase64String(split[0]);
            byte[] hash = Convert.FromBase64String(split[1]);

            byte[] hashToValidate = PBKDF2(pass, salt, PBKDF2_ITT, hash.Length);
            return SlowEquals(hash, hashToValidate);

        }
    }
}