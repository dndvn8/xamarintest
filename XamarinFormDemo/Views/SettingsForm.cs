using System;

using Xamarin.Forms;

namespace XamarinFormDemo
{
	public class SettingsForm : ContentPage
	{
		public SettingsForm()
		{
			
			NavigationPage.SetHasNavigationBar(this, false);
			Padding = new Thickness(0, Xamarin.Forms.Device.OnPlatform(20, 0, 0), 0, 0);

			Content = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Center,
				Children = {
					new Label{
						Text = "Xin chào, " + App.RealName
					}
				}
			};
		}
	}
}

