using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XamarinFormDemo
{
	public class RestService : IRestService
	{
		HttpClient client;
		logger log = new logger(typeof(RestService));
		//string RestUrl = "http://dndvn.pe.hu/app/";
		string loginUrl = "http://dndvn.pe.hu/app/login.php";

		public async Task<Tuple<bool, string>> Login(string sUsername, string sPassword)
		{
			if (string.IsNullOrEmpty(sUsername) || string.IsNullOrEmpty(sPassword))
			{
				return new Tuple<bool, string>(false, "Tài khoản hoặc mật khẩu chưa chính xác");
			}
			log.Info("Thong tin da day du de dang nhap");
			client = new HttpClient();
			client.Timeout = TimeSpan.FromSeconds(10);
			client.MaxResponseContentBufferSize = 256000;

			log.Info("Khoi tao duong dan dang nhap...");
			var uri = new Uri(loginUrl);
			try
			{
				log.Info("Khoi tao content...");
				var content = new FormUrlEncodedContent(new[]
				{
					new KeyValuePair<string,string>("tag","login"),
					new KeyValuePair<string,string>("username",sUsername),
					new KeyValuePair<string,string>("password",sPassword),
					new KeyValuePair<string,string>("logged","true")
				});

				log.Info("Gui thong tin dang nhap...");
				HttpResponseMessage response = null;
				response = await client.PostAsync(uri, content);

				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					log.Info("Nhan thong tin tra ve thanh cong \r\n" + json);
					Failed fail = null;
					Success success = null;

					log.Info("Json parse");
					if (json.Contains("user"))
						success = JsonConvert.DeserializeObject<Success>(json);
					else
						fail = JsonConvert.DeserializeObject<Failed>(json);
					if (success != null)
					{
						App.RealName = success.user_info.RealName;
						log.Info(string.Format("{0}/{1}", success.user_info.RealName, success.user_info.IPAddress));
						return new Tuple<bool, string>(true, success.user_info.RealName);
					}
					log.Info(fail.error_msg);
					return new Tuple<bool, string>(false, fail.error_msg);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return new Tuple<bool, string>(false, "Đăng nhập thất bại");
		}

		public async Task<Tuple<bool, string>> Register(string sUsername,string sRealName, string sPassword,string sConfirmPassword, string sEmail)
		{
			log.Info("Kiem tra thong tin con thieu khong");
			if (string.IsNullOrEmpty(sUsername) || string.IsNullOrEmpty(sPassword) || string.IsNullOrEmpty(sEmail))
			{
				return new Tuple<bool, string>(false, "Vui lòng điền đầy đủ thông tin");
			}

			log.Info("Kiem tra mat khau nhap lai");
			if (sPassword != sConfirmPassword) 
			{ 
				return new Tuple<bool, string>(false, "Hai mật khẩu phải giống nhau");
			}
			client = new HttpClient();
			client.Timeout = TimeSpan.FromSeconds(10);
			client.MaxResponseContentBufferSize = 256000;

			log.Info("Khoi tao duong dan dang ky...");
			var uri = new Uri(loginUrl);
			try
			{
				log.Info("Khoi tao content...");
				var content = new FormUrlEncodedContent(new[]
				{
					new KeyValuePair<string,string>("tag","register"),
					new KeyValuePair<string,string>("username",sUsername),
					new KeyValuePair<string,string>("password",sPassword),
					new KeyValuePair<string,string>("name",sRealName),
					new KeyValuePair<string,string>("email",sEmail),
					new KeyValuePair<string,string>("logged","false")
				});

				log.Info("Gui thong tin dang ky...");
				HttpResponseMessage response = null;
				response = await client.PostAsync(uri, content);

				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					log.Info("Nhan thong tin tra ve thanh cong \r\n" + json);
					Failed fail = null;
					Success success = null;

					log.Info("Json parse");
					if (json.Contains("user"))
						success = JsonConvert.DeserializeObject<Success>(json);
					else
						fail = JsonConvert.DeserializeObject<Failed>(json);
					if (success != null)
					{
						log.Info(string.Format("{0}/{1}", success.user_info.RealName, success.user_info.IPAddress));
						return new Tuple<bool, string>(true, success.user_info.RealName);
					}
					log.Info(fail.error_msg);
					return new Tuple<bool, string>(false, fail.error_msg);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return new Tuple<bool, string>(false, "Đăng ký thất bại");
		}
	}
}
