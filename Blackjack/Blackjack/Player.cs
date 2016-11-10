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
        //Set true if player has two of the same card face values. First two cards only.
        public bool IsSplitable
        {
            get
            {
                if (_playersCards.Count == 2)
                {
                    { return _playersCards[0].CardFaceValue == _playersCards[1].CardFaceValue; }
                }
                else
                {
                    return false;
                }
            }
        }

        //Get total value of cards, reduce Ace value to 1 if cards over 21.
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
                while (aceCount > 0)
                {
                    if (total > 21)
                    {
                        total = total - 10;
                    }
                    aceCount--;
                }
                return total;
            }
        }

        /// <summary>
        /// Add card to player from deck.
        /// </summary>
        public void Hit(Card card)
        {
            this._playersCards.Add(card);
        }

        /// <summary>
        /// Get all cards for player.
        /// </summary>
        public List<Card> GetAllCards()
        {
            return _playersCards;
        }

        /// <summary>
        /// When splitting remove and return card.
        /// </summary>
        public Card ReturnSplitCard()
        {
            Card cardToReturn = _playersCards[0];
            _playersCards.RemoveAt(0);
            return cardToReturn;
        }

        /// <summary>
        /// Handles user input and displays results to screen for single or split hands.
        /// </summary>
        /// <param name="player2"></param>
        /// <param name="dealer"></param>
        /// <param name="deck"></param>
        /// <param name="displayCards"></param>
        /// <param name="split"></param>
        public void HandleUserInput(Player player2, Dealer dealer, Deck deck, DisplayCards displayCards, bool split)
        {
            string hit = "";
            if (split)
            {
                //Display cards for split hand
                displayCards.PrintToScreenSplit(this, player2, dealer);
            }
            else
            {
                //Display cards for standard hand
                displayCards.PrintToScreen(this, dealer);
            }
            //If player does not stay and does not bust.
            //Ask user to hit or stay for main hand.
            while (hit != "s" && !this.IsBusted)
            {
                Console.WriteLine("(H)it or (S)tay?");
                hit = Console.ReadLine().ToLower();

                if (hit == "h")
                {
                    Hit(deck.GetCard());
                    //Display one or two hands depending on if player split.
                    if (!split)
                    {
                        displayCards.PrintToScreen(this, dealer);
                    }
                    else
                    {
                        displayCards.PrintToScreenSplit(this, player2, dealer);
                    }
                }
            }
            //Change hit variable from 's'tay to 'n' if player split.
            if (split)
            {
                hit = "n";
            }
            //Get user input for hit or stay for second hand of split cards
            while (hit != "s" && !player2.IsBusted && split)
            {
                Console.WriteLine("Second hand (H)it or (S)tay?" );
                hit = Console.ReadLine().ToLower();

                if (hit == "h")
                {
                    player2.Hit(deck.GetCard());
                    displayCards.PrintToScreenSplit(this, player2, dealer);                  
                }
            }
        }

        /// <summary>
        /// Check winner and display appropriate message.
        /// </summary>
        public string CheckIfWinner(Player player, Dealer dealer)
        {
            string result = "";
            if (player.IsBusted)
            {
                result = "BUST";
            }
            if (dealer.IsBusted)
            {
                result = "Dealer busts, YOU WIN";
            }
            if (player.TotalCardValue > dealer.TotalHandValue && !player.IsBusted && !dealer.IsBusted)
            {
                result = "YOU WIN";
            }
            if (player.TotalCardValue < dealer.TotalHandValue && !player.IsBusted && !dealer.IsBusted)
            {
                result = "YOU LOSE";
            }
            if (player.TotalCardValue == dealer.TotalHandValue && !player.IsBusted && !dealer.IsBusted)
            {
                result = "PUSH";
            }
            return result;
        }
    }
}