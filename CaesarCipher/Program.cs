using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            CaesarCiph cipherObj = GetCipherInput();

            EncodeDecode(cipherObj);
            Console.ReadLine();
        }

        private static void EncodeDecode(CaesarCiph cipherObj)
        {
            Console.WriteLine("Please input the text to encode");
            string text = Console.ReadLine().ToUpper();

            char[] cypherChar = cipherObj.CypherString(text.ToCharArray()).ToCharArray();
            Console.WriteLine(cypherChar);
            Console.WriteLine(cipherObj.DecipherString(cypherChar));
        }

        private static CaesarCiph GetCipherInput()
        {
            Console.WriteLine("Please input the alphabets for the Cipher: ");
            string alpha = Console.ReadLine().ToUpper();
            Console.WriteLine("Please input the offset for the Cipher: ");
            int offset = 0;
            int.TryParse(Console.ReadLine(), out offset);

            CaesarCiph cipherObj = new CaesarCiph(alpha);
            cipherObj.SetOffset(offset);
            List<CharCipher> ccList;
            cipherObj.GenerateCipher();
            cipherObj.PrintList();
            return cipherObj;
        }
    }
}
