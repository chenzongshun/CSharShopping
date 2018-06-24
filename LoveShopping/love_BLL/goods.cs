using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using love_DAL;
using System.Data;
using System.Data.SqlClient;

namespace love_BLL
{
    public class goods
    {
        long pjdh = 0;//评价单号

        public long Pjdh
        {
            get { return pjdh; }
            set { pjdh = value; }
        }
        long cmid = 0;//商品单号

        public long Cmid
        {
            get { return cmid; }
            set { cmid = value; }
        }
        string selledname = string.Empty;//卖家账号

        public string Selledname
        {
            get { return selledname; }
            set { selledname = value; }
        }
        string buydename = string.Empty;//买家账号

        public string Buydename
        {
            get { return buydename; }
            set { buydename = value; }
        }
        string neirong = string.Empty;//评价的内容

        public string Neirong
        {
            get { return neirong; }
            set { neirong = value; }
        }
        int xingji = 0;//评价的星级

        public int Xingji
        {
            get { return xingji; }
            set { xingji = value; }
        }
        DateTime fktime;//付款的时间

        public DateTime Fktime
        {
            get { return fktime; }
            set { fktime = value; }
        }
        DateTime shtime;//收货的时间

        public DateTime Shtime
        {
            get { return shtime; }
            set { shtime = value; }
        }
        DateTime pjtime = DateTime.Now;//这个单号的评价时间

        public DateTime Pjtime
        {
            get { return pjtime; }
            set { pjtime = value; }
        }

        decimal fkje = 0;//这个单号的评价时间

        public decimal Fkje
        {
            get { return fkje; }
            set { fkje = value; }
        }

        string comname = string.Empty;//商品名

        public string Comname
        {
            get { return comname; }
            set { comname = value; }
        }

        byte[] compic;//商品的图片

        public byte[] Compic
        {
            get { return compic; }
            set { compic = value; }
        }

        string selldeischakan = string.Empty;//卖家是否已经查看过

        public string Selldeischakan
        {
            get { return selldeischakan; }
            set { selldeischakan = value; }
        }



        /// <summary>
        /// 这是插入到订单表的方法
        /// </summary>
        public void insertgoods()
        {
            string sql = "insert into goods(cmid,comname,selledname,buydename,fkje,fktime,compic,selldeischakan) values(@cmid,@comname,@selledname,@buydename,@fkje,getdate(),@compic,@selldeischakan)";
            SqlParameter[] p = {   new SqlParameter("@cmid",Cmid), 
                                   new SqlParameter("@comname",comname), 
                                   new SqlParameter("@selledname",selledname), 
                                   new SqlParameter("@buydename",buydename), 
                                   new SqlParameter("@fkje",fkje), 
                                   new SqlParameter("@compic",compic), 
                                   new SqlParameter("@selldeischakan","否")};
            sqlHelper.ExecuteCommand(sql, System.Data.CommandType.Text, p);
        }

        /// <summary>
        /// 提供单号，查看是否评价完成，没有评价返回true，评价了返回false
        /// </summary>
        /// <returns></returns>
        public bool isorneirong()
        {
            string sql = string.Format("select neirong from goods where pjdh ='{0}'", pjdh);
            DataTable d = sqlHelper.ExecutedataTable(sql, CommandType.Text, null);
            if (d.Rows[0][0].ToString().Trim() == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 提供评价单号，内容，星级，时间自动采用本地，然后插入到数据库
        /// </summary>
        public void pjnrsjxj()
        {
            string sql = string.Format("update goods set neirong = '{0}',xingji = {1},pjtime = GETDATE() where pjdh={2}", neirong, xingji, pjdh);
            sqlHelper.ExecuteCommand(sql, CommandType.Text, null);
        }

    }
}
