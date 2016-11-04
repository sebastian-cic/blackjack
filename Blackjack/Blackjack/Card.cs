using System;
using System.Collections.Generic;

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

        //Constructor
        public Card(string suit , int faceValue)
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
    }
}
