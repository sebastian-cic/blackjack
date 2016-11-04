using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class DisplayCards
    {
        /// <summary>
        /// Method to draw cards on screen. Each card is drawn one line at a time by calling PrintLine() placing cards side by side.
        /// </summary>
        /// <param name="c">List of cards to be drawn</param>
        public void Drawcards(List<Card> c)
        {
          var count = 0;
          foreach(Card card in c)
            {
                PrintLine(count, GetFace(card), GetSuit(card));
            }
        
            Console.WriteLine();
            count++;

            foreach (Card card in c)
            {
                PrintLine(count, GetFace(card), GetSuit(card));
            }

            Console.WriteLine();
            count++;

            foreach (Card card in c)
            {
                PrintLine(count, GetFace(card), GetSuit(card));
            }

            Console.WriteLine();
            count++;
            foreach (Card card in c)
            {
                PrintLine(count, GetFace(card), GetSuit(card));
            }

            Console.WriteLine();
            count++;

            foreach (Card card in c)
            {
                PrintLine(count, GetFace(card), GetSuit(card));
            }

            Console.WriteLine();
            count++;

            foreach (Card card in c)
            {
                PrintLine(count, GetFace(card), GetSuit(card));
            }

            Console.WriteLine();
            count++;

            foreach (Card card in c)
            {
                PrintLine(count, GetFace(card), GetSuit(card));
            }

            Console.WriteLine();
            count++;
        }
        /// <summary>
        /// Draws one line of card by switching line number to be printed.
        /// </summary>
        /// <param name="lineNumber">Number between 0 and 6 for specific line to be printed</param>
        /// <param name="faceValue">Face value of the card</param>
        /// <param name="suit">Suit of the card</param>
        public void PrintLine(int lineNumber, string faceValue, string suit)
        {
            //UTF8 code to draw bottom line of card
            string line = "\u0305";
            string display = faceValue;

            switch (lineNumber)
            {
                case 0: Console.Write("________");
                    break;
                case 1:
                    Console.Write("|" + suit + "    " + suit + "|");
                    break;
                case 2:
                    Console.Write("|      |");
                    break;
                case 3:
                    Console.Write("|  " + display + "  |");
                    break;
                case 4:
                    Console.Write("|      |");
                    break;
                case 5:
                    Console.Write("|" + suit + "    " + suit + "|");
                    break;
                case 6: Console.Write(line + line + line + line + line + line + line + line);
                    break;
            }
        }

        /// <summary>
        /// Get face value of cards from numerical value.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>String representing the face card value</returns>
        public string GetFace(Card card)
        {
            string display = "";

            if (card.CardFaceValue == 1)
            {
                display = " A";
            }
            else if (card.CardFaceValue == 11)
            {
                display = " J";
            }
            else if (card.CardFaceValue == 12)
            {
                display = " Q";
            }
            else if (card.CardFaceValue == 13)
            {
                display = " K";
            }
            else if (card.CardFaceValue == 10)
            {
                display = "10";   
            }
            else
            {
                display = " " + card.CardFaceValue;
            }
            return display;
        }

        /// <summary>
        /// Get UTF8 value of card suit.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>String value for UTF8 code for card suit</returns>
        public string GetSuit(Card card)
        {
            string cardSuit = "";
            switch (card.Suit)
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
        /// Print cards to screen when player did not split.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="dealer"></param>
        public  void PrintToScreen(Player player , Dealer dealer)
        {
            Console.Clear();
            Console.WriteLine("DEALERS CARDS");
            Drawcards(dealer.GetAllCards());
            Console.WriteLine("YOUR CARDS");
            Drawcards(player.GetAllCards());
        }

        /// <summary>
        /// Print cards to screen if player split.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="player2"></param>
        /// <param name="dealer"></param>
        public void PrintToScreenSplit(Player player, Player player2, Dealer dealer)
        {
            Console.Clear();
            Console.WriteLine("DEALERS CARDS");
            Drawcards(dealer.GetAllCards());
            Console.WriteLine("YOUR CARDS");
            Drawcards(player.GetAllCards());
            Console.WriteLine("YOUR CARDS");
            Drawcards(player2.GetAllCards());
        }
    }
}
