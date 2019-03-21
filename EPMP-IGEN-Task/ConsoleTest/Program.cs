using Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    TimeConvert convert = new TimeConvert();

                    Console.Write("Enter the hour and minutes in the format hh:mm (hour:minutes) : ");

                    string time = Convert.ToString(Console.ReadLine());

                    var result = convert.Convert(time);

                    Console.WriteLine("{0}\u00B0", result);
                    Console.WriteLine("---------");
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press Enter to exit.");
            Console.Read();
        }
    }
}
