using mds.BaseModel;
using mds.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace mds.SecurityService
{
   public class SecurityProvider
    {
       private static SecurityProvider _instance = new SecurityProvider();

        public static SecurityProvider Instance
        {
            get { return _instance; }         
        }
        public SecurityProvider()
        {

        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="cookieVal"></param>
       /// <returns></returns>
       
        public OperationResult<Webuser> Login(string loginName,string pwd)
        {

            var result = new OperationResult<Webuser>();
            if ((string.IsNullOrEmpty(loginName)) || (loginName.Length > 4)) {
                result.Message = "非法数据";
                return result; }
            //pwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
            return WebUserProvider.Instance.Login(loginName, pwd);
           
        }
        public OperationResult<Webuser> GetCurrentUser(string cookieVal)
        {
            if (!string.IsNullOrEmpty(cookieVal))
            {
                string[] strArr = cookieVal.Split('&');
                if (strArr.Length == 3)
                {
                    int userId =0;
                    int.TryParse(strArr[1],out userId);
                    return WebUserProvider.Instance.GetDetail(userId);
                }
            }
            return new OperationResult<Webuser>() { 
            Message="无法获取当前用户信息"
            };
        }

        public OperationResult<loginsession> ThirdLogin(string loginName, string pwd)
        {
            return WebUserProvider.Instance.LoginSession(loginName, pwd);
        }

        internal OperationResult<loginsession> GetSession(string sessionSign)
        {
            return WebUserProvider.Instance.GetSessionBySign(sessionSign);
        }
    }
}
