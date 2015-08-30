using mds.BaseModel;
using mds.SecurityService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.Services.Protocols;

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

        //[WebMethod]
        //public void WebLogin(string loginName,string pwd)
        //{
        //    var r=SecurityProvider.Instance.Login(loginName, pwd);
        //    if (r.ActionResult)
        //    {
        //        CurrentUser.SetCookie(r.Data);
        //    }
        //}
        [WebMethod]
        public void CrossLogin(string loginName, string pwd)
        {
            this.Context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            var r = new OperationResult<string>(false);
            var tr = SecurityProvider.Instance.ThirdLogin(loginName, pwd);
            if (tr.ActionResult)
            {
                r.Data = CurrentUser.SetSession(tr.Data);
                r.ActionResult = string.IsNullOrEmpty(r.Data) ? false : true;
            }
            string callback = HttpContext.Current.Request["jsoncallback"];
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonObjStr = jss.Serialize(r);
            //额外追加上的一对括号["()"]不能删除,否则不能正常得到数据,最终返回的结果
            //结构类似于:  ?(jsonObj) ,供前台回调处理.
            HttpContext.Current.Response.Write(callback + "(" + jsonObjStr + ")");
            //HttpContext.Current.Response.Write(jsonObjStr);
            HttpContext.Current.Response.End();
        }
        [WebMethod]
        public OperationResult<string> ThirdLogin(string loginName, string pwd)
        {
            this.Context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            var r = new OperationResult<string>(false);
            var tr = SecurityProvider.Instance.ThirdLogin(loginName, pwd);
            if (tr.ActionResult)
            {
                r.Data = CurrentUser.SetSession(tr.Data);
                r.ActionResult = string.IsNullOrEmpty(r.Data) ? false : true;
            }
            return r;
        }
        [WebMethod]
        public bool SessionVaildate(string session)
        {
            return CurrentUser.isSession(session);
        }
    }
}
