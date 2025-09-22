using System;
using System.IO;

namespace SnakeMang
{
    class ScoreSaver
    {
        public void SaveScore(int score, string filename)
        {
            try
            {
                File.WriteAllText(filename, score.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the score: {ex.Message}");
            }
        }
    }
}