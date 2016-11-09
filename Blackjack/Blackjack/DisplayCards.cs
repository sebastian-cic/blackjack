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
                PrintLine(count, card.GetFace(), card.GetSuit());
            }
        
            Console.WriteLine();
            count++;

            foreach (Card card in c)
            {
                PrintLine(count, card.GetFace(), card.GetSuit());
            }

            Console.WriteLine();
            count++;

            foreach (Card card in c)
            {
                PrintLine(count, card.GetFace(), card.GetSuit());
            }

            Console.WriteLine();
            count++;
            foreach (Card card in c)
            {
                PrintLine(count, card.GetFace(), card.GetSuit());
            }

            Console.WriteLine();
            count++;

            foreach (Card card in c)
            {
                PrintLine(count, card.GetFace(), card.GetSuit());
            }

            Console.WriteLine();
            count++;

            foreach (Card card in c)
            {
                PrintLine(count, card.GetFace(), card.GetSuit());
            }

            Console.WriteLine();
            count++;

            foreach (Card card in c)
            {
                PrintLine(count, card.GetFace(), card.GetSuit());
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
