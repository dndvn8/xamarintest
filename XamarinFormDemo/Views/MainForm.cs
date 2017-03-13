using System;

using Xamarin.Forms;

namespace XamarinFormDemo
{
	public class MainForm : TabbedPage
	{
		public MainForm()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			//Title = "Xin chào: " + App.RealName;

			var homePage = new HomeForm();
			homePage.Title = "Home";
			homePage.Icon = "home.png";

			var settingPage = new LogoutForm();
			settingPage.Title = "Setting";
			settingPage.Icon = "gear.png";

			//var logoutPage = new LogoutForm();
			//logoutPage.Icon = "exit.png";
			//logoutPage.Title = "Logout";

			Children.Add(homePage);
			Children.Add(settingPage);
			//Children.Add(logoutPage);
		}
	}
}

