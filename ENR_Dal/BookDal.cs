using ENR_Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENR_Dal
{
    public class BookDal
    {
        private DBTool db = new DBTool();

        public BookDal() { }


        /// <summary>
        /// 修改电子书数据
        /// </summary>
        /// <param name="info">书籍对象</param>
        /// <returns>若成功返回大于0的int类型参数</returns>
        public int UpdataBookWithParameter(BookInfo info)
        {
            int result = 0;
            SqlParameter[][] parameter = new SqlParameter[3][];
            String[] SQL = new String[3];
            parameter[0] = new SqlParameter[] { new SqlParameter("@ID", info.OldID) };
            SQL[0] = "update Book set isDelete = 1 where ID = @ID";
            parameter[1] = new SqlParameter[] { new SqlParameter("@ID", info.AuditOpinion) };
            SQL[1] = "insert AuditOpinion(ID,isPass,opinion,createTime) values (@ID,'未审核','未审核',GETDATE()) ";
            SQL[2] = "insert Book(ID,imageName,imageUrl,name,author,text,serialState,bookType,fileName,fileUrl,fileSize,uploadUser,uploadTime,clickCount,isTrue,isDelete,auditOpinion) " +
                "values(@ID,@imageName,@imageUrl,@name,@author,@text,@serialState,@bookType,@fileName,@fileUrl,@fileSize,@uploadUser,GETDATE(),'0','0','0',@auditOpinion)";
            parameter[2] = setInsertParameters(info);

            result = db.NoQueryCmdByAffair(SQL, parameter);
            return result;
        }

        /// <summary>
        /// 插入电子书数据
        /// </summary>
        /// <param name="info">书籍对象</param>
        /// <returns>若成功返回大于0的int类型参数</returns>
        public int AddBookWithParameter(BookInfo info)
        {
            int result = 0;
            SqlParameter[][] parameter = new SqlParameter[2][];
            String[] SQL = new String[2];
            parameter[0] = new SqlParameter[] { new SqlParameter("@ID", info.AuditOpinion) };
            SQL[0] = "insert AuditOpinion(ID,isPass,opinion,createTime) values (@ID,'未审核','未审核',GETDATE()) ";
            SQL[1] = "insert Book(ID,imageName,imageUrl,name,author,text,serialState,bookType,fileName,fileUrl,fileSize,uploadUser,uploadTime,clickCount,isTrue,isDelete,auditOpinion) " +
                "values(@ID,@imageName,@imageUrl,@name,@author,@text,@serialState,@bookType,@fileName,@fileUrl,@fileSize,@uploadUser,GETDATE(),'0','0','0',@auditOpinion)";
            parameter[1] = setInsertParameters(info);
            
            result = db.NoQueryCmdByAffair(SQL, parameter);
            return result;
        }

        public int DeleteBookWithParameter(BookInfo info)
        {
            int result = 0;
            SqlParameter[] parameter = new SqlParameter[] { new SqlParameter("@ID", info.Id) };
            String SQL = "update Book set isDelete = 1 where ID = @ID";
            result = db.NoQueryCmd(SQL, parameter);
            return result;
        }



        /// <summary>
        /// 修改电子书下载次数
        /// </summary>
        /// <param name="info">书籍对象</param>
        /// <returns>若成功返回大于0的int类型参数</returns>
        public int UpdataDownloadBookWithParameter(BookInfo info)
        {
            int result = 0;
            SqlParameter[] parameter = new SqlParameter[] { new SqlParameter("@ID", info.Id) };
            String SQL = "update Book set clickCount = clickCount+1 where ID = @ID";
            result = db.NoQueryCmd(SQL, parameter);
            return result;
        }


        

        /// <summary>
        /// 查找电子书（已有分页查询版本）
        /// </summary>
        /// <param name="info">书籍对象</param>
        /// <returns>书籍集合</returns>
        public List<BookInfo> SelectBookWithParameter(BookInfo info)
        {
            String sql = "select ID,imageUrl,name,author,text,serialState,fileUrl,fileSize,uploadTime,clickCount,isTrue,isDelete,AuditID,isPass,opinion,createTime," +
                "DepartmentID,DepartmentName,PersonalID,(select name from Personal where ID = PersonalID) as 'PersonalName',UserID,UserName,UserEmail,imageName,fileName from BookInfomation where 1 = 1";
            sql = setSelectSQL(info, sql);
            List<SqlParameter> parameters = setSelectParmeters(info);
            sql += " order by uploadTime desc";
            return setViewData(db.SelectWithParamterReader(sql, parameters.ToArray()));
        }

        /// <summary>
        /// 查找电子书（已有分页查询版本）
        /// </summary>
        /// <returns>书籍集合</returns>
        public List<BookInfo> SelectBookNoParameter()
        {
            String sql = "select ID,imageUrl,name,author,text,serialState,fileUrl,fileSize,uploadTime,clickCount,isTrue,isDelete,AuditID,isPass,opinion,createTime," +
                "DepartmentID,DepartmentName,PersonalID,(select name from Personal where ID = PersonalID) as 'PersonalName',UserID,UserName,UserEmail,imageName,fileName from BookInfomation order by uploadTime desc";
            return setViewData(db.SelectNoParamterReader(sql));
        }


        /// <summary>
        /// 按下载次数降序排列查找电子书（已有分页查询版本）
        /// </summary>
        /// <param name="info">书籍对象</param>
        /// <returns>书籍集合</returns>
        public List<BookInfo> SelectFireBookWithParameter(BookInfo info)
        {
            String sql = "select ID,imageUrl,name,author,text,serialState,fileUrl,fileSize,uploadTime,clickCount,isTrue,isDelete,AuditID,isPass,opinion,createTime," +
                "DepartmentID,DepartmentName,PersonalID,(select name from Personal where ID = PersonalID) as 'PersonalName',UserID,UserName,UserEmail,imageName,fileName from BookInfomation where isDelete = '0' ";
            sql = setSelectSQL(info, sql);
            List<SqlParameter> parameters = setSelectParmeters(info);
            sql += " order by uploadTime desc";
            return setViewData(db.SelectWithParamterReader(sql, parameters.ToArray()));
        }

        /// <summary>
        /// 按下载次数降序排列查找电子书（已有分页查询版本）
        /// </summary>
        /// <returns>书籍集合</returns>
        public List<BookInfo> SelectFireBookNoParameter()
        {
            String sql = "select ID,imageUrl,name,author,text,serialState,fileUrl,fileSize,uploadTime,clickCount,isTrue,isDelete,AuditID,isPass,opinion,createTime," +
                "DepartmentID,DepartmentName,PersonalID,(select name from Personal where ID = PersonalID) as 'PersonalName',UserID,UserName,UserEmail,imageName,fileName from BookInfomation where isDelete = '0' order by clickCount desc";
            return setViewData(db.SelectNoParamterReader(sql));
        }


        





        /// <summary>
        /// 按条件分页查询电子书
        /// </summary>
        /// <param name="info">书籍对象</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>书籍集合</returns>
        public List<BookInfo> SelectBookWithParameter(BookInfo info, String pageIndex)
        {
            int count = 20 * (Convert.ToInt32(pageIndex) - 1);
            String sql = "select top 20 ID,imageUrl,name,author,text,serialState,fileUrl,fileSize,uploadTime,clickCount,isTrue,isDelete,AuditID,isPass,opinion,createTime," +
                "DepartmentID,DepartmentName,PersonalID,(select name from Personal where ID = PersonalID) as 'PersonalName',UserID,UserName,UserEmail,imageName,fileName " +
                "from BookInfomation order by uploadTime desc where ID not in (select top " + count.ToString() + " ID from BookInfomation  order by uploadTime desc) ";
            sql = setSelectSQL(info, sql);
            List<SqlParameter> parameters = setSelectParmeters(info);
            sql += " order by uploadTime desc";
            return setViewData(db.SelectWithParamterReader(sql, parameters.ToArray()));
        }



        /// <summary>
        /// 分页查找电子书(无参)
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <returns>书籍集合</returns>
        public List<BookInfo> SelectBookNoParameter(String pageIndex)
        {
            int count = 20 * (Convert.ToInt32(pageIndex) - 1);
            String sql = "select top 20 ID,imageUrl,name,author,text,serialState,fileUrl,fileSize,uploadTime,clickCount,isTrue,isDelete,AuditID,isPass,opinion,createTime," +
                "DepartmentID,DepartmentName,PersonalID,(select name from Personal where ID = PersonalID) as 'PersonalName',UserID,UserName,UserEmail,imageName,fileName " +
                "from BookInfomation order by uploadTime desc where ID not in (select top " + count.ToString() + " ID from BookInfomation  order by uploadTime desc) ";
            return setViewData(db.SelectNoParamterReader(sql));
        }



        /// <summary>
        /// 按下载次数分页降序排列查找电子书
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="info">书籍对象</param>
        /// <returns>书籍集合</returns>
        public List<BookInfo> SelectFireBookWithParameter(BookInfo info,String pageIndex)
        {
            int count = 20 * (Convert.ToInt32(pageIndex) - 1);
            String sql = "select top 20 ID,imageUrl,name,author,text,serialState,fileUrl,fileSize,uploadTime,clickCount,isTrue,isDelete,AuditID,isPass,opinion,createTime," +
                "DepartmentID,DepartmentName,PersonalID,(select name from Personal where ID = PersonalID) as 'PersonalName',UserID,UserName,UserEmail,imageName,fileName " +
                "from BookInfomation where isDelete = '0' and ID not in (select top " + count.ToString() + " ID from BookInfomation  order by uploadTime desc) ";
            sql = setSelectSQL(info, sql);
            List<SqlParameter> parameters = setSelectParmeters(info);
            sql += " order by uploadTime desc";
            return setViewData(db.SelectWithParamterReader(sql, parameters.ToArray()));
        }


        /// <summary>
        /// 按下载次数分页降序排列查找电子书
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <returns>书籍集合</returns>
        public List<BookInfo> SelectFireBookNoParameter(String pageIndex)
        {
            int count = 20 * (Convert.ToInt32(pageIndex) - 1);
            String sql = "select top 20 ID,imageUrl,name,author,text,serialState,fileUrl,fileSize,uploadTime,clickCount,isTrue,isDelete,AuditID,isPass,opinion,createTime," +
                "DepartmentID,DepartmentName,PersonalID,(select name from Personal where ID = PersonalID) as 'PersonalName',UserID,UserName,UserEmail,imageName,fileName " +
                "from BookInfomation where isDelete = '0' order by clickCount desc " +
                " and ID not in (select top " + count.ToString() + " ID from BookInfomation  order by uploadTime desc) ";
            return setViewData(db.SelectNoParamterReader(sql));
        }


        public String setSelectSQL(BookInfo info,String sql)
        {
            if (info.Name != null) { sql += " and name like @Name "; }
            if (info.Author != null) { sql += " and author = @Author";  }
            if (info.SerialState != null) { sql += " and serialState = @SerialState"; }
            if (info.BookTypeID != null) { sql += " and DepartmentID = @DepartmentID";  }
            if (info.BookTypeName != null) { sql += " and DepartmentName = @DepartmentName";  }
            if (info.PersonalID1 != null) { sql += " and PersonalID = @PersonalID";  }
            if (info.UploadUserID != null) { sql += " and UserID = @UserID";  }
            if (info.UploadUserText != null) { sql += " and UserName = @UserName";  }
            if (info.IsPass != null) { sql += " and isPass = @isPass";  }
            if (info.IsTrue != null) { sql += " and isTrue = @isTrue";  }
            if (info.Id != null) { sql += " and ID = @ID"; }
            return sql;
        }


        public List<SqlParameter> setSelectParmeters(BookInfo info)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (info.Id != null) { parameters.Add(new SqlParameter("@ID", info.Id)); }
            if (info.Name != null) { parameters.Add(new SqlParameter("@Name", "%"+info.Name+"%")); }
            if (info.Author != null) { parameters.Add(new SqlParameter("@Author", info.Author)); }
            if (info.SerialState != null) { parameters.Add(new SqlParameter("@Name", info.SerialState)); }
            if (info.BookTypeID != null) { parameters.Add(new SqlParameter("@DepartmentID", info.BookTypeID)); }
            if (info.BookTypeName != null) { parameters.Add(new SqlParameter("@DepartmentName", info.BookTypeName)); }
            if (info.PersonalID1 != null) { parameters.Add(new SqlParameter("@PersonalID", info.PersonalID1)); }
            if (info.UploadUserID != null) { parameters.Add(new SqlParameter("@UserID", info.UploadUserID)); }
            if (info.UploadUserText != null) { parameters.Add(new SqlParameter("@UserName", info.UploadUserText)); }
            if (info.IsDelete != null) { parameters.Add(new SqlParameter("@isDelete", info.IsDelete)); }
            if (info.IsPass != null) { parameters.Add(new SqlParameter("@isPass", info.IsPass)); }
            if (info.IsTrue != null) { parameters.Add(new SqlParameter("@isTrue", info.IsTrue)); }
            return parameters;
        }



        public SqlParameter[] setInsertParameters(BookInfo info)
        {
            SqlParameter[] parameters =  new SqlParameter[]
            {
                new SqlParameter("@ID",info.Id),
                new SqlParameter("@imageName",info.ImageName),
                new SqlParameter("@imageUrl",info.ImageUrl),
                new SqlParameter("@name",info.Name),
                new SqlParameter("@author",info.Author),
                new SqlParameter("@text",info.Text),
                new SqlParameter("@serialState",info.SerialState),
                new SqlParameter("@bookType",info.BookTypeID),
                new SqlParameter("@fileName",info.FileName),
                new SqlParameter("@fileUrl",info.FileUrl),
                new SqlParameter("@fileSize",info.FileSize),
                new SqlParameter("@uploadUser",info.UploadUserID),
                new SqlParameter("@auditOpinion",info.AuditOpinion)
            };
            return parameters;
        }


        public List<BookInfo> setViewData(SqlDataReader reader)
        {
            List<BookInfo> infos = new List<BookInfo>();
            while (reader.Read())
            {
                BookInfo info = new BookInfo();
                info.Id = reader["ID"].ToString();
                info.ImageUrl = reader["imageUrl"].ToString();
                info.Name = reader["name"].ToString();
                info.Author = reader["author"].ToString();
                info.Text = reader["text"].ToString();
                info.SerialState = reader["serialState"].ToString();
                info.FileUrl = reader["fileUrl"].ToString();
                info.FileSize = reader["fileSize"].ToString();
                info.UploadTime = reader["uploadTime"].ToString();
                info.DownloadCount = reader["clickCount"].ToString();
                info.IsTrue = reader["isTrue"].ToString();
                info.IsDelete = reader["isDelete"].ToString();
                info.AuditOpinion = reader["AuditID"].ToString();
                info.UploadTime = reader["createTime"].ToString();
                info.BookTypeID = reader["DepartmentID"].ToString();
                info.BookTypeName = reader["DepartmentName"].ToString();
                info.UploadUserID = reader["UserID"].ToString();
                info.UploadUserText = reader["UserName"].ToString();
                info.IsPass = reader["isPass"].ToString();
                info.Opinion1 = reader["opinion"].ToString();
                info.ImageName = reader["imageName"].ToString();
                info.FileName = reader["fileName"].ToString();

                if (!reader["isPass"].ToString().Equals("未审核"))
                {
                    info.PersonalID1 = reader["PersonalID"].ToString();
                    info.PersonalName1 = reader["PersonalName"].ToString();
                }
                infos.Add(info);
            }
            db.getSqlConnection().Close();
            return infos;
        }

    }
}
