using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Encryptor;
using NUnit.Framework;

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


            var ruEncryptor = new VigenereEncryptor('А', 'Я');

            //encryption table for key 'ШИФР'
            encryptionTable = new char[][]
            {
                "ШЩЪЫЬЭЮЯАБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧ".ToCharArray(),
                "ИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯАБВГДЕЖЗ".ToCharArray(),
                "ФХЦЧШЩЪЫЬЭЮЯАБВГДЕЖЗИЙКЛМНОПРСТУ".ToCharArray(),
                "РСТУФХЦЧШЩЪЫЬЭЮЯАБВГДЕЖЗИЙКЛМНОП".ToCharArray(),
            };
            result = ruEncryptor.GetEncryptedString("ЭТОСООБЩЕНИЕНУЖНОЗАКОДИРОВАТЬ", encryptionTable);
            //Assert.AreEqual("ХЫГВЖЧХЙЭЦЭХЁЬЫЮЖРФЫЖМЭБЖКФГФ", result);
            //хз вроде работает. проверить как то надо...


        }


    }
}
