namespace dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces.Validation
{
    public struct ValidationMessage
    {
        public VALIDATION_MESSAGE_TYPE ErrorType;

        public string ErrorInfo;

        public ValidationMessage(VALIDATION_MESSAGE_TYPE errorType, string errorInfo)
        {
            this.ErrorType = errorType;
            this.ErrorInfo = errorInfo;
        }
    }
}
