using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackclasses;


namespace Tests
{
    class Program
    {
        const int BLACKJACK = 21;   // The winning score and the max score before a bust
        static void Main(string[] args)
        {
            string playAgain = "";
            Deck deck = new Deck();

            do
            {
                Player playerHand = new Player(deck);   //Uses Player Class agg.
                Dealer dealerHand = new Dealer(deck);    
                
                Player ph = new Player(deck);
                deck.Shuffle();
                
                bool playerWon = false;
                bool gameOver = false;
                
                // Deal two cards to the player
                playerHand.Add(deck.Deal());
                playerHand.Add(deck.Deal());
                // Test
                //playerHand.Add(new Card('a', 'c'));
                //playerHand.Add(new Card('t', 'c'));

                Console.WriteLine("Player's hand: {0}", playerHand.ToString());
                if (playerHand.Score() == BLACKJACK)
                {
                    Console.WriteLine("Player got a Blackjack!");
                    playerWon = true;
                    gameOver = true;
                }

                if (!gameOver)
                {
                    // Deal two cards to the dealer
                    dealerHand.Add(deck.Deal());
                    dealerHand.Add(deck.Deal());
                    Console.WriteLine("Dealer's hand: {0}", dealerHand.ToString());
                    if (dealerHand.Score() == BLACKJACK)
                    {
                        Console.WriteLine("Dealer got a Blackjack!");
                        playerWon = false;
                        gameOver = true;
                    }
                }

                // Player's turn
                // TODO: Refactor to put the stuff this block of code does in the Player class
                if (!gameOver)
                {
                    bool stand = false;
                    while (!playerHand.IsBust && !stand)
                    {
                        Console.WriteLine("Do you want a hit? (y/n)");
                        string answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            playerHand.Add(deck.Deal());
                            Console.WriteLine("Player's hand: {0}", playerHand.ToString());
                        }
                        else
                        {
                            stand = true;
                        }
                    }

                    if (playerHand.IsBust)
                    {
                        playerWon = false;
                        gameOver = true;
                    }
                }


                // Dealer's turn
                if (!gameOver)
                {
                    bool stand = false;
                    while (!dealerHand.IsBust && !stand)
                    {
                        if (dealerHand.Score() < 17)    // 16 is the max score a dealer can have before they have to stand
                        {
                            dealerHand.Add(deck.Deal());
                            Console.WriteLine("Dealer's hand: {0}", dealerHand.ToString());
                        }
                        else
                        {
                            stand = true;
                        }
                    }

                    // Determine the winner
                    if (playerHand.Score() > dealerHand.Score() || dealerHand.IsBust)
                        playerWon = true;
                    else
                        playerWon = false;
                }

                // Display the winner
                if (playerWon)
                    Console.WriteLine("You won!");
                else
                    Console.WriteLine("The dealer won!");

                Console.WriteLine("Do you want to play again? (y/n)");
                playAgain = Console.ReadLine();
            } while (playAgain == "y");

            Console.WriteLine("Game done");
        
        }
    }
}
