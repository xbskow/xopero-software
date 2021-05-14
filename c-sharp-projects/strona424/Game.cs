using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace strona424
{
    class Game
    {
        private List<Player> players;
        private Dictionary<Values, Player> books;
        private Deck stock;
        private TextBox textBoxOnForm;

        public Game(string playerName, IEnumerable<string> opponentNames, TextBox textBoxOnForm)
        {
            Random random = new Random();
            this.textBoxOnForm = textBoxOnForm;
            players = new List<Player>();
            players.Add(new Player(playerName, random, textBoxOnForm));
            foreach (string player in opponentNames)
                players.Add(new Player(player, random, textBoxOnForm));
            books = new Dictionary<Values, Player>();
            stock = new Deck();
            Deal();
            players[0].SortHand();
        }

        private void Deal()
        {

        }

        public bool PlayOneRound(int selectedPlayerCard)
        {

        }

        public bool PullOutBooks(Player player)
        {

        }

        public string DescribeBooks()
        {

        }

        public string GetWinnerName()
        {

        }

        public IEnumerable<string> GetPlayerCardNames()
        {
            return players[0].GetCardNames();
        }

        public string DescribePlayerHands()
        {
            string description = "";
            for (int i = 0; i < players.Count; i++)
            {
                description += $"{players[i].Name} na {players[i].CardCount}";
                if (players[i].CardCount == 1)
                    description += " kartę.\r\n";
                else if (players[i].CardCount == 2 || players[i].CardCount == 3 || players[i].CardCount == 4)
                    description += " karty.\r\n";
                else
                    description += " kart.\r\n";
            }
            description += $"Na kupce pozostało kart: {stock.Count}\r\n";
            return description;
        }
    }
}
