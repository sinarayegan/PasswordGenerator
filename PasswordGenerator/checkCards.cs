using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public static class CheckCards
    {
        private static readonly string workingDirectory = @"C:\cards\";
        public static FileInfo[] AllCards()
        {
            DirectoryInfo di = new DirectoryInfo(workingDirectory);
            FileInfo[] files = di.GetFiles("*.txt");
            if (files.Length == 0)
            {
                Console.WriteLine("First Add a Card");
                
            }
            else
            {
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo file = files[i];
                    Console.WriteLine($"{i + 1} - " + file.Name.Remove(file.Name.LastIndexOf('.')));
                }

                
            }

            return files;

        }

        public static void ClearPassword(string cardName)
        {
            var content = File.ReadAllLines(workingDirectory + cardName);
            if (content.Length == 3)
            {
                var newContent = content.ToList();
                newContent.RemoveAt(2);
                File.WriteAllLines(workingDirectory + cardName, newContent);
            }
        }
    }
}
