using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        private int leftX;
        private int topY;

        public Point(int leftX,int topY)
        {
            this.LeftX = leftX;
            this.TopY = topY;
        }

        public int LeftX
        {
            get
            {
                return leftX;
            }
            set
            {
                if (value < -1 || value > Console.WindowWidth)
                {
                    throw new IndexOutOfRangeException();
                }

                leftX = value;
            }
        }

        public int TopY
        {
            get
            {
                return topY;
            }
            set
            {
                if (value < -1 || value > Console.WindowHeight)
                {
                    throw new IndexOutOfRangeException();
                }

                topY = value;
            }
        }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.LeftX, this.TopY);
            Console.Write(symbol);
        }

        public void Draw(int leftX, int topY, char symbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbol);
        }
    }
}
