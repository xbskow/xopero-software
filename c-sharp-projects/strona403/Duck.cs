using System;

namespace strona403
{
    class Duck : IComparable<Duck>
    {
        public int Size;
        public KindOfDuck Kind;

        public int CompareTo(Duck duckToCompare)
        {
            if (this.Size > duckToCompare.Size)
                return 1;
            else if (this.Size < duckToCompare.Size)
                return -1;
            else
                return 0;
        }
    }
}
