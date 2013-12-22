/**  版本信息模板在安装目录下，可自行修改。
* Credit.cs
*
* 功 能： N/A
* 类 名： Credit
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/29 14:59:44   N/A    初版
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
	/// Credit:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Credit
	{
		public Credit()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _sex;
		private string _mobile_num;
		private int? _i_num;
		private string _collateral;
		private string _limit_date;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
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
		public int? i_num
		{
			set{ _i_num=value;}
			get{return _i_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string collateral
		{
			set{ _collateral=value;}
			get{return _collateral;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string limit_date
		{
			set{ _limit_date=value;}
			get{return _limit_date;}
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

