using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using dreamscape.EncryptionTraining.EncryptionLibrary.FeistelEncryption.Encryptor;
using dreamscape.EncryptionTraining.EncryptionLibrary.FeistelEncryption.Decryptor;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.FeistelEncryption.Cryptographer
{
    public class FeistelCryptographer : ICryptographer
    {
        public IEncryptor Encryptor => new FeistelEncryptor();

        public IDecryptor Decryptor => new FeistelDecryptor();
    }
}