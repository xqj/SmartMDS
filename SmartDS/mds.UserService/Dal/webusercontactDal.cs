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
    internal class webusercontactDal : MysqlDatabaseFactory<WebuserContact>
    {
        private static string _DatabaseName = "socialsite";
        internal static List<WebuserContact> GetUnion(string searchName, DateTime startTime, DateTime endTime, GridPagerParam param, long operationBy, out int total)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM webusercontact where (webusercontactName like CONCAT('%',?searchName,'%') or (createTime BETWEEN ?startTime and ?endTime)) and createBy=?operationBy");
            strSql.Append(" order by createTime desc");
            strSql.Append(" limit ");
            strSql.Append(((param.CurrentPage - 1) * param.PageSize).ToString() + "," + param.PageSize.ToString());
            total = 0;
            var parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?searchName", searchName));
            parameters.Add(new MySqlParameter("?startTime", startTime)); parameters.Add(new MySqlParameter("?endTime", endTime)); parameters.Add(new MySqlParameter("?operationBy", operationBy));

            parameters.Add(new MySqlParameter("?CurrentPage", param.CurrentPage));

            parameters.Add(new MySqlParameter("?PageSize", param.PageSize));
            List<WebuserContact> resultList = GetListByReader<WebuserContact>(_DatabaseName, parameters, strSql.ToString(), CommandType.Text, delegate(MySqlDataReader dataReader, List<WebuserContact> result)
            {
                while (dataReader.Read())
                {
                    var temp = new WebuserContact()
                    {
                        ContactId = dataReader.GetInt32("ContactId"),
                        UserId = dataReader.GetInt32("UserId"),
                        HomeAddress = dataReader["HomeAddress"].ToString(),
                        Mobile = dataReader["Mobile"].ToString(),
                        Email = dataReader["Email"].ToString(),
                        CreateTime = dataReader.GetDateTime("CreateTime"),
                    }; result.Add(temp);
                }
            }); return resultList;
        }
        internal static List<WebuserContact> GetJoin(string searchName, DateTime startTime, DateTime endTime, GridPagerParam param, long operationBy, out int total)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM webusercontact where webusercontactName like CONCAT('%',?searchName,'%') and (createTime BETWEEN ?startTime AND ?endTime) and createBy=?operationBy");
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
            List<WebuserContact> resultList = GetListByReader<WebuserContact>(_DatabaseName, parameters, strSql.ToString(), CommandType.Text, delegate(MySqlDataReader dataReader, List<WebuserContact> result)
            {
                while (dataReader.Read())
                {
                    var temp = new WebuserContact()
                    {
                        ContactId = dataReader.GetInt32("ContactId"),
                        UserId = dataReader.GetInt32("UserId"),
                        HomeAddress = dataReader["HomeAddress"].ToString(),
                        Mobile = dataReader["Mobile"].ToString(),
                        Email = dataReader["Email"].ToString(),
                        CreateTime = dataReader.GetDateTime("CreateTime"),
                    }; result.Add(temp);
                }
            }); return resultList;
        }
        internal static WebuserContact GetDetail(int operationBy, int id)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?operationBy", operationBy));
            parameters.Add(new MySqlParameter("?id", id));
            WebuserContact result = GetDataByReader<WebuserContact>(_DatabaseName, parameters, "select * from webusercontact where id=?id;", CommandType.Text, delegate(MySqlDataReader dataReader) { if (dataReader.Read()) { var r = new WebuserContact(); r.ContactId = dataReader.GetInt32("ContactId"); r.UserId = dataReader.GetInt32("UserId"); r.HomeAddress = dataReader["HomeAddress"].ToString(); r.Mobile = dataReader["Mobile"].ToString(); r.Email = dataReader["Email"].ToString(); r.CreateTime = dataReader.GetDateTime("CreateTime"); return r; } else                    return null; }); return result;
        }
        internal static int Create(WebuserContact model)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?ContactId", model.ContactId));
            parameters.Add(new MySqlParameter("?UserId", model.UserId));
            parameters.Add(new MySqlParameter("?HomeAddress", model.HomeAddress));
            parameters.Add(new MySqlParameter("?Mobile", model.Mobile));
            parameters.Add(new MySqlParameter("?Email", model.Email));
            parameters.Add(new MySqlParameter("?CreateTime", model.CreateTime));

            ; return GetPrimarykey(_DatabaseName, parameters.ToArray(), "insert into webusercontact(ContactId,UserId,HomeAddress,Mobile,Email,CreateTime)  values (?ContactId,?UserId,?HomeAddress,?Mobile,?Email,?CreateTime);SELECT  @@IDENTITY as id", CommandType.Text);
        }
        internal static bool Modify(WebuserContact model)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?ContactId", model.ContactId));
            parameters.Add(new MySqlParameter("?UserId", model.UserId));
            parameters.Add(new MySqlParameter("?HomeAddress", model.HomeAddress));
            parameters.Add(new MySqlParameter("?Mobile", model.Mobile));
            parameters.Add(new MySqlParameter("?Email", model.Email));
            parameters.Add(new MySqlParameter("?CreateTime", model.CreateTime));

            return ExecuteNonQuery(_DatabaseName, parameters, "update webusercontact set ContactId=?ContactId,UserId=?UserId,HomeAddress=?HomeAddress,Mobile=?Mobile,Email=?Email,CreateTime=?CreateTime where userID=?userID;", CommandType.Text) > 0 ? true : false;
        }
    }
}