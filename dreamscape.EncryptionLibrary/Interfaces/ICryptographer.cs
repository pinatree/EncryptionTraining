namespace dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces
{
    public interface ICryptographer
    {
        IEncryptor Encryptor { get; }

        IDecryptor Decryptor { get; }
    }
}
