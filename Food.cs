using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Food
    {
        public Food(int Width, int Height, char Sym = '@')
        {
            Symbol = Sym;
            WindowWidth = Width;
            WindowHeight = Height;
            FoodCounter = 5;
            for (int i = 0; i < FoodCounter; i++) {
                CoordsX.Add(rand.Next(WindowWidth - 6) + 4);
                if ((int)CoordsX[i] % 2 != 0) CoordsX[i] = (int)CoordsX[i] - 1;
                CoordsY.Add(rand.Next(WindowHeight - 10) + 5);
                IsPick.Add(false);
            }
        }

        public bool Draw(ArrayList x, ArrayList y)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < CoordsX.Count; i++) {
                if ((bool)IsPick[i] == false)
                {
                    Console.SetCursorPosition((int)CoordsX[i], (int)CoordsY[i]);
                    Console.Write(Symbol);
                }
                else
                {
                    CoordsX[i] = rand.Next(WindowWidth - 10) + 4;
                    if ((int)CoordsX[i] % 2 != 0) CoordsX[i] = (int) CoordsX[i] - 1;
                    CoordsY[i] = rand.Next(WindowHeight - 10) + 5;
                    IsPick[i] = false;
                }
                for (int k = 0; k < x.Count; k++)
                {
                    if ((int) x[k] == (int) CoordsX[i] && (int) y[k] == (int) CoordsY[i])
                    {
                        IsPick[i] = true;
                        Console.SetCursorPosition((int)CoordsX[i], (int)CoordsY[i]);
                        Console.WriteLine(' ');
                        return true;
                    }
                }
            }
            return false;
        }
        private readonly char Symbol;
        private readonly int WindowWidth, WindowHeight;
        public Random rand = new Random();
        private ArrayList CoordsX = new ArrayList();
        private ArrayList CoordsY = new ArrayList();
        private ArrayList IsPick = new ArrayList();
        private readonly int FoodCounter; 
    }
}
