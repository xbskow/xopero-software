using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona277
{
    class DinnerParty
    {
        public DinnerParty(int numberOfPeople, bool healthyOption, bool fancyDecorations)
        {
            NumberOfPeople = numberOfPeople;
            HealthyOption = healthyOption;
            FancyDecorations = fancyDecorations;
        }

        public const int CostOfFoodPerPerson = 25;
        public int NumberOfPeople { get; set; }
        public bool FancyDecorations { get; set; }
        public bool HealthyOption { get; set; }

        private decimal CalculateCostOfDecorations()
        {
            decimal costOfDecorations;

            if (FancyDecorations) costOfDecorations = (NumberOfPeople * 15m) + 50m;
            else costOfDecorations = (NumberOfPeople * 7.5m) + 30m;

            return costOfDecorations;
        }

        private decimal CalculateCostOfBeveragesPerPerson()
        {
            decimal costOfBeveragesPerPerson;

            if (HealthyOption) costOfBeveragesPerPerson = 5m;
            else costOfBeveragesPerPerson = 20m;

            return costOfBeveragesPerPerson;
        }

        public decimal Cost
        {
            get
            {
                decimal totalCost = CalculateCostOfDecorations();
                totalCost += ((CalculateCostOfBeveragesPerPerson() + CostOfFoodPerPerson) * NumberOfPeople);
                if (HealthyOption) totalCost -= totalCost * 0.05m;
                return totalCost;
            }
        }
    }
}
