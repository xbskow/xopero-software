using System;   

namespace strona311
{
    class Program
    {
        static void Main(string[] args)
        {
            MyBaseClass baseTest = new MyBaseClass("BASETEST");
            MySubClass subTest = new MySubClass("SUBTEST", 2);
        }
    }
}
