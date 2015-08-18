using System;
namespace mds.UserService
{
  public  interface IWebUserProvider
    {
        mds.BaseModel.OperationResult<int> Create(mds.BaseModel.Webuser info);
        mds.BaseModel.OperationResult<mds.BaseModel.Webuser> GetDetail(int webuserId);
        mds.BaseModel.GridPager<mds.BaseModel.Webuser> GetPagerList(mds.BaseModel.GridPagerParam param);
        mds.BaseModel.GridPager<mds.BaseModel.Webuser> GetPagerList(mds.BaseModel.GridPagerParam param, System.Collections.Generic.List<int> searchIds);
        mds.BaseModel.ActionMsg Modify(mds.BaseModel.Webuser info);
    }
}
