using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Android.Net.Wifi.Aware;

namespace XamarinFormsDemo.ViewModels
{
    public class AudioViewModel : INotifyPropertyChanged {

        public AudioViewModel() {
            var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string iconDirectory = Path.Combine(localAppData, "icons");
            playIcon = Path.Combine(iconDirectory, "play.png");
            pauseIcon = Path.Combine(iconDirectory, "pause.png");
            songArt = Path.Combine(iconDirectory, "high.png");
        }

        private string playIcon;
        private string pauseIcon;
        private string songArt;

        private string playstate = "Pause";
        
        // The button state text
        public string PlayState {
            get => playstate;
            set {
                if (playstate == value)
                    return;
                playstate = value;
                RaisePropertyChanged();
                RaisePropertyChanged("TransportImage");
            }
        }

        public double TrackProgress => trackElapsed / trackLength;

        private double trackElapsed;

        public double TrackElapsed {
            get => trackElapsed;
            set {
                if (trackElapsed.Equals(value))
                    return;

                trackElapsed = value;
                RaisePropertyChanged();
                RaisePropertyChanged("TrackProgress");
            }
        }

        private double trackLength;

        public double TrackLength {
            get => trackLength;
            set {
                if (trackLength.Equals(value))
                    return;
                trackLength = value;
                RaisePropertyChanged();
            }
        }

        private bool isLoading;

        public bool IsLoading {
            get => isLoading;
            set {
                if (isLoading == value)
                    return;

                isLoading = value;
                RaisePropertyChanged();
            }
        }

        public string TransportImage => playstate == "Play" ? pauseIcon : playIcon;
        public string SongArt => songArt;

        private string artistName = string.Empty;

        public string ArtistName {
            get => artistName;
            set {
                if (artistName == value)
                    return;

                artistName = value;
                RaisePropertyChanged();
            }
        }

        private string album = string.Empty;

        public string Album {
            get => album;
            set {
                if (album == value)
                    return;

                album = value;
                RaisePropertyChanged();
            }
        }

        private string songTitle = string.Empty;

        public string SongTitle {
            get => songTitle;
            set {
                if (songTitle == value)
                    return;

                songTitle = value;
                RaisePropertyChanged();
            }
        }
        //property changed events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
