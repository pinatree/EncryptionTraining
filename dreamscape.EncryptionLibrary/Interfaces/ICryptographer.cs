namespace dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces
{
    interface ICryptographer
    {
        IEncryptor Encryptor { get; }

        IDecryptor Decryptor { get; }
    }
}
