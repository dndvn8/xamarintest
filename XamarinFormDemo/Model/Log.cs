using System;
using SQLite.Net.Attributes;

namespace XamarinFormDemo
{
	public class Log
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public DateTime datetime { get; set; }
		public string Level { get; set; }
		public string Logger { get; set; }
		public string Message { get; set; }

		public override string ToString()
		{
			return string.Format("[Log: Id={0}, datetime={1}, Level={2}, Logger={3}, Message={4}]", Id, datetime, Level, Logger, Message);
		}
	}
}
