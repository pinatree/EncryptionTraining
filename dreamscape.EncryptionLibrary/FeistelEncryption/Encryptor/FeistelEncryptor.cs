using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
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
            char[] keySymbols = new char[keylength];
            //Ключ в виде массива чисел
            int[] keyIntCodes = new int[keylength];

            int msglength = -1;
            //Сообщение в виде массива символов
            char[] messageSymbols;
            //Сообщение в виде массива чисел
            int[] messageIntCodes;

            //Шифр фейстеля работает с 2 половинами. Если длина сообщения нечетная,
            //то добавляем 1 к длине сообщения
            if (original.Length % 2 == 1)
            {
                msglength = original.Length + 1;
                messageSymbols = new char[msglength];
                messageIntCodes = new int[msglength];

                //Докидываем пробел для четности
                messageSymbols[msglength - 1] = ' ';
            }
            else
            {
                msglength = original.Length;
                messageSymbols = new char[msglength];
                messageIntCodes = new int[msglength];
            }

            //Левая часть сообщения
            char[] messageLeftSymbols = new char[msglength / 2];
            int[] messageLeftIntCodes = new int[msglength / 2];

            //Правая часть сообщения
            char[] messageRightSymbols = new char[msglength / 2];
            int[] messageRightIntCodes = new int[msglength / 2];

            //Записываем сообщение в массивы
            for (int x = 0; x < original.Length; x++)
            {
                messageSymbols[x] = original[x];
                messageIntCodes[x] = original[x];
            }

            //Записываем ключ в массивы
            for (int x = 0; x < keylength; x++)
            {
                keySymbols[x] = key[x];
                keyIntCodes[x] = key[x];
            }

            //Заполнение левой части
            for (int x = 0; x < msglength / 2; x++)
            {
                messageLeftSymbols[x] = messageSymbols[x];
                messageLeftIntCodes[x] = messageSymbols[x];
            }

            //Заполнение правой части
            for (int x = 0; x < msglength / 2; x++)
            {
                messageRightSymbols[x] = messageSymbols[x + (msglength / 2)];
                messageRightIntCodes[x] = messageSymbols[x + (msglength / 2)];
            }

            //Массивы размерностью в половину сообщения
            int[] halfIntCodes = new int[msglength / 2];
            char[] halfSymbols = new char[msglength / 2];

            //Проходимся всей длине ключа
            for (int x = 0; x < keylength; x++)
            {
                //Текущий символ ключа
                int currentKeySymbol = key[x];

                //Считаем записанные символы
                int resultCount = 0;

                //Первую половину сообщения в буффер
                for (int y = 0; y < msglength / 2; y++)
                {
                    halfSymbols[y] = messageLeftSymbols[y];
                    halfIntCodes[y] = messageLeftIntCodes[y];
                }

                //Цикл до конца 1 половины. Шифруем левую половину по правой
                for (int y = 0; y < msglength / 2; y++)
                {
                    //Если этот символ - последний
                    if (resultCount == (msglength / 2 - 1))
                    {
                        //^ - это XOR
                        messageLeftIntCodes[y] = messageLeftIntCodes[y] ^ currentKeySymbol;
                        messageLeftIntCodes[y] = messageRightIntCodes[y] ^ messageLeftIntCodes[y];
                    }
                    else
                    {
                        //^ - это XOR
                        messageLeftIntCodes[y] = messageLeftIntCodes[y] ^ 0;
                        messageLeftIntCodes[y] = messageLeftIntCodes[y] ^ messageRightIntCodes[y];
                    }
                    messageLeftSymbols[y] = (char)messageLeftIntCodes[y];
                    resultCount++;
                }

                //Кодируем правую часть сообщения
                for (int y = 0; y < msglength / 2; y++)
                {
                    messageRightSymbols[y] = halfSymbols[y];
                    messageRightIntCodes[y] = halfIntCodes[y];
                }

                //Записываем заширофванное сообщение в результат
                for (int y = 0; y < msglength / 2; y++)
                {
                    messageSymbols[y] = messageLeftSymbols[y];
                    messageSymbols[y + (msglength / 2)] = messageRightSymbols[y];
                    messageIntCodes[y] = messageLeftIntCodes[y];
                    messageIntCodes[y + (msglength / 2)] = messageRightIntCodes[y];
                }
            }

            //Зашифрованные данные хранятся в бинарном виде, поэтому
            //сериализуем массив в строку
            return DataSerializer.SerializeToString(messageSymbols);
        }
    }
}
