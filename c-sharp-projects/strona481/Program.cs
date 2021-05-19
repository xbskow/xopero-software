using System;
using System.IO;

namespace strona481
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("eureka.txt", "Eureka!");
            byte[] eurekaBytes = File.ReadAllBytes("eureka.txt");
            foreach (byte b in eurekaBytes)
                Console.Write($"{b} ");

            Console.WriteLine();

            foreach (byte b in eurekaBytes)
                Console.Write($"{b:x2} ");

            Console.WriteLine();

            File.WriteAllText("eureka2.txt", "שָׁלוֹם");

            eurekaBytes = File.ReadAllBytes("eureka2.txt");
            foreach (byte b in eurekaBytes)
                Console.Write($"{b} ");

            Console.WriteLine();

            foreach (byte b in eurekaBytes)
                Console.Write($"{b:x2} ");

            Console.ReadKey();

        }
    }
}
