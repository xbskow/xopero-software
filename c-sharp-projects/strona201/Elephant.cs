using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace strona201
{
    class Elephant
    {
        public string Name;
        public int EarSize;

        public void WhoAmI()
        {
            MessageBox.Show($"Moje uszy mają {EarSize} centymetrów szerokości.", $"{Name} mówi...");
        }
    }
}
