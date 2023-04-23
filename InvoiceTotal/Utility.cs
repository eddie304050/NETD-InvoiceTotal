using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceTotal
{
    class Utility
    {

        public static Boolean isDecimal(string input)
        {
            decimal number;
            return Decimal.TryParse(input, out number);
        }
    

        public static Boolean isInRange(decimal min, decimal max, string input)
        {

            decimal number;
            if (Decimal.TryParse(input, out number))
            {

                return min <= number && number <= max;
            }
            return false;

        }
    
    }

}
