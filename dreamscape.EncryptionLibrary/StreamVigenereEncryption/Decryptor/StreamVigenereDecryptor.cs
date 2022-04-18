using System.Collections.Generic;
using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.StreamVigenereEncryption.Decryptor
{
    public class StreamVigenereDecryptor : IDecryptor
    {
        //Алфавит для таблицы виженера
        public const string ALPHABET = "абвгдежзийклмнопрстуфхцчшщъыьэюя";

        public string Decrypt(string original, string key)
        {
            //Убираем ненужные пробелы
            original = original.Trim();

            string fullKey = key + original;

            //Длина ключа
            int keyLength = fullKey.Length;
            //Длина сообщения
            int messageLength = original.Length;

            //Таблица дешифровки
            char[,] decryptionTable = new char[2, keyLength];

            string decipherkey = key;

            //Указываем первый символ, для старта дешифрования
            decryptionTable[0, 0] = decipherkey[0];

            for (int x = 0; x < keyLength; x++)
            {
                if (x < original.Length)
                    decryptionTable[1, x] = original[x];
                else
                    decryptionTable[1, x] = ' ';
            }

            for (int x = 0; x < keyLength; x++)
            {
                int posInAlphabet = 0;
                for (int k = 0; k < ALPHABET.Length; k++)
                {
                    if (decipherkey[x] == ALPHABET[k])
                    {
                        posInAlphabet = k;
                    }
                }

                int indexInAlphabet = 0;
                for (int k = 0; k < ALPHABET.Length; k++)
                {
                    if (decryptionTable[1, x] == ALPHABET[k])
                    {
                        indexInAlphabet = k;
                    }
                }
                if ((indexInAlphabet - posInAlphabet) < 0)
                {
                    if (decryptionTable[1, x] != ' ')
                    {
                        decryptionTable[1, x] = ALPHABET[indexInAlphabet - posInAlphabet + 32];
                    }
                }
                else
                {
                    if (decryptionTable[1, x] != ' ')
                    {
                        decryptionTable[1, x] = ALPHABET[indexInAlphabet - posInAlphabet];
                    }
                }
                decipherkey = decipherkey + decryptionTable[1, x];
                decryptionTable[0, x] = decipherkey[x];
            }

            List<char> decResult = new List<char>(keyLength);
            for (int x = 0; x < keyLength; x++)
            {
                decResult.Add(decryptionTable[1, x]);
            }

            //Достаем дешифрованное сообщение
            string vigenereDecryptionResult = new string(decResult.ToArray());

            return vigenereDecryptionResult;
        }
    }
}
