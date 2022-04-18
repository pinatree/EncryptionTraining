using System.Collections.Generic;
using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.StreamVigenereEncryption.Encryptor
{
    //Потоковый шифр виженера
    public sealed class StreamVigenereEncryptor : IEncryptor
    {
        //Алфавит для таблицы виженера
        public const string ALPHABET = "абвгдежзийклмнопрстуфхцчшщъыьэюя";

        public string Encrypt(string original, string key)
        {
            //Убираем ненужные пробелы
            string message = original.Trim();

            //Строка шифрования для Виженера
            string fullKey = key + message;
            //Длина ключа
            int keyLength = fullKey.Length;
            //Длина сообщения
            int messageLength = message.Length;

            //Таблица шифрования (сопоставляем строки)
            char[,] encryptionTable = new char[2, keyLength];

            //цикл для ввода ключа в массив
            for (int x = 0; x < keyLength; x++)
            {
                encryptionTable[0, x] = fullKey[x];
            }

            //Записываем сообщение в 1 строку, до конца
            for (int x = 0; x < keyLength; x++)
            {
                if (x < messageLength)
                {
                    encryptionTable[1, x] = message[x];
                }
                else
                {
                    encryptionTable[1, x] = ' ';
                }
            }

            //Генерим таблицу Виженера
            char[,] vigenereTable = encryptionTable;
            for (int x = 0; x < keyLength; x++)
            {
                int posInAlphabet = 0;
                for (int y = 0; y < (ALPHABET.Length); y++)
                {
                    if (fullKey[x] == ALPHABET[y])
                    {
                        posInAlphabet = y;
                    }
                }

                int indexInAlphabet = 0;
                for (int k = 0; k < (ALPHABET.Length); k++)
                {
                    if (vigenereTable[1, x] == ALPHABET[k])
                    {
                        indexInAlphabet = k;
                    }
                }

                //Если заходим за алфавит - начинаем заново
                if ((posInAlphabet + indexInAlphabet) > 31)
                {
                    vigenereTable[1, x] = ALPHABET[posInAlphabet + indexInAlphabet - 32];
                }
                else
                {
                    if (vigenereTable[1, x] != ' ')
                    {
                        vigenereTable[1, x] = ALPHABET[posInAlphabet + indexInAlphabet];
                    }
                }
            }

            List<char> encResult = new List<char>(keyLength);

            for (int x = 0; x < keyLength; x++)
            {
                encResult.Add(vigenereTable[1, x]);
            }

            string vigenereEncryptionResult = new string(encResult.ToArray());

            return vigenereEncryptionResult;
        }
    }
}
