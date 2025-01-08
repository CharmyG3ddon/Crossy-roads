using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossy_roads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey key;
            while (true)
            {
                Game game = new Game();
                Console.Clear();


                while (true)
                {
                    Console.WriteLine("Would you like to play again? (Y/N)");
                    key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Y || key == ConsoleKey.N)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("please answer Y to continue or N to stop");
                    }
                }              
                if (key == ConsoleKey.N)
                {
                    Console.WriteLine("Thank you for playing!");
                    Console.ReadLine();
                    break; //Exit the game loop and end the program
                }
            }


        }
    }
}
