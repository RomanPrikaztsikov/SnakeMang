using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMang
{
    class GameOverScreen
    {
        public void Show(int finalScore)
        {
            Console.Clear();
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("GAME OVER");
            Console.SetCursorPosition(28, 12);
            Console.WriteLine($"Teie Tulemus: {finalScore}");
            Console.SetCursorPosition(25, 14);
            Console.WriteLine("Väljumiseks vajutage suvalist klahvi...");
            Console.ReadKey();
        }
    }
}
