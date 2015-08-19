using mds.Dal;
using mds.BaseModel;
using mds.Dal;
using mds.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace mds.UserService
{
    public class WebUserProvider : mds.UserService.IWebUserProvider
    {
        private static WebUserProvider _instance = new WebUserProvider();

        public static IWebUserProvider Instance
        {
            get { return WebUserProvider._instance; }
            
        }
        public GridPager<Webuser> GetPagerList(GridPagerParam param)
        {
             var r = new GridPager<Webuser>(false);

             r.Data = webuserDal.GetPagerList(param);
                r.ActionResult = (r.Data != null) ? true : false;
            
                return r;
        }
        public GridPager<Webuser> GetPagerList(GridPagerParam param,List<int> searchIds)
        {
            var r = new GridPager<Webuser>(false);

            r.Data = webuserDal.GetPagerList(param, searchIds);
            r.ActionResult = (r.Data != null) ? true : false;

            return r;
        }
        public OperationResult<Webuser> GetDetail(int webuserId)
        {
            // ArgumentHelper.AssertInRange("webuserId", webuserId, 1, int.MaxValue);
            var r = new OperationResult<Webuser>();
            r.Data = webuserDal.GetDetail(webuserId);
            r.ActionResult = (r.Data != null) ? true : false;
            return r;
        }
        public OperationResult<int> Create(Webuser info)
        {           // ArgumentHelper.AssertNotNullOrEmpty(info.webuserName);
            var r = new OperationResult<int>();
            r.Data = webuserDal.Create(info);
            r.ActionResult = (r.Data > 0) ? true : false;
            return r;
        }
        public ActionMsg Modify(Webuser info)
        {           // ArgumentHelper.AssertNotNullOrEmpty(info.infoName);
            var r = new ActionMsg();
            r.ActionResult = webuserDal.Modify(info);
            return r;
        }


        public OperationResult<int> Reg(string loginName, string pwd, string email, string verfiycode)
        {
            ArgumentHelper.AssertNotNullOrEmpty(loginName, pwd, email);
            var r = new OperationResult<int>();
            r.Data = webuserDal.Reg(loginName, pwd, email);
            r.ActionResult = (r.Data > 0) ? true : false;
            return r;
        }

        public OperationResult<Webuser> Login(string loginName, string pwd)
        {
            ArgumentHelper.AssertNotNullOrEmpty(loginName, pwd);
            var r = new OperationResult<Webuser>();
            r.Data = webuserDal.Login(loginName, pwd);
            r.ActionResult = (r.Data!=null) ? true : false;
            return r;
        }
    }
}