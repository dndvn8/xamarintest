using System;

using Xamarin.Forms;

namespace XamarinFormDemo
{
	public class LogoutForm : ContentPage
	{
		
		public LogoutForm()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			Padding = new Thickness(0, Xamarin.Forms.Device.OnPlatform(20, 0, 0), 0, 0);
			//BackgroundColor = Color.FromHex("#45aeda");


			this.indicator = new ActivityIndicator();
			this.relViews = new RelativeLayout();
			this.btnLogout = new Button();

			//indicator
			this.indicator.Color = Color.Red;
			this.indicator.WidthRequest = 60;
			this.indicator.HeightRequest = 60;
			this.indicator.SetBinding(VisualElement.IsVisibleProperty, new Binding("IsBusy", BindingMode.OneWay, source: this));
			this.indicator.SetBinding(ActivityIndicator.IsRunningProperty, new Binding("IsBusy", BindingMode.OneWay, source: this));

			//btnLogout
			this.btnLogout.Text = "Đăng xuất";
			this.btnLogout.BackgroundColor = Color.Red;
			this.btnLogout.TextColor = Color.White;
			this.btnLogout.Clicked += BtnLogout_Clicked;

			//rclViews
			this.relViews.Children.Add(btnLogout,
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.5 * 0.2; }),
								Constraint.RelativeToParent((parent) => { return parent.Height * 0.5; }),
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.8; })
			);
			this.relViews.Children.Add(indicator,
								Constraint.RelativeToView(btnLogout, (parent, sibling) => { return sibling.X + sibling.Width * 0.5 - 30; }),
								Constraint.RelativeToView(btnLogout, (parent, sibling) => { return sibling.Y - 90; }));
			Content = relViews;
		}

		void BtnLogout_Clicked(object sender, EventArgs e)
		{
			IsBusy = true;
			var loggedUser = App.db.GetLoggedUser();

			if (loggedUser != null)
			{
				App.db.Delete(loggedUser);
				Navigation.PushAsync(new LoginForm());
			}
			//var userInfo = App.db.GetData(App.Username);
			//if (userInfo != null) 
			//{
				
			//}
			IsBusy = false;
		}

		private RelativeLayout relViews;
		private Button btnLogout;
		private ActivityIndicator indicator;
	}
}

