using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona397
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shoe> shoeCloset = new List<Shoe>()
            {
                new Shoe() { Style = Style.Sneakers, Color = "Czarny" },
                new Shoe() { Style = Style.Clogs, Color = "Brązowy" },
                new Shoe() { Style = Style.Wingtips, Color = "Czarny" },
                new Shoe() { Style = Style.Loafers, Color = "Biały" },
                new Shoe() { Style = Style.Loafers, Color = "Czerwony" },
                new Shoe() { Style = Style.Sneakers, Color = "Zielony" }
            };

            int numberOfShoes = shoeCloset.Count;
            foreach (Shoe shoe in shoeCloset)
            {
                shoe.Style = Style.Flipflops;
                shoe.Color = "Pomarańczowy";
            }

            shoeCloset.RemoveAt(4);

            Shoe thirdShoe = shoeCloset[2];
            Shoe secondShoe = shoeCloset[1];
            shoeCloset.Clear();
            shoeCloset.Add(thirdShoe);
            if (shoeCloset.Contains(secondShoe))
                Console.WriteLine("A to ci niespodzianka.");
        }
    }
}
