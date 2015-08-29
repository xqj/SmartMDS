using mds.BaseModel;
using mds.DataAccess;
using mds.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace mds.Dal
{
    internal class loginuserDal : MysqlDatabaseFactory<BaseModel.loginuser>
    {
        private static string _DatabaseName = "userservice";
        internal static List<BaseModel.loginuser> GetUnion(string searchName, DateTime startTime, DateTime endTime, BaseModel.GridPagerParam param, long operationBy, out int total)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM loginuser where (loginuserName like CONCAT('%',?searchName,'%') or (createTime BETWEEN ?startTime and ?endTime)) and createBy=?operationBy");
            strSql.Append(" order by createTime desc");
            strSql.Append(" limit ");
            strSql.Append(((param.CurrentPage - 1) * param.PageSize).ToString() + "," + param.PageSize.ToString());
            total = 0;
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?searchName", searchName));
            parameters.Add(new MySqlParameter("?startTime", startTime)); parameters.Add(new MySqlParameter("?endTime", endTime)); parameters.Add(new MySqlParameter("?operationBy", operationBy));

            parameters.Add(new MySqlParameter("?CurrentPage", param.CurrentPage));

            parameters.Add(new MySqlParameter("?PageSize", param.PageSize));
            List<BaseModel.loginuser> resultList = GetListByReader<BaseModel.loginuser>(_DatabaseName, parameters, strSql.ToString(), CommandType.Text, delegate(MySqlDataReader dataReader, List<BaseModel.loginuser> result)
            {
                while (dataReader.Read())
                {
                    var temp = new BaseModel.loginuser()
                    {
                        LoginId = dataReader.GetInt32("LoginId"),
                        UserId = dataReader.GetInt32("UserId"),
                        LoginName = dataReader["LoginName"].ToString(),
                        Pwd = dataReader["Pwd"].ToString(),
                        CreateTime = dataReader.GetDateTime("CreateTime"),
                    }; result.Add(temp);
                }
            }); return resultList;
        }
        internal static List<BaseModel.loginuser> GetJoin(string searchName, DateTime startTime, DateTime endTime, BaseModel.GridPagerParam param, long operationBy, out int total)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM loginuser where loginuserName like CONCAT('%',?searchName,'%') and (createTime BETWEEN ?startTime AND ?endTime) and createBy=?operationBy");
            strSql.Append(" order by createTime desc");
            strSql.Append(" limit ");
            strSql.Append(((param.CurrentPage - 1) * param.PageSize).ToString() + "," + param.PageSize.ToString());
            total = 0;
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?searchName", searchName));
            parameters.Add(new MySqlParameter("?startTime", startTime));
            parameters.Add(new MySqlParameter("?endTime", endTime));
            parameters.Add(new MySqlParameter("?operationBy", operationBy));
            parameters.Add(new MySqlParameter("?CurrentPage", param.CurrentPage));
            parameters.Add(new MySqlParameter("?PageSize", param.PageSize));
            List<BaseModel.loginuser> resultList = GetListByReader<BaseModel.loginuser>(_DatabaseName, parameters, strSql.ToString(), CommandType.Text, delegate(MySqlDataReader dataReader, List<BaseModel.loginuser> result)
            {
                while (dataReader.Read())
                {
                    var temp = new BaseModel.loginuser()
                    {
                        LoginId = dataReader.GetInt32("LoginId"),
                        UserId = dataReader.GetInt32("UserId"),
                        LoginName = dataReader["LoginName"].ToString(),
                        Pwd = dataReader["Pwd"].ToString(),
                        CreateTime = dataReader.GetDateTime("CreateTime"),
                    }; result.Add(temp);
                }
            }); return resultList;
        }
        internal static BaseModel.loginuser GetDetail(int operationBy, int id)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?operationBy", operationBy));
            parameters.Add(new MySqlParameter("?id", id));
            BaseModel.loginuser result = GetDataByReader<BaseModel.loginuser>(_DatabaseName, parameters, "select * from loginuser where id=?id;", CommandType.Text, delegate(MySqlDataReader dataReader) { if (dataReader.Read()) { var r = new BaseModel.loginuser(); r.LoginId = dataReader.GetInt32("LoginId"); r.UserId = dataReader.GetInt32("UserId"); r.LoginName = dataReader["LoginName"].ToString(); r.Pwd = dataReader["Pwd"].ToString(); r.CreateTime = dataReader.GetDateTime("CreateTime"); return r; } else                    return null; }); return result;
        }
        internal static int Create(BaseModel.loginuser model)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?LoginId", model.LoginId));
            parameters.Add(new MySqlParameter("?UserId", model.UserId));
            parameters.Add(new MySqlParameter("?LoginName", model.LoginName));
            parameters.Add(new MySqlParameter("?Pwd", model.Pwd));
            parameters.Add(new MySqlParameter("?CreateTime", model.CreateTime));

            ; return GetPrimarykey(_DatabaseName, parameters.ToArray(), "insert into loginuser(LoginId,UserId,LoginName,Pwd,CreateTime)  values (?LoginId,?UserId,?LoginName,?Pwd,?CreateTime);SELECT  @@IDENTITY as id", CommandType.Text);
        }
        internal static bool Modify(BaseModel.loginuser model)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?LoginId", model.LoginId));
            parameters.Add(new MySqlParameter("?UserId", model.UserId));
            parameters.Add(new MySqlParameter("?LoginName", model.LoginName));
            parameters.Add(new MySqlParameter("?Pwd", model.Pwd));
            parameters.Add(new MySqlParameter("?CreateTime", model.CreateTime));

            return ExecuteNonQuery(_DatabaseName, parameters, "update loginuser set LoginId=?LoginId,UserId=?UserId,LoginName=?LoginName,Pwd=?Pwd,CreateTime=?CreateTime where userID=?userID;", CommandType.Text) > 0 ? true : false;
        }

        internal static loginuser Login(string loginName, string pwd)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?loginName",loginName));
            parameters.Add(new MySqlParameter("?pwd", pwd));
            BaseModel.loginuser result = GetDataByReader<BaseModel.loginuser>(_DatabaseName, parameters, "select * from loginuser where LoginName=?loginName and Pwd=?pwd;", CommandType.Text, delegate(MySqlDataReader dataReader) { if (dataReader.Read()) { 
                var r = new BaseModel.loginuser();
                r.LoginId = dataReader.GetInt32("LoginId"); r.UserId = dataReader.GetInt32("UserId"); r.LoginName = dataReader["LoginName"].ToString(); r.Pwd = dataReader["Pwd"].ToString();
                r.CreateTime = dataReader.GetDateTime("CreateTime"); return r;
            } else                   
                return null;
            });
            return result;
        }
    }
}