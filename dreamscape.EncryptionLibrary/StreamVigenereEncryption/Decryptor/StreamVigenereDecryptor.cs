using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using dreamscape.EncryptionTraining.EncryptionLibrary.ViginereEncryption.Helpers;
using System;
using System.Collections.Generic;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.StreamVigenereEncryption.Decryptor
{
    public class StreamVigenereDecryptor : IDecryptor
    {
        //Алфавит для таблицы виженера
        public const string ALPHABET = "абвгдежзийклмнопрстуфхцчшщъыьэюя";

        public string Decrypt(string original, string key)
        {
            original = original.Trim();

            string autokey = key + original;

            //Длина ключа
            int countKey = autokey.Length;
            //Длина сообщения
            int countMsg = original.Length;

            int countLines;

            //Фиг пойми что
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

            char[,] DeCipher = new char[countLines, countKey];

            //Генерим таблицу дешифровки Виженера
            //for (int j = 0; j < countKey; j++)
            //{
            //    int Step = 0;
            //    for (int k = 0; k < (ALPHABET.Length); k++)
            //    {
            //        if (key[j] == ALPHABET[k])
            //        {
            //            Step = k;
            //        }
            //    }

            //    for (int i = 1; i < countLines; i++)
            //    {
            //        int LetterIndex = 0;
            //        for (int k = 0; k < (ALPHABET.Length); k++)
            //        {
            //            if (DeCipher[i, j] == ALPHABET[k])
            //            {
            //                LetterIndex = k;
            //            }
            //        }
            //        if ((LetterIndex - Step) < 0)
            //        {
            //            if (DeCipher[i, j] != ' ')
            //            {
            //                DeCipher[i, j] = ALPHABET[LetterIndex - Step + 32];
            //            }
            //        }
            //        else
            //        {
            //            if (DeCipher[i, j] != ' ')
            //            {
            //                DeCipher[i, j] = ALPHABET[LetterIndex - Step];
            //            }
            //        }
            //        key = key + DeCipher[i, j];
            //        DeCipher[0, j] = key[j];

            //    }
            //}

            string decipherkey = key;

            //Указываем первый символ, для старта дешифрования
            DeCipher[0, 0] = decipherkey[0];

            //Заполняем зачем-то звездочками. Может, убрать это?
            for (int j = 1; j < countKey; j++)
            {
                DeCipher[0, j] = '*';
            }

            for (int i = 1; i < countLines; i++)
            {
                for (int j = 0; j < countKey; j++)
                {
                    if (j < original.Length)
                        DeCipher[i, j] = original[j];
                    else
                        DeCipher[i, j] = ' ';
                }
            }

            for (int j = 0; j < countKey; j++)
            {
                int Step = 0;
                for (int k = 0; k < (ALPHABET.Length); k++)
                {
                    if (decipherkey[j] == ALPHABET[k])
                    {
                        Step = k;
                    }
                }

                for (int i = 1; i < countLines; i++)
                {
                    int LetterIndex = 0;
                    for (int k = 0; k < (ALPHABET.Length); k++)
                    {
                        if (DeCipher[i, j] == ALPHABET[k])
                        {
                            LetterIndex = k;
                        }
                    }
                    if ((LetterIndex - Step) < 0)
                    {
                        if (DeCipher[i, j] != ' ')
                        {
                            DeCipher[i, j] = ALPHABET[LetterIndex - Step + 32];
                        }
                    }
                    else
                    {
                        if (DeCipher[i, j] != ' ')
                        {
                            DeCipher[i, j] = ALPHABET[LetterIndex - Step];
                        }
                    }
                    decipherkey = decipherkey + DeCipher[i, j];
                    DeCipher[0, j] = decipherkey[j];

                }
            }


            Console.WriteLine("Результат дешифрования (первый набор символов-ключ)");

            List<char> decResult = new List<char>(countKey);

            for (int i = 0; i < countLines; i++)
            {
                for (int j = 0; j < countKey; j++)
                {
                    if (i == 1)
                        decResult.Add(DeCipher[i, j]);
                }
                Console.Write(" ");
            }

            //Достаем дешифрованное сообщение
            string vigenereDecryptionResult = new string(decResult.ToArray());

            return vigenereDecryptionResult;
        }
    }
}
