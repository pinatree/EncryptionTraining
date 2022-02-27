using System;
using System.Linq;

using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Encryptor
{
    public class VigenereEncryptor : IEncryptor
    {
        private VigenereAlphabetHelper _symbolsChecker;

        public VigenereEncryptor(char alphabetStart = 'A', char alphabetEnd = 'Z')
        {
            _symbolsChecker = new VigenereAlphabetHelper(alphabetStart, alphabetEnd);
        }

        public string Encrypt(string original, string key)
        {
            if ((key == null) || (key == string.Empty))
                throw new ArgumentNullException("Key must be not null and not empty string");

            //Check: all symbols of the key exists in alphabet
            bool keyIsValid = _symbolsChecker.CheckStrIsValid(key);

            //Original string contains incorrect symbols => error
            if (keyIsValid == false)
                throw new ArgumentException("The key contains characters that" +
                    "are not in the alphabet. Be careful, a space is also a symbol.");

            //Check: all symbols of original string exists in alphabet
            bool stringIsValid = _symbolsChecker.CheckStrIsValid(original);

            //Original string contains incorrect symbols => error
            if (stringIsValid == false)
                throw new ArgumentException("The string contains characters that" +
                    "are not in the alphabet.Be careful, a space is also a symbol.");

            //Generate encryption table
            char[][] encryptTable = EncryptTableGenerator.GetEncryptionTable(key, _symbolsChecker);

            //Encrypt a string with an encryption table
            string encrypted = GetEncryptedString(original, encryptTable);

            return encrypted;
        }

        public string GetEncryptedString(string original, char[][] encryptionTable)
        {
            string encrypted = "";

            //get key length (equals encryption table rows count)
            int keyLength = encryptionTable.Count();

            //encrypt each symbol
            for(int x = 0; x < original.Length; x++)
            {
                //encryption table row for this symbol
                int currentRow = x % keyLength;

                //get current symbol
                char currentSymbol = original[x];
                
                //get column for this symbol
                int currentColumn = Convert.ToInt32(currentSymbol) - _symbolsChecker.StartPos;

                //get symbol  from table
                char addSymbol = encryptionTable[currentRow][currentColumn];

                encrypted = encrypted + addSymbol;
            }

            return encrypted;
        }
    }
}
