
namespace Blackjack
{
    class Card
    {
        public string Suit { get; private set; }
        public bool IsAce = false;
        //Gets value of card, changes face cards to 10 and Ace to 11
        public int Value
        {
            get
            {
                if (_cardFaceValue > 10)
                    return 10;
                else if (IsAce)
                    return 11;
                else
                    return _cardFaceValue;
            }
        }

        private int _cardFaceValue;

        public int CardFaceValue
        {
            get { return this._cardFaceValue; }
        }
       
        public Card(string suit, int faceValue)
        {       
            this.Suit = suit;
            this._cardFaceValue = faceValue;
            if (_cardFaceValue == 1)
            {
                this.IsAce = true;
            }
        }

        public override string ToString()
        {
            return _cardFaceValue + Suit;
        }

        /// <summary>
        /// Get UTF8 value of card suit.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>String value for UTF8 code for card suit</returns>
        public string GetSuit()
        {
            string cardSuit = "";
            switch (this.Suit)
            {
                case "s":
                    cardSuit = "\u2660";
                    break;

                case "h":
                    cardSuit = "\u2665";
                    break;

                case "d":
                    cardSuit = "\u2666";
                    break;

                case "c":
                    cardSuit = "\u2663";
                    break;
            }
            return cardSuit;
        }

        /// <summary>
        /// Get face value of cards from numerical value.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>String representing the face card value</returns>
        public string GetFace()
        {
            string display = "";

            if (CardFaceValue == 1)
            {
                display = " A";
            }
            else if (CardFaceValue == 11)
            {
                display = " J";
            }
            else if (CardFaceValue == 12)
            {
                display = " Q";
            }
            else if (CardFaceValue == 13)
            {
                display = " K";
            }
            else if (CardFaceValue == 10)
            {
                display = "10";
            }
            else
            {
                display = " " + CardFaceValue;
            }
            return display;
        }
    }
}
