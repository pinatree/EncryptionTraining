using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Decryptor;
using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Encryptor;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Cryptographer
{
    public class VigenereCryptographer : ICryptographer
    {
        public IEncryptor Encryptor { get; } = new VigenereEncryptor();

        public IDecryptor Decryptor { get; } = new VigenereDecryptor();
    }
}
