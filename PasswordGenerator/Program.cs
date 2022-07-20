using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.IO.Directory.CreateDirectory(@"C:\cards");
            string workingDirectory = @"C:\cards\";

            var userInput = Start.StartProject();
            if ( userInput == 1)
            {
                string input;
                long CardNumber = CardOperations.AddCardNumber();


                try
                {
                    FileStream fs = new FileStream(workingDirectory + CardNumber + ".txt", FileMode.CreateNew,
                        FileAccess.Write);

                    int cvv2 = CardOperations.AddCvv2();

                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("cvv2:" + cvv2);
                    string Date = CardOperations.AddExpDate();
                    sw.WriteLine("Expiry Date:" + Date);
                    sw.Close();
                    fs.Close();
                    Console.WriteLine("Your Card Information Has Been Submitted Successfully");

                }
                catch (Exception e)
                {
                    Console.WriteLine("This Card Has Already Submitted");

                }
                finally
                {
                    Main(args);
                }
                
            }
            else if (userInput == 2)
            {
                var files = CheckCards.AllCards();
                Console.WriteLine("Which One Do You Want To Delete?");
                int selectedCard = int.Parse(Console.ReadLine());
                string cardName = files[selectedCard - 1].Name;
                File.Delete(workingDirectory+cardName);
                Console.WriteLine("The Selected Card Has Been Deleted");
                Main(args);
            }
            else if (userInput == 3)
            {
                
                var files = CheckCards.AllCards();
                if (files.Length>0)
                {
                    Console.WriteLine("Which One Do You Want To Update?");
                    int selectedCard = int.Parse(Console.ReadLine());
                    string cardName = files[selectedCard - 1].Name;
                    CheckCards.ClearPassword(cardName);
                    FileStream fs = new FileStream(workingDirectory + cardName, FileMode.OpenOrCreate, FileAccess.Write);
                    int cvv2 = CardOperations.AddCvv2();
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("cvv2:" + cvv2);
                    string Date = CardOperations.AddExpDate();
                    sw.WriteLine("Expiry Date:" + Date);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    Console.WriteLine("Your Card Has Been Updated");
                    Console.WriteLine();
                    Main(args);

                }

                else
                {
                    Main(args);
                }
               
            }
            else if (userInput == 4)
            {
                var files = CheckCards.AllCards();
                Console.WriteLine("Which One Do You Want Password for?");
                int selectedCard = int.Parse(Console.ReadLine());
                string cardName = files[selectedCard - 1].Name;
                string RandomNumber = PassMaker.Make();
                CheckCards.ClearPassword(cardName);
                File.AppendAllText(workingDirectory+cardName,$"password:{RandomNumber}");
                Console.WriteLine($"Your Dynamic Password:{RandomNumber}");
                Main(args);
            }
            else if (userInput == 5)
            {
                 Environment.Exit(0);
                 
                 //var a = File.GetLastWriteTime(workingDirectory + cardName);
                 //TimeSpan t = DateTime.Now - a;
                 //Console.WriteLine(t.TotalMinutes);

            }
        }
    }
}
    
