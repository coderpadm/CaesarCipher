using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public class CharCipher
    {
        public char charToCipher;
        public char genCipherCode;

        public CharCipher(char cc,int offset,string cipherString)
        {
            this.charToCipher = cc;

            if(offset == 0)
            {
                this.genCipherCode = cc;
            }
            else
            {
                int len = cipherString.Length;
                if ( len > 0)
                {
                    int index = cipherString.IndexOf(cc);
                    int calcIndex = 0;
                    if(!(index < 0))
                    {
                        calcIndex = (index + offset) % len;
                    }
                    else
                    {
                        //error
                        calcIndex = -1;
                    }

                    if(!(calcIndex < 0))
                    {
                        this.genCipherCode = cipherString[calcIndex];
                    }
                    else
                    {
                        this.genCipherCode = cc;
                    }

                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Char " + this.charToCipher);
            sb.Append(": "+this.genCipherCode);
            return sb.ToString();
        }
    }
}
