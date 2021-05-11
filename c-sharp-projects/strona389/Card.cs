namespace strona389
{
    class Card
    {
        public Card(Suits suit, Values value)
        {
            this.Suit = suit;
            this.Value = value;
        }
        Suits Suit { get; set; }
        Values Value { get; set; }
        public string Name
        {
            get
            {
                return $"{Value.ToString()} of {Suit.ToString()}";
            }
        }
    }
}
