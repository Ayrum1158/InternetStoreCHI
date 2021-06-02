using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ICryptor
    {
        string Encrypt(string strToEncrypt);
        bool DecryptAndCompare(string strToDecrypt, string strToCompare);
    }
}
