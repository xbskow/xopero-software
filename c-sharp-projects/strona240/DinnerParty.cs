using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona240
{
    public class DinnerParty
    {
        public const int CostOfFoodPerPerson = 25;
        public int NumberOfPeople;
        public decimal CostOfBeveragesPerPerson;
        public decimal CostOfDecorations;
        
        public void SetHealthyOption(bool healthyOption)
        {
            if (healthyOption) CostOfBeveragesPerPerson = 5m;
            else CostOfBeveragesPerPerson = 20m;
        }

        public void CalculateCostOfDecorations(bool fancy)
        {
            if (fancy) CostOfDecorations = NumberOfPeople * 15m + 50m;
            else CostOfDecorations = NumberOfPeople * 7.50m + 30m;
        }

        public decimal CalculateCost(bool healthyOption)
        {
            decimal totalCost = (CostOfFoodPerPerson * NumberOfPeople) + (CostOfBeveragesPerPerson * NumberOfPeople) + CostOfDecorations;
            decimal discount;
            if (healthyOption) discount = 0.05m;
            else discount = 0m;
            return totalCost - (totalCost * discount);

        }
    }
}
