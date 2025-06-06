using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Helper
    {
        public int TryParseInt(object value)
        {
            try
            {
                int intValue = Convert.ToInt32(value);
                return intValue;
            }
            catch
            {
                return 0;
            }
        }
        
    }
}
