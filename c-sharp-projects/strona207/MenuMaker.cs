using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona207
{
    class MenuMaker
    {
        public Random Randomizer;

        string[] Meats = { "Pieczona wołowina", "Salami", "Indyk", "Szynka", "Karkówka" };
        string[] Condiments = { "żółta musztarda", "brązowa musztard", "musztarda miodowa", "majonez", "przyprawa", "sos francuski" };
        string[] breads = { "chleb ryżowy", "chleb biały", "chleb zbożowy", "pumpernikiel", "chleb włoski", "bułka" };

        public string GetMenuItem()
        {
            string randomMeat = Meats[Randomizer.Next(Meats.Length)];
            string randomCondiment = Condiments[Randomizer.Next(Condiments.Length)];
            string randomBread = breads[Randomizer.Next(breads.Length)];
            return $"{randomMeat}, {randomCondiment}, {randomBread}";
        }
    }
}
