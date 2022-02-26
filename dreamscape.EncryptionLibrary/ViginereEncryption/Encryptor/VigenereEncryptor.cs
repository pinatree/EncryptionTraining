using System;
using System.Linq;

using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Encryptor
{
    public class VigenereEncryptor : IEncryptor
    {
        private VigenereSymbolsHelper _symbolsChecker;

        public VigenereEncryptor(char alphabetStart = 'A', char alphabetEnd = 'Z')
        {
            _symbolsChecker = new VigenereSymbolsHelper(alphabetStart, alphabetEnd);
        }

        public string Encrypt(string original, string key)
        {
            string upperCase = VigenereStringConverter.SetToUpperCase(original);

            bool stringIsValid = _symbolsChecker.CheckStrIsValid(original);

            if (stringIsValid == false)
                throw new ArgumentException("Строка содержит недопустимые символы.");

            char[][] encryptTable = EncryptTableGenerator.GetEncryptionTable(key, _symbolsChecker);

            string encrypted = GetEncryptedString(original, encryptTable);

            return encrypted;
        }

        public string GetEncryptedString(string original, char[][] encryptionTable)
        {
            string result = "";

            //get key length
            int keyLength = encryptionTable.Count();

            //encrypt each symbol
            for(int x = 0; x < original.Length; x++)
            {
                int currentRow = x % keyLength;

                char currentSymbol = original[x];
                
                int currentColumn = Convert.ToInt32(currentSymbol) - _symbolsChecker.StartPos;

                char addSymbol = encryptionTable[currentRow][currentColumn];
                result = result + addSymbol;
            }

            return result;
        }
    }
}
