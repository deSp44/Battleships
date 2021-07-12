using System;
using System.IO;
using NAudio.Wave;
using Battleships.Properties;

namespace Battleships.Models
{
    public class BackgroundMusic
    {
        private readonly WaveOut _waveOut = new WaveOut();
        private readonly Mp3FileReader _musicSource = new Mp3FileReader(Path.Combine(Environment.CurrentDirectory + @"/media/play.mp3"));

        public void PlayMusic()
        {
            
            _waveOut.Init(_musicSource);
            _waveOut.Play();
            Mute(Settings.Default.UserMuteIsChecked);
        }

        public void ChangeVolume(int newVolume)
        {
            var floatVolume = (float)newVolume / 100;
            _waveOut.Volume = floatVolume;

            Settings.Default.UserMusicVolume = newVolume;
            Settings.Default.Save();
        }

        public void Mute(bool isMute)
        {
            if (isMute)
            {
                _waveOut.Volume = 0f;
                Settings.Default.UserMuteIsChecked = true;
                Settings.Default.Save();
            }
            else
            {
                _waveOut.Volume = (float)Settings.Default.UserMusicVolume / 100;
                Settings.Default.UserMuteIsChecked = false;
                Settings.Default.Save();
            }
        }
    }
}
