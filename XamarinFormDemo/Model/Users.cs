using System;
using SQLite.Net.Attributes;

namespace XamarinFormDemo
{
	public class User
	{
		[PrimaryKey]
		public string Username { get; set; }
		public string Password { get; set; }
		public bool Logged { get; set; }

		public override string ToString()
		{
			return string.Format("[SqlInfo: Username={0}, Password={1}, Logged={2}]", Username, Password, Logged);
		}
	}
}
