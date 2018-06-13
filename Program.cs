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
        static Random rand = new Random(DateTime.Now.Millisecond);
        static void Main(string[] args)
        {          
            int startX = Map.WIDTH / 2;
            Car car = new Car(startX);
            CreateEnemy();
            Move(car);
            //Main game loop
            while (true)
            {
                for (int i = 0; i < countEnemies; i++)
                {
                    if (listEnimies[i].Y > Map.HEIGHT - 2)
                    {
                        listEnimies.Clear();
                        CreateEnemy();
                    }
                }
                
                
                MoveEnemies();
                Console.SetCursorPosition(0, 0); // instead of Console.Clear()
                GraphicUpdate();
                DrawEnemies();
                Thread.Sleep(50);
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
                    while (true)
                    {
                        Thread.CurrentThread.IsBackground = true;
                        ConsoleKey direction = Console.ReadKey(true).Key;
                        if (direction == ConsoleKey.LeftArrow || direction == ConsoleKey.A)
                        {
                            c.X -= 2;
                            ChengeSymb(c.X, true);
                        }
                        else if (direction == ConsoleKey.RightArrow || direction == ConsoleKey.D)
                        {
                            c.X += 2;
                            ChengeSymb(c.X, false);
                        }
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
                chars[position + 2] = ' ';
            }
            else
            {
                chars[position - 2] = ' ';
            }
            Map.map[Map.HEIGHT - 2] = new string(chars);
        }

        public static void ChengeEnemiesSymb(Enemy enemy)
        {
            string t = Map.map[enemy.Y];
            string lastStr = Map.map[enemy.Y - 1];
            char[] chars2 = lastStr.ToCharArray();
            char[] chars = t.ToCharArray();
            chars2[enemy.X] = ' ';
            chars2[enemy.X2] = ' ';
            chars[enemy.X] = '#';
            chars[enemy.X2] = '#';
            Map.map[enemy.Y-1] = new string(chars2);
            Map.map[enemy.Y] = new string(chars);
        }

        static List<Enemy> listEnimies;
        static int countEnemies;
        
        public static void CreateEnemy()
        {
            
            countEnemies = 10;
            listEnimies = new List<Enemy>();
            for (int i = 0; i < countEnemies; i++)
            {
                listEnimies.Add(new Enemy());
            }
        }

        public static void MoveEnemies()
        {
            foreach (var enemy in listEnimies)
            {
                enemy.Y++;
            }
        }
        public static void DrawEnemies()
        {
            foreach (var enemy in listEnimies)
            {
                ChengeEnemiesSymb(enemy);   
            }
        }
    }
}
