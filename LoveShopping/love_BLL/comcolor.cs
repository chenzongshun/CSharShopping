using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace love_BLL
{
    public class comcolor
    {
        long comid = 0;//商品的id

        public long Comid
        {
            get { return comid; }
            set { comid = value; }
        }
        string color = string.Empty;//商品的颜色

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        /// <summary>
        /// 插入颜色
        /// </summary>
        public void insertcolor()
        {
            string sql = string.Format("insert comcolor values('{0}','{1}')", Comid, Color);
            love_DAL.sqlHelper.ExecuteCommand(sql, System.Data.CommandType.Text,null);
        }
    }
}
