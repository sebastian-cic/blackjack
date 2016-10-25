using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class DisplayCards
    {
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

        public void PrintLine(int i, string dis,string suit)
        {
            string line = "\u0305";
            string display = dis;
            string x = suit;

            switch (i)
            {
                case 0: Console.Write("________");
                    break;
                case 1:
                    Console.Write("|" + x + "    " + x + "|");
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
                    Console.Write("|" + x + "    " + x + "|");
                    break;
                case 6: Console.Write(line + line + line + line + line + line + line + line);
                    break;
            }
        }
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
            else if (card.CardFaceValue != 10)
            {
                display = " " + card.CardFaceValue;
            }
            else
            {
                display = "10";
            }
            return display;
        }
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
    }

}
