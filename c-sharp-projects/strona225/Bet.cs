using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;  

namespace strona225
{
    class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            if (Amount > 0)
                return $"{Bettor.Name} postawił {Amount} na psa numer {Dog}";
            else
                return $"{Bettor.Name} nie zawarł zakładu";
        }

        public int PayOut(int Winner)
        {
            if (Winner + 1 == Dog)
                return Amount;
            else
                return -Amount;
        }
    }
}
