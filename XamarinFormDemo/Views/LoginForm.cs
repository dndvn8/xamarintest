using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace XamarinFormDemo
{
	public class LoginForm : ContentPage
	{
		#region declare
		private bool _existed = false;
		private logger _logger = new logger(typeof(LoginForm));
		#endregion
		#region Designer generated code
		public LoginForm()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			BackgroundColor = Color.FromHex("#45aeda");

			this.actLoading = new ActivityIndicator();
			this.imgLogo = new Image();
			this.txtUsername = new LineEntry();
			this.txtPassword = new LineEntry();
			this.btnLogin = new Button();
			this.btnRegister = new Button();
			this.btnFacebookLogin = new Button();
			this.relViews = new RelativeLayout();

			//actLoading
			this.actLoading.HorizontalOptions = LayoutOptions.CenterAndExpand;
			this.actLoading.Color = Color.Green;
			this.actLoading.SetBinding(VisualElement.IsVisibleProperty, new Binding("IsBusy", BindingMode.OneWay, source: this));
			this.actLoading.SetBinding(ActivityIndicator.IsRunningProperty, new Binding("IsBusy", BindingMode.OneWay, source: this));

			//imgLogo
			this.imgLogo.Source = "xamagon.png";
			this.imgLogo.Aspect = Aspect.AspectFit;

			//txtUsername
			this.txtUsername.Placeholder = "Tên đăng nhập";
			this.txtUsername.TextColor = Color.White;
			this.txtUsername.BorderColor = Color.FromHex("#45aeda");
			this.txtUsername.PlaceholderColor = Color.White;
			this.txtUsername.Completed += TxtUsername_Completed;

			//txtPassword
			this.txtPassword.Placeholder = "Mật khẩu";
			this.txtPassword.TextColor = Color.White;
			this.txtPassword.BorderColor = Color.FromHex("#45aeda");
			this.txtPassword.PlaceholderColor = Color.White;
			this.txtPassword.IsPassword = true;
			this.txtPassword.Completed += TxtPassword_Completed;

			//btnLogin
			this.btnLogin.BackgroundColor = Color.FromHex("#196fb4");
			this.btnLogin.TextColor = Color.White;
			this.btnLogin.Text = "Đăng nhập";
			this.btnLogin.Clicked += BtnLogin_Clicked;

			//btnRegister
			this.btnRegister.BackgroundColor = Color.FromHex("#196fb4");
			this.btnRegister.TextColor = Color.White;
			this.btnRegister.Text = "Đăng ký";
			this.btnRegister.Clicked +=	BtnRegister_Clicked;

			//btnFacebookLogin
			this.btnFacebookLogin.BackgroundColor = Color.Red;
			this.btnFacebookLogin.TextColor = Color.White;
			this.btnFacebookLogin.FontAttributes = FontAttributes.Bold;
			this.btnFacebookLogin.Text = "Login with Google";
			this.btnFacebookLogin.IsEnabled = false;
			this.btnFacebookLogin.Clicked +=BtnFacebookLogin_Clicked;

			//Layout
			this.relViews.Padding = new Thickness(0, Xamarin.Forms.Device.OnPlatform(20, 0, 0), 0, 0);
			this.relViews.Children.Add(imgLogo,
			                    Constraint.RelativeToParent((parent) => { return parent.Width * 0.5 * 0.25; }),
			                    Constraint.Constant(0),
			                    Constraint.RelativeToParent((parent) => { return parent.Width * 0.75; }),
			                    Constraint.RelativeToParent((parent) => { return parent.Width * 0.75; })
			);
			this.relViews.Children.Add(txtUsername,
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.5 * 0.2; }),
			                    Constraint.RelativeToView(imgLogo,(parent, sibling) => { return sibling.Y + sibling.Height; }),
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.8; })
			);
			this.relViews.Children.Add(txtPassword,
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.5 * 0.2; }),
			                    Constraint.RelativeToView(txtUsername, (parent, sibling) => { return sibling.Y + sibling.Height * 2; }),
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.8; })
			);
			this.relViews.Children.Add(btnLogin,
			                    Constraint.RelativeToView(txtPassword, (parent, sibling) => { return sibling.X; }),
								Constraint.RelativeToView(txtPassword, (parent, sibling) => { return sibling.Y + sibling.Height * 2; }),
			                    Constraint.RelativeToView(txtPassword, (parent, sibling) => { return sibling.Width * 0.5 - 10; }),
			                    Constraint.RelativeToView(txtPassword, (parent, sibling) => { return sibling.Height * 2; })
			);
			this.relViews.Children.Add(btnRegister,
								Constraint.RelativeToView(btnLogin, (parent, sibling) => { return sibling.X + sibling.Width + 20; }),
								Constraint.RelativeToView(btnLogin, (parent, sibling) => { return sibling.Y; }),
								Constraint.RelativeToView(btnLogin, (parent, sibling) => { return sibling.Width; }),
								Constraint.RelativeToView(btnLogin, (parent, sibling) => { return sibling.Height; })
			);
			this.relViews.Children.Add(btnFacebookLogin,
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.5 * 0.2; }),
								Constraint.RelativeToView(btnLogin, (parent, sibling) => { return sibling.Y + sibling.Height * 1.2; }),
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.8; }),
								Constraint.RelativeToView(btnLogin, (parent, sibling) => { return sibling.Height; })
			);
			this.relViews.Children.Add(actLoading,
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.5 - 10; }),
			                    Constraint.RelativeToParent((parent) => { return parent.Height * 0.5; })
			);
			this.Content = this.relViews;
		}
		#endregion

		#region Method generated code
		//the login button pressed.
		private async void BtnLogin_Clicked(object sender, EventArgs e)
		{
			var loginResult = new Tuple<bool, string>(false, "Đăng nhập thất bại");
			IsBusy = true;
			try
			{
				loginResult = await App.restManager.Login(txtUsername.Text, txtPassword.Text);
			}
			catch (Exception ex)
			{
				_logger.Error(ex);
			}

			if (loginResult.Item1)
			{
				_logger.Info("Đăng nhập thành công tài khoản: " + txtUsername.Text);
				if (!_existed)
				{
					_logger.Info("Thêm tài khoản " + txtUsername.Text + "vào database");
					App.db.Insert(new User { Username = txtUsername.Text.ToLower(), Password = txtPassword.Text, Logged = true });
				}
				App.Username = txtUsername.Text.ToLower();
				_logger.Info("Mở Main page");
				await Navigation.PushAsync(new MainForm());
			}
			else
			{
				_logger.Info("Đăng nhập thất bại tài khoản " + txtUsername.Text + " :\r\n Lỗi:" + loginResult.Item2);
				await DisplayAlert("Đăng nhập", loginResult.Item2, "OK");
			}
			IsBusy = false;
		}

		private async void BtnRegister_Clicked(object sender, EventArgs e)
		{
			IsBusy = true;
			await Navigation.PushAsync(new RegisterForm());
			IsBusy = false;
		}

		private async void BtnFacebookLogin_Clicked(object sender, EventArgs e)
		{
			IsBusy = true;
			await Navigation.PushAsync(new FacebookLoginForm());
			IsBusy = false;
		}

		// Texts the username completed.
		private void TxtUsername_Completed(object sender, EventArgs e)
		{
			this.txtPassword.Focus();
		}

		// Texts the password completed.
		private void TxtPassword_Completed(object sender, EventArgs e)
		{
			this.BtnLogin_Clicked(null, null);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			var config = DependencyService.Get<IConfig>();
			_logger.Info("Connect to db with path: " + System.IO.Path.Combine(config.DirectoryDB, "db.db3"));
			//IsBusy = true;
			_logger.Info("Lấy thông tin tài khoản đăng nhập");
			var loggedUser = App.db.GetLoggedUser();


			if (loggedUser != null) 
			{
				_logger.Info("Tồn tại tài khoản trong databases");
				_logger.Info(loggedUser.ToString());

				_logger.Info("Đánh dấu tồn tại tài khoản và gán thông tin cho textbox");
				this._existed = true;
				this.txtUsername.Text = loggedUser.Username;
				this.txtPassword.Text = loggedUser.Password;

				_logger.Info("Tiến hành đăng nhập");
				this.BtnLogin_Clicked(null, null);
			}
			//IsBusy = false;
		}
		#endregion

		private ActivityIndicator actLoading;
		private Image imgLogo;
		private LineEntry txtUsername;
		private LineEntry txtPassword;
		private Button btnLogin;
		private Button btnRegister;
		private Button btnFacebookLogin;
		private RelativeLayout relViews;
	}
}

