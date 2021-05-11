using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona312
{
    class DinnerParty : Party
    {
        public DinnerParty(int numberOfPeople, bool fancyDecorations, bool healthyOption) : base(numberOfPeople, fancyDecorations)
        {
            HealthyOption = healthyOption;
        }

        public bool HealthyOption { get; set; }

        private decimal CalculateCostOfBeveragesPerPerson()
        {
            decimal costOfBeveragesPerPerson;

            if (HealthyOption) costOfBeveragesPerPerson = 5m;
            else costOfBeveragesPerPerson = 20m;

            return costOfBeveragesPerPerson;
        }

        override public decimal Cost
        {
            get
            {
                decimal totalCost = base.Cost;
                totalCost += ((CalculateCostOfBeveragesPerPerson() + CostOfFoodPerPerson) * NumberOfPeople);
                if (HealthyOption) totalCost -= totalCost * 0.05m;
                return totalCost;
            }
        }
    }
}
