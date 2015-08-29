using System;
namespace mds.UserService
{
  public  interface IWebUserProvider
    {
      mds.BaseModel.OperationResult<mds.BaseModel.Webuser> Reg(string loginName, string pwd, string email, string verfiycode);
      mds.BaseModel.OperationResult<mds.BaseModel.Webuser> Login(string loginName, string pwd);
        mds.BaseModel.OperationResult<int> Create(mds.BaseModel.Webuser info);
        mds.BaseModel.OperationResult<mds.BaseModel.Webuser> GetDetail(int webuserId);
        mds.BaseModel.GridPager<mds.BaseModel.Webuser> GetPagerList(mds.BaseModel.GridPagerParam param);
        mds.BaseModel.GridPager<mds.BaseModel.Webuser> GetSearchPager(mds.BaseModel.GridPagerParam param,string searchKey);
        mds.BaseModel.GridPager<mds.BaseModel.Webuser> GetPagerList(mds.BaseModel.GridPagerParam param, System.Collections.Generic.List<int> searchIds);
        mds.BaseModel.ActionMsg Modify(mds.BaseModel.Webuser info);

        BaseModel.ActionMsg ChangePwd(int userId, string oldPwd, string newPwd);

        BaseModel.OperationResult<BaseModel.loginsession> LoginSession(string loginName, string pwd);

        BaseModel.OperationResult<BaseModel.loginsession> GetSessionBySign(string sessionSign);
    }
}
