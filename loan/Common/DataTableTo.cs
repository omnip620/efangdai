using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace loan.Common
{
    public class DataTableTo
    {
        public IList<string> ConvertToModel(DataTable dt)
        {
            // 定义集合
            IList<string> ts = new List<string>();

            // 获得此模型的类型
            Type type = typeof(string);

            string tempName = "";

            foreach (DataRow dr in dt.Rows)
            {
                String t = "";

                // 获得此模型的公共属性
                PropertyInfo[] propertys = t.GetType().GetProperties();

                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;

                    // 检查DataTable是否包含此列
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter
                        if (!pi.CanWrite) continue;

                        object value = dr[tempName];
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }

                ts.Add(t);
            }

            return ts;

        }

        public object DataTableToJson(System.Data.DataTable dt)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("[");

            //string js = "1";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("[");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        //js = dt.Rows[i][j].ToString().Trim();
                        Json.Append("\"");
                        Json.Append(dt.Rows[i][j].ToString().Trim());
                        Json.Append("\"");
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("]");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }

            Json.Append("]");
            return Json;


        }


        public List<object> DataTableToList(System.Data.DataTable dt)
        {
           // ArrayList list = new ArrayList();
            List<object> list = new List<object>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i].ItemArray);
            }

            return list;
        }
    }
}