using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace strona225
{
    class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            MyRadioButton.Content = $"{Name} ma {Cash} zł";
        }

        public void ClearBet() => MyBet = null;

        public bool PlaceBet(int Amount, int DogToWin)
        {
            if (Amount <= Cash)
            {
                MyBet = new Bet() { Amount = Amount, Dog = DogToWin, Bettor = this };
                return true;
            }
            return false;
            
        }

        public void Collect(int Winner)
        {
            MyBet.PayOut(Winner + 1);
        }


    }
}
