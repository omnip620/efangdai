//DataSet与泛型集合间的互相转换 
//利用反射机制将DataTable的字段与自定义类型的公开属性互相赋值。 
//注意：从DataSet到IList<T>的转换，自定义类型的公开属性必须与DataTable中的字段名称 
//一致，才能到达想要的结果。建议DataTable的定义从数据库来，自定义类型用O/R Mapping的方式获得。

//代码说明 

/// <summary>
/// 泛型集合与DataSet互相转换
/// </summary>
using System.Data;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
namespace Pan
{
   public class common
   {
       public static string ToJson(DataTable dt)
       {
           StringBuilder jsonBuilder = new StringBuilder();
           jsonBuilder.Append("{\"");
           jsonBuilder.Append(dt.TableName.ToString());
           jsonBuilder.Append("\":[");
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               jsonBuilder.Append("{");
               for (int j = 0; j < dt.Columns.Count; j++)
               {
                   jsonBuilder.Append("\"");
                   jsonBuilder.Append(dt.Columns[j].ColumnName);
                   jsonBuilder.Append("\":\"");
                   jsonBuilder.Append(dt.Rows[i][j].ToString());
                   jsonBuilder.Append("\",");
               }
               jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
               jsonBuilder.Append("},");
           }
           jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
           jsonBuilder.Append("]");
           jsonBuilder.Append("}");
           return jsonBuilder.ToString();
       }
       ///<summary> 
       /// dataTable转换成Json格式 
       ///</summary> 
       ///<param name="dt"></param> 
       ///<returns></returns> 
       public static string DataTable2Json(System.Data.DataTable dt)
       {
           StringBuilder jsonBuilder = new StringBuilder();
           jsonBuilder.Append("{\"Name\":\"" + dt.TableName + "\",\"Rows");
           jsonBuilder.Append("\":[");
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               jsonBuilder.Append("{");
               for (int j = 0; j < dt.Columns.Count; j++)
               {
                   jsonBuilder.Append("\"");
                   jsonBuilder.Append(dt.Columns[j].ColumnName);
                   jsonBuilder.Append("\":\"");
                   jsonBuilder.Append(dt.Rows[i][j].ToString().Replace("\"", "\\\"")); //对于特殊字符，还应该进行特别的处理。 
                   jsonBuilder.Append("\",");
               }
               jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
               jsonBuilder.Append("},");
           }
           jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
           jsonBuilder.Append("]");
           jsonBuilder.Append("}");
           return jsonBuilder.ToString();
       } 

       #region DataSet转换成Json格式
       /// <summary>      
       /// DataSet转换成Json格式      
       /// </summary>      
       /// <param name="ds">DataSet</param>      
       /// <returns></returns>      
       public static string ToJson(DataSet ds)
       {
           StringBuilder json = new StringBuilder();

           foreach (DataTable dt in ds.Tables)
           {
               json.Append("{\"");
               json.Append(dt.TableName);
               json.Append("\":");
               json.Append(ToJson(dt));
               json.Append("}");
           }
           return json.ToString();
       }
       #endregion  
   
   }
}