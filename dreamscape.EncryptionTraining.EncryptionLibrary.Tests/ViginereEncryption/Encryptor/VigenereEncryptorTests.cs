using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Encryptor;
using NUnit.Framework;
using System;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Tests.ViginereEncryption.Encryptor
{
    public class VigenereEncryptorTests
    {
        private VigenereEncryptor _encryptor;

        [SetUp]
        public void SetUp()
        {
            _encryptor = new VigenereEncryptor();
        }

        [Test]
        public void CheckGetEncryptedString()
        {
            //encryption table for key 'BJYHG'
            char[][] encryptionTable = new char[][]
            {
                "BCDEFGHIJKLMNOPQRSTUVWXYZA".ToCharArray(),
                "JKLMNOPQRSTUVWXYZABCDEFGHI".ToCharArray(),
                "YZABCDEFGHIJKLMNOPQRSTUVWX".ToCharArray(),
                "HIJKLMNOPQRSTUVWXYZABCDEFG".ToCharArray(),
                "GHIJKLMNOPQRSTUVWXYZABCDEF".ToCharArray(),
            };
            var result = _encryptor.GetEncryptedString("AAC", encryptionTable);
            Assert.AreEqual("BJA", result);
        }

        [Test]
        public void CheckEncryption()
        {
            var result = _encryptor.Encrypt("AAC", "BJYHG");
            Assert.AreEqual("BJA", result);

            //Empty string key => error
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    _encryptor.Encrypt("ASD", "");
                });

            //Null key => error
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    _encryptor.Encrypt("ASD", null);
                });

            //Crazy key => error
            Assert.Throws<ArgumentException>(
                () =>
                {
                    _encryptor.Encrypt("ASD", "123ва2");
                });
        }
    }
}
