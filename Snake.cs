using System;
using System.Collections;

namespace SnakeGame
{
    class Snake
    {
        public Snake(char Symbol)
        {
            for (int i = 0; i < startLength; i++)
            {
                CoordsX.Add(0);
                CoordsY.Add(0);
            }
            Alive = true;
            this.Symbol = Symbol;
            CoordsX[0] = 10;
            CoordsY[0] = 5;
            Length = startLength;
            for (int i = 1; i < Length; i++) {
                CoordsX[i] = (int) CoordsX[i - 1] - 1;
                CoordsY[i] = (int) CoordsY[i - 1];
            }
            Direction = Side.Right;
        }

        public void Move(ConsoleKeyInfo key)
        {
            for (int i = CoordsX.Count - 1; i > 0; i--)
            {
                CoordsX[i] = CoordsX[i - 1];
                CoordsY[i] = CoordsY[i - 1];
            }
            char buf = (char)key.Key;
            switch (buf)
            {
                case 'W': if (Direction != Side.Down) Direction = Side.Up; break;
                case 'D': if (Direction != Side.Left) Direction = Side.Right; break;
                case 'S': if (Direction != Side.Up) Direction = Side.Down; break;
                case 'A': if (Direction != Side.Right) Direction = Side.Left; break;
            }
            switch (Direction)
            {
                case Side.Up: CoordsY[0] = (int)CoordsY[0] - 1; break;
                case Side.Right: CoordsX[0] = (int)CoordsX[0] + 2; break;
                case Side.Down: CoordsY[0] = (int)CoordsY[0] + 1; break;
                case Side.Left: CoordsX[0] = (int)CoordsX[0] - 2; break;
            }
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < CoordsX.Count; i++)
            {
                Console.SetCursorPosition((int) CoordsX[i], (int) CoordsY[i]);
                Console.Write(Symbol);
            }
        }

        public void Update(ConsoleKeyInfo buf)
        {
            if (GetAlive() == true)
            {
                Clear();
                Move(buf);
                Draw();
            }
        }

        public void Clear()
        {
            for (int i = 0; i < CoordsX.Count; i++) {
                Console.SetCursorPosition((int) CoordsX[i], (int) CoordsY[i]);
                Console.Write(' ');
            }
        }

        public bool GetAlive() { return Alive; }
        public void SetAlive(bool Val) { Alive = Val; }

        public bool IsAlive(int Width, int Height)
        {
            if ((int)CoordsX[0] <= 2 || (int)CoordsX[0] >= Width - 2 || (int)CoordsY[0] <= 2 || (int)CoordsY[0] >= Height - 3)
            {
                Alive = false;
            }
            else
            {
                Alive = true;
            }
            return Alive;
        }

        public void IncLength()
        {
            int x = (int) CoordsX[0];
            int y = (int) CoordsY[0];

            switch (Direction)
            {
                case Side.Up: y -= 1; break;
                case Side.Right: x += 2; break;
                case Side.Down: y += 1; break;
                case Side.Left: x -= 2; break;
            }

            CoordsX.Add(0);
            CoordsY.Add(0);
            for (int i = CoordsX.Count - 1; i > 0; i--)
            {
                CoordsX[i] = CoordsX[i - 1];
                CoordsY[i] = CoordsY[i - 1];
            }
            CoordsX[0] = x;
            CoordsY[0] = y;
            Length++;
        }

        public bool IsIntersected()
        {
            for (int i = 0; i < CoordsX.Count; i++)
            {
                for (int j = 0; j < CoordsX.Count; j++)
                {
                    if ((int)CoordsX[i] == (int)CoordsX[j] && (int)CoordsY[i] == (int)CoordsY[j] && i != j )
                    {
                        return true;

                    }
                }
            }
            return false;
        }
        public ArrayList GetCoordsX() { return CoordsX; }
        public ArrayList GetCoordsY() { return CoordsY; }
        public int GetHeadX() { return (int)CoordsX[0]; }
        public int GetHeadY() { return (int)CoordsY[0]; }

        private bool Alive;
        private int Length;
        private ArrayList CoordsX = new ArrayList();
        private ArrayList CoordsY = new ArrayList();
        private readonly char Symbol;
        private const int startLength = 4;
        private Side Direction;
        public enum Side
        {
            Up,
            Right,
            Down,
            Left
        }
    }
}
