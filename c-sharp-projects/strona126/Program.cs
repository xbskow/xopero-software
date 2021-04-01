using System;

namespace strona126
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            string poem = "";

            while (x < 4)
            {
                poem += "a";
                if (x < 1)
                {
                    poem += " ";
                }
                poem += "n";

                if (x > 1)
                {
                    poem += " oyster";
                    x += 2;
                }
                if (x == 1)
                {
                    poem += "noys ";
                }
                if (x < 1)
                {
                    poem += "oise ";
                }
                x++;
            }
            Console.WriteLine(poem);
        }
    }
}
