using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace YuDa.DeviceClient
{
    public class LoginUser
    {
        public static string LoginID;
        public static string UserName;
        public static string CompanyName;
        public static string CompanyID;
        public static string Account_Token;
        public static string ClientVersion = "20211124-1";



        public static string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        
    }

    public class PubulicMsgResult
    {
        public ResultCode code { get; set; }

        public string msg { get; set; }
    }

    /// <summary>
    /// 登录结果
    /// </summary>
    public class LoginResult : PubulicMsgResult
    {
        public LoginData data { get; set; }
    }

    public class LoginData
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
    }

    /// <summary>
    /// 登录用户信息结果
    /// </summary>
    public class UserInfoResult : PubulicMsgResult
    {
        public UserInfo data { get; set; }
    }

    public class UserInfo
    {
        public string userName { get; set; }
        public string companyID { get; set; }
        public string companyName { get; set; }
    }

    public enum ResultCode : int
    {
        Success = 0,
        Error = 1,

    }
}
