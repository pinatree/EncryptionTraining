using dreamscape.EncryptionTraining.EncryptionLibrary.FeistelEncryption.Helpers;
using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.FeistelEncryption.Decryptor
{
    public class FeistelDecryptor : IDecryptor
    {
        public string Decrypt(string encrypted, string key)
        {
            //Длина ключа
            int keylength = key.Length;

            //Ключ в виде массива символов
            char[] char_key = new char[keylength];

            //ключ в виде массива чисел???
            int[] int_key = new int[keylength];

            //int msglength = -1;
            //char[] char_message = null;

            char[] char_message = DataSerializer.DeserializeFromString<char[]>(encrypted);

            int[] int_message = new int[char_message.Length];

            int msglength = char_message.Length;
            for(int x = 0; x < char_message.Length; x++)
            {
                int_message[x] = char_message[x];
            }
            
            ////Если длина сообщения нечетная, то добавляем 1 к длине сообщения (чтобы могли распарсить)
            //if (encrypted.Length % 2 == 1)
            //{
            //    msglength = encrypted.Length + 1;
            //    char_message = new char[msglength];
            //    int_message = new int[msglength];
            //    char_message[msglength - 1] = '.';
            //}
            //else
            //{
            //    msglength = encrypted.Length;
            //    char_message = new char[msglength];
            //    int_message = new int[msglength];
            //}

            char[] char_message_left = new char[msglength / 2];
            char[] char_message_right = new char[msglength / 2];
            int[] int_message_left = new int[msglength / 2];
            int[] int_message_right = new int[msglength / 2];
            int count = 0;

            //Console.WriteLine("Зашифрованное сообщение в двоичном виде");
            for (int i = 0; i < msglength; i++)
            {
                Console.Write(Convert.ToString(int_message[i], 2) + " ");

            }
            Console.WriteLine();


            for (int i = 0; i < msglength / 2; i++)
            {
                char_message_left[i] = char_message[i];
                int_message_left[i] = char_message_left[i];
                char_message_right[i] = char_message[i + (msglength / 2)];
                int_message_right[i] = char_message_right[i];
            }

            int[] int_temp = new int[msglength / 2];
            char[] temp = new char[msglength / 2];

            for (int j = keylength - 1; j >= 0; j--)
            {

                int int_keys_letter = key[j];
                count = 0;


                for (int i = 0; i < msglength / 2; i++)
                {
                    if (count == (msglength / 2 - 1))
                    {
                        int_message_left[i] = int_message_left[i] ^ int_keys_letter;
                        int_message_left[i] = int_message_right[i] ^ int_message_left[i];

                    }
                    else
                    {
                        int_message_left[i] = int_message_left[i] ^ 0;
                        int_message_left[i] = int_message_right[i] ^ int_message_left[i];

                    }
                    char_message_left[i] = (char)int_message_left[i];
                    count++;
                }

                for (int i = 0; i < msglength / 2; i++)
                {
                    temp[i] = char_message_right[i];
                    int_temp[i] = int_message_right[i];
                    char_message_right[i] = char_message_left[i];
                    int_message_right[i] = int_message_left[i];
                    char_message_left[i] = temp[i];
                    int_message_left[i] = int_temp[i];

                }

                for (int i = 0; i < msglength / 2; i++)
                {
                    char_message[i] = char_message_left[i];
                    char_message[i + (msglength / 2)] = char_message_right[i];
                    int_message[i] = int_message_left[i];
                    int_message[i + (msglength / 2)] = int_message_right[i];
                }
            }

            return new string(char_message);

        }
    }
}
