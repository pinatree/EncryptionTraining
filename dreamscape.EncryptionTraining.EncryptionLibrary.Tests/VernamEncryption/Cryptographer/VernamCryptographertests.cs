using dreamscape.EncryptionTraining.EncryptionLibrary.StreamVigenereEncryption.Encryptor;
using dreamscape.EncryptionTraining.EncryptionLibrary.VernamEncryption.Cryptographer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Tests.VernamEncryption.Cryptographer
{
    public class VernamCryptographerTests
    {
        [Test]
        public void TestEncDecryptRandom()
        {
            for (int x = 0; x < 100; x++)
            {
                string message = CreateString(100);
                string key = ""; //ключ там не нужен CreateString(45);

                VernamCryptographer vernamCryptographer = new VernamCryptographer();
                string encrypted_str_key = vernamCryptographer.Encryptor.Encrypt(message, key);

                string encrypted_str = encrypted_str_key.Substring(0, encrypted_str_key.IndexOf("|"));
                //такая логика с единицами, чтобы отсечь черточку
                string encrypted_key = encrypted_str_key.Substring(encrypted_str_key.IndexOf("|") + 1, encrypted_str_key.Length - encrypted_str_key.IndexOf("|") - 1);

                string decrypted = vernamCryptographer.Decryptor.Decrypt(encrypted_str, encrypted_key);

                Assert.AreEqual(message, decrypted);
            }
        }

        static Random rd = new Random();
        static string CreateString(int stringLength)
        {
            const string allowedChars = StreamVigenereEncryptor.ALPHABET;
            char[] chars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}
