using System;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Blackjack
{
    class Program
    {
        private static DisplayCards dis;
        private static Dealer d;
        private static Player p;
        private static Player p2;
        private static Deck c;
        private static bool split = false;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            
            string userinput = "y";
            string userSplitInput = "";
            dis = new DisplayCards();

            while (userinput == "y")
            {

                c = new Deck();
                p = new Player();
                d = new Dealer();
                p2 = new Player();

                p.AddPlayerCard(c.sameCard());
                p.AddPlayerCard(c.sameCard());
                d.AddDealerCard(c.GetCard());

                if (p.IsSplitable)
                {
                    PrintToScreen();

                    Console.WriteLine("Split?");
                    userSplitInput = Console.ReadLine();

                    if (userSplitInput == "y")
                    {
                        p2.AddPlayerCard(p.ReturnSplitCard());
                        split = true;
                    }
                }
                if (!split) {
                HandleUserInput(p);
                Console.Clear();
                }
                if (split)
                {
                    Console.Clear();
                    HandleUserInput(p);
                    Console.Clear();
                    HandleUserInput(p2);
                }

                if (!p.IsBusted && !split)
                {
                    DealerHits();
                }
                if (split && !p2.IsBusted || !p.IsBusted )
                {
                    DealerHits();
                }

                CheckWinner(p);

                Console.WriteLine("Enter 'y' to play again" );
                userinput = Console.ReadLine();
                Console.Clear();
            }
        }


        public static void  HandleUserInput(Player p)
        {
            string hit = "";
            if (split)
            {
                PrintToScreenSplit();
            }else { 
            PrintToScreen();
            }
            while (hit != "s" && !p.IsBusted)
            { 
                Console.WriteLine("hit or stay?");
                hit = Console.ReadLine();

                if (hit == "h")
                {
                    Hit(p);
                    if (!split)
                    {
                        PrintToScreen();
                    }
                    else
                    {
                        PrintToScreenSplit();
                    }

                }
            }
        }



        public static void DealerHits()
        {
            Console.Clear();
            while (d.TotalCardValue < 17)
            {
                d.AddDealerCard(c.GetCard());
                if (!split)
                {
                    PrintToScreen();
                }else
                {
                    PrintToScreenSplit();
                }
                int times = 100;
                while (times > 0)
                {
                    Thread.Sleep(5);
                    times--;
                }

                Console.Clear();

            }
        }


        public static void Hit(Player p)
        {
            p.AddPlayerCard(c.GetCard());
        }

        public static void PrintToScreen()
        {
            Console.Clear();
            Console.WriteLine("DEALERS CARDS");
            dis.Drawcards(d.GetAllCards());
            Console.WriteLine("YOUR CARDS");
            dis.Drawcards(p.GetAllCards());
        }

        public static void PrintToScreenSplit()
        {
            Console.Clear();
            Console.WriteLine("DEALERS CARDS");
            dis.Drawcards(d.GetAllCards());
            Console.WriteLine("YOUR CARDS");
            dis.Drawcards(p.GetAllCards());
            Console.WriteLine("YOUR CARDS");
            dis.Drawcards(p2.GetAllCards());
        }

        public static void CheckWinner(Player p)
        {
            if (p.IsBusted)
            {
                PrintToScreen();
                Console.WriteLine("BUST");
            }
            if (d.IsBusted)
            {
                PrintToScreen();
                Console.WriteLine("Dealer busts, YOU WIN");
            }
            if (p.TotalCardValue > d.TotalCardValue && !p.IsBusted && !d.IsBusted)
            {
                PrintToScreen();
                Console.WriteLine("YOU WIN");
            }
            if (p.TotalCardValue < d.TotalCardValue && !p.IsBusted && !d.IsBusted)
            {
                PrintToScreen();
                Console.WriteLine("you lose");
            }
            if (p.TotalCardValue == d.TotalCardValue && !p.IsBusted && !d.IsBusted)
            {
                PrintToScreen();
                Console.WriteLine("PUSH");
            }
        }
    }
}
