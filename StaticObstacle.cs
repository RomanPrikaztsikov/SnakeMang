using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMang
{
    class StaticObstacle : Figure
    {
        public StaticObstacle(int x, int y, char symbol)
        {
            pList = new List<Point>();
            pList.Add(new Point(x, y, symbol));
        }
    }
}