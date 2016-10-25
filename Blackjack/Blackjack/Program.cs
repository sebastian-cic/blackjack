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

        static void Main(string[] args)
        {
           
            Deck c = new Deck();
            p = new Player();
            d = new Dealer();
            string userinput = "y";

            p.AddPlayerCard(c.GetCard());
            p.AddPlayerCard(c.GetCard());
            d.AddDealerCard(c.GetCard());

            Console.OutputEncoding = System.Text.Encoding.UTF8;
             dis = new DisplayCards();
  
            while (userinput != "s" && !p.IsBusted)
            {
                PrintToScreen();
                Console.WriteLine("hit or stay?");
                userinput = Console.ReadLine();

                if (userinput == "h" )
                {
                   
                    p.AddPlayerCard(c.GetCard());
                
                }
                Console.Clear();
            }

            if (!p.IsBusted)
            {
                while(d.TotalCardValue < 17)
                {
                    d.AddDealerCard(c.GetCard());
                    PrintToScreen();
                    
       
                    int times = 100;
                    while (times > 0)
                    {
                        Thread.Sleep(10);
                        times--;
                    }
                    
                    Console.Clear();
                   
                }
            }
            if(p.IsBusted)
            {
                PrintToScreen();
                Console.WriteLine("BUST");
            }
            if (d.IsBusted)
            {
                PrintToScreen();
                Console.WriteLine("Dealer busts, YOU WIN");
            }
            if(p.TotalCardValue > d.TotalCardValue && !p.IsBusted && !d.IsBusted)
            {
                PrintToScreen();
                Console.WriteLine("YOU WIN");
            }
            if (p.TotalCardValue < d.TotalCardValue && !p.IsBusted && !d.IsBusted)
            {
                PrintToScreen();
                Console.WriteLine("you lose");
            }
            if(p.TotalCardValue == d.TotalCardValue && !p.IsBusted && !d.IsBusted)
            {
                PrintToScreen();
                Console.WriteLine("PUSH");
            }

            Console.ReadLine();
       
        }
        public static void PrintToScreen()
        {
            Console.WriteLine("DEALER");
            dis.Drawcards(d.GetAllCards());
            Console.WriteLine("YOUR CARDS");
            dis.Drawcards(p.GetAllCards());
        }
    }
}
