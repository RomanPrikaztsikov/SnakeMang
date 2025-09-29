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

            StaticObstacle obstacle = new StaticObstacle(15, 10, 'X');
            obstacle.Draw();

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

            PowerUp powerUp = null;
            Random rand = new Random();
            bool isSpeedBoosted = false;
            int speed = 100;
            int powerUpTimer = 0;

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail() || obstacle.IsHit(snake.GetNextPoint()))
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

                if (powerUp == null && rand.Next(100) == 0)
                {
                    int x = rand.Next(1, 78);
                    int y = rand.Next(1, 23);
                    powerUp = new PowerUp(x, y);
                    powerUp.Draw();
                }

                if (powerUp != null && snake.GetNextPoint().IsHit(powerUp))
                {
                    isSpeedBoosted = true;
                    speed = 50;
                    powerUp = null;
                    powerUpTimer = 0;
                }

                if (isSpeedBoosted)
                {
                    powerUpTimer++;

                    if (powerUpTimer >= 50)
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

            GameOverScreen gameOver = new GameOverScreen();
            gameOver.Show(snake.score.CurrentScore);

            Console.WriteLine();
            Console.Write("Sisesta oma nimi: ");
            string nimi = Console.ReadLine();

            string failitee = "C:\\Users\\opilane\\source\\repos\\TARpv24 Prikaztsikov\\SnakeMang\\score.txt";
            ScoreSaver saver = new ScoreSaver();
            saver.SaveScore(nimi, snake.score.CurrentScore, failitee);
        }
    }
}
