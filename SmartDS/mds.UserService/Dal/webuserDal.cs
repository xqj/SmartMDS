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
    internal class webuserDal : MysqlDatabaseFactory<webuser>
    {
        private static string _DatabaseName = "socialsite";
        internal static List<webuser> GetUnion(string searchName, DateTime startTime, DateTime endTime, GridPagerParam param, long operationBy, out int total)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM webuser where (webuserName like CONCAT('%',?searchName,'%') or (createTime BETWEEN ?startTime and ?endTime)) and createBy=?operationBy");
            strSql.Append(" order by createTime desc");
            strSql.Append(" limit ");
            strSql.Append(((param.CurrentPage - 1) * param.PageSize).ToString() + "," + param.PageSize.ToString());
            total = 0;
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?searchName", searchName));
            parameters.Add(new MySqlParameter("?startTime", startTime)); parameters.Add(new MySqlParameter("?endTime", endTime)); parameters.Add(new MySqlParameter("?operationBy", operationBy));

            parameters.Add(new MySqlParameter("?CurrentPage", param.CurrentPage));

            parameters.Add(new MySqlParameter("?PageSize", param.PageSize));
            List<webuser> resultList = GetListByReader<webuser>(_DatabaseName, parameters, strSql.ToString(), CommandType.Text, delegate(MySqlDataReader dataReader, List<webuser> result)
            {
                while (dataReader.Read())
                {
                    var temp = new webuser()
                    {
                        UserId = dataReader.GetInt32("UserId"),
                        LoginName = dataReader["LoginName"].ToString(),
                        Mobile = dataReader["Mobile"].ToString(),
                        IDCard = dataReader["IDCard"].ToString(),
                        Nationality = dataReader["Nationality"].ToString(),
                        ImgUrl = dataReader["ImgUrl"].ToString(),
                        CreateTime = dataReader.GetDateTime("CreateTime"),
                    }; result.Add(temp);
                }
            }); return resultList;
        }
        internal static List<webuser> GetJoin(string searchName, DateTime startTime, DateTime endTime, GridPagerParam param, long operationBy, out int total)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM webuser where webuserName like CONCAT('%',?searchName,'%') and (createTime BETWEEN ?startTime AND ?endTime) and createBy=?operationBy");
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
            List<webuser> resultList = GetListByReader<webuser>(_DatabaseName, parameters, strSql.ToString(), CommandType.Text, delegate(MySqlDataReader dataReader, List<webuser> result)
            {
                while (dataReader.Read())
                {
                    var temp = new webuser()
                    {
                        UserId = dataReader.GetInt32("UserId"),
                        LoginName = dataReader["LoginName"].ToString(),
                        Mobile = dataReader["Mobile"].ToString(),
                        IDCard = dataReader["IDCard"].ToString(),
                        Nationality = dataReader["Nationality"].ToString(),
                        ImgUrl = dataReader["ImgUrl"].ToString(),
                        CreateTime = dataReader.GetDateTime("CreateTime"),
                    }; result.Add(temp);
                }
            }); return resultList;
        }
        internal static webuser GetDetail(int operationBy, int id)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?operationBy", operationBy));
            parameters.Add(new MySqlParameter("?id", id));
            webuser result = GetDataByReader<webuser>(_DatabaseName, parameters, "select * from webuser where id=?id;", CommandType.Text, delegate(MySqlDataReader dataReader) { if (dataReader.Read()) { var r = new webuser(); r.UserId = dataReader.GetInt32("UserId"); r.LoginName = dataReader["LoginName"].ToString(); r.Mobile = dataReader["Mobile"].ToString(); r.IDCard = dataReader["IDCard"].ToString(); r.Nationality = dataReader["Nationality"].ToString(); r.ImgUrl = dataReader["ImgUrl"].ToString(); r.CreateTime = dataReader.GetDateTime("CreateTime"); return r; } else                    return null; }); return result;
        }
        internal static int Create(webuser model)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?UserId", model.UserId));
            parameters.Add(new MySqlParameter("?LoginName", model.LoginName));
            parameters.Add(new MySqlParameter("?Mobile", model.Mobile));
            parameters.Add(new MySqlParameter("?Sex", model.Sex));
            parameters.Add(new MySqlParameter("?IDCard", model.IDCard));
            parameters.Add(new MySqlParameter("?Nationality", model.Nationality));
            parameters.Add(new MySqlParameter("?ImgUrl", model.ImgUrl));
            parameters.Add(new MySqlParameter("?CreateTime", model.CreateTime));

            ; return DatabaseFactory.GetPrimarykey(_DatabaseName, parameters.ToArray(), "insert into webuser(UserId,LoginName,Mobile,Sex,IDCard,Nationality,ImgUrl,CreateTime)  values (?UserId,?LoginName,?Mobile,?Sex,?IDCard,?Nationality,?ImgUrl,?CreateTime);SELECT  @@IDENTITY as id", CommandType.Text);
        }
        internal static bool Modify(webuser model)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?UserId", model.UserId));
            parameters.Add(new MySqlParameter("?LoginName", model.LoginName));
            parameters.Add(new MySqlParameter("?Mobile", model.Mobile));
            parameters.Add(new MySqlParameter("?Sex", model.Sex));
            parameters.Add(new MySqlParameter("?IDCard", model.IDCard));
            parameters.Add(new MySqlParameter("?Nationality", model.Nationality));
            parameters.Add(new MySqlParameter("?ImgUrl", model.ImgUrl));
            parameters.Add(new MySqlParameter("?CreateTime", model.CreateTime));

            return DatabaseFactory.ExecuteNonQuery(_DatabaseName, parameters, "update webuser set UserId=?UserId,LoginName=?LoginName,Mobile=?Mobile,Sex=?Sex,IDCard=?IDCard,Nationality=?Nationality,ImgUrl=?ImgUrl,CreateTime=?CreateTime where userID=?userID;", CommandType.Text) > 0 ? true : false;
        }
    }
}