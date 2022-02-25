using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using dreamscape.EncryptionTraining.EncryptionLibrary.TranspositionEncryption.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.TranspositionEncryption
{
    public sealed class TranspositionEncryptor : IEncryptor
    {
        public string Encrypt(string originalVal, string key)
        {
            originalVal = SpacePlaceholder.GetSpaceFilled(originalVal, key.Length);

            DataTable tabularString = GetTabularString(originalVal, key.Length);

            DataTable replacedTabularString = GetReplacedTabularString(tabularString, key);

            string encryptedText = GetEncryptedString(replacedTabularString);

            return encryptedText;
        }

        private DataTable GetTabularString(string originalVal, int keyLength)
        {
            int rowsCount = originalVal.Length / keyLength;

            if (originalVal.Length % keyLength != 0)
                rowsCount++;

            //Fill empty columns
            DataTable result = new DataTable();
            for (int x = 0; x < keyLength; x++)
            {
                result.Columns.Add();
            }

            for (int x = 0; x < rowsCount; x++)
            {
                DataRow dataRow = result.NewRow();

                List<char> row = originalVal.Skip(x * keyLength).Take(keyLength).ToList();

                for (int y = 0; y < row.Count(); y++)
                {
                    dataRow[y] = row[y];
                }
                result.Rows.Add(dataRow);
            }

            return result;
        }

        private DataTable GetReplacedTabularString(DataTable tabularString, string key)
        {
            List<SymbolPosition> symbolPositions = new List<SymbolPosition>();

            for (int x = 0; x < key.Length; x++)
            {
                SymbolPosition symbolPosition = new SymbolPosition();
                symbolPosition.OldPosition = x;
                symbolPosition.Symbol = key[x].ToString();

                symbolPositions.Add(symbolPosition);
            }

            symbolPositions = symbolPositions.OrderBy(x => x.Symbol).ToList();

            DataTable result = tabularString.Copy();

            for (int x = 0; x < symbolPositions.Count; x++)
            {
                var posForReplace = symbolPositions[x];

                for (int y = 0; y < tabularString.Rows.Count; y++)
                {
                    result.Rows[y][x] = tabularString.Rows[y][posForReplace.OldPosition];
                }
            }

            return result;
        }

        private string GetEncryptedString(DataTable replacedTable)
        {
            string result = "";

            for (int x = 0; x < replacedTable.Columns.Count; x++)
            {
                for (int y = 0; y < replacedTable.Rows.Count; y++)
                {
                    result = result + replacedTable.Rows[y][x];
                }
            }

            return result;
        }


    }
}
