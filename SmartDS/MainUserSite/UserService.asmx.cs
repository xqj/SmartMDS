using mds.BaseModel;
using mds.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MainUserSite
{
    /// <summary>
    /// UserService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService
    {
        private static IWebUserProvider _instance = new WebUserProvider();
        [WebMethod(EnableSession = true)]
        public ActionMsg Login(string loginName, string pwd)
        {
            var r = new ActionMsg(false,"登陆失败");
            var sr=_instance.Login(loginName, pwd);
            if (sr.ActionResult)
            {
                r.Message = "操作成功";
                Session.Add("UserSession",sr.Data);
            }
            r.ActionResult = sr.ActionResult;
            return r;
        }
        [WebMethod(EnableSession = true)]
        public ActionMsg Reg(string loginName, string pwd, string email)
        {
            var r = new ActionMsg(false, "注册失败");
            var sr = _instance.Reg(loginName, pwd,email,string.Empty);
            if (sr.ActionResult)
            {
                r.Message = "操作成功";
                Session.Add("UserSession", sr.Data);
            }
            r.ActionResult = sr.ActionResult;
            return r;
        }
        [WebMethod(EnableSession = true)]
        public OperationResult<ResumeView> GetPagers(int currentPage,int pageSize)
        {
            var r = new OperationResult<ResumeView>(false);
            var sr = _instance.GetPagerList(new GridPagerParam() { CurrentPage=currentPage, PageSize=pageSize });
            if (sr.ActionResult)
            {
                r.Message = "操作成功";
              
            }
            r.ActionResult = sr.ActionResult;
            return r;
        }
        [WebMethod(EnableSession = true)]
        public OperationResult<ResumeView> SearchGetPagers(int currentPage, int pageSize,string searchKey)
        {
            var r = new OperationResult<ResumeView>(false);

            var sr = _instance.GetPagerList(new GridPagerParam() { CurrentPage = currentPage, PageSize = pageSize });
            if (sr.ActionResult)
            {
                r.Message = "操作成功";

            }
            r.ActionResult = sr.ActionResult;
            return r;
        }
    }
    public class ResumeView{
        public int UserId{set;get;}
        public string UserName{set;get;}

    }
}
