using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XamarinFormsDemo
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

		    var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string iconDirectory = Path.Combine(localAppData, "icons");
		    Directory.CreateDirectory(iconDirectory);

		    var filePath = Path.Combine(iconDirectory, "play.png");

            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("XamarinFormsDemo.Resources.Images.play.png");

		    if (stream != null) {
		        using (var file = File.Create(filePath)) {
		            byte[] buffer = new byte[8 * 1024];
		            int len;
		            while ((len = stream.Read(buffer, 0, buffer.Length)) > 0) {
		                file.Write(buffer, 0, len);
		            }
		        }

		    }

		    stream = assembly.GetManifestResourceStream("XamarinFormsDemo.Resources.Images.pause.png");
		    filePath = Path.Combine(iconDirectory, "pause.png");
            if (stream != null) {
		        using (var file = File.Create(filePath)) {
		            byte[] buffer = new byte[8 * 1024];
		            int len;
		            while ((len = stream.Read(buffer, 0, buffer.Length)) > 0) {
		                file.Write(buffer, 0, len);
		            }
		        }

		    }

		    stream = assembly.GetManifestResourceStream("XamarinFormsDemo.Resources.Images.high.png");
		    filePath = Path.Combine(iconDirectory, "high.png");
		    if (stream != null) {
		        using (var file = File.Create(filePath)) {
		            byte[] buffer = new byte[8 * 1024];
		            int len;
		            while ((len = stream.Read(buffer, 0, buffer.Length)) > 0) {
		                file.Write(buffer, 0, len);
		            }
		        }

		    }

            MainPage = new MainPage();
		    //MainPage = new ContentPage {
		    //    Content = new StackLayout {
		    //        VerticalOptions = LayoutOptions.Center,
		    //        Children = {
		    //            new Label {
		    //                HorizontalTextAlignment = TextAlignment.Center,
		    //                Text = "Welcome to Xamarin Forms!"
		    //            }
		    //        }
		    //    }
		    //};
//		    var layout = new StackLayout {
//		        VerticalOptions = LayoutOptions.Center,
//		        Children = {
//		            new Label {
//		                HorizontalTextAlignment = TextAlignment.Center,
//		                Text = "Welcome to Xamarin Forms!"
//		            }
//		        }
//		    };
//
//		    MainPage = new ContentPage {
//		        Content = layout
//		    };
//
//		    Button button = new Button {
//		        Text = "Click Me"
//		    };
//
//		    button.Clicked += async (s, e) => {
//		        await MainPage.DisplayAlert("Alert", "You clicked me", "Ok");
//		    };
//
//		    layout.Children.Add(button);
		}


        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
