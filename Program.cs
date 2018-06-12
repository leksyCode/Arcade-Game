using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeGame
{
    class Program
    {

        static void Main(string[] args)
        {
            int startX = Map.WIDTH / 2;
            Car c = new Car(startX);

            while (true)
            {
                Move(c);
                Console.Clear();
                GraphicUpdate();
            }
        }

        public static void GraphicUpdate()
        {
            for (int i = 0; i < Map.HEIGHT; i++)
            {
                Console.WriteLine(Map.map[i]);
            }
        }

        public static void Move(Car c)
        {
            char direction = Convert.ToChar(Console.ReadKey(true).Key);
            switch (direction)
            {
                case 'A':
                    {
                        c.X--;
                        ChengeSymb(c.X, true);
                        break;
                    }
                case 'D':
                    {
                        c.X++;
                        ChengeSymb(c.X, false);
                        break;
                    }
            }
        }

        public static void ChengeSymb(int position, bool leftDir)
        {
            string t = Map.map[Map.HEIGHT - 2];
            char[] chars = t.ToCharArray();
            chars[position] = '#';
            if (leftDir)
            {
                chars[position + 1] = ' ';
            }
            else
            {
                chars[position - 1] = ' ';
            }
            Map.map[Map.HEIGHT - 2] = new string(chars);
        }
    }
}
