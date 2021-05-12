using System;

namespace strona414
{
    class Penguin : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("Pingwiny nie latają!");
        }

        public override string ToString()
        {
            return $"Pingwin {base.Name}";
        }
    }
}
