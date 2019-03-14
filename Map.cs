using System;

namespace SnakeGame
{
    class Map
    {
        public Map(int Width, int Height, char Symbol = '*')
        {
            BorderSymbol = Symbol;
            this.Width = Width;
            this.Height = Height;
            Console.SetWindowSize(Width, Height);
            Console.SetBufferSize(Width, Height);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 2; i < Width; i += 2) {
                Console.SetCursorPosition(i, 2);
                Console.Write(BorderSymbol);
                Console.SetCursorPosition(i, Height - 3);
                Console.Write(BorderSymbol);
            }
            for (int i = 2; i < Height - 3; i += 1)
            {
                Console.SetCursorPosition(2, i);
                Console.Write(BorderSymbol);
                Console.SetCursorPosition(Width - 2, i);
                Console.Write(BorderSymbol);
            }
            Console.SetCursorPosition(2, Height - 1);
            Console.Write("Scores:");
        }

        public void GameOverPrint(int W, int H)
        {
            int x = W / 4;
            int y = H / 5;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("0 0 0 0 0    0 0 0 0 0    0 0   0 0    0 0 0 0 0");
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("0            0       0    0   0   0    0        ");
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("0            0       0    0   0   0    0        ");
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("0    0  0    0 0 0 0 0    0   0   0    0 0 0 0 0");
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("0       0    0       0    0   0   0    0        ");
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("0       0    0       0    0   0   0    0        ");
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("0 0 0 0 0    0       0    0       0    0 0 0 0 0");
            Console.SetCursorPosition(x, ++y);
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("0 0 0 0 0    0       0    0 0 0 0 0    0 0 0 0 0");
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("0       0    0       0    0            0       0");
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("0       0    0       0    0            0       0");
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("0       0    0       0    0 0 0 0 0    0 0 0 0 0");
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("0       0    0       0    0            0    0");
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("0       0     0     0     0            0      0");
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("0 0 0 0 0      0 0 0      0 0 0 0 0    0       0");
        }

        public void PrintScore(long Value)
        {
            if (Value < 200)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (Value >= 200 && Value <= 400)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.SetCursorPosition(10, Height - 1);
            Console.Write(Value);
        }

        private char BorderSymbol;
        private int Width, Height;
    }
}
