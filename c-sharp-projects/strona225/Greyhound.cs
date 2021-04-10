using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace strona225
{
    class Greyhound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public Image MyPictureBox = null;
        public int Location = 0;
        public Random MyRandom;

        public bool Run()
        {
            Location = (int)(MyPictureBox.Margin.Left + MyPictureBox.Width);
            Location += MyRandom.Next(1, 5);
            if (Location == RacetrackLength)
                return true; // if winning
            else
                return false;
        }

        public void TakeStartingPosition()
        {
            Location = StartingPosition;
            // get x position
        }
    }   
}
