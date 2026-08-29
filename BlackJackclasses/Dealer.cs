using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackclasses
{
    public class Dealer : Player
    {
       // protected Bjhand dealers = new Bjhand();

        public Dealer(Deck d) : base(d) { }

        public Dealer(Deck d, int maxCards)
            : base(d, maxCards)
        { }

        //public int DealersScore
        //{
        //    get { return dealers.Score(); }
        //}

        public override string ToString()
        {
            string showHand;
            if (!players.BlackJack && !players.IsBust)
            {
                showHand = base.ToString();

                return showHand.Substring(0);
            }
            else
            {
                showHand = base.ToString();
            }
            return showHand.Substring(3);
        }
      

        public void DealerTurn()
        {
            if (!gameOver() && !players.IsBust)
            { 
                    while(players.Score() < 17)    // 16 is the max score a dealer can have before they have to stand
                    {
                        players.Add(deck.Deal());
                    }          
            }
            //if (players.Score() > pla.Score() || dealers.IsBust)
            //{
            //    playerWon = true;
            //}
            //else
            //{
            //    playerWon = false;
            //}
            //return playerWon;
        }
    }
}
