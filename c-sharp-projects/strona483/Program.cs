using System;
using System.IO;

namespace strona483
{
    class Program
    {
        static void Main(string[] args)
        {
            int intValue = 48769414;
            string stringValue = "Witaj!";
            byte[] byteArray = { 47, 129, 0, 116 };
            float floatValue = 491.695f;
            char charValue = 'E';

            using (FileStream output = File.Create("danebinarne.dat"))
            using (BinaryWriter writer = new BinaryWriter(output))
            {
                writer.Write(intValue);
                writer.Write(stringValue);
                writer.Write(byteArray);
                writer.Write(floatValue);
                writer.Write(charValue);
            }

            byte[] dataWritten = File.ReadAllBytes("danebinarne.dat");
            foreach (byte b in dataWritten)
                Console.Write($"{b:x2} ");
            Console.WriteLine($"- {dataWritten.Length} bajtów");

            
            Console.WriteLine();


            using (FileStream input = File.OpenRead("danebinarne.dat"))
            using (BinaryReader reader = new BinaryReader(input))
            {
                int intRead = reader.ReadInt32();
                string stringRead = reader.ReadString();
                byte[] byteArrayRead = reader.ReadBytes(4);
                float floatRead = reader.ReadSingle();
                char charRead = reader.ReadChar();

                Console.Write($"int: {intRead} string: {stringRead} bajty: ");
                foreach (byte b in byteArrayRead)
                    Console.Write($"{b} ");
                Console.Write($"float: {floatRead} char: {charRead}");
            }

            Console.ReadKey();

            
        }
    }
}
