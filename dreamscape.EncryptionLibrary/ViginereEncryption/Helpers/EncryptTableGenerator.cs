using System;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers
{
    public static class EncryptTableGenerator
    {
        public static char[][] GetEncryptionTable(string key, VigenereAlphabetHelper helper)
        {
            //output
            char[][] result = new char[key.Length][];

            //fill table
            for (int x = 0; x < key.Length; x++)
            {
                //current symbol
                char currentSymbol = key[x];

                //Get the alphabet starting with this character
                char[] alphabetString = GenerateAlphabetFromPos(currentSymbol, helper);

                //put it into result table
                result[x] = alphabetString;
            }

            return result;
        }

        public static char[] GenerateAlphabetFromPos(char firstSymbol, VigenereAlphabetHelper helper)
        {
            //output array
            char[] result = new char[helper.AlphabetLen];

            //convert input char to integer
            int firstSymbol_intVal = Convert.ToInt32(firstSymbol);

            //new alphabet starts from input symbol
            result[0] = firstSymbol;

            //fill new alphabet
            for (int x = 1; x < helper.AlphabetLen; x++)
            {
                //get next symbol with offset
                char symbolWithOffset = helper.GetSymbolWithOffset(firstSymbol, x);

                result[x] = symbolWithOffset;
            }

            return result;
        }

        public static char[] GenerateAlphabetFromPosPlusOne(char firstSymbol, VigenereAlphabetHelper helper)
        {
            //output array
            char[] result = new char[helper.AlphabetLen + 1];

            //convert input char to integer
            int firstSymbol_intVal = Convert.ToInt32(firstSymbol);

            //new alphabet starts from input symbol
            result[0] = firstSymbol;

            //fill new alphabet
            for (int x = 1; x <= helper.AlphabetLen; x++)
            {
                //get next symbol with offset
                char symbolWithOffset = helper.GetSymbolWithOffset(firstSymbol, x);

                result[x] = symbolWithOffset;
            }

            return result;
        }

    }
}
