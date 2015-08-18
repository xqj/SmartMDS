
using mds.BaseModel;
using mds.Dal;
using mds.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Cat.BussinessService
{
    public class ContractProvider
    {
        private static ContractProvider _instance = new ContractProvider();
        public GridPager<WebuserContact> GetPagerList(string searchName, DateTime? startTime, DateTime? endTime, GridPagerParam param, long operationBy, bool isUnion = false)
        {
            ArgumentHelper.AssertInRange("operationBy", (int)operationBy, 1, int.MaxValue);
            startTime = startTime.HasValue ? startTime.Value : DateTime.Now.AddDays(-1.0);
            endTime = endTime.HasValue ? endTime.Value : DateTime.Now.AddDays(1.0);
            var r = new GridPager<WebuserContact>(false);
            int total = 0;
            if (isUnion)
            {
                r.Data = webusercontactDal.GetUnion(searchName, startTime.Value, endTime.Value, param, operationBy, out total);
                r.ActionResult = (r.Data != null) ? true : false;
            }
            else
            {
                r.Data = webusercontactDal.GetJoin(searchName, startTime.Value, endTime.Value, param, operationBy, out total);
                r.ActionResult = (r.Data != null) ? true : false;
            } return r;
        }
        public OperationResult<WebuserContact> GetDetail(int operationBy, int webusercontactId)
        {
            ArgumentHelper.AssertInRange("operationBy", (int)operationBy, 1, int.MaxValue);
            // ArgumentHelper.AssertInRange("webusercontactId", webusercontactId, 1, int.MaxValue);
            var r = new OperationResult<WebuserContact>();
            r.Data = webusercontactDal.GetDetail(operationBy, webusercontactId);
            r.ActionResult = (r.Data != null) ? true : false;
            return r;
        }
        public OperationResult<int> Create(WebuserContact info)
        {           // ArgumentHelper.AssertNotNullOrEmpty(info.webusercontactName);
            var r = new OperationResult<int>();
            r.Data = webusercontactDal.Create(info);
            r.ActionResult = (r.Data > 0) ? true : false;
            return r;
        }
        public ActionMsg Modify(WebuserContact info)
        {           // ArgumentHelper.AssertNotNullOrEmpty(info.infoName);
            var r = new ActionMsg();
            r.ActionResult = webusercontactDal.Modify(info);
            return r;
        }
       
    }
}