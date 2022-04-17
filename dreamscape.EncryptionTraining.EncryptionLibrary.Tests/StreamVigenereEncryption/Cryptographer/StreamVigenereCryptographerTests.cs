using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using dreamscape.EncryptionTraining.EncryptionLibrary.StreamVigenereEncryption.Cryptographer;
using dreamscape.EncryptionTraining.EncryptionLibrary.StreamVigenereEncryption.Encryptor;
using NUnit.Framework;
using System;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Tests.StreamVigenereEncryption.Cryptographer
{
    public class StreamVigenereCryptographerTests
    {
        [Test]
        public void CompareRandomDecAndEnc()
        {
            for (int x = 0; x < 100; x++)
            {
                string message = CreateString(100);
                string key = CreateString(45);

                StreamVigenereCryptographer svCryptographer = new StreamVigenereCryptographer();
                string encrypted = svCryptographer.Encryptor.Encrypt(message, key);

                string decrypted = svCryptographer.Decryptor.Decrypt(encrypted, key);
                
                Assert.AreEqual(message, decrypted.Trim());
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
