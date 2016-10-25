using System;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Deck c = new Deck();
            Player p = new Player();
            Dealer d = new Dealer();
            string userinput = "y";

            p.AddPlayerCard(c.GetCard());
            p.AddPlayerCard(c.GetCard());
            d.AddDealerCard(c.GetCard());

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            DisplayCards dis = new DisplayCards();
  
            while (userinput != "s" && !p.IsBusted)
            {
                Console.WriteLine("DEALERS CARDS");
                dis.Drawcards(d.GetAllCards());
                Console.WriteLine("YOUR CARDS");
                dis.Drawcards(p.GetAllCards());
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
                    Console.WriteLine("DEALER");
                    dis.Drawcards(d.GetAllCards());
                    Console.WriteLine("YOUR CARDS");
                    dis.Drawcards(p.GetAllCards());
       
                    Console.WriteLine("hit or stay?");
                    int times = 100;
                    while (times > 0)
                    {
                        Thread.Sleep(15);
                        times--;
                    }
                    Console.Clear();
                }
            }
            if(p.IsBusted)
            {
                Console.WriteLine("BUST");
            }
            if(p.TotalCardValue > d.TotalCardValue && !p.IsBusted)
            {
                Console.WriteLine("YOU wind");
            }else
            {
                Console.WriteLine("you lose");
            }
            

            Console.ReadLine();
           
        }

    }
}
