using System;
using System.Runtime.Serialization;

namespace XamarinFormDemo
{

	//	{
	//  "tag": "register",
	//  "success": 1,
	//  "error": 0,
	//  "user": {
	//    "username": "duynd",
	//    "created_at": "2017-03-07 08:48:21",
	//    "updated_at": null
	//  },
	//  "user_info": {
	//    "user_name": "Nguyễn Đình Duy",
	//    "user_email": "duynd@elcom.com.vn",
	//    "user_ip": "192.168.61.45",
	//    "user_logged": "0"
	//  }
	//}
	[DataContract]
	public class user
	{
		[DataMember(Name = "username")]
		public string Username { get; set; }
		[DataMember(Name = "createed_at")]
		public DateTime Created_Date { get; set; }
		[DataMember(Name = "updated_at")]
		public Nullable<DateTime> Updated_Date { get; set; }
	}
	[DataContract]
	public class user_info
	{ 
		[DataMember(Name = "user_name")]
		public string RealName { get; set; }
		[DataMember(Name = "user_email")]
		public string Email { get; set; }
		[DataMember(Name = "user_ip")]
		public string IPAddress { get; set; }
		[DataMember(Name = "user_logged")]
		public string Logged { get; set; }
	}
    [DataContract]
    public class contact
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }
        [DataMember(Name = "user_name")]
        public string RealName { get; set; }
        [DataMember(Name = "user_logged")]
        public string Logged { get; set; }
    }
	public class Success
	{
		public string tag { get; set; }
		public int success { get; set; }
		public int error { get; set; }
		public user user { get; set; }
		public user_info user_info { get; set; }
	}
	public class Failed
	{ 
		public string tag { get; set; }
		public int success { get; set; }
		public int error { get; set; }
		public string error_msg { get; set; }
	}
}
