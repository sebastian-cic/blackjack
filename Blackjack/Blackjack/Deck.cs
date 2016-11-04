using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    class Deck
    {
        public List<Card> _deck = new List<Card>(52);
        private List<string> _suits = new List<string> { "h", "c", "s", "d" };

        public Deck()
        {
            PopulateDeck();
        }

        /// <summary>
        /// Create deck of 52 cards.
        /// </summary>
        private void PopulateDeck()
        {
            foreach (string suitType in _suits)
            {
                for (int j = 1; j <= 13; j++)
                {
                    Card card = new Card(suitType, j);        
                    _deck.Add(card);
                }
            }
            //Shuffle deck
            _deck = _deck.OrderBy(a => Guid.NewGuid()).ToList();
        }

        /// <summary>
        /// Get first card from deck.
        /// </summary>
        /// <returns>Card</returns>
        public Card GetCard()
        {
            Card c = _deck.First();
            _deck.Remove(c);
            return c;
        }
        //Get same card (for testing splits).
        public Card sameCard()
        {
            Card c = new Card("h", 5);
            return c;
        }
    }
}
