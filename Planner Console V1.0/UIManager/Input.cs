using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner_Console_V1._0.UIManager
{
    internal static class Input
    {
        internal static char GetKeyStroke()
        {
           ConsoleKeyInfo key = Console.ReadKey(intercept:true);
            Console.WriteLine();
            return key.KeyChar;
        }

        internal static string GetReadLine()
        {
            string input = Console.ReadLine();
            Console.WriteLine();
            if (input == "bk")
            {
                Console.WriteLine();
                UI.MainMenu();
            }
            Console.WriteLine();
            return input;
        }
        internal static string GetSubject()
        {
           string output = Console.ReadLine();
            if (output == "bk")
            {
                Console.WriteLine();
                UI.MainMenu();
            }
            Console.WriteLine();
            return output;
        }

        internal static DateTime GetDateTime()
        {
            while (true)
            {
                string output = Console.ReadLine();
                if (output == "bk")
                {
                    Console.WriteLine();
                    UI.MainMenu();
                }
                string format = "dd/MM/yyyy HH:mm";

                if (DateTime.TryParseExact(output, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime date)) 
                {
                    Console.WriteLine();
                    return date;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid date and time, please re-enter");
                    Thread.Sleep(1000);
                }
            }
        }

    }
}
