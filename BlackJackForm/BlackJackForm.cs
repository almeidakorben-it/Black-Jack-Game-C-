using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackJackclasses;

namespace BlackJackForm
{
    public partial class BlackJackForm : Form
    {

        /*************************************   Fields *********************************************/
        const string DPIC_BOX = "DcardPicBox";
        const string PIC_BOX = "cardPicBox";
        const string CARD = "card";           // First part of card image file name
        const string FILE_SUFFIX = ".jpg";           // Last part of image file name
        const string IMAGE_FOLDER = "\\CardImages\\";
        const int MAX_HAND_SIZE = 16;         // number of pictures boxes available to display cards in hand
        public bool stand = false;
        bool playerWon = false;
       // private bool HitButton_Clicked; // Hit button

        
        Deck deck;       
        Player players;
        Dealer dealers;
               

        public BlackJackForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            deck = new Deck();
            deck.Shuffle();
            players = new Player(deck);
            dealers = new Dealer(deck);
         
            players.Delt(2);
            dealers.Delt(2);

            DisplayHand();  // Show the player's hand    
            DisplayHandDealer();
           
        }
        private void DisplayHandDealer() //display dealer Hand
        {
            for (int picBoxNum = 1; picBoxNum <= MAX_HAND_SIZE; picBoxNum++)
            {
                if (picBoxNum <= dealers.Cards.Length)
                    DisplayCards(picBoxNum, dealers.Cards[picBoxNum - 1]);  
                else
                    DisplayCards(picBoxNum, "");
            }
        }

        private void DisplayHand() // display player Hand
        {
            for (int picBoxNum = 1; picBoxNum <= MAX_HAND_SIZE; picBoxNum++)
            {
                if (picBoxNum <= players.Cards.Length)
                    DisplayCard(picBoxNum, players.Cards[picBoxNum - 1]);  
                else
                    DisplayCard(picBoxNum, "");
            }
        }

        private void DisplayCards(int picBoxNum, string cardCode) // Get Dealers Cards
        {
            PictureBox Dcard = (PictureBox)this.Controls[DPIC_BOX + picBoxNum.ToString()];
            if (cardCode != "")
            {
                Dcard.Image = Image.FromFile(System.Environment.CurrentDirectory +
                    IMAGE_FOLDER + CARD + cardCode.ToLower() + FILE_SUFFIX);
                Dcard.Show();
            }
        }
        // Get Players Cards
        private void DisplayCard(int picBoxNum, string cardCode)
        {
            PictureBox card = (PictureBox)this.Controls[PIC_BOX + picBoxNum.ToString()];
            if (cardCode != "")
            {
                card.Image = Image.FromFile(System.Environment.CurrentDirectory +
                    IMAGE_FOLDER + CARD + cardCode.ToLower() + FILE_SUFFIX);
                card.Show();
            }
           
        }
        private void CheckForWinner()
        {
            if (players.Score() > dealers.Score() || dealers.IsBust)
            {
                playerWon = true;
            }
            else if (dealers.Score() > players.Score() || players.IsBust)
            {
                playerWon = false;
            }
            if (stand)
            {
                if (playerWon == true)
                {
                    winLabel.Text = "You won!";
                }
                if (playerWon == false)
                {
                    winLabel.Text = "The dealer won!";
                }
            }
        }

        private void HitButton_Click(object sender, EventArgs e)
        {
            
                players.playersTurn();
                DisplayHand();

            if(players.Score() > 21)
            {
                HitButton.Enabled = false;
            }                          
        }

        private void StandButton_Click(object sender, EventArgs e)
        {
            
            dealers.DealerTurn();//Dealers Turn method
            DisplayHandDealer();// DisplayHand of Dealer
            stand = true; // Makes stand true, to enter the Check Win Condition
            HitButton.Enabled = false; //if player Stands, Hit Button Disabled.
            CheckForWinner(); // Check for winner
                       
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
