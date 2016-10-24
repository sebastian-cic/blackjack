using System;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello");
            Deck c = new Deck();
            Player p = new Player();

            p.AddPlayerCard(c.GetCard());
            p.AddPlayerCard(c.GetCard());
            p.AddPlayerCard(c.GetCard());
            p.AddPlayerCard(c.GetCard());
            p.AddPlayerCard(c.GetCard());
            Console.WriteLine(p.IsBusted);
            Console.ReadLine();
        }
    }
}
