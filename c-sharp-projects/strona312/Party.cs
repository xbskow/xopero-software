using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona312
{
    class Party
    {
        public Party(int numberOfPeople, bool fancyDecorations)
        {
            NumberOfPeople = numberOfPeople;
            fancyDecorations = FancyDecorations;
        }
        public const int CostOfFoodPerPerson = 25;
        public int NumberOfPeople { get; set; }
        public bool FancyDecorations { get; set; }

        public decimal CalculateCostOfDecorations()
        {
            decimal costOfDecorations;
            if (FancyDecorations) costOfDecorations = (NumberOfPeople * 15m) + 50m;
            else costOfDecorations = (NumberOfPeople * 7.5m) + 30m;
            return costOfDecorations;
        }

        virtual public decimal Cost
        {
            get
            {
                decimal totalCost = CalculateCostOfDecorations();
                totalCost += CostOfFoodPerPerson * NumberOfPeople;
                if (NumberOfPeople > 12) totalCost += 100;
                return totalCost;
            }
        }
    }
}
