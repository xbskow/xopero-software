using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona335
{
    class Bee : IStingPatrol
    {
        public int AlertLevel
        {
            get
            {
                return 3;
            }
        }
        public int StingerLength { get; set; }
        public bool LookForEnemies()
        {
            return true;
        }
        public int SharpenStinger(int Length)
        {
            return Length;
        }
    }
}
