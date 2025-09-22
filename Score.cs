using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMang
{
    class Score
    {
        public int CurrentScore { get; private set; }

        public Score()
        {
            CurrentScore = 0;
        }

        public void Increase(int value)
        {
            CurrentScore += value;
        }

        public void Draw()
        {
            Console.SetCursorPosition(1, 26);
            Console.WriteLine($"Score: {CurrentScore}");
        }
    }
}