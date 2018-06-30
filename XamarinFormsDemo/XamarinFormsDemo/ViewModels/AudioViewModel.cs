using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamarinFormsDemo.ViewModels
{
    public class AudioViewModel : INotifyPropertyChanged {
        private string playstate = "Play";

        // The button state text
        public string PlayState {
            get => playstate;
            set {
                if (playstate == value)
                    return;
                playstate = value;
                RaisePropertyChanged();
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

        //property changed events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
