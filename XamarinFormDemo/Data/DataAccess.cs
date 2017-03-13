using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SQLite.Net;
using Xamarin.Forms;

namespace XamarinFormDemo
{
	public class DataAccess : IDisposable
	{
		private SQLiteConnection conn;
		private logger _logger = new logger(typeof(DataAccess));
		public DataAccess()
		{
			try
			{
				var config = DependencyService.Get<IConfig>();
				conn = new SQLiteConnection(config.Platform, Path.Combine(config.DirectoryDB, "db.db3"));
				conn.CreateTable<User>();
				conn.CreateTable<Log>();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}

		}

		// Thêm người dùng
		public void Insert(User user)
		{
			try
			{
				conn.Insert(user);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
		// Them log
		public void Insert(Log log)
		{
			try
			{
				conn.Insert(log);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		// chinh sua user
		public void Update(User user)
		{
			try
			{
				conn.Update(user);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		// xoa user
		public void Delete(User user)
		{
			try
			{
				conn.Delete(user);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		// xoa log
		public void Delete(Log log)
		{
			try
			{
				conn.Delete(log);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		public User GetData(string Username)
		{
			try
			{
				return conn.Table<User>().FirstOrDefault(x => x.Username.Equals(Username));
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return null;
		}

		public List<User> GetAllData() 
		{
			try
			{
				return conn.Table<User>().OrderBy(x => x.Username).ToList();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return null;
		}

		public User GetLoggedUser()
		{
			try
			{
				return conn.Table<User>().FirstOrDefault(x => x.Logged == true);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return null;
		}


		public void Dispose()
		{
			conn.Dispose();
		}
	}
}
