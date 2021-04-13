using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona240
{
    class DinnerParty
    {
        public const int CostOfFoodPerPerson = 25;
        private int numberOfPeople;
        public decimal CostOfBeveragesPerPerson;
        public decimal CostOfDecorations;
        
        public void SetHealthyOption(bool healthyOption)
        {
            if (healthyOption) CostOfBeveragesPerPerson = 5m;
            else CostOfBeveragesPerPerson = 20m;
        }

        public void CalculateCostOfDecorations(bool fancy)
        {
            if (fancy) CostOfDecorations = (numberOfPeople * 15m) + 50m;
            else CostOfDecorations = (numberOfPeople * 7.50m) + 30m;
        }

        public decimal CalculateCost(bool healthyOption)
        {
            decimal totalCost = ((CostOfFoodPerPerson + CostOfBeveragesPerPerson) * numberOfPeople) + CostOfDecorations;
            decimal discount;
            if (healthyOption) discount = 0.05m;
            else discount = 0m;
            return totalCost - (totalCost * discount);
        }

        public void SetPartyOptions(int people, bool fancy)
        {
            numberOfPeople = people;
            CalculateCostOfDecorations(fancy);
        }

        public int GetNumberOfPeople()
        {
            return numberOfPeople;
        }
    }
}
