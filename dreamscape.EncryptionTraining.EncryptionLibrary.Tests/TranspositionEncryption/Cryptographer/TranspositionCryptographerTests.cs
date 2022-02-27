using dreamscape.EncryptionTraining.EncryptionLibrary.TranspositionEncryption;
using NUnit.Framework;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Tests.TranspositionEncryption.Cryptographer
{
    public class TranspositionCryptographerTests
    {
        [Test]
        public void TestEncryptionDecription()
        {
            TranspositionCryptographer cryptographer = new TranspositionCryptographer();

            string key = "ENCRYPTIONKEY";
            string original = "MYFAVORITEENCRYPTIONSTRING";

            string ecnrypted = cryptographer.Encryptor.Encrypt(original, key);
            string decrypted = cryptographer.Decryptor.Decrypt(ecnrypted, key);

            Assert.AreEqual(decrypted.Trim(), original.Trim());

            key = "йцу";
            original = "По своей сути рыбатекст является альтернативой традиционному";

            ecnrypted = cryptographer.Encryptor.Encrypt(original, key);
            decrypted = cryptographer.Decryptor.Decrypt(ecnrypted, key);

            Assert.AreEqual(decrypted.Trim(), original.Trim());

            key = "AJDFSDOHFDSAOFASD";
            original = "DSGBDYDFHJDHGFDHDHGFHGFDTRDHDFGHDGFHDGFHF";

            ecnrypted = cryptographer.Encryptor.Encrypt(original, key);
            decrypted = cryptographer.Decryptor.Decrypt(ecnrypted, key);

            Assert.AreEqual(decrypted.Trim(), original.Trim());

            key = "DNX(*AW236r1y-r7mw7-u7-udyfas8hfmqr";
            original = "По своей сути рыбатекст является альтернативой традиционному " +
                "lorem ipsum, который вызывает у некторых людей недоумение при " +
                "попытках прочитать рыбу текст. В отличии от lorem ipsum, текст " +
                "рыба на русском языке наполнит любой макет непонятным смыслом и " +
                "придаст неповторимый колорит советских времен.";

            ecnrypted = cryptographer.Encryptor.Encrypt(original, key);
            decrypted = cryptographer.Decryptor.Decrypt(ecnrypted, key);

            Assert.AreEqual(decrypted.Trim(), original.Trim());
        }
    }
}
