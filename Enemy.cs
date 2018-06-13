using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeGame
{
    class Enemy
    {
        static Random rand = new Random(DateTime.Now.Millisecond);
        private int y;
        public int X { get; set; }
        public int X2 { get; set; }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value < Map.HEIGHT)
                {
                    y = value;
                }
                else
                {
                    y = 0;
                }
            }
        }
        public Enemy()
        {
            y = 0;
            while (X % 2 == 0)
            {
                X = rand.Next(1, Map.WIDTH - 2);
                X2 = X + 1;
            }
        }
    }
}
