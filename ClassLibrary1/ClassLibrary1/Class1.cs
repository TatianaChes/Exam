using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public bool PasswordCheck(string source)
        {
           if (source.Length > 4 && !Char.IsDigit(source[0]))
            {
                return true;
            }
 
         

            return false;

          
        }
    }
}
