using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ENR_Dal
{
    public class DBTool
    {
        private string connStr = "";
        private static SqlConnection conn = null;

        public DBTool()
        {
            //读取配置文件信息获取数据库连接字符串，初始化连接字符串
            connStr = ConfigurationManager.ConnectionStrings["UserConnStr"].ConnectionString;

        }

        public DBTool(string connStrName)
        {
            //读取配置文件信息获取数据库连接字符串，初始化连接字符串
            connStr = ConfigurationManager.ConnectionStrings[connStrName].ConnectionString;
        }
        //获取数据库连接
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns>SqlConnetcion</returns>
        public SqlConnection getSqlConnection()
        {
            initSqlConnection();
            return conn;
        }

        //初始化数据库连接
        private void initSqlConnection()
        {
            if (conn == null)
            {
                conn = new SqlConnection(connStr);
            }
        }

        //无参查询
        /// <summary>
        /// 无参查询
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns>BindingSource</returns>
        public BindingSource SelectNoParamter(string sqlStr)
        {
            BindingSource bs = new BindingSource();
            initSqlConnection();
            SqlCommand command = new SqlCommand(sqlStr, conn);
            SqlDataReader reader = command.ExecuteReader();
            bs.DataSource = reader;
            conn.Close();
            return bs;
        }

        //无参查询
        /// <summary>
        /// 无参查询
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectNoParamterDataSet(string sqlStr)
        {
            DataSet ds = new DataSet();
            initSqlConnection();
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
            adapter.Fill(ds);
            conn.Close();
            return ds;
        }

        ///无参查询
        /// <summary>
        /// 无参查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlDataReader SelectNoParamterReader(string sql)
        {
            initSqlConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;

        }
        ///带参查询
        /// <summary>
        /// 带参查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public SqlDataReader SelectWithParamterReader(string sql, SqlParameter[] param)
        {
            initSqlConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(param);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        //带参查询
        /// <summary>
        /// 带参查询
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="paramter"></param>
        /// <returns>BindingSource</returns>
        public BindingSource SelectWithParamter(string sqlStr, SqlParameter[] paramter)
        {
            BindingSource bs = new BindingSource();
            initSqlConnection();
            conn.Open();
            SqlCommand command = new SqlCommand(sqlStr, conn);
            command.Parameters.AddRange(paramter);
            SqlDataReader reader = command.ExecuteReader();
            bs.DataSource = reader;
            conn.Close();
            return bs;
        }
        //带参查询
        /// <summary>
        /// 带参查询
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="paramter"></param>
        /// <returns>DataSet</returns>
        public DataSet SelectWithParamterDataSet(string sqlStr, SqlParameter[] paramter)
        {
            DataSet ds = new DataSet();
            initSqlConnection();
            conn.Open();
            SqlCommand command = new SqlCommand(sqlStr, conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            command.Parameters.AddRange(paramter);
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteReader();
            adapter.Fill(ds);
            conn.Close();
            return ds;
        }

        //执行数据库更新操作
        /// <summary>
        /// 数据库更新（增，删，改）
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="paramter"></param>
        /// <returns></returns>
        public int NoQueryCmd(string sqlStr, SqlParameter[] paramter)
        {
            int result = 0;
            initSqlConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddRange(paramter);
            result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        //删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="paramter"></param>
        /// <returns></returns>
        public int Delete(string sqlStr, SqlParameter[] paramter)
        {
            int result = 0;
            initSqlConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddRange(paramter);
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.DeleteCommand = cmd;
            result = adp.DeleteCommand.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        //添加数据
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="paramter"></param>
        /// <returns></returns>
        public int Add(string sqlStr, SqlParameter[] paramter)
        {
            int result = 0;
            initSqlConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddRange(paramter);
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.InsertCommand = cmd;
            result = adp.InsertCommand.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        //修改数
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="paramter"></param>
        /// <returns></returns>
        public int Update(string sqlStr, SqlParameter[] paramter)
        {
            int result = 0;
            initSqlConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddRange(paramter);
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.UpdateCommand = cmd;
            result = adp.UpdateCommand.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public object ExecuteScalar(String sql, SqlParameter[] param)
        {
            object result = 0;
            initSqlConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(param);
            conn.Open();
            result = cmd.ExecuteScalar();
            conn.Close();
            return result;
        }

        //执行数据库更新操作
        /// <summary>
        /// 使用事务进行数据库更新（增、删、改）
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="paramter"></param>
        /// <returns></returns>
        public int NoQueryCmdByAffair(string[] sqlStr, SqlParameter[][] paramter)
        {
            initSqlConnection();
            conn.Open();
            SqlTransaction trans = null;        //默认让SqlTransaction对象为空
            trans = conn.BeginTransaction();     //开启事务：标志事务的开始
            try
            {
                for (int i = 0; i < sqlStr.Length; i++)
                {
                    SqlCommand cmd = new SqlCommand(sqlStr[i], conn);
                    cmd.Parameters.AddRange(paramter[i]);
                    cmd.Transaction = trans;
                    if (cmd.ExecuteNonQuery() == 0) { trans.Rollback(); conn.Close(); return 0; }
                }
                trans.Commit();
                conn.Close();
                return 1;
            } catch(Exception)
            {
                trans.Rollback();
                conn.Close();
            }
            
            return 0;
        }
    }
}
