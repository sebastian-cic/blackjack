using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Player
    {
        private List<Card> _playersCards = new List<Card>();
        public Boolean IsBusted
        {
            get
            {
                var total = 0;
                foreach (Card c in this._playersCards)
                {
                    total = total + c.Value;
                }
                if (total > 21)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public Player()
        {

        }

        public void AddPlayerCard(Card card)
        {
            this._playersCards.Add(card);
        }
   
    }
}
