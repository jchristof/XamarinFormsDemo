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

		    CopyResourceToFile("XamarinFormsDemo.Resources.Images.play-icon.png", Path.Combine(iconDirectory, "play-icon.png"));
		    CopyResourceToFile("XamarinFormsDemo.Resources.Images.pause-icon.png", Path.Combine(iconDirectory, "pause-icon.png"));
		    CopyResourceToFile("XamarinFormsDemo.Resources.Images.high.png", Path.Combine(iconDirectory, "high.png"));
		    
            MainPage = new MainPage();
		}

	    private void CopyResourceToFile(string resourcePath, string filePath) {
	        var assembly = typeof(App).GetTypeInfo().Assembly;
	        var stream = assembly.GetManifestResourceStream(resourcePath);

	        if (stream == null)
	            return;

	        using (var file = File.Create(filePath)) {
	            byte[] buffer = new byte[8 * 1024];
	            int len;
	            while ((len = stream.Read(buffer, 0, buffer.Length)) > 0) {
	                file.Write(buffer, 0, len);
	            }
	        }
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
