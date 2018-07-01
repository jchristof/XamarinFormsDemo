using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace XamarinFormsDemo.ViewModels
{
    public class AudioViewModel : INotifyPropertyChanged {

        public AudioViewModel() {
            var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string iconDirectory = Path.Combine(localAppData, "icons");
            playIcon = Path.Combine(iconDirectory, "play.png");
            pauseIcon = Path.Combine(iconDirectory, "pause.png");
            songIcon = Path.Combine(iconDirectory, "high.png");
        }

        private string playIcon;
        private string pauseIcon;
        private string songIcon;

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

        private string message = string.Empty;

        // playback messages
        public string Message {
            get => message;

            set {
                if (message == value)
                    return;

                message = value;
                RaisePropertyChanged();
            }
        }

        private double progress;

        public double Progress {
            get => progress;
            set {
                if (progress.Equals(value))
                    return;

                progress = value;
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
        public string SongImage => songIcon;

        //property changed events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
