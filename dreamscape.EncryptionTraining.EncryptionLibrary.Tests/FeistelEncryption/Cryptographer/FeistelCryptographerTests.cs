using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dreamscape.EncryptionTraining.EncryptionLibrary.FeistelEncryption.Cryptographer;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Tests.FeistelEncryption.Cryptographer
{
    public class FeistelCryptographerTests
    {
        [Test]
        public void TestRandomCombinationsEncAndDecrpytion()
        {
            for(int x = 0; x < 100; x++)
            {
                string message = CreateString(100);
                string key = CreateString(45);

                FeistelCryptographer feistelCryptographer = new FeistelCryptographer();
                string encrypted = feistelCryptographer.Encryptor.Encrypt(message, key);
                Console.WriteLine(encrypted);
                string decrypted = feistelCryptographer.Decryptor.Decrypt(encrypted, key);

                Assert.AreEqual(message, decrypted);
            }
        }

        static Random rd = new Random();
        static string CreateString(int stringLength)
        {
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
            char[] chars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}
