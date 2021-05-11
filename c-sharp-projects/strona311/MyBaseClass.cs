using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona311
{
    class MyBaseClass
    {
        public MyBaseClass(string baseClassNeedsThis)
        {
            Console.WriteLine($"To jest klasa bazowa: {baseClassNeedsThis}");
        }
    }
}
