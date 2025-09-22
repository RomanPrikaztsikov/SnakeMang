using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMang
{
    class BonusFood : Point
    {
        public int BonusPoints { get; set; }

        public BonusFood(int x, int y, char sym, int bonusPoints) : base(x, y, sym)
        {
            BonusPoints = bonusPoints;
        }
    }
}