using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using System;
using dreamscape.EncryptionTraining.EncryptionLibrary.FeistelEncryption.Helpers;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.FeistelEncryption.Encryptor
{
    public class FeistelEncryptor : IEncryptor
    {
        public string Encrypt(string original, string key)
        {
            //Длина ключа
            int keylength = key.Length;

            //Ключ в виде массива символов
            char[] char_key = new char[keylength];

            //ключ в виде массива чисел???
            int[] int_key = new int[keylength];

            int msglength = -1;
            char[] char_message = null;
            int[] int_message = null;

            //Если длина сообщения нечетная, то добавляем 1 к длине сообщения (чтобы могли распарсить)
            if (original.Length % 2 == 1)
            {
                msglength = original.Length + 1;
                char_message = new char[msglength];
                int_message = new int[msglength];

                //Докидываем точку, чтобы было четное
                char_message[msglength - 1] = '.';
            }
            else
            {
                msglength = original.Length;
                char_message = new char[msglength];
                int_message = new int[msglength];
            }


            //Обрабатываем

            //Левая часть сообщения
            char[] char_message_left = new char[msglength / 2];
            int[] int_message_left = new int[msglength / 2];

            //Правая часть сообщения
            char[] char_message_right = new char[msglength / 2];
            int[] int_message_right = new int[msglength / 2];

            //Преобразуем сообщение в массивы
            Console.WriteLine("Сообщение в двоичном виде");
            for (int i = 0; i < original.Length; i++)
            {
                char_message[i] = original[i];
                int_message[i] = char_message[i];

                Console.Write(Convert.ToString(int_message[i], 2) + " ");
            }

            //Преобразуем ключ в массивы
            Console.WriteLine();
            Console.WriteLine("Ключ в двоичном виде");
            for (int j = 0; j < keylength; j++)
            {
                char_key[j] = key[j];
                int_key[j] = char_key[j];

                Console.Write(Convert.ToString(int_key[j], 2) + " ");
            }
            Console.WriteLine();

            //Заполнение левой части
            for (int i = 0; i < msglength / 2; i++)
            {
                char_message_left[i] = char_message[i];
                int_message_left[i] = char_message_left[i];
            }

            //Заполнение правой части
            for (int i = 0; i < msglength / 2; i++)
            {
                char_message_right[i] = char_message[i + (msglength / 2)];
                int_message_right[i] = char_message[i + (msglength / 2)];
            }

            //ок, верим, что тут все было сделано правильно
            //Console.Write(char_message_left);
            //Console.WriteLine(char_message_right);

            //Массивы размерностью в половину сообщения
            int[] int_temp = new int[msglength / 2];
            char[] temp = new char[msglength / 2];


            Console.WriteLine();
            Console.WriteLine("Шифрование");

            //Проходимся всей длине ключа
            for (int j = 0; j < keylength; j++)
            {
                //Текущий символ ключа
                int int_keys_letter = key[j];

                int count = 0;

                //Первую половину сообщения в буффер
                for (int i = 0; i < msglength / 2; i++)
                {
                    temp[i] = char_message_left[i];
                    int_temp[i] = int_message_left[i];
                }

                //Цикл до конца 1 половины. Шифруем левую половину по правой
                for (int i = 0; i < msglength / 2; i++)
                {
                    //Если этот символ - последний
                    if (count == (msglength / 2 - 1))
                    {
                        //^ - это XOR
                        int_message_left[i] = int_message_left[i] ^ int_keys_letter;
                        int_message_left[i] = int_message_right[i] ^ int_message_left[i];
                    }
                    else
                    {
                        //^ - это XOR
                        int_message_left[i] = int_message_left[i] ^ 0;
                        int_message_left[i] = int_message_left[i] ^ int_message_right[i];
                    }
                    char_message_left[i] = (char)int_message_left[i];
                    count++;
                }

                //Кодируем правую часть сообщения
                for (int i = 0; i < msglength / 2; i++)
                {
                    char_message_right[i] = temp[i];
                    int_message_right[i] = int_temp[i];
                }

                //Записываем заширофванное сообщение в результат
                for (int i = 0; i < msglength / 2; i++)
                {
                    char_message[i] = char_message_left[i];
                    char_message[i + (msglength / 2)] = char_message_right[i];
                    int_message[i] = int_message_left[i];
                    int_message[i + (msglength / 2)] = int_message_right[i];
                }
                Console.Write(char_message_left);
                Console.WriteLine(char_message_right);
                Console.WriteLine();
            }

            return DataSerializer.SerializeToString<char[]>(char_message);
        }
    }
}
