namespace dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces.Validation
{
    public interface IValidator
    {
        public ValidationInfo GetValidationInfo(string encryption, string key);
    }
}
