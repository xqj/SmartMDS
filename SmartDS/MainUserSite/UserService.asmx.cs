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
        public mds.BaseModel.GridPager<mds.BaseModel.Webuser> GetPagers(int currentPage, int pageSize)
        {
          return _instance.GetPagerList(new GridPagerParam() { CurrentPage=currentPage, PageSize=pageSize });
           
        }
        [WebMethod(EnableSession = true)]
        public mds.BaseModel.GridPager<mds.BaseModel.Webuser> SearchGetPagers(int currentPage, int pageSize, string searchKey)
        {
            if(string.IsNullOrEmpty(searchKey))
                return _instance.GetPagerList(new GridPagerParam() { CurrentPage = currentPage, PageSize = pageSize });
            else
                return _instance.GetSearchPager(new GridPagerParam() { CurrentPage = currentPage, PageSize = pageSize }, searchKey);
        }
    }
    
}
