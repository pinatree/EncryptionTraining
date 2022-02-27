using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using dreamscape.EncryptionTraining.EncryptionLibrary.StreamVigenereEncryption.Decryptor;
using dreamscape.EncryptionTraining.EncryptionLibrary.StreamVigenereEncryption.Encryptor;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.StreamVigenereEncryption.Cryptographer
{
    public class StreamVigenereCryptographer : ICryptographer
    {
        public IEncryptor Encryptor { get; } = new StreamVigenereEncryptor();

        public IDecryptor Decryptor { get; } = new StreamVigenereDecryptor();
    }
}
