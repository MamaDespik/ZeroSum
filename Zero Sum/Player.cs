using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static Zero_Sum.Globals;

namespace Zero_Sum
{
    public class Player
    {
        #region Properties
        public string Name;  //Name of the player
        public int Goal; //Their assigned goal
        public int Coins = 20; //Their current number of coins
        public int Score; //Their score (at the end of the game)
        public bool ActiveInRound; //If they are active in the current round
        public bool ActiveInGame;  //If they are active in the game
        public Dictionary<string, int> Guesses; //Guesses for each other player's goal
        public List<Tuple<string, int>> Tracking;//Tracking of other player's purchases.
        public int Id;  //A randomly assigned ID
        public List<int> BoughtShares;

        //public bool WaitingForAction;
        public string Action;
        public int Guess;

        public event WritingEventHandler OnWriting;
        public event TakingTurnEventHandler OnTakingTurn;
        public event CoinValueChangedEventHandler OnCoinValueChange;

        #endregion

        #region Constructor
        public Player(String inName, int inID)
        {
            Name = inName;
            Goal = -1;
            Score = 0;
            ActiveInRound = true;
            ActiveInGame = true;
            Guesses = new Dictionary<string, int>();
            Tracking = new List<Tuple<string, int>>();
            Id = inID;
        }

        #endregion

        #region Public Methods
        //Allow the player to take an action on their turn
        public bool TakeTurn(int currentShareValue)
        {
            //Initialize conditions for the turn
            bool boughtShare = false;
            string action = ACTION_PASS_TURN;

            Write(Name + "'s turn:  ");

            //If the Player is active in the game and the round, get their action for the turn
            if (!ActiveInRound) action = ACTION_PASS_ROUND;
            if (!ActiveInGame) action = ACTION_PASS_GAME;
            if ((ActiveInGame && ActiveInRound))
            {
                OnTakingTurn?.Invoke(this);
                action = DecideAction(currentShareValue);
            }

            //Take the action
            switch (action)
            {
                case ACTION_BUY:
                    boughtShare = BuyShare(currentShareValue);
                    break;
                case ACTION_PASS_TURN:
                    PassTurn();
                    break;
                case ACTION_PASS_ROUND:
                    PassRound();
                    break;
                case ACTION_PASS_GAME:
                    PassGame();
                    break;
                default:
                    break;
            }

            return boughtShare;
        }

        //(Generic) Decide on what action to take for the turn
        public virtual string DecideAction(int currentShareValue)
        {
            string action = "";

            //50% chance to buy or pass
            if (RANDOM.Next(2) == 1) action = ACTION_BUY;
            else action = ACTION_PASS_ROUND;

            return action;
        }


        public void TrackPurchases(string player, int share)
        {
            Tracking.Add(new Tuple<string, int>(player,share));
        }

        //Allow the player to guess other players goals
        public void GuessGoals(List<Player> Players)
        {
            foreach (Player p in Players.Where(p => p != this))
                Guesses.Add(p.Name, GuessGoal(p));
        }

        #region Getters/Setters
        //Change the player's coins
        public virtual void AddCoins(int adjustment)
        {
            Coins += adjustment;
            OnCoinValueChange?.Invoke(this, GetCoins());
        }

        //Get the player's coin count
        public int GetCoins()
        {
            return Coins;
        }

        #endregion

        #endregion

        #region Helper Methods
        //Perform all checks and actions needed when the player decides to buy a share on their turn
        bool BuyShare(int shareValue)
        {
            bool success = false;

            //Check to see if the player has enough coins to buy
            if (GetCoins() < shareValue)
                WriteLine(Name + " cannot afford to buy share for " + shareValue + ".");
            else
            {
                AddCoins(-shareValue);
                BoughtShares.Add(shareValue);
                success = true;
                WriteLine(Name + " buys share for " + shareValue + ".");
            }

            return success;
        }

        //Perform all actions needed when the player decides to pass their turn
        void PassTurn()
        {
            WriteLine(Name + " passes.");
        }

        //Perform all actions needed when the player decides to pass for the remainder of the round
        void PassRound()
        {
            ActiveInRound = false;
            WriteLine(Name + " is done for the round.");
        }

        //Perform all actions needed when the player decides to pass for the remainder of the game
        void PassGame()
        {
            ActiveInRound = false;
            ActiveInGame = false;
            WriteLine(Name + " is done for the game.");
        }

