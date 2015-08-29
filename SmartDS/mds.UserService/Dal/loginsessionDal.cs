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
namespace mds.BussinessService.Dal
{
    internal class loginsessionDal : MysqlDatabaseFactory<BaseModel.loginsession>
    {
        private static string _DatabaseName = "Cat_bank";
        internal static List<BaseModel.loginsession> GetUnion(string searchName, DateTime startTime, DateTime endTime, BaseModel.GridPagerParam param, long operationBy, out int total)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM loginsession where (loginsessionName like CONCAT('%',?searchName,'%') or (createTime BETWEEN ?startTime and ?endTime)) and createBy=?operationBy");
            strSql.Append(" order by createTime desc");
            strSql.Append(" limit ");
            strSql.Append(((param.CurrentPage - 1) * param.PageSize).ToString() + "," + param.PageSize.ToString());
            total = 0;
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?searchName", searchName));
            parameters.Add(new MySqlParameter("?startTime", startTime)); parameters.Add(new MySqlParameter("?endTime", endTime)); parameters.Add(new MySqlParameter("?operationBy", operationBy));

            parameters.Add(new MySqlParameter("?CurrentPage", param.CurrentPage));

            parameters.Add(new MySqlParameter("?PageSize", param.PageSize));
            List<BaseModel.loginsession> resultList = GetListByReader<BaseModel.loginsession>(_DatabaseName, parameters, strSql.ToString(), CommandType.Text, delegate(MySqlDataReader dataReader, List<BaseModel.loginsession> result)
            {
                while (dataReader.Read())
                {
                    var temp = new BaseModel.loginsession()
                    {
                        SessionId = dataReader.GetInt32("SessionId"),
                        LoginId = dataReader.GetInt32("LoginId"),
                        SessionSign = dataReader["SessionSign"].ToString(),
                        CreateTime = dataReader.GetDateTime("CreateTime"),
                        Timelength = dataReader.GetInt32("Timelength"),
                        TimeUnit = dataReader["TimeUnit"].ToString(),
                    }; result.Add(temp);
                }
            }); return resultList;
        }
        internal static List<BaseModel.loginsession> GetJoin(string searchName, DateTime startTime, DateTime endTime, BaseModel.GridPagerParam param, long operationBy, out int total)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM loginsession where loginsessionName like CONCAT('%',?searchName,'%') and (createTime BETWEEN ?startTime AND ?endTime) and createBy=?operationBy");
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
            List<BaseModel.loginsession> resultList = GetListByReader<BaseModel.loginsession>(_DatabaseName, parameters, strSql.ToString(), CommandType.Text, delegate(MySqlDataReader dataReader, List<BaseModel.loginsession> result)
            {
                while (dataReader.Read())
                {
                    var temp = new BaseModel.loginsession()
                    {
                        SessionId = dataReader.GetInt32("SessionId"),
                        LoginId = dataReader.GetInt32("LoginId"),
                        SessionSign = dataReader["SessionSign"].ToString(),
                        CreateTime = dataReader.GetDateTime("CreateTime"),
                        Timelength = dataReader.GetInt32("Timelength"),
                        TimeUnit = dataReader["TimeUnit"].ToString(),
                    }; result.Add(temp);
                }
            }); return resultList;
        }
        internal static BaseModel.loginsession GetDetail(int operationBy, int id)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?operationBy", operationBy));
            parameters.Add(new MySqlParameter("?id", id));
            BaseModel.loginsession result = GetDataByReader<BaseModel.loginsession>(_DatabaseName, parameters, "select * from loginsession where id=?id;", CommandType.Text, delegate(MySqlDataReader dataReader) { if (dataReader.Read()) { var r = new BaseModel.loginsession(); r.SessionId = dataReader.GetInt32("SessionId"); r.LoginId = dataReader.GetInt32("LoginId"); r.SessionSign = dataReader["SessionSign"].ToString(); r.CreateTime = dataReader.GetDateTime("CreateTime"); r.Timelength = dataReader.GetInt32("Timelength"); r.TimeUnit = dataReader["TimeUnit"].ToString(); return r; } else                    return null; }); return result;
        }
        internal static int Create(BaseModel.loginsession model)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?SessionId", model.SessionId));
            parameters.Add(new MySqlParameter("?LoginId", model.LoginId));
            parameters.Add(new MySqlParameter("?SessionSign", model.SessionSign));
            parameters.Add(new MySqlParameter("?CreateTime", model.CreateTime));
            parameters.Add(new MySqlParameter("?Timelength", model.Timelength));
            parameters.Add(new MySqlParameter("?TimeUnit", model.TimeUnit));

            ; return DatabaseFactory.GetPrimarykey(_DatabaseName, parameters.ToArray(), "insert into loginsession(SessionId,LoginId,SessionSign,CreateTime,Timelength,TimeUnit)  values (?SessionId,?LoginId,?SessionSign,?CreateTime,?Timelength,?TimeUnit);SELECT  @@IDENTITY as id", CommandType.Text);
        }
        internal static bool Modify(BaseModel.loginsession model)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?SessionId", model.SessionId));
            parameters.Add(new MySqlParameter("?LoginId", model.LoginId));
            parameters.Add(new MySqlParameter("?SessionSign", model.SessionSign));
            parameters.Add(new MySqlParameter("?CreateTime", model.CreateTime));
            parameters.Add(new MySqlParameter("?Timelength", model.Timelength));
            parameters.Add(new MySqlParameter("?TimeUnit", model.TimeUnit));

            return DatabaseFactory.ExecuteNonQuery(_DatabaseName, parameters, "update loginsession set SessionId=?SessionId,LoginId=?LoginId,SessionSign=?SessionSign,CreateTime=?CreateTime,Timelength=?Timelength,TimeUnit=?TimeUnit where userID=?userID;", CommandType.Text) > 0 ? true : false;
        }
    }
}