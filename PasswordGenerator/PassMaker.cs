using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public static class PassMaker
    {
        public static string Make()
        {
            Random RandomNumber = new Random();

            string random = RandomNumber.Next(0, 1000000).ToString("D6");
            return random;
        }
       
    }
}