        //(Generic) Allow the player to guess one player's goal
        protected virtual int GuessGoal(Player player)
        {
            int guess = GOALS[RANDOM.Next(GOALS.Count())];
            return guess;
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

    //A Player with hard-coded descision making.  Meant to be an easy computer opponent.
    class DumbAIPlayer : Player
    {
        #region Properties
        public int CoinsAtRoundStart; //The number of coins they had at the start of a round

        #endregion

        #region Constructor
        public DumbAIPlayer(String inName, int inID) : base(inName, inID) { }

        #endregion

        #region Override Methods
        //Decide on what action to take for the turn
        public override string DecideAction(int currentShareValue)
        {
            Action = ACTION_PASS_TURN;

            if (GetCoins() < currentShareValue) Action = ACTION_PASS_ROUND;
            else
            {
                //Determine how many coins you want from the current share
                int desiredReturn;
                switch (Goal)
                {
                    case 3:
                        //This goal always wants to lose as many coins as possible (but let's prevent underflow)
                        desiredReturn = int.MinValue + 100;
                        break;
                    case 40:
                        //This goal always wants to gain as many coins as possible (but let's prevent overflow)
                        desiredReturn = int.MaxValue - 100;
                        break;
                    default:
                        //Other goals may want to lose or gain coins based on their current value
                        int coinsAlreadyGained = 0;
                        foreach (int boughShare in BoughtShares) coinsAlreadyGained += (int)ReturnEstimate(boughShare);
                        desiredReturn = Goal - (CoinsAtRoundStart + coinsAlreadyGained);
                        break;
                }

                //Estimate the return from purchasing the current share
                double estimatedReturn = ReturnEstimate(currentShareValue);

                //Determine if buying the current share would get you closer to your goal (with a small buffer to allow for overshooting)
                bool getsCloser = Math.Abs(desiredReturn - estimatedReturn) < Math.Abs(desiredReturn) + .7;
                //Buy it if it does
                if (getsCloser)
                    Action = ACTION_BUY;
            }

            //When taking turn, AI waits a half second
            //int secondsToWait = RANDOM.Next(0, 2);
            NonBlockingSleep(500);

            return Action;
        }

        public override void AddCoins(int adjustment)
        {
            base.AddCoins(adjustment);
            CoinsAtRoundStart = GetCoins();
        }

        //Allow the player to guess one player's goals
        protected override int GuessGoal(Player player)
        {
            int coinTotal = 20;
            foreach (Tuple<string,int> record in Tracking)
            {
                if (record.Item1 == player.Name)
                {
                    //AI track purchases perfectly, so this artificially adds some uncertainty to their guessing
                    int badness = RANDOM.Next(-1, 2);
                    coinTotal += record.Item2 + badness;
                }
            }
            

            if (coinTotal < 7) return 3;
            if (coinTotal < 15) return 10;
            if (coinTotal < 25) return 20;
            if (coinTotal < 35) return 30;
            return 40;
        }
        #endregion

        #region Unique Methods
        //Estimate on how much the given share will return (based on weighted (frequency) averages across all possible payouts)
        double ReturnEstimate(int currentShareValue)
        {
            double estimate = 0;

            switch (currentShareValue)
            {
                case 0:
                    estimate = 1.1;
                    break;
                case 1:
                    estimate = .2;
                    break;
                case 2:
                    estimate = -.5;
                    break;
                case 3:
                    estimate = -1.4;
                    break;
                case 4:
                    estimate = -1.9;
                    break;
                case 5:
                    estimate = -2.8;
                    break;
                case 6:
                    estimate = -3;
                    break;
            }

            return estimate;
        }
        #endregion
    }

    //A Player to be controlled by a human.
    public class HumanPlayer : Player
    {
        #region Properties
        public event GuessingGoalEventHandler OnGuessingGoal;

        #endregion

        #region Constructor
        public HumanPlayer(String inName, int inID) : base(inName, inID) { }

        #endregion

        #region Override Methods
        //Decide on what action to take for the turn
        public override string DecideAction(int currentShareValue)
        {
            Action = "";

            while (Action == "")
                NonBlockingSleep(1);

            return Action;
        }

        protected override int GuessGoal(Player player)
        {
            Guess = -1;
            OnGuessingGoal?.Invoke(this, player.Name);
            while (Guess == -1)
                NonBlockingSleep(1);

            return Guess;
        }

        #endregion

    }
}
