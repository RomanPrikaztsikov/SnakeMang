using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SnakeMang
{
    class StaticObstacle : Point
    {
        public StaticObstacle(int x, int y, char symbol) : base(x, y, symbol) { }

        public void Draw()
        {
            base.Draw();
        }
    }

}
