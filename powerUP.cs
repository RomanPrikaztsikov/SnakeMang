using System;

namespace SnakeMang
{
    class PowerUp : Point
    {
        public PowerUp(int x, int y) : base(x, y, 'P')
        {
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            base.Draw();
            Console.ResetColor();
        }
    }
}
