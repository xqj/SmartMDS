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
    internal class webuserDal : MysqlDatabaseFactory<Webuser>
    {
        private static string _DatabaseName = "socialsite";
        internal static List<Webuser> GetPagerList(GridPagerParam param)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserId,UserName FROM webuser");
            strSql.Append(" order by CreateTime desc");
            strSql.Append(" limit ");
            strSql.Append(((param.CurrentPage - 1) * param.PageSize).ToString() + "," + param.PageSize.ToString());
            List<Webuser> resultList = GetListByReader<Webuser>(_DatabaseName, null, strSql.ToString(), CommandType.Text, delegate(MySqlDataReader dataReader, List<Webuser> result)
            {
                while (dataReader.Read())
                {
                    var temp = new Webuser()
                    {
                        UserId = dataReader.GetInt32("UserId"),
                        UserName = dataReader["UserName"].ToString()
                    };
                    result.Add(temp);
                }
            });
            return resultList;
        }
        internal static List<Webuser> GetPagerList(GridPagerParam param, List<int> userIds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserId,UserName FROM webuser where UserId in ги");
            strSql.Append(string.Join(",", userIds));
            strSql.Append(")");
            strSql.Append(" order by CreateTime desc");
            strSql.Append(" limit ");
            strSql.Append(((param.CurrentPage - 1) * param.PageSize).ToString() + "," + param.PageSize.ToString());
            List<Webuser> resultList = GetListByReader<Webuser>(_DatabaseName, null, strSql.ToString(), CommandType.Text, delegate(MySqlDataReader dataReader, List<Webuser> result)
            {
                while (dataReader.Read())
                {
                    var temp = new Webuser()
                    {
                        UserId = dataReader.GetInt32("UserId"),
                        UserName = dataReader["UserName"].ToString()
                    };
                    result.Add(temp);
                }
            });
            return resultList;
        }
        internal static Webuser GetDetail(int id)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?id", id));
            Webuser result = GetDataByReader<Webuser>(_DatabaseName, parameters, "select * from webuser where id=?id;", CommandType.Text, delegate(MySqlDataReader dataReader)
            {
                if (dataReader.Read())
                {
                    var r = new Webuser();
                    r.UserId = dataReader.GetInt32("UserId");
                    r.LoginName = dataReader["LoginName"].ToString();
                    r.Mobile = dataReader["Mobile"].ToString();
                    r.IDCard = dataReader["IDCard"].ToString();
                    r.Nationality = dataReader["Nationality"].ToString();
                    r.ImgUrl = dataReader["ImgUrl"].ToString(); 
                    r.CreateTime = dataReader.GetDateTime("CreateTime"); 
                    return r;
                }
                else
                    return null;
            });
            return result;
        }
        internal static int Create(Webuser model)
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

            ; return GetPrimarykey(_DatabaseName, parameters.ToArray(), "insert into webuser(UserId,LoginName,Mobile,Sex,IDCard,Nationality,ImgUrl,CreateTime)  values (?UserId,?LoginName,?Mobile,?Sex,?IDCard,?Nationality,?ImgUrl,?CreateTime);SELECT  @@IDENTITY as id", CommandType.Text);
        }
        internal static bool Modify(Webuser model)
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

            return ExecuteNonQuery(_DatabaseName, parameters, "update webuser set UserId=?UserId,LoginName=?LoginName,Mobile=?Mobile,Sex=?Sex,IDCard=?IDCard,Nationality=?Nationality,ImgUrl=?ImgUrl,CreateTime=?CreateTime where userID=?userID;", CommandType.Text) > 0 ? true : false;
        }

        internal static int Reg(string loginName, string pwd, string email)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?LoginName", loginName));
            parameters.Add(new MySqlParameter("?Email", email));
            parameters.Add(new MySqlParameter("?Pwd", pwd));
            parameters.Add(new MySqlParameter("?CreateTime", DateTime.Now));
            ; return GetPrimarykey(_DatabaseName, parameters.ToArray(), "insert into webuser(LoginName,Email,Pwd,CreateTime)  values (?LoginName,?Email,?Pwd,?CreateTime);SELECT  @@IDENTITY as id", CommandType.Text);
        }

        internal static Webuser Login(string loginName, string pwd)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("?LoginName", loginName));
            parameters.Add(new MySqlParameter("?Pwd", pwd));
            Webuser result = GetDataByReader<Webuser>(_DatabaseName, parameters, "select * from webuser where LoginName=?LoginName and Pwd=?Pwd;", CommandType.Text, delegate(MySqlDataReader dataReader)
            {
                if (dataReader.Read())
                {
                    var r = new Webuser(); r.UserId = dataReader.GetInt32("UserId");
                    r.LoginName = dataReader["LoginName"].ToString();
                    r.Mobile = dataReader["Mobile"].ToString();
                    r.Email = dataReader["Email"].ToString();
                    r.IDCard = dataReader["IDCard"].ToString();
                    r.Nationality = dataReader["Nationality"].ToString();
                    r.ImgUrl = dataReader["ImgUrl"].ToString();
                    r.CreateTime = dataReader.GetDateTime("CreateTime");
                    return r;
                }
                else
                    return null;
            });
            return result;
        }
    }
}