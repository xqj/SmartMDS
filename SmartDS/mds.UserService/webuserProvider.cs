using mds.Dal;
using mds.BaseModel;
using mds.Dal;
using mds.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Cat.BussinessService
{
    public class WebUserProvider
    {
        public GridPager<webuser> GetPagerList(string searchName, DateTime? startTime, DateTime? endTime, GridPagerParam param, long operationBy, bool isUnion = false)
        {
            ArgumentHelper.AssertInRange("operationBy", (int)operationBy, 1, int.MaxValue);
            startTime = startTime.HasValue ? startTime.Value : DateTime.Now.AddDays(-1.0);
            endTime = endTime.HasValue ? endTime.Value : DateTime.Now.AddDays(1.0);
            var r = new GridPager<webuser>(false);
            int total = 0;
            if (isUnion)
            {
                r.Data = webuserDal.GetUnion(searchName, startTime.Value, endTime.Value, param, operationBy, out total);
                r.ActionResult = (r.Data != null) ? true : false;
            }
            else
            {
                r.Data = webuserDal.GetJoin(searchName, startTime.Value, endTime.Value, param, operationBy, out total);
                r.ActionResult = (r.Data != null) ? true : false;
            } return r;
        }
        public OperationResult<webuser> GetDetail(int operationBy, int webuserId)
        {
            ArgumentHelper.AssertInRange("operationBy", (int)operationBy, 1, int.MaxValue);
            // ArgumentHelper.AssertInRange("webuserId", webuserId, 1, int.MaxValue);
            var r = new OperationResult<webuser>();
            r.Data = webuserDal.GetDetail(operationBy, webuserId);
            r.ActionResult = (r.Data != null) ? true : false;
            return r;
        }
        public OperationResult<int> Create(webuser info)
        {           // ArgumentHelper.AssertNotNullOrEmpty(info.webuserName);
            var r = new OperationResult<int>();
            r.Data = webuserDal.Create(info);
            r.ActionResult = (r.Data > 0) ? true : false;
            return r;
        }
        public ActionMsg Modify(webuser info)
        {           // ArgumentHelper.AssertNotNullOrEmpty(info.infoName);
            var r = new ActionMsg();
            r.ActionResult = webuserDal.Modify(info);
            return r;
        }
        
    }
}