using System;
using System.Collections.Generic;
using System.IO;
using NAudio.Wave;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Battleships.Properties;

namespace Battleships.Models
{
    public class BackgroundMusic
    {
        WaveOut _waveOut = new WaveOut();

        public void PlayMusic()
        {
            Mp3FileReader _musicSource = new Mp3FileReader(Path.Combine(Environment.CurrentDirectory + @"/media/play.mp3"));
            _waveOut.Init(_musicSource);
            _waveOut.Play();
            _waveOut.Volume = (float)Settings.Default.UserVolume / 100;
        }

        public void ChangeVolume(int newVolume)
        {
            float floatVolume = (float)newVolume / 100;
            _waveOut.Volume = floatVolume;

            Settings.Default.UserVolume = newVolume;
            Settings.Default.Save();
        }
    }
}
