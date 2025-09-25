using System;
using System.IO;

namespace SnakeMang
{
    class ScoreSaver
    {
        public void SaveScore(string nimi, int score, string filename)
        {
            try
            {
                string sisu = $"{nimi}: {score}";
                File.AppendAllText(filename, sisu + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Viga: {ex.Message}");
            }
        }
    }
}
