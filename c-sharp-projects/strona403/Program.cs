using System;
using System.Collections.Generic;

namespace strona403
{
    class Program
    {
        public static void PrintDucks(List<Duck> ducks)
        {
            foreach (Duck duck in ducks)
            {
                Console.WriteLine($"{duck.Size}-centymetrowa kaczka {duck.Kind}");
            }
            Console.WriteLine("Koniec kaczek!");
        }
        static void Main(string[] args)
        {
            DuckComparerBySize sizeComparer = new DuckComparerBySize();
            DuckComparerByKind kindComparer = new DuckComparerByKind();
            DuckComparer comparer = new DuckComparer();

            List<Duck> ducks = new List<Duck>()
            {
                new Duck() { Kind = KindOfDuck.Mallard, Size = 17 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 18 },
                new Duck() { Kind = KindOfDuck.Decoy, Size = 14 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 11 },
                new Duck() { Kind = KindOfDuck.Mallard, Size = 14 },
                new Duck() { Kind = KindOfDuck.Decoy, Size = 13 }
            };

            Console.WriteLine("Nieposortowane kaczki\n" +
                              "---------------------");
            PrintDucks(ducks);

            Console.WriteLine("\nPosortowane wg. rozmiaru\n" +
                              "------------------------");
            ducks.Sort(sizeComparer);
            PrintDucks(ducks);

            Console.WriteLine("\nPosortowane wg. rodzaju\n" +
                              "-----------------------");
            ducks.Sort(kindComparer);
            PrintDucks(ducks);

            Console.WriteLine("\nPosortowane wg. rodzaju, potem rozmiaru\n" +
                              "---------------------------------------");
            comparer.SortBy = SortCriteria.KindThenSize;
            ducks.Sort(comparer);
            PrintDucks(ducks);

            Console.WriteLine("\nPosortowane wg. rozmiaru, potem rodzaju\n" +
                              "---------------------------------------");
            comparer.SortBy = SortCriteria.SizeThenKind;
            ducks.Sort(comparer);
            PrintDucks(ducks);

            Console.ReadKey();
        }
    }
}
