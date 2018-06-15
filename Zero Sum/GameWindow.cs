using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Zero_Sum.Globals;

namespace Zero_Sum
{
    public partial class GameWindow : Form
    {
        #region Properties
        Game CurrentGame;
        bool Debug;
        int gamecount = 0;
        List<int> WinnerGoalsRecord = new List<int>();
        Player CurrentPlayer;

        #endregion

        #region Constructor
        public GameWindow()
        {
            InitializeComponent();

            //GuessField.Hide();
            //GuessLabel.Hide();
            //SetupGameButton.Hide();
            //RunGameButton.Hide();
            //OKButton.Hide();
            //AddPlayerButton.Hide();
            //NameField.Hide();
            //NameLabel.Hide();
            //DoneButton.Hide();
            //DebugButton.Hide();
            //StopButton.Hide();
            //ActionsBox.Hide();
            ActionsBox.Items.AddRange(new object[] {
            ACTION_BUY, ACTION_PASS_TURN, ACTION_PASS_ROUND, ACTION_PASS_GAME});
            Output.ScrollBars = ScrollBars.Both;
        }

        #endregion

        #region UI Events
        private void NewGame_Click(object sender, EventArgs e)
        {
            NewGameMethod();
        }

        private void SetupGame_Click(object sender, EventArgs e)
        {
            SetupMethod();
        }

        private void RunGame_Click(object sender, EventArgs e)
        {
            RunGameMethod();
        }

        private void AddPlayer_Click(object sender, EventArgs e)
        {
            AddPlayerMethod();
        }

        private void Debug_Click(object sender, EventArgs e)
        {
            DebugMethod();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopMethod();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            DoneMethod();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            OKButtonMethod();
        }

        private void OKButton2_Click(object sender, EventArgs e)
        {
            OKButton2Method();
        }

        #endregion

        #region UI Methods
        void NewGameMethod()
        {
            CurrentGame = new Game();
            CurrentGame.OnWriting += Write;
            CurrentGame.OnShareBought += UpdateShareCollectionDisplay;
            CurrentGame.OnNewShareAvailable += UpdateCurrentShareDisplay;
            SetupGameButton.Show();
            Output.Clear();
            PlayerDisplayPanel.Hide();
            TurnPanel.Hide();
        }

        void SetupMethod()
        {
            AddPlayerButton.Show();
            NameLabel.Show();
            NameField.Show();
            DoneButton.Show();

            CurrentGame.Setup();

            DoneButton.Hide();
            AddPlayerButton.Hide();
            NameLabel.Hide();
            NameField.Hide();
            SetupGameButton.Hide();
            RunGameButton.Show();
        }

        void RunGameMethod()
        {
            RunGameButton.Hide();
            PlayerDisplayPanel.Show();
            CurrentShareText.Text = "0";
            CurrentShareBox.Show();
            foreach (Player p in CurrentGame.Players)
            {
                p.OnTakingTurn += TakingTurn;
            }

            List<Player> winners = CurrentGame.Run();

            gamecount++;
            //Print to keep track of goal win percentage
            winners.ForEach(p => WinnerGoalsRecord.Add(p.Goal));
            three.Text = (int)(((double)WinnerGoalsRecord.Where(g => g == 3).Count() / gamecount) * 100) + "%";
            ten.Text = (int)(((double)WinnerGoalsRecord.Where(g => g == 10).Count() / gamecount) * 100) + "%";
            twenty.Text = (int)(((double)WinnerGoalsRecord.Where(g => g == 20).Count() / gamecount) * 100) + "%";
            thirty.Text = (int)(((double)WinnerGoalsRecord.Where(g => g == 30).Count() / gamecount) * 100) + "%";
            forty.Text = (int)(((double)WinnerGoalsRecord.Where(g => g == 40).Count() / gamecount) * 100) + "%";
            GameCount.Text = gamecount.ToString();


        }

        void AddPlayerMethod()
        {
            if (CurrentGame.Players.Count < 5)
            {
                HumanPlayer tempPlayer = new HumanPlayer(NameField.Text, RANDOM.Next());
                tempPlayer.OnTakingTurn += TakingTurn;
                tempPlayer.OnGuessingGoal += Guessing;
                tempPlayer.OnCoinValueChange += UpdateCoinDisplay;
                CurrentGame.Players.Add(tempPlayer);
                WriteLine(NameField.Text + " joined the game!");
                NameField.Clear();
                DoneButton.Show();
            }
            else WriteLine("Cannot add new player.");
        }

        void DebugMethod()
        {
            Debug = true;
            while (Debug && (gamecount < 1000))
            {
                NonBlockingSleep(1);
                NewGameMethod();
                SetupMethod();
                RunGameMethod();
            }
        }

        void StopMethod()
        {
            Debug = false;
        }

        void DoneMethod()
        {
            CurrentGame.WaitingForPlayers = false;
        }

        void OKButtonMethod()
        {
            var action = ActionsBox.SelectedItem;
            if (action == null) return;
            CurrentPlayer.Action = ActionsBox.SelectedItem.ToString();
            ActionsBox.SelectedItem = null;
            TurnPanel.Hide();
        }

        void OKButton2Method()
        {
            var guess = GuessesBox.SelectedItem;
            if (guess == null) return;
            CurrentPlayer.Guess = Convert.ToInt32(guess);
            GuessesBox.SelectedItem = null;
            GuessingPanel.Hide();
        }

        #endregion

        #region Helper Methods
        void Write(string msg)
        {
            Output.AppendText(msg);
            //Output.AppendText(Environment.NewLine);
        }
        void WriteLine(string msg)
        {
            Write(msg + Environment.NewLine);
        }

        public void TakingTurn(Player inPlayer)
        {
                CurrentPlayer = inPlayer;
                UpdateShareCollectionDisplay(CurrentPlayer, 0);

            if (CurrentPlayer is HumanPlayer)
            {
                PlayerNameText.Text = CurrentPlayer.Name;
                TurnPanel.Show();
                PlayerGoalText.Text = CurrentPlayer.Goal.ToString();
                UpdateCoinDisplay(CurrentPlayer, CurrentPlayer.GetCoins());
                CurrentPlayer.Action = ActionsBox.SelectedItem?.ToString();
            }
            else
            {
                PlayerNameText.Text = CurrentPlayer.Name;
                PlayerGoalText.Text = "?";
                PlayerCoinsText.Text = "?";
                //BoughtSharesText.Text = "?";
            }

        }

        void Guessing(Player inPlayer, string name)
        {
            CurrentPlayer = inPlayer;
            PlayerNameForGuessLabel.Text = name;
            GuessingPanel.Show();
        }

        void UpdateCoinDisplay(Player inPlayer, int newCoinValue)
        {
            if (inPlayer == CurrentPlayer && inPlayer is HumanPlayer) PlayerCoinsText.Text = newCoinValue.ToString();
        }

        void UpdateShareCollectionDisplay(Player buyingPlayer, int shareValue)
        {
            //if (buyingPlayer == CurrentPlayer && buyingPlayer is HumanPlayer)
            if (buyingPlayer == CurrentPlayer)
            {
                string shares = "-";
                if (CurrentPlayer.BoughtShares.Count != 0) shares = "";
                CurrentPlayer.BoughtShares.ForEach(s => shares += " " + s.ToString() + ",");
                BoughtSharesText.Text = shares.TrimEnd(',');
            }

            //else BoughtSharesText.Text = "Unknown";
        }

        void UpdateCurrentShareDisplay(int shareValue)
        {
            CurrentShareText.Text = shareValue.ToString();
            CurrentShareBox.Show();
        }
        #endregion
    }
}
