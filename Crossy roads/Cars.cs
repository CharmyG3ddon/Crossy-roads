using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Crossy_roads
{
    class Cars: Object
    {

        public int carPosY;
        public int carPosX;
        public int leftMapEnd, rightMapEnd;
        public char carTile;
        public int score = 0;
        public int carSpeed;
        private bool carDriving = false;
        public char carDirection;
        public int offsetY, height;

        public Cars(int posY,int offsetX, int mapWidth, char tile, int speed,int firstY, int lastY)
        {
            carPosY = posY;
            leftMapEnd = offsetX;
            rightMapEnd = mapWidth;
            carTile = tile;
            carSpeed = speed;
            offsetY = firstY;
            height = lastY;
        }

        public void MoveCar()
        {
            //if there is a car, move it forward
            if(carDriving && carDirection=='L')
            {
                if(carPosX>=rightMapEnd)
                {
                    DestroyCar();
                }
                else
                {
                    for(int i = 1; i <= carSpeed;i++)
                    {
                        carPosX++;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition(carPosX, carPosY);
                        Console.WriteLine(carTile);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

            }
            else if(carDriving && carDirection=='R')
            {
                if (carPosX <= leftMapEnd)
                {
                    DestroyCar();
                }
                else
                {
                    for (int i = 1; i <= carSpeed; i++)
                    {
                        carPosX--;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition(carPosX, carPosY);
                        Console.WriteLine(carTile);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }  
            }
            //else spawn a new car
            else
            {
                SpawnCar();
            }
        }
        public void DestroyCar()
        {
            carDriving = false;
            Console.SetCursorPosition(carPosX, carPosY);
            Console.WriteLine();
        }

        public void SpawnCar()
        {
            carDriving = true;
            //randomize car spawn to not spawn them all together
            Random random = new Random();
            int rndSpawner = random.Next(offsetY, height+offsetY);
            if(carPosY == rndSpawner)
            {
                //spawn either left or right
                int rndDir = random.Next(1, 3);
                if (rndDir == 1)
                {
                    carPosX = leftMapEnd;
                    carDirection = 'L';
                }
                else
                {
                    carPosX = rightMapEnd;
                    carDirection = 'R';
                }
                Console.SetCursorPosition(carPosX, carPosY);
                Console.WriteLine(carTile);
            }     
        }
    }
}
