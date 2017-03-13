using System;

using Xamarin.Forms;

namespace XamarinFormDemo
{
	public class App : Application
	{
		public static RestManager restManager { get; private set; }
		public static DataAccess db { get; private set; }
		public static int ScreenWidth;
		public static int ScreenHeight;
		public static string RealName;
		public static string Username;
		public static string SaveToken;
		public App()
		{
			// The root page of your application
			db = new DataAccess();
			restManager = new RestManager(new RestService());
			MainPage = new NavigationPage(new LoginForm());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
