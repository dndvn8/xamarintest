using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinFormDemo
{
	public interface IRestService
	{
		Task<Tuple<bool, string>> Login(string sUsername, string sPassword);
		Task<Tuple<bool, string>> Register(string sUsername,string sRealName, string sPassword, string sConfirmPassword, string sEmail);
        Task<List<contact>> GetAllUser();
	}
}
