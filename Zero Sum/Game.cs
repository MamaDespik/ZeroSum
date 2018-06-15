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
    class Game
    {
        #region Properties
        public List<Player> Players; //List of players in the game
        public int RoundWashCount; //Count of how many rounds have been washes
        public Round CurrentRound; //The currently active round
        protected List<Player> Winners = new List<Player>(); //List of the winners at the end of the game
        public bool WaitingForPlayers;

        public event WritingEventHandler OnWriting;
        public event WaitingForPlayersEventHandler OnWaitingForPlayers;
        public event NewRoundEventHandler OnNewRound;
        public event ShareBoughtEventHandler OnShareBought;
        public event NewShareAvailableEventHandler OnNewShareAvailable;

        #endregion

        #region Constructor
        public Game()
        {
            RoundWashCount = 0;
            Players = new List<Player>();
        }

        #endregion

        #region Public Methods
        //When the game starts, set up all variables
        public void Setup()
        {
            GetHumanPlayers();
            if (Players.Count == 0) DELAY_FACTOR = 0;
            GetComputerPlayers();

            Players.ForEach(p => p.OnWriting += Write);

            AssignGoals();
            SetPlayerOrder();
        }

        //Run the game
        public List<Player> Run()
        {
            int roundCount = 1;
            //Create new rounds until three rounds total have been washes (no coins exchange hands)
            while (RoundWashCount < 3)
            {
                OnNewRound?.Invoke(roundCount);
                NonBlockingSleep(1);

                WriteLine("");
                WriteLine("------------- Round " + roundCount + " -----------");

                if (RunRound())
                {
                    //If the round ends as a wash, increment the counter
                    RoundWashCount++;
                    WriteLine("Current number of washes: " + RoundWashCount);
                }
                roundCount++;
                Players.Add(Players.Pull(0));//move the current player to the end of the line

                if (roundCount > 50) break; //prevent games from lasting forever
            }
            EndGame();
            return Winners;
        }

        #endregion

        #region Helper Methods

        //Add a human player to the game
        void GetHumanPlayers()
        {
            WaitingForPlayers = true;
            OnWaitingForPlayers?.Invoke();

            while (WaitingForPlayers)NonBlockingSleep(10);
        }

        //Fill any open spots in the game with computer players
        void GetComputerPlayers()
        {
            List<string> ComputerNames = new List<string>{"Groot", "Thor", "Hulk", "Mantis", "Thanos", "Spider-Man",
                "Captain America", "Iron Man", "Black Panther", "Doctor Strange", "Scarlet Witch",
                "Star-Lord", "Loki", "Gamora", "Black Widow", "Vision", "Bucky", "Nebula", "Drax", "Ant-Man (Not Pictured)"};

            while(Players.Count<5)
            {
                NonBlockingSleep(1);
                Player tempPlayer = new DumbAIPlayer(ComputerNames.Pull(RANDOM.Next(ComputerNames.Count())), RANDOM.Next());
                Players.Add(tempPlayer);
                WriteLine(tempPlayer.Name + " joined the game!");
            }
        }

        //Assign one of the goals to each player
        protected virtual void AssignGoals()
        {
            List<int> goalAssignments = new List<int>(GOALS);
            for (int i = Players.Count; i > 0; i--)
                Players[i - 1].Goal = goalAssignments.Pull(RANDOM.Next(0, i));
        }

        //Determine which player goes first, and the order of players
        protected virtual void SetPlayerOrder()
        {
            //sort by randomly assigned ID
            Players.Sort((x, y) => x.ID - y.ID);

            //Write the order to the console
            string playerList = "";
            Players.ForEach(p => playerList += p.Name + ", ");
            playerList = playerList.Remove(playerList.Count() - 2, 2);
            WriteLine("Player order: " + playerList);
        }

        //Run a new round and return whether the round was a wash or not
        bool RunRound()
        {
            CurrentRound = new Round(Players);
            CurrentRound.OnShareBought += PostSharePurchase;
            CurrentRound.OnNewShareAvailable += PostNewShare;
            CurrentRound.Setup();
            CurrentRound.OnWriting += Write;
            return CurrentRound.PlayRound();
        }

        //Process the end game stage
        void EndGame()
        {
            WriteLine("");
            WriteLine("Entering End Game");

            GetPlayerGuesses();
            SetScores();
            DeclareWinner();
        }

        //Get the guesses from each player
        void GetPlayerGuesses()
        {
            foreach (Player p in Players)
                p.GuessGoals(Players);
        }

        //Calculate the score for each player
        void SetScores()
        {
            foreach (Player p in Players)
                SetScore(p);
        }

        //Calculate the score for a single player
        void SetScore(Player currentPlayer)
        {
            WriteLine("");
            WriteLine("--------- Scoring " + currentPlayer.Name + " ---------");

            //See if the player met their goal
            if (checkGoal(currentPlayer))
            {
                currentPlayer.Score += 3;
                WriteLine("Met goal of " + currentPlayer.Goal + ": " + currentPlayer.GetCoins());
            }
            else WriteLine("Failed goal of " + currentPlayer.Goal + ":  " + currentPlayer.GetCoins() + " coins.");

            //check the guesses of the player
            foreach (KeyValuePair<string, int> kvp in currentPlayer.Guesses)
                if (checkGuess(kvp)) currentPlayer.Score += 2;

            WriteLine("Score: " + currentPlayer.Score);
        }

        //Determine if a player has met their goal
        bool checkGoal(Player currentPlayer)
        {
            bool metGoal = false;

            switch (currentPlayer.Goal)
            {
                case 3:
                    if (currentPlayer.GetCoins() <= 3) metGoal = true;
                    break;
                case 40:
                    if (currentPlayer.GetCoins() >= 40) metGoal = true;
                    break;
                default:
                    if (currentPlayer.GetCoins() == currentPlayer.Goal) metGoal = true;
                    break;
            }

            return metGoal;
        }

        //Determine if a guess is correct
        bool checkGuess(KeyValuePair<string, int> kvp)
        {
            bool isGuessCorrect = false;

            //Find the player being guessed about
            Player guessedPlayer;
            guessedPlayer = Players.Find(match => match.Name == kvp.Key);

            //Evaluate if the guess is correct
            isGuessCorrect = guessedPlayer.Goal == kvp.Value;

            //Write the guess
            string message = "Guess for ";
            message += guessedPlayer.Name + ": " + kvp.Value;
            if (isGuessCorrect) message += ".  Correct!";
            else message += ".  Nope!";
            WriteLine(message);

            return isGuessCorrect;
        }

        //Determine the winner(s) and end the game
        void DeclareWinner()
        {

            //foreach (Player p in Players)
            //{
            //    Write("");
            //    Write("--------- " + p.Name + " --------");
            //    Write("Scored: " + p.Score);
            //    Write("Goal: " + p.Goal);
            //    Write("Coins: " + p.Coins);
            //}

            //Find player(s) with the highest score
            int highestScore = Players.Max(p => p.Score);
            Winners = Players.FindAll(p => (p.Score == highestScore));

            //Print winning message
            string winnerNames = "Winner: ";
            Winners.ForEach(p => winnerNames += p.Name + ", ");
            WriteLine("");
            WriteLine(winnerNames);

            //Write("Nobody Wins!");
        }

        #endregion

        #region Functional Methods
        //Send a message to the game window
        protected void Write(string msg)
        {
            //GameWindow.Write(msg);

            //msg += Environment.NewLine;
            OnWriting?.Invoke(msg);
        }
        protected void WriteLine(string msg)
        {
            Write(msg + Environment.NewLine);
        }

        void PostSharePurchase(Player buyingPlayer, int shareValue)
        {
            OnShareBought?.Invoke(buyingPlayer, shareValue);
        }

        void PostNewShare(int shareValue)
        {
            OnNewShareAvailable?.Invoke(shareValue);
        }
        #endregion
    }

    class DebugGame : Game
    {
        #region Constructor
        public DebugGame() : base() { }

        #endregion

        #region Override Methods
        //Assigns goals in order, rather than randomly
        protected override void AssignGoals()
        {

            for (int i = Players.Count; i > 0; i--)
                Players[i - 1].Goal = GOALS[i - 1];
        }

        #endregion

        #region Unique Methods

        #endregion
    }
}
