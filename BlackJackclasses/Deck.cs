using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace BlackJackclasses
{
    public class Deck
    {
        public List<Card> deck = new List<Card>();

        // DECK CONSTRUCTOR
        public Deck()
        {
            MakeDeck();
        }
       
        public void Add(Card c)
        {
            deck.Add(c);
        }

        //PROPERTIES        
        public int NumCards
        {
            get { return deck.Count(); }
        }

        public bool IsEmpty
        {
            get
            {
                return deck.Count() == 0;
            }
        }

        //METHODS
        private List<Card> MakeDeck()
        {
            char[] values = { 'A', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K' };
            char[] suits = { 'C', 'D', 'H', 'S' };

            foreach (char v in values)
            {
                foreach (char s in suits)
                {
                    deck.Add(new Card(v, s));
                }
            }
            return deck;
        }

        //returns the top card and removes the top card from the deck, shifting down(hopefully)
        public Card Deal()
        {
            Card temp = null;
            if (deck.Count > 0)
            {
                temp = deck[0];
                deck.RemoveAt(0);
            }
            return temp;
        }

        public void Shuffle()
        {
            Random random = new Random();
            Card temp;
            for (int i = 0; i <= 51; i++)
            {
                int rand = random.Next(0, 51);

                temp = deck[i];
                deck[i] = deck[rand];
                deck[rand] = temp;
            }
        }

        public override string ToString()
        {
            int counter = 0;
            string output = "";
            foreach (Card c in deck)
            {
                output += c.ToString() + " ";
                // this is to add a new line every 13 iterations
                counter++;
                if (counter == 12)
                {
                    output += "\n";
                    counter = 0;
                }
            }
            return output;
        }
    }
}

        
                

            
        
    

