using ProjetoGusmaoFinal.Classes;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoGusmaoFinal.Services
{
    public class HashService
    {
        public static HashResponse Crypt(string Value)
        {
            HashResponse HashResponse = new();
            try
            {
                byte[] CryptedValue = SHA256.HashData(Encoding.UTF8.GetBytes(Value));
                HashResponse.Hash = Convert.ToBase64String(CryptedValue);
                HashResponse.Success = true;
                return HashResponse;
            }
            catch { 
                return HashResponse;
            }
        }
    }
}
