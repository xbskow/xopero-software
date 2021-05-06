using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona349
{
    class Program
    {
        interface IClown
        {
            string FunnyThingIHave { get; }
            void Honk();
        }
        interface IScaryClown : IClown
        {
            string ScaryThingIHave { get; }
            void ScareLittleChildren();
        }
        class FunnyFunny : IClown
        {
            public FunnyFunny(string funnyThingIHave)
            {
                this.funnyThingIHave = funnyThingIHave;
            }
            protected string funnyThingIHave;
            public string FunnyThingIHave { get { return $"Cześć dzieciaki! Mam {funnyThingIHave}"; } }
            public void Honk()
            {
                Console.WriteLine(this.FunnyThingIHave);
            }
        }
        class ScaryScary : FunnyFunny, IScaryClown
        {
            public ScaryScary(string funnyThingIHave, int numberOfScaryThings) : base(funnyThingIHave)
            {
                this.numberOfScaryThings = numberOfScaryThings;
            }
            private int numberOfScaryThings;
            public string ScaryThingIHave
            {
                get
                {
                    return $"Mam {numberOfScaryThings} pająków";
                }
            }

            public void ScareLittleChildren()
            {
                Console.WriteLine($"Nie możesz miec mojego {base.funnyThingIHave}");
            }
        }
        static void Main(string[] args)
        {
            ScaryScary fingersTheClown = new ScaryScary("duże buty", 35);
            FunnyFunny someFunnyClown = fingersTheClown;
            IScaryClown someOtherScaryClown = someFunnyClown as ScaryScary;
            someOtherScaryClown.Honk();
            Console.ReadKey();
        }
    }
}
