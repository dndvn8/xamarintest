using System;
using System.Diagnostics;

namespace XamarinFormDemo
{
	public class logger
	{
		private Type _type;
		public logger(Type type)
		{
			_type = type;
		}

		private string GetMethod()
		{
			return _type.FullName;
		}

		public void Info(string msg)
		{
			Log log = new Log();
			log.Level = "Info";
			log.datetime = DateTime.Now;
			log.Logger = GetMethod();
			log.Message = msg;
			Debug.WriteLine(log.ToString());
			App.db.Insert(log);
		}

		public void Error(string msg)
		{
			Log log = new Log();
			log.Level = "Error";
			log.datetime = DateTime.Now;
			log.Logger = GetMethod();
			log.Message = msg;
			Debug.WriteLine(log.ToString());
			App.db.Insert(log);
		}

		public void Error(Exception ex)
		{
			Log log = new Log();
			log.Level = "Error";
			log.datetime = DateTime.Now;
			log.Logger = GetMethod();
			log.Message = ex.ToString();
			Debug.WriteLine(log.ToString());
			App.db.Insert(log);
		}
	}
}
