using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces
{
    public interface IDecryptor
    {
        string Decrypt(string encrypted, string key);
    }
}
