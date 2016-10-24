namespace Blackjack
{
    class Card
    {
        public string Suit { get; private set; }
        public int Value {
            get
            {
                if (_cardFaceValue > 10)
                    return 10;
                else
                    return _cardFaceValue;
            }
        }

        private int _cardFaceValue;

        public Card(string suit , int faceValue)
        {
            this.Suit = suit;
            this._cardFaceValue = faceValue; 
        }

        public override string ToString()
        {
            return _cardFaceValue + Suit;
        }

    }
}
