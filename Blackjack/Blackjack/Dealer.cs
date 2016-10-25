using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Dealer
    {
        private List<Card> _dealerCards = new List<Card>();
        public bool IsBusted
        {
            get { return TotalCardValue > 21; }

        }

        public int TotalCardValue
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

        public Dealer()
        {

        }


        public void AddDealerCard(Card card)
        {
            this._dealerCards.Add(card);
        }
        public void DisplayCards()

        {
            foreach (Card c in this._dealerCards)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public List<Card> GetAllCards()
        {
            return _dealerCards;
        }
    }
}
