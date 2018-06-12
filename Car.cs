using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeGame
{
    class Car
    {
        private int x;
        public int X
        {
            get { return x; }
            set
            {
                if (value < 1)
                    x = 1;
                else if (value > Map.WIDTH - 2)
                    x = Map.WIDTH - 2;
                else x = value;
            }
        }
        public int Health { get; set; } = 100;

        public Car(int x)
        {
            X = x;
        }

        public bool IsAlive()
        {
            if (Health > 0)
            {
                return true;
            }
            return false;
        }

    }
}

