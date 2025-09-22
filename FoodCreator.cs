using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMang
{
    class FoodCreator
    {
        private int mapWidth;
        private int mapHeight;
        private char sym;

        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        public Point CreateFood()
        {
            int x = random.Next(2, mapWidth - 2);
            int y = random.Next(2, mapHeight - 2);

            if (random.Next(0, 10) == 0)
            {
                return new BonusFood(x, y, '$', 5);
            }
            return new Point(x, y, sym);
        }
    }
}