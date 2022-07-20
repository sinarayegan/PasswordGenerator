using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public static class Start
    {
        public static int StartProject()
        {
            Console.WriteLine("1 = Submit New Card  2 = Delete a Card  3 = Update a Card 4 = create Dynamic Password  5 = Exit");
            var userInput = int.Parse(Console.ReadLine());
            return userInput;
        }
        
    }
}
