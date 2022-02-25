using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.TranspositionEncryption
{
    public class TranspositionCryptographer : ICryptographer
    {
        public IEncryptor Encryptor { get; } = new TranspositionEncryptor();

        public IDecryptor Decryptor { get; } = new TranspositionDecryptor();
    }
}
