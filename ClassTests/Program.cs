using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackclasses;

namespace ClassTests
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDeck();
            TestHand();
            TestHands();
            TestScore();
            
        }
        static void TestScore()
        {
            Console.WriteLine("-------------------------------------------------");
            Deck deck = new Deck();
            Player playerHand = new Player(deck);
            Dealer dealerHand = new Dealer(deck);
            int i = 0;

            deck.Shuffle();

            playerHand.Add(deck.Deal());
            playerHand.Add(deck.Deal());

            dealerHand.Add(deck.Deal());
            dealerHand.Add(deck.Deal());
            while(i < 1)
            {
                Console.WriteLine("Score Tests for playerHand and DealerHand");
            Console.WriteLine("Player:" + playerHand.Score());
            Console.WriteLine();
            Console.WriteLine("Dealer:" + dealerHand.Score());
            i++;
            }
        }
            
          static void TestDeck ()
		{
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Testing Deck");
            Deck blackjack = new Deck();
            blackjack.Shuffle();

            Console.WriteLine("Hello World!");
            Console.WriteLine("Creating a new Deck");

            // test our constructor
            // first test some bad perameters 
            for (int i = 0; i < 52; i++)
            {
                
                Console.WriteLine("what did we get for our card # {0}?", i);
                Console.WriteLine("What card did we get " + blackjack.deck[i].ToString());
                Console.WriteLine("What was the value " + blackjack.deck[i].Value);
                Console.WriteLine("What was the suite " + blackjack.deck[i].Suit);
                

            }

            Console.WriteLine("End Deck Test");
            Console.WriteLine("-------------------------------------------------");
            
		}

        static void TestHand()
        {

            
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Testing Hand");
            Hand hand = new Hand();
            Card c1 = new Card('A', 'S');

            Console.WriteLine("Hello World!");
            Console.WriteLine("Creating a new Hand");
            hand.Add(c1);
            Console.WriteLine("Number of cards (expect 1): {0}", hand.NumCards);
            Console.WriteLine("Card codes (expect AS): {0}", hand.ToString()); 

            Console.WriteLine("Adding cards to Hand and Remove AS");
            hand.Add(new Card('3', 'C'));
            hand.Add(new Card('J', 'D'));
            //hand.Disacard('A', 'S');
            Console.WriteLine("Number of cards (expect 2): {0}", hand.NumCards);
            Console.WriteLine("Card codes (expect 3C and JD): {0}", hand.ToString()); 

            Console.WriteLine("-------------------------------------------------");
            

        }

        static void TestHands()
        {   
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Testing BjHand");
            Deck deck = new Deck();
            Player playerHand = new Player(deck); 
            Dealer dealerHand = new Dealer(deck);  

           
            deck.Shuffle();

        
            Console.WriteLine(deck.ToString());

            playerHand.Add(deck.Deal());
            playerHand.Add(deck.Deal());

            dealerHand.Add(deck.Deal());
            dealerHand.Add(deck.Deal());


            
            while (!dealerHand.IsBust || !playerHand.IsBust)
            {
                Console.WriteLine("Player's hand: {0}", playerHand.ToString());
                Console.WriteLine("Dealer's hand: {0}", dealerHand.ToString());
                Console.WriteLine("Players score: {0}", playerHand.Score());
                Console.WriteLine("Dealers score: {0}", dealerHand.Score());
                Console.WriteLine("Do we have an Ace in our players hand: {0}", playerHand.HasAce);
                Console.WriteLine("Do we have an Ace in our dealers hand: {0}", dealerHand.HasAce);
                
                playerHand.Add(deck.Deal());
                dealerHand.Add(deck.Deal());
                Console.WriteLine("Are we bust in our players hand: {0}", playerHand.IsBust);
                Console.WriteLine("Are we bust in our dealers hand: {0}", dealerHand.IsBust);
            }

           

        }
    }
}
