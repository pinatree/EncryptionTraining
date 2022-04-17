using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers;
using System.Collections.Generic;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.StreamVigenereEncryption.Encryptor
{
    //Потоковый шифр виженера
    public sealed class StreamVigenereEncryptor : IEncryptor
    {
        //Алфавит для таблицы виженера
        public const string ALPHABET = "абвгдежзийклмнопрстуфхцчшщъыьэюя";

        public string Encrypt(string original, string key)
        {
            string msg = "";
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] != ' ')
                {
                    msg = msg + original[i];
                }
            }

            //Строка шифрования для Виженера
            string autokey = key + msg;
            //Длина ключа
            int countKey = autokey.Length;
            //Длина сообщения
            int countMsg = msg.Length;

            int countLines;

            // Проверка количества строк (если последняя строка неполная - то берём 2
            // 1-строка ключ, и последняя строка будет утеряна из-за целочисленного деления,
            // иначе, если последняя строка будет полной, то добавляем только одну строку для ключа)
            if ((countMsg % countKey) != 0)
            {
                countLines = countMsg / countKey + 2;
            }
            else
            {
                countLines = countMsg / countKey + 1;
            }

            //Таблица шифрования Виженера
            char[,] keyAndMsg = new char[countLines, countKey];

            //цикл для ввода ключа в массив
            for (int j = 0; j < countKey; j++)
            {
                keyAndMsg[0, j] = autokey[j];
            }

            //цикл для вывода сообщения в виде массива
            //j начинается с "1", поскольку нулевой строкой будет служить ключ
            int SymbNumb = 0; // SymbNumb - индекс символа в первоначальном сообщении
            for (int i = 1; i < countLines; i++)
            {
                for (int j = 0; j < countKey; j++)
                {
                    if (SymbNumb < countMsg)        //проверка на наличие символа (касается последней строки)
                    {
                        keyAndMsg[i, j] = msg[SymbNumb];
                    }
                    else
                    {
                        keyAndMsg[i, j] = ' ';
                    }
                    SymbNumb++;
                }
            }

            //Переходим к шифрованию - дешифрованию

            //Шифрование Виженера

            char[,] Cipher = keyAndMsg;
            for (int j = 0; j < countKey; j++)
            {
                int Step = 0;
                for (int k = 0; k < (ALPHABET.Length); k++)
                {
                    if (autokey[j] == ALPHABET[k])
                    {
                        Step = k;
                    }
                }

                for (int i = 1; i < countLines; i++)
                {
                    int LetterIndex = 0;
                    for (int k = 0; k < (ALPHABET.Length); k++)
                    {
                        if (Cipher[i, j] == ALPHABET[k])
                        {
                            LetterIndex = k;
                        }
                    }
                    if ((Step + LetterIndex) > 31)
                    {
                        Cipher[i, j] = ALPHABET[Step + LetterIndex - 32];
                    }
                    else
                    {
                        if (Cipher[i, j] != ' ')
                        {
                            Cipher[i, j] = ALPHABET[Step + LetterIndex];
                        }
                    }

                }
            }

            List<char> encResult = new List<char>(countKey);

            for (int i = 0; i < countLines; i++)
            {
                for (int j = 0; j < countKey; j++)
                {
                    if (i == 1)
                        encResult.Add(Cipher[i, j]);
                }
            }

            string vigenereEncryptionResult = new string(encResult.ToArray());

            return vigenereEncryptionResult;

        }
    }
}
