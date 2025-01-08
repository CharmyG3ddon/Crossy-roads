using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Crossy_roads
{
    class Map
    {
        public int fieldWidth { get; set; }
        public int fieldHeight { get; set; }
        protected char fieldTile;
        public int offsetX = 0;
        public int offsetY = 0;
        public Map(int width, int height, char tile) 
        { 
            fieldWidth = width;
            fieldHeight = height;
            fieldTile = tile; 
        }
        public void mapLoad()
        {
            //string of fieldtile the widtht of the field
            string line = new string(fieldTile, fieldWidth);
            //Draw top border
            Console.SetCursorPosition(offsetX, offsetY);
            Console.WriteLine(line);
            //Draw bottom border
            Console.SetCursorPosition(offsetX, fieldHeight + offsetY);
            Console.WriteLine(line);
        }
    }
}
