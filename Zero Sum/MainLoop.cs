using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Zero_Sum
{


    static class MainLoop
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GameWindow gameWindow = new GameWindow();
            Application.Run(gameWindow);

            //This is where it gets good
            //just kidding, that's not how this works
        }
    }

    public static class Globals
    {
        //Actions that a player can take
        public const string ACTION_BUY = "Buy Share";
        public const string ACTION_PASS_TURN = "Pass Turn";
        public const string ACTION_PASS_ROUND = "Pass Round";
        public const string ACTION_PASS_GAME = "Pass Game";

        //Percentage of time to wait while counting delays
        public static double DELAY_FACTOR = 1;

        //List of goals available in a game
        public static List<int> GOALS = new List<int> { 3, 10, 20, 30, 40 };

        //Globally used random number generator
        public static Random RANDOM = new Random();

        //Remove an element from a list and return it
        public static T Pull<T>(this List<T> list, int index)
        {
            T r = list[index];
            list.RemoveAt(index);
            return r;
        }

        public static void NonBlockingSleep(int msDelay)
        {
            msDelay = (int) (msDelay * DELAY_FACTOR);
            for (int i = msDelay; i >= 0; i -= 10)
            {
                Application.DoEvents();
                Thread.Sleep(10);
            }

        }
    }

    public delegate void WritingEventHandler(string msg);
    public delegate void WaitingForPlayersEventHandler();
    public delegate void TakingTurnEventHandler(Player currentPlayer);
    public delegate void GuessingGoalEventHandler(Player currentPlayer, string playerForGuessingName);
    public delegate void ShareBoughtEventHandler(Player buyingPlayer, int shareValue);
    public delegate void NewShareAvailableEventHandler(int shareValue);
    public delegate void CoinValueChangedEventHandler(Player thisPlayer, int newCoinValue);
    public delegate void NewRoundEventHandler(int newRoundNumber);
}
