using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackclasses
{
     public class Hand
    {
        protected int maxCards;
        protected List<Card> cards = new List<Card>();

        //PROPERTIES//
        public int NumCards
        {
            get { return cards.Count; }
        }
    

        public Hand() 
        {         
            maxCards = 5;
        }

        public Hand(int max) 
        {
            maxCards = max;
        }
        public void Add(Card card)
        {
            if (isFull) { }
            else
            {
                cards.Add(card);
            }
        }

        // for matching cards
        public bool HasCard(Card card)
        {
            foreach (Card c in cards)
            {
                if (c == card)
                    return true;
            }
            return false;
        }

        // for matching values
        public bool HasCard(char value)
        {
            foreach (Card c in cards)
            {
                if (c.Value == value)
                    return true;
            }
            return false;
        }

        // for matching value and suit
        public bool HasCard(char v, char s)
        {
            foreach (Card c in cards)
            {
                if (c.Value == v)
                {
                    if (c.Suit == s)
                        return true;
                }
            }
            return false;
        }

        public Card Discard(char v, char s) 
        {
            Card foundCard = null;
            foreach(Card c in cards)
            {
                if(c.Value == v && c.Suit == s)
                {
                    cards.Remove(c);
                    foundCard = c;
                }              
            }
            return foundCard;
        }

        public bool isFull
        {
             get{return NumCards >= maxCards;}
        }

        public override string ToString()
        {
            string output = "";
            foreach (Card c in cards)
            {
                output += c.ToString() + " ";
            }
            output = output.Trim();   // remove the trailing space
            return output;
        }

    }
}
