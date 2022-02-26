using System;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers
{
    public class VigenereSymbolsHelper
    {
        public char StartPos { get; private set; }

        public char EndPos { get; private set; }

        public int AlphabetLen { get; private set; }

        public char[] Alphabet { get; }

        public VigenereSymbolsHelper(char startPos, char endPos)
        {
            this.StartPos = startPos;

            this.EndPos = endPos;

            this.AlphabetLen = EndPos - StartPos + 1;

            Alphabet = new char[endPos - startPos + 1];

            for (int x = 0; x <= (endPos - startPos); x++)
            {
                Alphabet[x] = Convert.ToChar(startPos + x);
            }
        }

        public char GetSymbolWithOffset(char symbol, int offset)
        {
            int symbolPos = Convert.ToInt32(symbol);

            int nextSymbolPos = symbolPos + offset;

            if ((nextSymbolPos >= StartPos) && (nextSymbolPos <= EndPos))
                return Convert.ToChar(nextSymbolPos);

            int overflow = nextSymbolPos - EndPos - 1;
            overflow = overflow % (AlphabetLen);

            return Convert.ToChar(StartPos + overflow);
        }

        //Check all symbols in string are between start and end
        public bool CheckStrIsValid(string check)
        {
            foreach (char symbol in check)
            {
                bool charIsValid = CheckSymbolBetween(symbol);

                if (charIsValid == false)
                    return false;
            }

            return true;
        }

        //Check symbol between start and end
        public bool CheckSymbolBetween(int check)
        {
            return ((check >= StartPos) && (check <= EndPos));
        }

        //Check symbol between start and end
        public bool CheckSymbolBetween(char check)
        {
            int converted = Convert.ToInt32(check);
            return CheckSymbolBetween(converted);
        }
    }
}
