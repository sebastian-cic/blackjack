using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blackjack
{
    class Dealer
    {
        private List<Card> _dealerCards = new List<Card>();
        public bool IsBusted
        {
            get { return TotalHandValue > 21; }
        }

        //Get total value of cards, reduce Ace value to 1 if cards over 21.
        public int TotalHandValue
        {
            get
            {
                var aceCount = 0;
                var total = 0;
                foreach (Card c in this._dealerCards)
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

        /// <summary>
        /// Add card to dealer hand from deck.
        /// </summary>
        /// <param name="card"></param>
        public void Hit(Card card)
        {
            this._dealerCards.Add(card);
        }


        /// <summary>
        /// Get all cards for dealer.
        /// </summary>
        /// <returns>List of all dealer cards</returns>
        public List<Card> GetAllCards()
        {
            return _dealerCards;
        }

        /// <summary>
        /// Handle dealer actions. Dealer hits until 17 or busts.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="player2"></param>
        /// <param name="displayCards"></param>
        /// <param name="split">Bool representing if player split cards</param>
        /// <param name="deck"></param>
        public  void DealerHits(Player player, Player player2, DisplayCards displayCards, bool split, Deck deck)
        {
            Console.Clear();
            while (this.TotalHandValue < 17)
            {
                this.Hit(deck.GetCard());

                //Display for split or single hand
                if (!split)
                {
                    displayCards.PrintToScreen(player, this);
                }
                else
                {
                    displayCards.PrintToScreenSplit(player, player2, this);
                }

                //Slow dealer display time          
                Thread.Sleep(500);
                
                Console.Clear();
            }
        }
    }
}
