using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using dreamscape.EncryptionTraining.EncryptionLibrary.VernamEncryption.Decryptor;
using dreamscape.EncryptionTraining.EncryptionLibrary.VernamEncryption.Encryptor;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.VernamEncryption.Cryptographer
{
    public class VernamCryptographer : ICryptographer
    {
        public IEncryptor Encryptor { get; } = new VernamEncryptor();

        public IDecryptor Decryptor { get; } = new VernamDecryptor();
    }
}
