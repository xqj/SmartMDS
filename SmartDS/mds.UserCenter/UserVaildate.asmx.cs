using mds.SecurityService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace mds.UserCenter
{
    /// <summary>
    /// UserVaildate 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class UserVaildate : System.Web.Services.WebService
    {

        [WebMethod]
        public void WebLogin(string loginName,string pwd)
        {
            var r=SecurityProvider.Instance.Login(loginName, pwd);
            if (r.ActionResult)
            {
                CurrentUser.SetCookie(r.Data);
            }
        }
        [WebMethod]
        public string ThirdLogin(string loginName, string pwd)
        {
            var r = SecurityProvider.Instance.ThirdLogin(loginName, pwd);
            if (r.ActionResult)
            {
                return CurrentUser.SetSession(r.Data);
            }
            return string.Empty;
        }
    }
}
