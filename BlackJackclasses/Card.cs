using System;



namespace BlackJackclasses
{
    public class Card
    {
              // Fields
        private char suit;
        private char value;

        //CONSTRUCTORS
        public Card(char v, char s)
        {
            value = char.ToUpper(v);
            suit = char.ToUpper(s);
        }

        //PROPERTIES
        public char Value
        {
            get
            {
                return value;
            }
        }

        public char Suit
        {
            get
            {
                return suit;
            }
        }

        //METHODS
        public override string ToString()
        {
            return value.ToString() + suit;
        }

        public bool IsBlack()
        {
            return suit == 'C' || suit == 'S';
        }

        public bool IsRed()
        {
            return suit == 'H' || suit == 'D';
        }
   }
}
    

