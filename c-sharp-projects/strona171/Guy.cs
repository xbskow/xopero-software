using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace strona171
{
    class Guy
    {
        public string Name;
        public int Cash;
        
        public int GiveCash(int amount)
        {
            if (amount <= Cash && amount > 0)
            {
                Cash -= amount;
                return amount;
            } 
            else
            {
                MessageBox.Show($"Nie mam wystarczającej ilości pieniędzy aby ci dać {amount} zł", $"{Name} powiedział...");
                return 0;
            }
        }
        public int ReceiveCash(int amount)
        {
            if (amount > 0)
            {
                Cash += amount;
                return amount;
            }
            else
            {
                MessageBox.Show($"{amount} zł to nie jest ilość pieniędzy jaką mogę wziąć ", $"{Name} powiedział...");
                return 0;
            }
        }
    }
}
