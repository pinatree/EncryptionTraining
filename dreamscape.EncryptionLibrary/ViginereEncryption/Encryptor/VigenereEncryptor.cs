using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Encryptor
{
    public class VigenereEncryptor : IEncryptor
    {
        private VigenereSymbolsChecker _symbolsChecker;

        public VigenereEncryptor(char alphabetStart = 'A', char alphabetEnd = 'Z')
        {
            _symbolsChecker = new VigenereSymbolsChecker(alphabetStart, alphabetEnd);
        }

        public string Encrypt(string original, string key)
        {
            throw new NotImplementedException();
        }

        public string SetToUpperCase(string input) => input.ToUpper();
                
        public char[] GenerateAlphabetFromPos(char firstSymbol)
        {
            //output array
            char[] result = new char[_symbolsChecker.AlphabetLen];

            //convert input char to integer
            int firstSymbol_intVal = Convert.ToInt32(firstSymbol);

            //new alphabet starts from input symbol
            result[0] = firstSymbol;

            //fill new alphabet
            for (int x = 1; x < _symbolsChecker.AlphabetLen; x++)
            {
                //get next symbol with offset
                char symbolWithOffset = GetSymbolWithOffset(firstSymbol, x);

                result[x] = symbolWithOffset;
            }

            return result;
        }

        public char GetSymbolWithOffset(char symbol, int offset)
        {
            int symbolPos = Convert.ToInt32(symbol);

            int nextSymbolPos = symbolPos + offset;

            if ((nextSymbolPos >= _symbolsChecker.StartPos) && (nextSymbolPos <= _symbolsChecker.EndPos))
                return Convert.ToChar(nextSymbolPos);

            int overflow = nextSymbolPos - _symbolsChecker.EndPos - 1;
            overflow = overflow % (_symbolsChecker.AlphabetLen);

            return Convert.ToChar(_symbolsChecker.StartPos + overflow);
        }

        public char[][] GetEncryptionTable(string key)
        {
            //output
            char[][] result = new char[key.Length][];

            //fill table
            for (int x = 0; x < key.Length; x++)
            {
                char keySymbol = key[x];
                char[] alphabetString = GenerateAlphabetFromPos(keySymbol);
                result[x] = alphabetString;
            }

            return result;
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
                int currentColumn = x % _symbolsChecker.AlphabetLen;

                char addSymbol = encryptionTable[currentRow][currentColumn];
                result = result + addSymbol;
            }

            return result;
        }
    }
}
