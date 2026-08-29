using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackclasses
{
    public class Bjhand : Hand
    {
        
        private bool hasAce = false;
           

        public Bjhand() : base(5) { }

        public int GetScore
        {
            get { return Score(); }
        }

        public bool IsBust 
        {
            get { return isBust(); }
        }
        public bool BlackJack
        {
            get { return Score() == 21; }
        }
         public bool isBust()
        {
            bool bust = false;
            if (Score() > 21)
            {
                bust = true;
            }
            
            return bust;
        }
         
         public bool HasAce
         {
             get
             {
                 foreach (Card c in cards)
                 {
                     if (c.Value == 'A')
                     {
                         hasAce = true;
                     }
                 }

                 return hasAce;
             }
         }

         public int Score()
         {
             int score = 0;
                   
             foreach (Card c in cards)
             {

                 switch (c.Value)
                 {
                     case 'T':
                     case 'J':
                     case 'K':
                     case 'Q':
                         score += 10;
                         break;
                     case '2':
                         score += 2;
                         break;
                     case '3':
                         score += 3;
                         break;
                     case '4':
                         score += 4;
                         break;
                     case '5':
                         score += 5;
                         break;
                     case '6':
                         score += 6;
                         break;
                     case '7':
                         score += 7;
                         break;
                     case '8':
                         score += 8;
                         break;
                     case '9':
                         score += 9;
                         break;
                     case 'A':
                         score += 1;
                         break;
                     default:
                         score += 0;
                         break;
                 }
             }
             if (HasAce && score <= 11)
             {
                 score += 10;
             }
             return score;
             }
         } 
    }

