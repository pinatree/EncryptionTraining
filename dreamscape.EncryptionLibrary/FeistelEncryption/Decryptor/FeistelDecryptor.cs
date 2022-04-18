using dreamscape.EncryptionTraining.EncryptionLibrary.FeistelEncryption.Helpers;
using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.FeistelEncryption.Decryptor
{
    public class FeistelDecryptor : IDecryptor
    {
        public string Decrypt(string encrypted, string key)
        {
            //Длина ключа
            int keylength = key.Length;

            //Ключ в виде массива символов
            char[] keySymbols = new char[keylength];
            //Ключ в виде массива чисел
            int[] keyIntCodes = new int[keylength];

            char[] messageSymbols = DataSerializer.DeserializeFromString<char[]>(encrypted);
            int[] messageIntCodes = new int[messageSymbols.Length];
            int msglength = messageSymbols.Length;

            for(int x = 0; x < messageSymbols.Length; x++)
            {
                messageIntCodes[x] = messageSymbols[x];
            }

            char[] messageLeftSymbols = new char[msglength / 2];
            char[] messageRightSymbols = new char[msglength / 2];
            int[] messageLeftIntCodes = new int[msglength / 2];
            int[] messageRightIntCodes = new int[msglength / 2];

            for (int x = 0; x < msglength / 2; x++)
            {
                messageLeftSymbols[x] = messageSymbols[x];
                messageLeftIntCodes[x] = messageLeftSymbols[x];
                messageRightSymbols[x] = messageSymbols[x + (msglength / 2)];
                messageRightIntCodes[x] = messageRightSymbols[x];
            }

            int[] halfIntCodes = new int[msglength / 2];
            char[] halfSymbols = new char[msglength / 2];

            for (int x = keylength - 1; x >= 0; x--)
            {
                int int_keys_letter = key[x];
                int resultCount = 0;

                for (int y = 0; y < msglength / 2; y++)
                {
                    if (resultCount == (msglength / 2 - 1))
                    {
                        messageLeftIntCodes[y] = messageLeftIntCodes[y] ^ int_keys_letter;
                        messageLeftIntCodes[y] = messageRightIntCodes[y] ^ messageLeftIntCodes[y];
                    }
                    else
                    {
                        messageLeftIntCodes[y] = messageLeftIntCodes[y] ^ 0;
                        messageLeftIntCodes[y] = messageRightIntCodes[y] ^ messageLeftIntCodes[y];
                    }
                    messageLeftSymbols[y] = (char)messageLeftIntCodes[y];
                    resultCount++;
                }

                for (int y = 0; y < msglength / 2; y++)
                {
                    halfSymbols[y] = messageRightSymbols[y];
                    halfIntCodes[y] = messageRightIntCodes[y];
                    messageRightSymbols[y] = messageLeftSymbols[y];
                    messageRightIntCodes[y] = messageLeftIntCodes[y];
                    messageLeftSymbols[y] = halfSymbols[y];
                    messageLeftIntCodes[y] = halfIntCodes[y];
                }

                for (int y = 0; y < msglength / 2; y++)
                {
                    messageSymbols[y] = messageLeftSymbols[y];
                    messageSymbols[y + (msglength / 2)] = messageRightSymbols[y];
                    messageIntCodes[y] = messageLeftIntCodes[y];
                    messageIntCodes[y + (msglength / 2)] = messageRightIntCodes[y];
                }
            }

            return new string(messageSymbols);
        }
    }
}
