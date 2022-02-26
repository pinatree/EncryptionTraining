using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers;

using System;
using System.Linq;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Decryptor
{
    public class VigenereDecryptor : IDecryptor
    {
        private VigenereSymbolsHelper _symbolsChecker;

        public VigenereDecryptor(char alphabetStart = 'A', char alphabetEnd = 'Z')
        {
            _symbolsChecker = new VigenereSymbolsHelper(alphabetStart, alphabetEnd);
        }

        public string Decrypt(string encrypted, string key)
        {
            string upperCase = VigenereStringConverter.SetToUpperCase(encrypted);

            bool stringIsValid = _symbolsChecker.CheckStrIsValid(encrypted);

            if (stringIsValid == false)
                throw new ArgumentException("Строка содержит недопустимые символы.");

            char[][] encryptTable = EncryptTableGenerator.GetEncryptionTable(key, _symbolsChecker);

            string decrypt = GetDecryptedString(encrypted, encryptTable);

            return decrypt;
        }

        public string GetDecryptedString(string original, char[][] encryptionTable)
        {
            string result = "";

            //get key length
            int keyLength = encryptionTable.Count();

            //encrypt each symbol
            for (int x = 0; x < original.Length; x++)
            {
                int currentRow = x % keyLength;

                char currentSymbol = original[x];

                int symbolPosInEncTable = 0;

                foreach(var symbol in encryptionTable[currentRow])
                {
                    if(symbol == currentSymbol)
                    {
                        break;
                    }
                    symbolPosInEncTable++;
                }

                char addSymbol = _symbolsChecker.Alphabet[symbolPosInEncTable];
                result = result + addSymbol;
            }

            return result;
        }
    }
}
