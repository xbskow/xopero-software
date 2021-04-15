using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona304
{
    class JewelThief : Locksmith
    {
        private Jewels stolenJewels = null;
        override public void ReturnContents(Jewels safeContents, Owner owner)
        {
            stolenJewels = safeContents;
            Console.WriteLine($"Kradnę zawartość sejfu! {stolenJewels.Sparkle()}");
        }
    }
}
