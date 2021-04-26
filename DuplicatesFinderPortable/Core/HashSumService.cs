using DuplicatesFinderPortable.Core.Services;
using System;
using System.IO;
using System.Security.Cryptography;

namespace DuplicatesFinderPortable.Core
{
    public class HashSumService : IHashSumService
    {
        public string ComputeCheckSum(string path)
        {
            using (FileStream fs = File.OpenRead(path))

            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] checkSum = md5.ComputeHash(fs);

                string result = BitConverter.ToString(checkSum).Replace("-", string.Empty);

                return result;
            }
        }
    }
}
