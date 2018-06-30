using System;
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
