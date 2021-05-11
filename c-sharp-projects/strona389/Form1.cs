using System;
using System.Windows.Forms;

namespace strona389
{
    public partial class Form1 : Form
    {
        Card card;
        public Form1()
        {
            InitializeComponent();
            card = new Card(Suits.Spades, Values.Ace);
            SetName(card);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            card = new Card((Suits)random.Next(4), (Values)random.Next(1, 14));
            SetName(card);
        }

        private void SetName(Card card)
        {
            string cardName = card.Name;
            label1.Text = cardName;
        }
    }
}
