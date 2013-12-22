/**  版本信息模板在安装目录下，可自行修改。
* News.cs
*
* 功 能： N/A
* 类 名： News
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/29 14:59:46   N/A    初版
*
* Copyright (c) 2012 Pan Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pan.DBUtility;//Please add references
namespace Pan.DAL
{
	/// <summary>
	/// 数据访问类:News
	/// </summary>
	public partial class News
	{
		public News()
		{ }
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from News");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pan.Model.News model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into News(");
			strSql.Append("title,summary,isTop,isReco,type,content,author,source,views,keywords,description,time)");
			strSql.Append(" values (");
			strSql.Append("@title,@summary,@isTop,@isReco,@type,@content,@author,@source,@views,@keywords,@description,@time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,80),
					new SqlParameter("@summary", SqlDbType.VarChar,225),
					new SqlParameter("@isTop", SqlDbType.Char,2),
					new SqlParameter("@isReco", SqlDbType.Char,2),
					new SqlParameter("@type", SqlDbType.VarChar,20),
					new SqlParameter("@content", SqlDbType.VarChar,-1),
					new SqlParameter("@author", SqlDbType.VarChar,20),
					new SqlParameter("@source", SqlDbType.VarChar,40),
					new SqlParameter("@views", SqlDbType.Char,10),
					new SqlParameter("@keywords", SqlDbType.VarChar,225),
					new SqlParameter("@description", SqlDbType.VarChar,225),
					new SqlParameter("@time", SqlDbType.Char,20)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.summary;
			parameters[2].Value = model.isTop;
			parameters[3].Value = model.isReco;
			parameters[4].Value = model.type;
			parameters[5].Value = model.content;
			parameters[6].Value = model.author;
			parameters[7].Value = model.source;
			parameters[8].Value = model.views;
			parameters[9].Value = model.keywords;
			parameters[10].Value = model.description;
			parameters[11].Value = model.time;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Pan.Model.News model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update News set ");
			strSql.Append("title=@title,");
			strSql.Append("summary=@summary,");
			strSql.Append("isTop=@isTop,");
			strSql.Append("isReco=@isReco,");
			strSql.Append("type=@type,");
			strSql.Append("content=@content,");
			strSql.Append("author=@author,");
			strSql.Append("source=@source,");
			strSql.Append("views=@views,");
			strSql.Append("keywords=@keywords,");
			strSql.Append("description=@description,");
			strSql.Append("time=@time");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,80),
					new SqlParameter("@summary", SqlDbType.VarChar,225),
					new SqlParameter("@isTop", SqlDbType.Char,2),
					new SqlParameter("@isReco", SqlDbType.Char,2),
					new SqlParameter("@type", SqlDbType.VarChar,20),
					new SqlParameter("@content", SqlDbType.VarChar,-1),
					new SqlParameter("@author", SqlDbType.VarChar,20),
					new SqlParameter("@source", SqlDbType.VarChar,40),
					new SqlParameter("@views", SqlDbType.Char,10),
					new SqlParameter("@keywords", SqlDbType.VarChar,225),
					new SqlParameter("@description", SqlDbType.VarChar,225),
					new SqlParameter("@time", SqlDbType.Char,20),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.summary;
			parameters[2].Value = model.isTop;
			parameters[3].Value = model.isReco;
			parameters[4].Value = model.type;
			parameters[5].Value = model.content;
			parameters[6].Value = model.author;
			parameters[7].Value = model.source;
			parameters[8].Value = model.views;
			parameters[9].Value = model.keywords;
			parameters[10].Value = model.description;
			parameters[11].Value = model.time;
			parameters[12].Value = model.id;

			int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from News ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from News ");
			strSql.Append(" where id in (" + idlist + ")  ");
			int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pan.Model.News GetModel(int id)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 id,title,summary,isTop,isReco,type,content,author,source,views,keywords,description,time from News ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Pan.Model.News model = new Pan.Model.News();
			DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pan.Model.News DataRowToModel(DataRow row)
		{
			Pan.Model.News model = new Pan.Model.News();
			if (row != null)
			{

				if (row["id"] != null && row["id"].ToString() != "")
				{
					model.id = int.Parse(row["id"].ToString());
				}
				if (row["title"] != null)
				{
					model.title = row["title"].ToString();
				}
				try
				{
					if (row["summary"] != null)
					{
						model.summary = row["summary"].ToString();
					}
				}
				catch { }
					if (row["isTop"] != null)
					{
						model.isTop = row["isTop"].ToString();
					}
					if (row["isReco"] != null)
					{
						model.isReco = row["isReco"].ToString();
					}
					if (row["type"] != null)
					{
						model.type = row["type"].ToString();
					}
				try
				{
					if (row["content"] != null)
					{
						model.content = row["content"].ToString();
					}
				
					if (row["author"] != null)
					{
						model.author = row["author"].ToString();
					}
					if (row["source"] != null)
					{
						model.source = row["source"].ToString();
					}
					if (row["views"] != null)
					{
						model.views = row["views"].ToString();
					}
					if (row["keywords"] != null)
					{
						model.keywords = row["keywords"].ToString();
					}
					if (row["description"] != null)
					{
						model.description = row["description"].ToString();
					}
				}
				catch { }
					if (row["time"] != null)
					{
						model.time = row["time"].ToString();
					}
				
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select id,title,summary,isTop,isReco,type,content,author,source,views,keywords,description,time ");
			strSql.Append(" FROM News ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
            strSql.Append(" order by id desc ");
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ");
			if (Top > 0)
			{
				strSql.Append(" top " + Top.ToString());
			}
			strSql.Append(" id,title,summary,isTop,isReco,type,content,author,source,views,keywords,description,time ");
			strSql.Append(" FROM News ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) FROM News ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby);
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from News T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "News";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
		public DataSet GetModeListNoContent(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select id,title,isTop,isReco,type,time ");
			strSql.Append(" FROM News ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by time desc");
			return DbHelperSQL.Query(strSql.ToString());
		}

		public DataSet GetListByPageCustom(string sql, string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT ");
			strSql.Append(sql);
			strSql.Append(" FROM (  SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby);
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from News T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		public DataSet GetListByCustom(string sql)
		{
			return DbHelperSQL.Query(sql);


		}

		#endregion  ExtensionMethod
	}
}

