using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public static class CardOperations
    {
        public static string input;
        public static int AddCvv2()
        {
            Console.WriteLine("Please Enter Your Card cvv2:");
            input = Console.ReadLine();
            int cvv2;
            while (!(int.TryParse(input, out cvv2)) || cvv2.ToString().Length > 4 || cvv2.ToString().Length < 3)

            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid CVV2 Number!");
                Console.ResetColor();
                Console.WriteLine("Please Enter Your CVV2 Number:");
                input = Console.ReadLine();
            }

            return cvv2;
        }

        public static long AddCardNumber()
        {
            
            Console.WriteLine("Please Enter Your Card Number:");
            var input = Console.ReadLine();
            long CardNumber;
            while (!(long.TryParse(input, out CardNumber)) || CardNumber.ToString().Length != 16)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Card Number!");
                Console.ResetColor();
                Console.WriteLine("Please Enter Your Card Number:");
                input = Console.ReadLine();
            }

            return CardNumber;

        }

        public static string AddExpDate()
        {

            Console.WriteLine("Please Enter Your Card Expiry Date In This Format: YY/MM");
            string Date = Console.ReadLine();
            
            var dateSplit = Date.Split('/');
            while (!((Date.Length == 5) && dateSplit[0].Length==2 && dateSplit[1].Length == 2 && int.Parse(dateSplit[0])>=0 && int.Parse(dateSplit[1])>0 && int.Parse(dateSplit[1]) < 13))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Date!");
                Console.ResetColor();
                Console.WriteLine("Please Enter Your Card Expiry Date In This Format: YY/MM");
                Date = Console.ReadLine();
                dateSplit = Date.Split('/');
            }

            return Date;
        }
    }
}
