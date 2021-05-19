using System;
using System.IO;

namespace strona446
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(@"D:\strona446");
            StreamWriter sw = new StreamWriter(@"D:\strona446\tajny_plan.txt");
            sw.WriteLine("W jaki sposób pokonać Kapitana Wspaniałego?");
            sw.WriteLine("Kolejny genialny, tajny plan Kanciarza.");
            sw.Write("Stworzę armię klonów, ");
            sw.WriteLine("uwolnię je i wystawię przeciwko mieszkańcom Obiektowa.");
            string location = "centrum handlowe.";
            for (int number = 0; number <= 6; number++)
            {
                sw.WriteLine($"Klon numer {number} atakuje {location}");
                if (location == "centrum handlowe.") location = "centrum miasta.";
                else location = "centrum handlowe.";
            }
            sw.Close();
        }
    }
}
