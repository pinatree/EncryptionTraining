using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.TranspositionEncryption.Helpers
{
    public static class SpacePlaceholder
    {
        public static string GetSpaceFilled(string input, int keyLen)
        {
            if (keyLen < 1)
                throw new ArgumentOutOfRangeException("Key length must be 1 or more");

            if( (input == null) || (input == string.Empty) )
                throw new ArgumentOutOfRangeException("Input must be not null and not empty string");

            int div = input.Count() % keyLen;

            if (div == 0)
            {
                return input;
            }
            else
            {
                int needSpaces = keyLen - div;
                for (int x = 0; x < needSpaces; x++)
                {
                    input = input + " ";
                }

                return input;
            }                
        }
    }
}
