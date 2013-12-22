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
using System.ComponentModel.DataAnnotations;
namespace Pan.Model
{
    /// <summary>
    /// News:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]

    public partial class News
    {
        public News()
        { }
        #region Model
        private int _id;

        private string _title;
        private string _summary;
        private string _istop;
        private string _isreco;
        private string _type;
        private string _content;
        private string _author;
        private string _source;
        private string _views;
        private string _keywords;
        private string _description;
        private string _time;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Required]
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Required]
        public string summary
        {
            set { _summary = value; }
            get { return _summary; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string isTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string isReco
        {
            set { _isreco = value; }
            get { return _isreco; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string author
        {
            set { _author = value; }
            get { return _author; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string views
        {
            set { _views = value; }
            get { return _views; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string keywords
        {
            set { _keywords = value; }
            get { return _keywords; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string time
        {
            set { _time = value; }
            get { return _time; }
        }
        #endregion Model

    }

}


