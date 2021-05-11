using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona311
{
    class MySubClass : MyBaseClass
    {
        public MySubClass(string baseClassNeedsThis, int anotherValue) : base(baseClassNeedsThis)
        {
            Console.WriteLine($"To jest pochodna: {baseClassNeedsThis} i {anotherValue}");
        }
    }
}
