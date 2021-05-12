namespace strona416
{
    class Card
    {
        public Card(Suits suit, Values value)
        {
            this.Suit = suit;
            this.Value = value;
        }
        public Suits Suit { get; set; }
        public Values Value { get; set; }
        public string Name
        {
            get
            {
                return $"{Value} of {Suit}";
            }
        }

        public static bool DoesCardMatch(Card CardToCheck, Suits Suit)
        {
            if (CardToCheck.Suit == Suit)
                return true;
            else
                return false;
        } 

        public static bool DoesCardMatch(Card CardToCheck, Values Value)
        {
            if (CardToCheck.Value == Value)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
