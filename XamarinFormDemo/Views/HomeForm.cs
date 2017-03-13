using System;
using System.Windows.Input;
using Refractored.XamForms.PullToRefresh;
using Xamarin.Forms;

namespace XamarinFormDemo
{
	public class HomeForm : ContentPage
	{
		
		public HomeForm()
		{
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

