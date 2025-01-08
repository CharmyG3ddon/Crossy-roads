using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.ConstrainedExecution;


namespace Crossy_roads
{
    class Game
    {
        protected Map playMap;
        protected UIElements uiElements;
        protected Player player;
        private int fieldWidth = 50, fieldHeight = 25;
        private char fieldTile = '%';
        public int scoreCounter;
        protected List<Cars> m_cars = new List<Cars>();

        private DateTime startTime;  // For storing the start time of the timer
        public Game() 
        {
            //show intro, get player name and difficulty
            uiElements= new UIElements();
            uiElements.UIElementsDraw();
            //draw the map, set offset from edges
            playMap = new Map(fieldWidth, fieldHeight, fieldTile)
            {
                offsetX = 5,
                offsetY = 2
            };
            //draw player at middle bottom, with character being first character of name
            player = new Player((fieldWidth + playMap.offsetX) / 2, fieldHeight + playMap.offsetY, uiElements.PlayerName[0],3);
            //start timer
            startTime = DateTime.Now;

            //set scorecounter and score to 0
            scoreCounter = 0;
            player.score = 0;
            //spawn all the cars (-1 for top line)
            for (int i = playMap.offsetY-1;i<fieldHeight; i++)
            {
                m_cars.Add(new Cars(playMap.offsetY + i, playMap.offsetX, playMap.offsetX + fieldWidth, '8', uiElements.difficulty,playMap.offsetY,fieldHeight));
            }
            //begin play
            while (true)
            {
                Console.Clear();

                playMap.mapLoad();

                player.PlayerDraw(player.playerPosX,player.playerPosY);

                HandleInput();
                foreach (Cars car in m_cars)
                {
                    car.MoveCar();
                    //if a car hit the player
                    TestPlayerHit(car);
                }
                //ui elements: score and timer, at correct position
                TimeSpan elapsedTime = DateTime.Now - startTime;
                uiElements.InGameCounters(elapsedTime,scoreCounter,fieldWidth+playMap.offsetX,fieldHeight+playMap.offsetY,player.livesLeft);
                Thread.Sleep(100);
                if(player.livesLeft == 0)
                {
                    break;
                }
            }
            //after game ended, show endscreen
            TimeSpan _elapsedTime = DateTime.Now - startTime;
            uiElements.EndScreen(_elapsedTime,player.score);

        }


        //Controls for playing the game
        public void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.Z:
                        player.MoveUp(playMap.offsetY);
                        //if player has reached end and scored, reset map for next level
                        if(player.score>scoreCounter)
                        {
                            scoreCounter = player.score;
                            player.ResetPosition(fieldHeight,playMap.offsetY);                            
                        }
                        break;
                    case ConsoleKey.S:
                        player.MoveDown(playMap.offsetY+playMap.fieldHeight);
                        break;
                    case ConsoleKey.Q:
                        player.MoveLeft(playMap.offsetX);
                        break;;
                    case ConsoleKey.D:
                        player.MoveRight(playMap.offsetX+playMap.fieldWidth);
                        break;
                }
            }
        }

        public void TestPlayerHit(Cars car)
        {
            //repeat for longer cars
            for (int i = 1; i <= uiElements.difficulty; i++)
            {
                if (car.carPosX-i == player.playerPosX && car.carPosY == player.playerPosY && car.carDirection == 'L')
                {
                    player.ResetPosition(fieldHeight, playMap.offsetY);
                    player.livesLeft--;
                }
                else if (car.carPosX+i == player.playerPosX && car.carPosY == player.playerPosY && car.carDirection == 'R')
                {
                    player.ResetPosition(fieldHeight, playMap.offsetY);
                    player.livesLeft--;
                }
            }
    
        }

    }
}
