using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Cryptographer;
using NUnit.Framework;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Tests.ViginereEncryption.Cryptographer
{
    public class VigenereCryptographerTests
    {
        [Test]
        public void CheckEncryptionDecryptionEquals()
        {
            VigenereCryptographer cryptographer = new VigenereCryptographer();

            string key = "ENCRYPTIONKEY";
            string original = "MYFAVORITEENCRYPTIONSTRING";

            string ecnrypted = cryptographer.Encryptor.Encrypt(original, key);
            string decrypted = cryptographer.Decryptor.Decrypt(ecnrypted, key);

            Assert.AreEqual(decrypted, original);

            key = "AJDFISFAHASDOHFDSAOFASD";
            original = "DSGBDYHDRVYHDRFGHDGFJDGFYGFDHDFGHGFHDFHJDHGFDHDHGFHGFDTRDHDFGHDGFHDGFHF";

            ecnrypted = cryptographer.Encryptor.Encrypt(original, key);
            decrypted = cryptographer.Decryptor.Decrypt(ecnrypted, key);

            Assert.AreEqual(decrypted, original);
        }
    }
}
