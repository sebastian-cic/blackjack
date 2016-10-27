using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Player
    {
        private List<Card> _playersCards = new List<Card>();

        public bool IsBusted
        {
            get { return TotalCardValue > 21; }
          
        }
        public bool IsSplitable
        {
            get
            {if (_playersCards.Count == 2)
                {
                    { return _playersCards[0].CardFaceValue == _playersCards[1].CardFaceValue; }
                }
                else
                    return false;
            }
           
        }

        public int TotalCardValue
        {
            get
            {
                var aceCount = 0;
                var total = 0;
                foreach (Card c in this._playersCards)
                {
                    if (c.IsAce)
                    {
                        aceCount++;
                    }
                    total = total + c.Value;
                }

                while(aceCount > 0)
                {
                    if(total > 21)
                    {
                        total = total - 10;             
                    }
                    aceCount--;
                }
                return total;
            }
         }

        public Player()
        {

        }

        public void AddPlayerCard(Card card)
        {
            this._playersCards.Add(card);
        }
        
        public void DisplayCards()
        {
            foreach(Card c in this._playersCards)
            {
                Console.WriteLine(c.ToString());
             
            }
        }
        public List<Card> GetAllCards()
        {
            return _playersCards;
        }

        public Card ReturnSplitCard()
        {
            Card cardToReturn = _playersCards[0];
            _playersCards.RemoveAt(0);
            return cardToReturn;
        }
   
    }
}
