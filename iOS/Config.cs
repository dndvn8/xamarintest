using System;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamarinFormDemo.iOS.Config))]
namespace XamarinFormDemo.iOS
{
	public class Config : IConfig
	{
		private string directoryDb;
		private ISQLitePlatform platform;
		public string DirectoryDB
		{
			get
			{
				if (string.IsNullOrEmpty(directoryDb))
				{
					var directory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
					directoryDb = System.IO.Path.Combine(directory, "..", "Library");
				}
				return directoryDb;
			}
		}

		public ISQLitePlatform Platform
		{
			get
			{
				if (platform == null)
				{
					platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
				}
				return platform;
			}
		}
	}
}
