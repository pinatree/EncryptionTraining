using System.Collections.Generic;
using System.Linq;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces.Validation
{
    public sealed class ValidationInfo
    {
        //Is encryption string + key are correct
        public bool AllDone
        {
            get => ValidationMessages.All(validationMessage => validationMessage.ErrorType != VALIDATION_MESSAGE_TYPE.ERROR);
        }

        public List<ValidationMessage> ValidationMessages { get; private set; }

    }
}
