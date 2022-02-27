using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.StreamVigenereEncryption.Encryptor
{
    public sealed class StreamVigenereEncryptor : IEncryptor
    {
        private VigenereAlphabetHelper _alphabetHelper;

        public StreamVigenereEncryptor(char aplhStartSymbol = 'A', char alphEndSymbol = 'Z')
        {
            this._alphabetHelper = new VigenereAlphabetHelper(aplhStartSymbol, alphEndSymbol);
        }

        public string Encrypt(string original, string key)
        {
            var vigenereTable = _alphabetHelper.GetAlphabetTable();

            return "";
        }
    }
}
