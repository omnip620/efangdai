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
namespace Pan.Model
{
	/// <summary>
	/// Affiliate:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Affiliate
	{
		public Affiliate()
		{}
		#region Model
		private int _id;
		private string _enterprise;
		private string _enterprise_type;
		private string _person;
		private string _person_post;
		private string _mobile_num;
		private string _time;
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
		public string enterprise
		{
			set{ _enterprise=value;}
			get{return _enterprise;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string enterprise_type
		{
			set{ _enterprise_type=value;}
			get{return _enterprise_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string person
		{
			set{ _person=value;}
			get{return _person;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string person_post
		{
			set{ _person_post=value;}
			get{return _person_post;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mobile_num
		{
			set{ _mobile_num=value;}
			get{return _mobile_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string time
		{
			set{ _time=value;}
			get{return _time;}
		}
		#endregion Model

	}
}

