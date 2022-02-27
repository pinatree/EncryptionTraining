using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers;

using System;
using System.Linq;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Decryptor
{
    public class VigenereDecryptor : IDecryptor
    {
        private VigenereAlphabetHelper _symbolsChecker;

        public VigenereDecryptor(char alphabetStart = 'A', char alphabetEnd = 'Z')
        {
            _symbolsChecker = new VigenereAlphabetHelper(alphabetStart, alphabetEnd);
        }

        public string Decrypt(string encrypted, string key)
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
            bool stringIsValid = _symbolsChecker.CheckStrIsValid(encrypted);

            //Original string contains incorrect symbols => error
            if (stringIsValid == false)
                throw new ArgumentException("The string contains characters that" +
                    "are not in the alphabet.Be careful, a space is also a symbol.");

            //Generate encryption table
            char[][] encryptTable = EncryptTableGenerator.GetEncryptionTable(key, _symbolsChecker);

            //Decrypt a string with an encryption table
            string decrypt = GetDecryptedString(encrypted, encryptTable);

            return decrypt;
        }

        public string GetDecryptedString(string original, char[][] encryptionTable)
        {
            string decrypted = "";

            //get key length (equals encryption table rows count)
            int keyLength = encryptionTable.Count();

            //encrypt each symbol
            for (int x = 0; x < original.Length; x++)
            {
                //encryption table row for this symbol
                int currentRow = x % keyLength;

                //get current symbol
                char currentSymbol = original[x];

                //Find encrypted character in encrypted string
                int symbolPosInEncTable = 0;
                foreach(var symbol in encryptionTable[currentRow])
                {
                    if(symbol == currentSymbol)
                    {
                        break;
                    }
                    symbolPosInEncTable++;
                }

                //Substitute a string from the original alphabet
                char addSymbol = _symbolsChecker.Alphabet[symbolPosInEncTable];

                decrypted = decrypted + addSymbol;
            }

            return decrypted;
        }
    }
}
