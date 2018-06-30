using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Plugin.SimpleAudioPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsDemo.ViewModels;

namespace XamarinFormsDemo.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AudioPlayer : ContentView
	{

	    public AudioPlayer() {
	        BindingContext = new AudioViewModel();
	        InitializeComponent();
	        player = CrossSimpleAudioPlayer.Current;

	        AudioViewModel.Message = "Audio player ready";

	        player.PlaybackEnded += (sender, e) => {
	            AudioViewModel.PlayState = "Play";
	        };

            //fake an audio load
	        Task.Run(async () => {
	            await Task.Delay(TimeSpan.FromSeconds(2));

	            var audioFileToLoad = "YMXB.mp3";
                hasLoadedAudio = LoadAudio(audioFileToLoad);
	            AudioViewModel.Message = $"{audioFileToLoad} now loaded";
	        });

            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 500), () => {
                if (player == null)
                    return false;

                AudioViewModel.Progress = Convert.ToDouble(player.CurrentPosition) / player.Duration;
                return true;
            });
        }

        private AudioViewModel AudioViewModel => BindingContext as AudioViewModel;

        private readonly ISimpleAudioPlayer player;
	    private bool hasLoadedAudio;

	     private bool LoadAudio(string audioFilePath) {

	        var assembly = typeof(App).GetTypeInfo().Assembly;
	        var audioStream = assembly.GetManifestResourceStream($"XamarinFormsDemo.Resources.Audio.{audioFilePath}");

            if (audioStream == null)
	            return false;

	        player.Load(audioStream);
	        return true;
	    }

        private void Button_OnClicked(object sender, EventArgs e) {
       
            if (player.IsPlaying) {
                AudioViewModel.PlayState = "Play";
                player.Pause();
            }
            else {
                player.Play();

                AudioViewModel.PlayState = "Pause";
            }
        }
    }
}