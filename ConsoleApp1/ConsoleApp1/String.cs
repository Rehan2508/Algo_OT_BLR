using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class String
    {
        public static void Main(string[] args)
        {
            string myName = "Saket";
            string message = "My name is " + myName;
            string uppercase = message.ToUpper();
            string lowercase = message.ToLower();
            Console.WriteLine(uppercase);
            Console.WriteLine(lowercase);
            string age = Console.ReadLine();
            Console.WriteLine(age);
            
            int asciiValue = Console.Read();
            Console.WriteLine("ASCII value is {0}: ",asciiValue);
            Console.ReadKey();
        }
    }
}
