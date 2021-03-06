﻿using System;
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

	        Player.PlaybackEnded += (sender, e) => {
	            AudioViewModel.PlayState = "Pause";
	        };

            //fake an audio load
	        Task.Run(async () => {
	            AudioViewModel.IsLoading = true;
                await Task.Delay(TimeSpan.FromSeconds(5));

	            audioFileToPlay = "YMXB.mp3";
                hasLoadedAudio = LoadAudio(audioFileToPlay);

	            AudioViewModel.Album = "The Obvious Exit";
	            AudioViewModel.ArtistName = "Flippy";
	            AudioViewModel.SongTitle = "y=mx+b";
	            AudioViewModel.IsLoading = false;
	            
	        });

            Device.StartTimer(TimeSpan.FromSeconds(.5), () => {
                if (Player == null)
                    return false;

                AudioViewModel.TrackElapsed = Player.CurrentPosition;
                return true;
            });
        }

        private AudioViewModel AudioViewModel => BindingContext as AudioViewModel;

	    private ISimpleAudioPlayer Player => CrossSimpleAudioPlayer.Current;

	    private String audioFileToPlay = string.Empty;

        private bool hasLoadedAudio;

	     private bool LoadAudio(string audioFilePath) {

	        var assembly = typeof(App).GetTypeInfo().Assembly;
	        var audioStream = assembly.GetManifestResourceStream($"XamarinFormsDemo.Resources.Audio.{audioFilePath}");

            if (audioStream == null)
	            return false;

	        Player.Load(audioStream);
	        AudioViewModel.TrackLength = Player.Duration;
            return true;
	    }

        private void Button_OnClicked(object sender, EventArgs e) {
       
            if (Player.IsPlaying) {
                AudioViewModel.PlayState = "Pause";
                Player.Pause();
            }
            else {
                Player.Play();
                AudioViewModel.PlayState = "Play";
            }
        }
    }
}