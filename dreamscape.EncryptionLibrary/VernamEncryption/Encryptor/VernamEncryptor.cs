using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using System;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.VernamEncryption.Encryptor
{
    public class VernamEncryptor : IEncryptor
    {
        public const string ALPHABET = "абвгдежзийклмнопрстуфхцчшщъыьэюя";

        public string Encrypt(string original, string key)
        {
            Random random = new Random();

            int[] messageIntSymbols = new int[original.Length];
            char[] key_vernam = new char[original.Length];
            int[] index_letter_key_vernam = new int[original.Length];
            char[] cipher_vernam = new char[original.Length];
            int[] int_cipher_vernam = new int[original.Length];

            string result_key = "";
            for (int i = 0; i < original.Length; i++)
            {
                index_letter_key_vernam[i] = random.Next(0, 32);
                key_vernam[i] = ALPHABET[index_letter_key_vernam[i]];
                messageIntSymbols[i] = original[i];
                result_key = result_key + key_vernam[i];
            }

            string result_encrypted = "";

            //Шифрование
            for (int i = 0; i < original.Length; i++)
            {
                for (int j = 0; j < ALPHABET.Length; j++)
                {
                    for (int kj = 0; kj < ALPHABET.Length; kj++)
                    {
                        if ((original[i].Equals(ALPHABET[j])) & (key_vernam[i].Equals(ALPHABET[kj])))
                        {
                            int_cipher_vernam[i] = j ^ kj;
                            cipher_vernam[i] = ALPHABET[int_cipher_vernam[i]];
                            result_encrypted = result_encrypted + cipher_vernam[i];
                        }
                    }
                }
            }

            return result_encrypted + "|" + result_key;
        }
    }
}
