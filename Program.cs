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

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            snake.score.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail() || obstacle.IsHit(snake))
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

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }

            GameOverScreen gameOver = new GameOverScreen();
            gameOver.Show(snake.score.CurrentScore);

            ScoreSaver saver = new ScoreSaver();
            saver.SaveScore(snake.score.CurrentScore, "score.txt");
        }

        static void Draw(Figure figure)
        {
            figure.Draw();
        }
    }
}