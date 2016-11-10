using System;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            //Enable display of suit characters in console.
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string userinput = "y";     
        
            while (userinput == "y")
            {
                DisplayCards dis = new DisplayCards();
                string userSplitInput = "";
                bool split = false;
                Deck deck = new Deck();
                Player player = new Player();
                Dealer dealer = new Dealer();
                Player splitPlayer = new Player();

                //Deal starting cards
                player.Hit(deck.GetCard());
                player.Hit(deck.GetCard());
                dealer.Hit(deck.GetCard());

                //Runs if player has two of the same card
                if (player.IsSplitable)
                {
                    dis.PrintToScreen(player, dealer);

                    Console.WriteLine("Split? (Y)es or(N)o");
                    userSplitInput = Console.ReadLine().ToLower();

                    if (userSplitInput == "y")
                    {
                        splitPlayer.Hit(player.ReturnSplitCard());
                        split = true;
                    }
                }

                //Run code for single or split hand
                if (!split)
                {
                    player.HandleUserInput(splitPlayer, dealer, deck, dis, split);
                    Console.Clear();
                }
                else if (split)
                {
                    Console.Clear();
                    player.HandleUserInput(splitPlayer, dealer, deck, dis, split);
                    Console.Clear();
                }

                //Player split and one or both hands did not bust
                if (!player.IsBusted && !split)
                {
                    dealer.DealerHits(player, splitPlayer, dis, split, deck);
                }
                else if (split && !splitPlayer.IsBusted || !player.IsBusted )
                {
                    dealer.DealerHits(player, splitPlayer, dis, split, deck);
                }

                //Single hand not split
                if (!split)
                {
                    Console.Clear();
                    dis.PrintToScreen(player, dealer);
                    Console.WriteLine(player.CheckIfWinner(player, dealer));  
                }
                else
                {
                    Console.Clear();
                    dis.PrintToScreenSplit(player,splitPlayer,dealer);
                    Console.WriteLine("Your first hand :"+ player.CheckIfWinner(player,dealer));
                    Console.WriteLine("Your second hand:"+ player.CheckIfWinner(splitPlayer,dealer));
                }

                //Ask user to keep playing
                Console.WriteLine("Enter 'Y' to play again or 'N' to exit");
                userinput = Console.ReadLine().ToLower();
                while (userinput != "y" && userinput != "n")
                {
                    Console.WriteLine("Enter 'Y' to play again or 'N' to exit");
                    userinput = Console.ReadLine().ToLower();
                }
              
                Console.Clear();
            }
        }
    }
}
