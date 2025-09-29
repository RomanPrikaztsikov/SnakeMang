using NAudio.Wave;
using System;
using System.IO;

namespace SnakeMang
{
    public class Sounds
    {
        private string pathToMedia;

        public Sounds(string pathToResources)
        {
            pathToMedia = pathToResources;
        }

        public void PlayBackground(string songName)
        {
            try
            {
                var waveOut = new WaveOutEvent();
                var audioFile = new AudioFileReader(Path.Combine(pathToMedia, "music.mp3"));
                waveOut.Init(audioFile);
                waveOut.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Viga BG music: {ex.Message}");
            }
        }

        public void PlayEat()
        {
            try
            {
                using (var audioFile = new AudioFileReader(Path.Combine(pathToMedia, "eat.mp3")))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Viga eating sound: {ex.Message}");
            }
        }
    }
}
