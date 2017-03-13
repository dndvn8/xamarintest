using System;

using Xamarin.Forms;

namespace XamarinFormDemo
{
	public class RegisterForm : ContentPage
	{
		#region declare
		private logger _logger = new logger(typeof(LoginForm));
		#endregion
		public RegisterForm()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			BackgroundColor = Color.FromHex("#45aeda");

			this.actLoading = new ActivityIndicator();
			this.imgLogo = new Image();
			this.txtUsername = new LineEntry();
			this.txtPassword = new LineEntry();
			this.txtConfirmPassword = new LineEntry();
			this.txtRealName = new LineEntry();
			this.txtEmail = new LineEntry();
			this.btnCancel = new Button();
			this.btnRegister = new Button();
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

			//txtConfirmPassword
			this.txtConfirmPassword.Placeholder = "Nhập lại mật khẩu";
			this.txtConfirmPassword.TextColor = Color.White;
			this.txtConfirmPassword.BorderColor = Color.FromHex("#45aeda");
			this.txtConfirmPassword.PlaceholderColor = Color.White;
			this.txtConfirmPassword.IsPassword = true;
			this.txtConfirmPassword.Completed += TxtConfirmPassword_Completed;

			//txtRealName
			this.txtRealName.Placeholder = "Họ & Tên";
			this.txtRealName.TextColor = Color.White;
			this.txtRealName.BorderColor = Color.FromHex("#45aeda");
			this.txtRealName.PlaceholderColor = Color.White;
			this.txtRealName.Completed += TxtRealName_Completed;


			//txtEmail
			this.txtEmail.Placeholder = "Email";
			this.txtEmail.TextColor = Color.White;
			this.txtEmail.BorderColor = Color.FromHex("#45aeda");
			this.txtEmail.PlaceholderColor = Color.White;
			this.txtEmail.Completed += TxtEmail_Completed;

			//btnRegister
			this.btnRegister.BackgroundColor = Color.FromHex("#196fb4");
			this.btnRegister.TextColor = Color.White;
			this.btnRegister.Text = "Đăng ký";
			this.btnRegister.Clicked += BtnRegister_Clicked;

			//btnCancel
			this.btnCancel.BackgroundColor = Color.FromHex("#196fb4");
			this.btnCancel.TextColor = Color.White;
			this.btnCancel.Text = "Hủy";
			this.btnCancel.Clicked += BtnCancel_Clicked;

			this.relViews.Padding = new Thickness(0, Xamarin.Forms.Device.OnPlatform(20, 0, 0), 0, 0);
			this.relViews.Children.Add(imgLogo,
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.5 * 0.25; }),
								Constraint.Constant(0),
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.75; }),
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.75; })
			);
			this.relViews.Children.Add(txtUsername,
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.5 * 0.2; }),
								Constraint.RelativeToView(imgLogo, (parent, sibling) => { return sibling.Y + sibling.Height; }),
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.8; })
			);
			this.relViews.Children.Add(txtPassword,
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.5 * 0.2; }),
								Constraint.RelativeToView(txtUsername, (parent, sibling) => { return sibling.Y + sibling.Height * 2; }),
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.8; })
			);
			this.relViews.Children.Add(txtConfirmPassword,
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.5 * 0.2; }),
								Constraint.RelativeToView(txtPassword, (parent, sibling) => { return sibling.Y + sibling.Height * 2; }),
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.8; })
			);
			this.relViews.Children.Add(txtRealName,
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.5 * 0.2; }),
								Constraint.RelativeToView(txtConfirmPassword, (parent, sibling) => { return sibling.Y + sibling.Height * 2; }),
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.8; })
			);
			this.relViews.Children.Add(txtEmail,
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.5 * 0.2; }),
								Constraint.RelativeToView(txtRealName, (parent, sibling) => { return sibling.Y + sibling.Height * 2; }),
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.8; })
			);
			this.relViews.Children.Add(btnRegister,
								Constraint.RelativeToView(txtEmail, (parent, sibling) => { return sibling.X; }),
								Constraint.RelativeToView(txtEmail, (parent, sibling) => { return sibling.Y + sibling.Height * 2; }),
								Constraint.RelativeToView(txtEmail, (parent, sibling) => { return sibling.Width * 0.5 - 10; }),
								Constraint.RelativeToView(txtEmail, (parent, sibling) => { return sibling.Height * 2; })
			);
			this.relViews.Children.Add(btnCancel,
								Constraint.RelativeToView(btnRegister, (parent, sibling) => { return sibling.X + sibling.Width + 20; }),
								Constraint.RelativeToView(btnRegister, (parent, sibling) => { return sibling.Y; }),
								Constraint.RelativeToView(btnRegister, (parent, sibling) => { return sibling.Width; }),
								Constraint.RelativeToView(btnRegister, (parent, sibling) => { return sibling.Height; })
			);
			this.relViews.Children.Add(actLoading,
								Constraint.RelativeToParent((parent) => { return parent.Width * 0.5 - 10; }),
								Constraint.RelativeToParent((parent) => { return parent.Height * 0.5; })
			);
			this.Content = this.relViews;
		}

		#region Method generated code
		//the login button pressed.
		private async void BtnRegister_Clicked(object sender, EventArgs e)
		{
			var registerResult = new Tuple<bool, string>(false, "Đăng ký thất bại");
			IsBusy = true;
			try
			{
				registerResult = await App.restManager.Register(txtUsername.Text, txtRealName.Text, txtPassword.Text, txtConfirmPassword.Text, txtEmail.Text);
			}
			catch (Exception ex)
			{
				_logger.Error(ex);
			}
			if (registerResult.Item1)
			{
				_logger.Info("Đăng ký thành công tài khoản: " + txtUsername.Text);

				_logger.Info("Mở Login page");
				await Navigation.PushAsync(new LoginForm());
			}
			else
			{
				_logger.Info("Đăng ký thất bại tài khoản " + txtUsername.Text + " :\r\n Lỗi:" + registerResult.Item2);
				await DisplayAlert("Đăng ký", registerResult.Item2, "OK");
			}
			IsBusy = false;
		}

		private async void BtnCancel_Clicked(object sender, EventArgs e)
		{
			IsBusy = true;
			await Navigation.PushAsync(new LoginForm());
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
			this.txtConfirmPassword.Focus();
		}

		// Texts the confirm password completed.
		private void TxtConfirmPassword_Completed(object sender, EventArgs e)
		{
			this.txtRealName.Focus();
		}

		private void TxtRealName_Completed(object sender, EventArgs e)
		{
			this.txtEmail.Focus();
		}

		private void TxtEmail_Completed(object sender, EventArgs e)
		{
			this.BtnRegister_Clicked(null, null);
		}

		#endregion

		private ActivityIndicator actLoading;
		private Image imgLogo;
		private LineEntry txtUsername;
		private LineEntry txtPassword;
		private LineEntry txtConfirmPassword;
		private LineEntry txtRealName;
		private LineEntry txtEmail;
		private Button btnCancel;
		private Button btnRegister;
		private RelativeLayout relViews;
	}
}

