using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.TranspositionEncryption
{
    public sealed class TranspositionDecryptor : IDecryptor
    {
        public string Decrypt(string encrypted, string key)
        {
            DataTable encryptedReplacedTabular = GetDecryptedTabular(encrypted, key.Length);
            DataTable restoredOrder = RestoreColumnsOrder(encryptedReplacedTabular, key);
            string decrypted = GetDecryptedString(restoredOrder);

            return decrypted;
        }

        private DataTable GetDecryptedTabular(string encryptedStr, int keyLength)
        {
            int rowsCount = encryptedStr.Length / keyLength;

            if (encryptedStr.Length % keyLength != 0)
                throw new ArgumentException("The number of characters must be a multiple of the key");

            DataTable result = new DataTable();
            for (int x = 0; x < keyLength; x++)
            {
                result.Columns.Add();
            }
            for (int x = 0; x < rowsCount; x++)
            {
                result.Rows.Add();
            }

            for (int x = 0; x < keyLength; x++)
            {
                var columnSymbols = encryptedStr.Skip(x * rowsCount).Take(rowsCount).ToList();

                for (int y = 0; y < rowsCount; y++)
                {
                    try
                    {
                        result.Rows[y][x] = columnSymbols[y];
                    }
                    catch(ArgumentOutOfRangeException)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        private DataTable RestoreColumnsOrder(DataTable mixed, string key)
        {
            List<SymbolPosition> symbolPositions = new List<SymbolPosition>();

            for (int x = 0; x < key.Length; x++)
            {
                SymbolPosition symbolPosition = new SymbolPosition();
                symbolPosition.OldPosition = x;
                symbolPosition.Symbol = key[x].ToString();

                symbolPositions.Add(symbolPosition);
            }

            //Получаем, какие позиции мы меняли
            symbolPositions = symbolPositions.OrderBy(x => x.Symbol).ToList();

            //Возвращаем позиции на место

            DataTable result = mixed.Copy();

            for (int x = 0; x < symbolPositions.Count; x++)
            {
                var posForReplace = symbolPositions[x];

                for (int y = 0; y < mixed.Rows.Count; y++)
                {
                    result.Rows[y][posForReplace.OldPosition] = mixed.Rows[y][x];
                }
            }

            return result;

        }

        private string GetDecryptedString(DataTable replacedTable)
        {
            string result = "";

            for (int x = 0; x < replacedTable.Rows.Count; x++)
            {
                for (int y = 0; y < replacedTable.Columns.Count; y++)
                {
                    result = result + replacedTable.Rows[x][y];
                }
            }

            return result;
        }
    }
}
