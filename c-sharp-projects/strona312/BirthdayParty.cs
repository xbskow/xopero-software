using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona312
{
    class BirthdayParty : Party
    {
        public string CakeWriting { get; set; }

        public BirthdayParty(int numberOfPeople, bool fancyDecorations, string cakeWriting) : base(numberOfPeople, fancyDecorations)
        {
            CakeWriting = cakeWriting;
        }

        private int ActualLength
        {
            get
            {
                if (CakeWriting.Length > MaxWritingLength())
                    return MaxWritingLength();
                else
                    return CakeWriting.Length;
            }
        }

        private int CakeSize()
        {
            if (NumberOfPeople <= 4) return 20;
            else return 40;
        }

        private int MaxWritingLength()
        {
            if (CakeSize() == 8) return 16;
            else return 40;
        }

        public bool CakeWritingTooLong
        {
            get
            {
                if (CakeWriting.Length > MaxWritingLength()) return true;
                else return false;
            }
        }

        override public decimal Cost
        {
            get
            {
                decimal totalCost = base.Cost;
                decimal cakeCost;
                if (CakeSize() == 20) cakeCost = 40m + ActualLength * 0.25m;
                else cakeCost = 75m + ActualLength * 0.25m;
                return totalCost + cakeCost;
            }
        }
    }
}
