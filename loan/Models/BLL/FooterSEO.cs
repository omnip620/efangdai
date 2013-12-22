using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Pan.BLL
{
    public class FooterSEO
    {
        Pan.DAL.FooterSEO dal = new DAL.FooterSEO();
        
        /// <summary>
        /// 获取最大id
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">添加数据的model</param>
        /// <returns>返回当前添加的id,Error时返回0</returns>
        public int Add(Pan.Model.FooterSEO model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="model">修改数据的model</param>
        /// <returns>返回受影响的行数,Error时返回0</returns>
        public int Update(Pan.Model.FooterSEO model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id">删除数据的id</param>
        /// <returns>返回受影响的行数,Error时返回0</returns>
        public int Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns>返回DataSet</returns>
        public DataSet GetList()
        {
            return dal.GetList();
        }
    }
}