/**  版本信息模板在安装目录下，可自行修改。
* Affiliate.cs
*
* 功 能： N/A
* 类 名： Affiliate
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/29 14:59:43   N/A    初版
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
	/// 数据访问类:Affiliate
	/// </summary>
	public partial class Affiliate
	{
		public Affiliate()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "Affiliate"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Affiliate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pan.Model.Affiliate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Affiliate(");
			strSql.Append("enterprise,enterprise_type,person,person_post,mobile_num,time)");
			strSql.Append(" values (");
			strSql.Append("@enterprise,@enterprise_type,@person,@person_post,@mobile_num,@time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@enterprise", SqlDbType.VarChar,50),
					new SqlParameter("@enterprise_type", SqlDbType.VarChar,20),
					new SqlParameter("@person", SqlDbType.VarChar,16),
					new SqlParameter("@person_post", SqlDbType.VarChar,20),
					new SqlParameter("@mobile_num", SqlDbType.Char,11),
					new SqlParameter("@time", SqlDbType.Char,20)};
			parameters[0].Value = model.enterprise;
			parameters[1].Value = model.enterprise_type;
			parameters[2].Value = model.person;
			parameters[3].Value = model.person_post;
			parameters[4].Value = model.mobile_num;
			parameters[5].Value = model.time;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Pan.Model.Affiliate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Affiliate set ");
			strSql.Append("enterprise=@enterprise,");
			strSql.Append("enterprise_type=@enterprise_type,");
			strSql.Append("person=@person,");
			strSql.Append("person_post=@person_post,");
			strSql.Append("mobile_num=@mobile_num,");
			strSql.Append("time=@time");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@enterprise", SqlDbType.VarChar,50),
					new SqlParameter("@enterprise_type", SqlDbType.VarChar,20),
					new SqlParameter("@person", SqlDbType.VarChar,16),
					new SqlParameter("@person_post", SqlDbType.VarChar,20),
					new SqlParameter("@mobile_num", SqlDbType.Char,11),
					new SqlParameter("@time", SqlDbType.Char,20),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.enterprise;
			parameters[1].Value = model.enterprise_type;
			parameters[2].Value = model.person;
			parameters[3].Value = model.person_post;
			parameters[4].Value = model.mobile_num;
			parameters[5].Value = model.time;
			parameters[6].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Affiliate ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Affiliate ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Pan.Model.Affiliate GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,enterprise,enterprise_type,person,person_post,mobile_num,time from Affiliate ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Pan.Model.Affiliate model=new Pan.Model.Affiliate();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Pan.Model.Affiliate DataRowToModel(DataRow row)
		{
			Pan.Model.Affiliate model=new Pan.Model.Affiliate();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["enterprise"]!=null)
				{
					model.enterprise=row["enterprise"].ToString();
				}
				if(row["enterprise_type"]!=null)
				{
					model.enterprise_type=row["enterprise_type"].ToString();
				}
				if(row["person"]!=null)
				{
					model.person=row["person"].ToString();
				}
				if(row["person_post"]!=null)
				{
					model.person_post=row["person_post"].ToString();
				}
				if(row["mobile_num"]!=null)
				{
					model.mobile_num=row["mobile_num"].ToString();
				}
				if(row["time"]!=null)
				{
					model.time=row["time"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,enterprise,enterprise_type,person,person_post,mobile_num,time ");
			strSql.Append(" FROM Affiliate ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by id desc ");
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,enterprise,enterprise_type,person,person_post,mobile_num,time ");
			strSql.Append(" FROM Affiliate ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Affiliate ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from Affiliate T ");
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
			parameters[0].Value = "Affiliate";
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

		#endregion  ExtensionMethod
	}
}

