using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class CaesarCiph
    {
        string alphabets;
        int offset;
        List<CharCipher> ccList { get; set; }

        public CaesarCiph(string alphabets)
        {
            if(alphabets.Length <=0)
            {
                throw new ArgumentException("Please provide alphabets as they can't be empty. ");
            }
            this.alphabets = alphabets;
        }
        
        public void SetOffset(int numOffset)
        {
            if(numOffset < 0)
            {
                throw new ArgumentException("The offset should be positive");
            }
            if(numOffset >= this.alphabets.Length)
            {
                throw new ArgumentException
                    ("The offset should be a number between 0 and {0}.",
                    ((this.alphabets.Length)-1).ToString());
            }
            this.offset = numOffset;

        }
        

        public void GenerateCipher()
        {
            List<CharCipher> CharCiphList = new List<CharCipher>();

            if (this.alphabets.Length > 0)
            {
                foreach (char alphabet in this.alphabets)
                {
                    CharCipher cc = new CharCipher(alphabet,this.offset,this.alphabets);
                    CharCiphList.Add(cc);
                }
            }
            this.ccList=CharCiphList;
        }

        public void PrintList()
        {
            List<CharCipher> ccList = this.ccList;
            foreach (var item in ccList)
            {
                Console.WriteLine(item.ToString());
            }
        }


        public string CypherString(char[] stringToCypher)
        {
            StringBuilder sb = new StringBuilder();

            for(int i=0; i<stringToCypher.Length; i++)
            {
                if(ccList.Exists(e => (e.charToCipher == stringToCypher[i])))
                {
                    char cipher = ccList.Find(c => (c.charToCipher == stringToCypher[i])).genCipherCode;

                    sb.Append(cipher);
                }
                else
                {
                    string errorMsg = "Cipher not available for the text input";
                    return errorMsg;
                }
               
            }
            return sb.ToString();
        }

        public string DecipherString(char[] stringToDecipher)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < stringToDecipher.Length; i++)
            {
                if (ccList.Exists(e => (e.charToCipher == stringToDecipher[i])))
                {
                    char cipher = ccList.Find(c => (c.genCipherCode == stringToDecipher[i])).charToCipher;

                    sb.Append(cipher);
                }
                else
                {
                    string errorMsg = "Cipher not available to decode the string";
                    return errorMsg;
                }
                
            }
            return sb.ToString();
        }

    }
}
