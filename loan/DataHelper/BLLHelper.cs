using System;
using System.Collections.Generic;
using Pan.DBUtility;
using System.Data;
using System.Text;

namespace loan.DataHelper
{
    public class BLLHelper
    {
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name,sex,mobile_num,i_num,collateral,limit_date,time ");
            strSql.Append(" FROM Credit ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by id desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataTable GetDataTable(string strSelect, string strFrom, string strWhere, string orderBy)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(strSelect);
            strSql.Append(" from ");
            strSql.Append(strFrom);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);

            }
            strSql.Append(" order by ");
            strSql.Append(orderBy);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }


    }
}