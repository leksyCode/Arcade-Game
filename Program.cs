using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadeGame
{
    class Program
    {

        static void Main(string[] args)
        {
            int startX = Map.WIDTH / 2;
            Car c = new Car(startX);

            //Main game loop
            while (true)
            {
                
                Move(c);
                Console.SetCursorPosition(0,0); // instead of Console.Clear()
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
            // Because of that the console stops executing the thread, we do the input in another thread
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                ConsoleKey direction = Console.ReadKey(true).Key;
                if (direction == ConsoleKey.LeftArrow || direction == ConsoleKey.A)
                {
                    c.X--;
                    ChengeSymb(c.X, true);
                }
                else if (direction == ConsoleKey.RightArrow || direction == ConsoleKey.D)
                {
                    c.X++;
                    ChengeSymb(c.X, false);
                }
            }).Start();
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
