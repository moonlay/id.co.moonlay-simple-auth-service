using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Utilities
{
    public class SHA1Encrypt
    {
        public static string Hash(string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.ASCII.GetBytes(input));
            return string.Concat(hash.Select(x => x.ToString("x2")));
        }
    }
}
