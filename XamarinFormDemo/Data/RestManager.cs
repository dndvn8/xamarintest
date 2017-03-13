using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinFormDemo
{
	public class RestManager
	{
		IRestService restService;

		public RestManager(IRestService service)
		{
			restService = service;
		}

		public Task<Tuple<bool, string>> Login(string user, string pass)
		{
			return restService.Login(user, pass);
		}
		public Task<Tuple<bool, string>> Register(string user,string name, string pass, string cpass, string email)
		{
			return restService.Register(user, name, pass, cpass, email);
		}
	}
}
