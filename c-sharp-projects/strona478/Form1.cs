using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace strona478
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        private Deck RandomDeck(int Number)
        {
            Deck myDeck = new Deck(new Card[] { });
            for (int i = 0; i < Number; i++)
                myDeck.Add(new Card(
                    (Suits)random.Next(4),
                    (Values)random.Next(1, 14)));
            return myDeck;
        }

        private void DealCards(Deck deckToDeal, string Title)
        {
            Console.WriteLine(Title);
            while (deckToDeal.Count > 0)
            {
                Card nextCard = deckToDeal.Deal(0);
                Console.WriteLine(nextCard.Name);
            }
            Console.WriteLine("-----------------------");
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deck deckToWrite = RandomDeck(5);
            using (Stream output = File.Create("Zestaw1.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(output, deckToWrite);
            }
            DealCards(deckToWrite, "To co zapisałem do pliku");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Deck deckFromFile;
            using (Stream input = File.OpenRead("Zestaw1.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                deckFromFile = (Deck)bf.Deserialize(input);
                DealCards(deckFromFile, "To co z pliku odczytałem");    
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Stream output = File.Create("Zestaw2.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                for (int i = 1; i <= 5; i++)
                {
                    Deck deckToWrite = RandomDeck(random.Next(1, 10));
                    bf.Serialize(output, deckToWrite);
                    DealCards(deckToWrite, $"Zestaw numer {i} zapisany");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (Stream input = File.OpenRead("Zestaw2.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                for (int i = 1; i <= 5; i++)
                {
                    Deck deckToRead = (Deck)bf.Deserialize(input);
                    DealCards(deckToRead, $"Zestaw numer {i} odczytany");
                }
            }
        }
    }
}
