using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona409
{
    class Program
    {
        static void Main(string[] args)
        {
            CardComparer_byValue compareByValue = new CardComparer_byValue();
            List<Card> cards = new List<Card>();
            Card card;
            Random random = new Random();
            Console.WriteLine("Pięć losowych kart:");
            for (int i = 0; i < 5; i++)
            {
                cards.Add(new Card((Suits)random.Next(4), (Values)random.Next(1, 14)));
                Console.WriteLine(cards[i]);
            }

            cards.Sort(compareByValue);

            Console.WriteLine("\nTe same karty posortowane:");
            for (int i = 0; i < cards.Count; i++)
            {
                Console.WriteLine(cards[i]);
            }

            Console.ReadKey();
        }
    }
}
