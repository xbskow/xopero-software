using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona336
{
    class Program
    {
        public class TallGuy : IClown
        {
            public string Name;
            public int Height;
            public string FunnyThingIHave
            {
                get
                {
                    return "duże buty";
                }
            }
            public void TalkAboutYourself()
            {
                Console.WriteLine($"Nazywam się {Name}, mam {Height} centymetrów wzrostu oraz {FunnyThingIHave}");
            }
            public void Honk()
            {
                Console.WriteLine("Tut tuut!");
            }
        }
        static void Main(string[] args)
        {
            TallGuy tallGuy = new TallGuy() { Height = 74, Name = "Adam" };
            tallGuy.TalkAboutYourself();
            tallGuy.Honk();
        }
    }
}
