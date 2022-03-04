using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Decryptor;
using NUnit.Framework;
using System;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Tests.ViginereEncryption.Decryptor
{
    public class VigenereDecryptorTests
    {
        [Test]
        public void CheckGetDecryptedString()
        {
            VigenereDecryptor decryptor = new VigenereDecryptor('A', 'Z');

            //encryption table for key 'BJYHG'
            char[][] encryptionTable = new char[][]
            {
                "BCDEFGHIJKLMNOPQRSTUVWXYZA".ToCharArray(),
                "JKLMNOPQRSTUVWXYZABCDEFGHI".ToCharArray(),
                "YZABCDEFGHIJKLMNOPQRSTUVWX".ToCharArray(),
                "HIJKLMNOPQRSTUVWXYZABCDEFG".ToCharArray(),
                "GHIJKLMNOPQRSTUVWXYZABCDEF".ToCharArray(),
            };
            var result = decryptor.GetDecryptedString("BJA", encryptionTable);
            Assert.AreEqual("AAC", result);
        }

        [Test]
        public void CheckDecryption()
        {
            VigenereDecryptor decryptor = new VigenereDecryptor('A', 'Z');

            var result = decryptor.Decrypt("BJA", "BJYHG");
            Assert.AreEqual("AAC", result);

            //Empty string key => error
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    decryptor.Decrypt("ASD", "");
                });

            //Null key => error
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    decryptor.Decrypt("ASD", null);
                });

            //Crazy key => error
            Assert.Throws<ArgumentException>(
                () =>
                {
                    decryptor.Decrypt("ASD", "123ва2");
                });
        }
    }
}
