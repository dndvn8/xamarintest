using System;
using SQLite.Net.Interop;

namespace XamarinFormDemo
{
	public interface IConfig
	{
		string DirectoryDB { get; }
		ISQLitePlatform Platform { get; }
	}
}
