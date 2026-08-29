  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackclasses
{

    public class Player:Bjhand
    {
     //   protected Hand hand = new Hand();  // Composition, whole-part
        protected Bjhand players = new Bjhand();
        protected Deck deck; // Aggregation, has-a (a looser relationship than composition)
        
        const int BLACKJACK = 21;   // The winning score and the max score before a bust

        
        public bool playerWon = false;
        protected bool stand = false;
        protected bool hit = false;
        

        public Player(Deck d)
        {
            deck = d;
            players = new Bjhand();
        }

        public Player(Deck d,int maxCards)
        {
            deck = d;
           // players = new Bjhand(maxCards);
        }

        public string ShowHand()
        {
            return players.ToString();
        }

        public string[] Cards
        {
            get { return players.ToString().Split(' '); }
        }

        public void Delt(int numCards)
        {
            for (int i = 0; i < numCards; i++)
            {
                players.Add(deck.Deal());
            }
        }

        public bool IsBlackJack
        {
            get 
            { 
             return Score() == 21;
            }
        }

        
        public bool gameOver() 
        {           
            bool isgameOver = false;
            if (IsBlackJack)
            {
                isgameOver = true;
            }
            return isgameOver;
        }

        public void playersTurn() 
        {           
            if (!gameOver() && !players.IsBust)
            {
                if (players.Score() < 21)
                {
                    players.Add(deck.Deal());
                }            
            }
            if (players.IsBust)
            {
                playerWon = false;
            }
        }

        public bool WantToHit()
        {        
            if(!players.IsBust)
            {
                hit = true;
            }
            return hit;
        }

        
        
    }
}
