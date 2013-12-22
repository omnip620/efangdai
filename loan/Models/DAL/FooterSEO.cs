using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pan.DBUtility;
using System.Data.SqlClient;
using System.Data;//Please add references

namespace Pan.DAL
{
    public class FooterSEO
    {

        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "FooterSEO");
        }

        public int Add(Pan.Model.FooterSEO model)
        {
            string sql = "insert into FooterSEO(keys,val) values(@keys,@val);select @@IDENTITY";
            SqlParameter[] parameters = {
                                        new SqlParameter("@keys", SqlDbType.NVarChar,50),
                                        new SqlParameter("@val", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.Keys;
            parameters[1].Value = model.Val;
            object obj = DbHelperSQL.GetSingle(sql, parameters);
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }

        public int Update(Pan.Model.FooterSEO model) 
        {
            string sql = "update FooterSEO set keys=@keys, val=@val where id=@id ";
            SqlParameter[] parameters = { 
                                        new SqlParameter("",SqlDbType.NVarChar,50),
                                        new SqlParameter("",SqlDbType.NVarChar,50),
                                        new SqlParameter("",SqlDbType.Int)
                                        };
            parameters[0].Value = model.Keys;
            parameters[1].Value = model.Val;
            parameters[2].Value = model.Id;
            object obj = DbHelperSQL.GetSingle(sql, parameters);
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }

        public int Delete(int id)
        {
            string sql = "delete footerSEO whre id=@id ";
            SqlParameter[] parameters = { new SqlParameter("@id",SqlDbType.Int)};
            parameters[0].Value = id;
            object obj = DbHelperSQL.GetSingle(sql, parameters);
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }

        //获取所有行
        public DataSet GetList()
        {
            string sql = "select id, keys, val from footerSEO ";
            return DbHelperSQL.Query(sql);
        }
    }
}