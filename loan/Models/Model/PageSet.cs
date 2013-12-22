/**  版本信息模板在安装目录下，可自行修改。
* PageSet.cs
*
* 功 能： N/A
* 类 名： PageSet
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/2 20:37:48   N/A    初版
*
* Copyright (c) 2012 Pan Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Pan.Model
{
	/// <summary>
	/// PageSet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PageSet
	{
		public PageSet()
		{}
		#region Model
		private int _id;
		private string _href;
		private string _column;
		private string _title;
		private string _keywords;
		private string _description;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string href
		{
			set{ _href=value;}
			get{return _href;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string column
		{
			set{ _column=value;}
			get{return _column;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string keywords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model

	}
}

