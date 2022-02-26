using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers
{
    public class VigenereSymbolsChecker
    {
        public char StartPos { get; private set; }
        public int StartPosInt { get; private set; }

        public char EndPos { get; private set; }
        public int EndPosInt { get; private set; }

        public int AlphabetLen { get; private set; }

        public VigenereSymbolsChecker(char startPos, char endPos)
        {
            this.StartPos = startPos;
            this.StartPosInt = Convert.ToInt32(startPos);

            this.EndPos = endPos;
            this.EndPosInt = Convert.ToInt32(EndPosInt);

            this.AlphabetLen = EndPos - StartPos + 1;
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
