using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace strona439
{
    public partial class Form1 : Form
    {
        private Queue<Lumberjack> breakfastLine = new Queue<Lumberjack>();
        public Form1()
        {
            InitializeComponent();
        }

        private void addFlapjacks_Click(object sender, EventArgs e)
        {
            Flapjack food;
            if (crispy.Checked)
                food = Flapjack.Chrupkiego;
            else if (soggy.Checked)
                food = Flapjack.Wilgotnego;
            else if (browned.Checked)
                food = Flapjack.Rumianego;
            else
                food = Flapjack.Bananowego;

            if (breakfastLine.Count > 0)
            {
                Lumberjack currentLumberjack = breakfastLine.Peek();
                currentLumberjack.TakeFlapjacks(food, (int)howMany.Value);
            }
            RedrawList();
        }

        private void nextLumberjack_Click(object sender, EventArgs e)
        {
            if (breakfastLine.Count > 0)
            {
                Lumberjack nextLumberjack = breakfastLine.Dequeue();
                nextLumberjack.EatFlapjacks();
                nextInLine.Text = "";
                RedrawList();
            }
        }

        private void addLumberjack_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(name.Text))
            {
                breakfastLine.Enqueue(new Lumberjack(name.Text));
                name.Text = "";
                RedrawList();
            }
        }

        private void RedrawList()
        {
            int i = 0;
            line.Items.Clear();
            foreach (Lumberjack lumberjack in breakfastLine)
            {
                i++;
                line.Items.Add($"{i}. {lumberjack.Name}");
                
            }
            if (breakfastLine.Count == 0)
                nextInLine.Text = "";
            else
            {
                Lumberjack currentLumberjack = breakfastLine.Peek();
                nextInLine.Text = $"{currentLumberjack.Name} ma {currentLumberjack.FlapjackCount} naleśników";
            }
        }
    }
}
