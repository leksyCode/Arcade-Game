using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeGame
{
    class Enemy
    {
      
        private int y;
        public int X { get; set; }

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
                    y = 2;
                }
                        } }
        public Enemy ()
        {
            Random rand = new Random();
            y = 2;
            X = rand.Next(1,Map.WIDTH-2);
        }
    }
}
