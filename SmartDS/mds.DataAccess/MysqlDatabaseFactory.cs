using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace mds.DataAccess
{
    public class MysqlDatabaseFactory<T>
    {

        public delegate T initData<T>(MySqlDataReader dataReader);

        protected static T GetDataByReader<T>(string connectionName, List<MySqlParameter> parameters, string cmdText, CommandType cmdType, initData<T> dataAction)
        {
            MySqlConnection con = new MySqlConnection(DataConnectionFactory.GetConnectionString(connectionName));
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            cmd.CommandType = cmdType;
            con.Open();
            var dataReader = cmd.ExecuteReader();
            T data = default(T);
            try
            {
                data = dataAction(dataReader);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dataReader.Close();
                con.Close();
            }
            return data;
        }
        public delegate void initList<T>(MySqlDataReader dataReader, List<T> result);

        protected static List<T> GetListByReader<T>(string connectionName, List<MySqlParameter> parameters, string cmdText, CommandType cmdType, initList<T> dataAction)
        {
            MySqlConnection con = new MySqlConnection(DataConnectionFactory.GetConnectionString(connectionName));
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            cmd.CommandType = cmdType;
            con.Open();
            var dataReader = cmd.ExecuteReader();
            List<T> data = new List<T>();
            try
            {
                dataAction(dataReader, data);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dataReader.Close();
                con.Close();
            }
            return data;
        }

        protected static int GetPrimarykey(string connectionName, MySqlParameter[] parameters, string cmdText, CommandType cmdType)
        {
            MySqlConnection con = new MySqlConnection(DataConnectionFactory.GetConnectionString(connectionName));

            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            cmd.CommandType = cmdType;
            con.Open();
            int r=0;
            try
            {
                r = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

            }
            finally
            {

                con.Close();
            }
            return r;
        }
        protected static int ExecuteNonQuery(string connectionName, List<MySqlParameter> parameters, string cmdText, CommandType cmdType)
        {
            MySqlConnection con = new MySqlConnection(DataConnectionFactory.GetConnectionString(connectionName));
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            cmd.CommandType = cmdType;
            con.Open();
            int r = 0;
            try
            {
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return r;
        }
    }
}
