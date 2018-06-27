using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using static Zero_Sum.Globals;

namespace Zero_Sum
{
    class Round
    {
        #region Properties
        public List<int> Shares;  //list of shares available in the round
        List<Player> Players;  //list of players participating in the round
        List<Player> Buyers;  //list of players who have bought shares (player entered each time they buy a share)
        int Pot;  //amount of money that's been spent on shared, to be distributed at the end of round
        int TurnPassCount; //counter for how many turns have been passed in a row

        public event WritingEventHandler OnWriting;
        public event ShareBoughtEventHandler OnShareBought;
        public event NewShareAvailableEventHandler OnNewShareAvailable;

        #endregion

        #region Constructor
        public Round(List<Player> inPlayers)
        {
            Shares = new List<int> { 0, 1, 2, 3, 4, 5, 6 };
            Players = new List<Player>(inPlayers);
            Buyers = new List<Player>();
            Pot = 0;
            TurnPassCount = 0;
        }

        #endregion

        #region Public Methods
        //Set the initial conditions at the start of the round
        public void Setup()
        {
            //Each player active in the game should start active in the round
            foreach (Player p in Players)
            {
                p.BoughtShares = new List<int>();
                p.ActiveInRound = p.ActiveInGame;
            }

            OnNewShareAvailable?.Invoke(Shares[0]);
        }

        //Play the Round, and return whether the round was a wash (0 coins exchange hands) or not
        public bool PlayRound()
        {
            bool isWash = true;
            //OnShareBought?.Invoke(null, Shares);

            //Allow turns to be taken until 3 turns have been passed in a row
            while (TurnPassCount < 3)
            {
                NonBlockingSleep(1);

                //Round needs to end if there are no more shares
                if (Shares.Count < 1) break;

                //let the current player take their turn, and switch on if they bought the current share or not
                if (Players[0].TakeTurn(Shares[0]))
                {
                    OnShareBought?.Invoke(Players[0], Shares[0]);
                    //increase the pot by the value and remove the share
                    Pot += Shares.Pull(0);
                    if (Shares.Count > 0) OnNewShareAvailable?.Invoke(Shares[0]);
                    //record that the current player bought a share
                    Buyers.Add(Players[0]);
                    //reset the pass counter
                    TurnPassCount = 0;
                }
                //if they passed, increase the counter
                else TurnPassCount++;

                NonBlockingSleep(1500);
                //move the current player to the end of the line
                Players.Add(Players.Pull(0));
            }

            //if there's money in the pot and more than one player purchased, the round wasn't a wash;
            //there's currently an uncertainty in the rules: if shares are purchased by multiple players in a way that causes everyone to break even, is the round a wash?  current rules say no.
            if ((Pot > 0) && (Buyers.Distinct().Count() > 1)) isWash = false;

            //divy up the money to end the round
            Payout();

            //Wait for 5 seconds before ending the round
            NonBlockingSleep(5000);

            //let the game know if the round was a wash
            return isWash;
        }
        #endregion

        #region Helper Methods
        //Distribute the pot evenly to each player who purchased a share
        void Payout()
        {
            WriteLine("Paying out Pot of " + Pot + " coins.");

            //loop through players who have bought a share, giving out one coin at a time
            while (Pot > 0)
            {
                NonBlockingSleep(1);
                Pot--; //out of the pot
                Buyers[0].AddCoins(1); //and into your hand
                Players.ForEach(p => p.TrackPurchases(Buyers[0].Name, 1));
                Buyers.Add(Buyers.Pull(0)); //now go to the end of the line
            }
        }

        #endregion

        #region Functional Methods
        //Send a message to the game window
        void Write(string msg)
        {
            OnWriting?.Invoke(msg);
        }
        void WriteLine(string msg)
        {
            Write(msg + Environment.NewLine);
        }

        #endregion
    }
}
