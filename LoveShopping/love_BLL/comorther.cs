using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace love_BLL
{
    public class comorther
    {
        long comid = 0;

        public long Comid
        {
            get { return comid; }
            set { comid = value; }
        }
        string orther = string.Empty;//商品的其它分类，由卖家填写，因为不同的商品有不同的分类，比如手机有电池的大小，而服装类却是尺寸大小
        
        public string Orther
        {
            get { return orther; }
            set { orther = value; }
        }

        public void insertorther()
        { 
            string sql=string.Format("insert comorther values('{0}','{1}')",Comid,Orther);
            love_DAL.sqlHelper.ExecuteCommand(sql, System.Data.CommandType.Text, null);
        }

    }
}
