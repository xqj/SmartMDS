using mds.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace mds.SecurityService
{
    public class CurrentUser
    {
        public bool isLogin(string cookieVal)
        {
            if (!string.IsNullOrEmpty(cookieVal))
            {
                string[] strArr = cookieVal.Split('&');
                if (strArr.Length == 3)
                {
                    string key = DateTime.Now.ToString("yyyyMMdd");
                    string keyS = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strArr[1], "MD5");
                    if ((keyS == strArr[2]) && (strArr[0] == key))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static OperationResult<Webuser> GetCurrentUser()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[DefineTable.LoginCookieName];
            if (cookie != null)
                return SecurityProvider.Instance.GetCurrentUser(HttpUtility.UrlDecode(cookie.Value));
            return new OperationResult<Webuser>();
        }
        public static Webuser GetSafeCurrentUser()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[DefineTable.LoginCookieName];
            if (cookie != null)
            {
                var info = SecurityProvider.Instance.GetCurrentUser(HttpUtility.UrlDecode(cookie.Value));
                if (info.ActionResult)
                    return info.Data;
            }
            return new Webuser();
        }

        public static void SetCookie(Webuser Webuser)
        {
            HttpCookie cookie = new HttpCookie(DefineTable.LoginCookieName);
            cookie.Expires = DateTime.Now.AddDays(1);
            cookie.HttpOnly = true;
            cookie.Value = HttpUtility.UrlEncode(Webuser.UserId.ToString() + "&" + System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Webuser.UserId.ToString(), "MD5"));
            HttpContext.Current.Response.SetCookie(cookie);
        }
    }
}
