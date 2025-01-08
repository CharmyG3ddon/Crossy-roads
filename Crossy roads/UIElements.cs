using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Crossy_roads
{
    class UIElements
    {
        public string PlayerName { get; private set; }
        public int difficulty = 0;
        
        //intro to game
        public void UIElementsDraw()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Crossy Road!");

            Console.Write("enter player name:");
            PlayerName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Welcome to Crossy roads");
            Console.WriteLine("choose your difficulty:");
            Console.WriteLine("for easy, enter 'E', for medium, enter M, for hard enter H");
            while (difficulty ==0)
            {
                string input= Console.ReadLine();
                input = input.ToUpper();
                switch (input)
                {
                    case "E":
                        difficulty = 1;
                        break;
                    case "M":
                        difficulty = 2;
                        break;
                    case "H":
                        difficulty = 3;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please enter 'E', for medium, enter M, for hard enter H");
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine($"Welcome, {PlayerName}!");
            Console.WriteLine($"You have chosen to play {(difficulty == 1 ? "Easy" : difficulty == 2 ? "Medium": "hard")} mode.");
            Console.WriteLine("Press any key to start the game...");
            Console.ReadKey();
        }

        public void InGameCounters(TimeSpan time, int score, int mapWidth, int mapHeight, int lives)
        {
            Console.SetCursorPosition(mapWidth + 2, mapHeight);
            Console.WriteLine("points:" + score);
            Console.SetCursorPosition(mapWidth + 2, 2);
            Console.WriteLine("Lives:" + lives);
            Console.SetCursorPosition(1, 0);
            Console.WriteLine(($"Time: {time:mm\\:ss}"));
        }

        public void EndScreen(TimeSpan time, int score)
        {
            double finalScoreDouble = score / (time.TotalSeconds/10);
            int finalScoreInt = (int)finalScoreDouble;
            Console.Clear();
            Console.WriteLine($"you achieved a score of {finalScoreInt}");
            Console.WriteLine("Would you like to save your score? (Y/N)");
            while (true)
            {
                ConsoleKey key;
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Y)
                {
                    SaveFile(finalScoreInt);
                    break;
                }
                else if(key == ConsoleKey.N)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("please answer Y to save or N to not save");
                }
            }
        }
        private void SaveFile(int score)
        {
            string getfromFile = PlayerName + ": " + score;
            //try reading a file if this is not the first time being played
            StreamWriter exisitingWriter = null;
            try
            {
                exisitingWriter = new StreamWriter("playerScores.txt",true);
                exisitingWriter.WriteLine(getfromFile);
            }
            catch (Exception e)
            {
                //if this is the first time playing, create a new txt file
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter("playerScores.txt");
                    writer.WriteLine(getfromFile);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    writer?.Close();
                }
                Console.WriteLine(e);
            }
            finally
            {
                exisitingWriter?.Close();
            }

        }
    }
}
