using Cat.BussinessService.Dal;
using Cat.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Cat.BussinessService
{  
  public class Provider  
    {    
    public GridPager<webusercontact> GetPagerList(string searchName, DateTime? startTime, DateTime? endTime, GridPagerParam param, long operationBy, bool isUnion = false)        {            ArgumentHelper.AssertInRange("operationBy", (int)operationBy, 1, int.MaxValue);
            startTime= startTime.HasValue ? startTime.Value : DateTime.Now.AddDays(-1.0);
            endTime = endTime.HasValue ? endTime.Value : DateTime.Now.AddDays(1.0);
            var r = new GridPager<webusercontact>(false);
            int total = 0;
           if (isUnion)            {                r.Data = webusercontactDal.GetUnion(searchName, startTime.Value, endTime.Value, param, operationBy, out total);
               r.ActionResult = (r.Data != null) ? true : false;
           }            else            {                r.Data = webusercontactDal.GetJoin(searchName, startTime.Value, endTime.Value, param, operationBy, out total);
               r.ActionResult = (r.Data != null) ? true : false;
           }             return r;
   }        public OperationResult<webusercontact> GetDetail(int operationBy, int webusercontactId)        {            ArgumentHelper.AssertInRange("operationBy", (int)operationBy, 1, int.MaxValue);
          // ArgumentHelper.AssertInRange("webusercontactId", webusercontactId, 1, int.MaxValue);
           var r = new OperationResult<webusercontact>();
           r.Data = webusercontactDal.GetDetail(operationBy, webusercontactId);
           r.ActionResult = (r.Data != null) ? true : false;
           return r;
       }        public OperationResult<int> Create(webusercontact info)        {           // ArgumentHelper.AssertNotNullOrEmpty(info.webusercontactName);
              var r = new OperationResult<int>();
           r.Data = webusercontactDal.Create(info);
           r.ActionResult = (r.Data>0) ? true : false;
           return r;
       }        public ActionMsg Modify(webusercontact info)        {           // ArgumentHelper.AssertNotNullOrEmpty(info.infoName);
             var r = new ActionMsg();
           r.ActionResult = webusercontactDal.Modify(info);
           return r;
       }           public ActionMsg IsShow(int operationBy, int infoId, bool isShow)        {            ArgumentHelper.AssertInRange("operationBy", operationBy, 1, int.MaxValue);
           //ArgumentHelper.AssertInRange("infoId", infoId, 1, int.MaxValue);
           var r = new ActionMsg();
           r.ActionResult = webusercontactDal.IsShow(operationBy, infoId, isShow);
           return r;
       }        public ActionMsg IsBatchShow(int operationBy, List<int> infoIds, bool isShow)        {            ArgumentHelper.AssertInRange("operationBy", operationBy, 1, int.MaxValue);
           ArgumentHelper.AssertNotNull<List<int>>(infoIds);
           var r = new ActionMsg();
           r.ActionResult = webusercontactDal.IsBatchShow(operationBy, infoIds, isShow);
           return r;
       }    }}