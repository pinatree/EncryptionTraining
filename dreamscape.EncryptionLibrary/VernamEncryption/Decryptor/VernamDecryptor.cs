using dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces;
using System.Collections.Generic;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.VernamEncryption.Decryptor
{
    public class VernamDecryptor : IDecryptor
    {
        public const string ALPHABET = "абвгдежзийклмнопрстуфхцчшщъыьэюя";

        public string Decrypt(string encrypted, string key)
        {
            int[] decryptedIntArr = new int[encrypted.Length];

            List<int> int_cipher_vernam = new List<int>(encrypted.Length);
            
            foreach(char symbol in encrypted)
            {
                int_cipher_vernam.Add(ALPHABET.IndexOf(symbol));
            }

            string decrypted = "";

            for (int i = 0; i < encrypted.Length; i++)
            {
                for (int j = 0; j < ALPHABET.Length; j++)
                {
                    for (int kj = 0; kj < ALPHABET.Length; kj++)
                    {
                        if ((encrypted[i].Equals(ALPHABET[j])) & (key[i].Equals(ALPHABET[kj])))
                        {
                            decryptedIntArr[i] = int_cipher_vernam[i] ^ kj;
                            //deciphermessage[i] = ALPHABET[int_deciphermessage[i]];
                            decrypted = decrypted + ALPHABET[decryptedIntArr[i]];
                            //Console.Write(deciphermessage[i]);
                        }
                    }
                }
            }
            return decrypted;
        }
    }
}
