using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossy_roads
{
    class Player: Object
    {
        public int playerPosX, playerPosY;
        public char playerTile;
        public int score = 0;
        public int livesLeft;

        public Player(int posX, int posY,char tile, int lives)
        {
            playerPosX = posX;
            playerPosY = posY;
            playerTile = tile;
            livesLeft = lives;
        }

        public void PlayerDraw(int posX,int posY)
        {
            Console.SetCursorPosition(posX,posY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(playerTile);
            Console.ForegroundColor= ConsoleColor.White;
        }

        public void MoveUp(int upperBoundary)
        {
            if (playerPosY > upperBoundary)
            {
                playerPosY--;
            }
            else if( playerPosY == upperBoundary)
            {
                score++;
            }
        }

        // Method to move the racket down
        public void MoveDown(int lowerBoundary)
        {
            if (playerPosY < lowerBoundary)
            {
                playerPosY++;
            }
        }

        public void MoveRight(int upperBoundary)
        {
            if (playerPosX < upperBoundary)
            {
                playerPosX++;
            }
        }

        // Method to move the racket down
        public void MoveLeft(int lowerBoundary)
        {
            if (playerPosX > lowerBoundary)
            {
                playerPosX--;
            }
        }

        public void ResetPosition(int fieldHeight, int offsetY)
        {
            playerPosY = fieldHeight + offsetY;
        }
    }
}
