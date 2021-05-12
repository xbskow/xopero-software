using System;

namespace strona414
{
    class Bird
    {
        public string Name { get; set; }
        public virtual void Fly()
        {
            Console.WriteLine("Frr... frr...");
        }
        public override string ToString()
        {
            return $"Ptak {Name}";
        }
    }
}
