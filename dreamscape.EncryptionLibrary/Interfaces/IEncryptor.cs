using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dreamscape.EncryptionTraining.EncryptionLibrary.Interfaces
{
    public interface IEncryptor
    {
        string Encrypt(string original, string key);
    }
}
