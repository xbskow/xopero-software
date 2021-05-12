﻿namespace strona409
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
        public override string ToString()
        {
            return Name;
        }
    }
}
