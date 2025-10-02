using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SnakeMang
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Walls walls = new Walls(80, 25);
            walls.Draw();

            //Mängu lõpetav plokk
            StaticObstacle obstacle = new StaticObstacle(15, 10, 'X');
            obstacle.Draw();

            //valitakse juhuslikult üks sümbol kahest
            Random random = new Random();
            char[] possibleChars = { '¤', 'S' };
            char selectedChar = possibleChars[random.Next(0, 2)];
            Point p = new Point(4, 5, selectedChar);
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            snake.score.Draw();

            //kasutame random powerUP ilmumiseks, kui tihti see ilmub ja millises positsioonis
            PowerUp powerUp = null;
            Random rand = new Random();
            bool isSpeedBoosted = false;
            int speed = 100; //100 millisekundit viivitus, mäng töötab kiirusega 10 kaadrit sekundis.
            int powerUpTimer = 0; //taimer, määrame powerUP kestamine

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail() || obstacle.IsHit(snake.GetNextPoint())) //mäng lõppes kui kasutaja sõidab seinasse või Obstacle
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                if (powerUp == null && rand.Next(100) == 0) //arvutab numbri, kui tulemus on 0 ilmub powerUP
                {
                    int x = rand.Next(1, 78);
                    int y = rand.Next(1, 23);
                    powerUp = new PowerUp(x, y);
                    powerUp.Draw();
                }

                if (powerUp != null && snake.GetNextPoint().IsHit(powerUp))
                {
                    isSpeedBoosted = true;
                    speed = 50; //viivitus muutub 50, madu liigub kaks korda kiiremini, sest mäng liigub 20 k/s
                    powerUp = null;
                    powerUpTimer = 0;
                }

                if (isSpeedBoosted)
                {
                    powerUpTimer++;

                    if (powerUpTimer >= 100) //kui möödub 100 kaadrit (5 sekundit), PowerUP kaob ja kiirus taastub 100
                    {
                        isSpeedBoosted = false;
                        speed = 100;
                    }
                }

                Thread.Sleep(speed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }

            GameOverScreen gameOver = new GameOverScreen(); //mäng lõppes
            gameOver.Show(snake.score.CurrentScore);

            Console.WriteLine();
            Console.Write("Sisesta oma nimi: "); //kasutaja sisestab oma nimi
            string nimi = Console.ReadLine();

            string failitee = "C:\\Users\\opilane\\source\\repos\\TARpv24 Prikaztsikov\\SnakeMang\\score.txt"; //salveta skoor
            ScoreSaver saver = new ScoreSaver();
            saver.SaveScore(nimi, snake.score.CurrentScore, failitee);
        }
    }
}
