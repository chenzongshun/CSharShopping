using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using love_DAL;
using System.Data;
using System.Data.SqlClient;


namespace love_BLL
{
    public class commodity
    {
        int comid = 0;//商品的id            //在类里面字段的默认访问修饰符为private

        public int Comid
        {
            get { return comid; }
            set { comid = value; }
        }
        string username = string.Empty;//商品的持有者，也就是主人的账号

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        string name = string.Empty;//商品的名字

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        decimal shoujia = 0;//商品的售价

        public decimal Shoujia
        {
            get { return shoujia; }
            set { shoujia = value; }
        }
        string kuadi = string.Empty;//商品的运送快递

        public string Kuadi
        {
            get { return kuadi; }
            set { kuadi = value; }
        }
        int kucun = 0;//商品的剩余库存

        public int Kucun
        {
            get { return kucun; }
            set { kucun = value; }
        }
        string isbaoyou = string.Empty;//是否包邮

        public string Isbaoyou
        {
            get { return isbaoyou; }
            set { isbaoyou = value; }
        }
        int yuexiaoliang = 0;//商品的月销量

        public int Yuexiaoliang
        {
            get { return yuexiaoliang; }
            set { yuexiaoliang = value; }
        }

        /// <summary>
        /// 如果赋值的话那么就是赋值的，没有赋值的就是业务逻辑层里面的系统日期时间
        /// </summary>
        DateTime adddatetime = DateTime.Now;//这个商品的添加时间

        /// <summary>
        /// 如果赋值的话那么就是赋值的，没有赋值的就是业务逻辑层里面的系统日期时间
        /// </summary>
        public DateTime Adddatetime1
        {
            get { return adddatetime; }
            set { adddatetime = value; }
        }

        public DateTime Adddatetime
        {
            get { return adddatetime; }
            set { adddatetime = value; }
        }
        string scd = string.Empty;//商品的生产地

        public string Scd
        {
            get { return scd; }
            set { scd = value; }
        }
        string isorcolor = string.Empty;//是否有颜色

        public string Isorcolor
        {
            get { return isorcolor; }
            set { isorcolor = value; }
        }

        string isororther = string.Empty;//是否有其他分类

        public string Isororther
        {
            get { return isororther; }
            set { isororther = value; }
        }
        string xiangxi = string.Empty;//商品的详细信息

        public string Xiangxi
        {
            get { return xiangxi; }
            set { xiangxi = value; }
        }
        byte[] picda = null;//商品的大图

        public byte[] Picda
        {
            get { return picda; }
            set { picda = value; }
        }
        byte[] pic1 = null;//商品的详图1

        public byte[] Pic1
        {
            get { return pic1; }
            set { pic1 = value; }
        }
        byte[] pic2 = null;//商品的详图2

        public byte[] Pic2
        {
            get { return pic2; }
            set { pic2 = value; }
        }
        byte[] pic3 = null;//商品的详图3

        public byte[] Pic3
        {
            get { return pic3; }
            set { pic3 = value; }
        }

        private string fahuodizhi = string.Empty;//商品的发货地址==卖家的地址

        public string Fahuodizhi
        {
            get { return fahuodizhi; }      //读取

            set { fahuodizhi = value; }

            //set
            //{
            //    if (fahuodizhi != "男" || fahuodizhi != "女")
            //    {
            //        //提示不能为性别以外的                 
            //    }
            //    else
            //    {
            //        fahuodizhi = value;
            //    }
            //}     //设置、写入  value == 传进来的值
        }


        /// <summary>
        /// 修改商品表的基本内容还有卖家表的发货地址
        /// </summary>
        public void IsYuLanupdate()
        {
            //修改商品表
            string sql1 = string.Format
                ("update commodity set name='{0}',shoujia={1} , kuadi='{2}',kucun='{3}',isbaoyou='{4}',yuexiaoliang={5},adddatetime='{6}',scd='{7}' where comid='{8}'",
                Name, Shoujia, kuadi, kucun, isbaoyou, yuexiaoliang, adddatetime, scd, comid);

            sqlHelper.ExecuteCommand(sql1, System.Data.CommandType.Text, null);
        }

        /// <summary>
        /// 删除指定id对应的商品
        /// </summary>
        public void delete()
        { //在删除商品之前需要把外键里的东西删除掉，然后才能删除主键里面的内容，相当于销毁银行卡之前必须先把里面的钱弄出来
            string sql1 = string.Format("delete comcolor where comid={0}", comid);
            string sql2 = string.Format("delete comorther where comid={0}", comid);
            string sql3 = string.Format("delete commodity where comid={0}", comid);
            string sql4 = string.Format("delete goods where cmid={0}", comid);

            sqlHelper.ExecuteCommand(sql1, System.Data.CommandType.Text, null);
            sqlHelper.ExecuteCommand(sql2, System.Data.CommandType.Text, null);
            sqlHelper.ExecuteCommand(sql4, System.Data.CommandType.Text, null);
            sqlHelper.ExecuteCommand(sql3, System.Data.CommandType.Text, null);
        }


        /// <summary>
        /// 添加商品到商品库
        /// </summary>
        public void addcommodity()
        {
            string addcommodity = "insert commodity(comid,username,name,shoujia,kuadi,kucun,isbaoyou,yuexiaoliang,adddatetime,scd,isorcolor,isororther,xiangxi,picda,pic1,pic2,pic3) values(@comid,@username,@name,@shoujia,@kuadi,@kucun,@isbaoyou,@yuexiaoliang,@adddatetime,@scd,@isorcolor,@isororther,@xiangxi,@picda,@pic1,@pic2,@pic3)";
            SqlParameter[] p ={
                             new SqlParameter("@comid",comid),                             
                             new SqlParameter("@username",username),
                             new SqlParameter("@name",name),
                             new SqlParameter("@shoujia",shoujia),
                             new SqlParameter("@kuadi",kuadi),
                             new SqlParameter("@kucun",kucun),
                             new SqlParameter("@isbaoyou",isbaoyou),
                             new SqlParameter("@yuexiaoliang",yuexiaoliang),
                             new SqlParameter("@adddatetime",adddatetime),
                             new SqlParameter("@scd",scd),
                             new SqlParameter("@isorcolor",isorcolor),
                             new SqlParameter("@isororther",isororther),
                             new SqlParameter("@xiangxi",xiangxi),
                             new SqlParameter("@picda",picda),
                             new SqlParameter("@pic1",pic1),
                             new SqlParameter("@pic2",pic2),
                             new SqlParameter("@pic3",pic3)};
            sqlHelper.ExecuteCommand(addcommodity, System.Data.CommandType.Text, p);
        }


        /// <summary>
        /// 返回商品表的所有信息
        /// </summary>
        /// <returns></returns>
        public DataTable selectall()
        {
            //string sql = "select * from commodity";
            string sql = "select c.comid 商品id,c.name 商品名,c.shoujia 售价,c.kuadi 快递,c.kucun 库存,c.isbaoyou 是否包邮,c.yuexiaoliang 月销量,c.adddatetime 添加时间,c.scd 生产地,c.xiangxi 详细信息 from commodity c where username = '" + username + "'";

            return sqlHelper.ExecutedataTable(sql, System.Data.CommandType.Text, null);
        }

        /// <summary>
        /// 专用于商品详细表中的修改
        /// </summary>
        public void IsXiangXiupdate()
        {
            string sql = "update commodity set kucun=@kucun,name=@name,scd=@scd,shoujia=@shoujia,kuadi=@kuadi, adddatetime=@adddatetime,isbaoyou=@isbaoyou,pic1=@pic1,pic2=@pic2,pic3=@pic3,picda=@picda,xiangxi=@xiangxi,isorcolor=@isorcolor,isororther=@isororther where comid = @comid";
            SqlParameter[] p = {   new SqlParameter("@kucun",kucun),
                                   new SqlParameter("@name",name),
                                   new SqlParameter("@scd",scd),
                                   new SqlParameter("@shoujia",shoujia),
                                   new SqlParameter("@kuadi",kuadi),
                                   new SqlParameter("@adddatetime",adddatetime),
                                   new SqlParameter("@isbaoyou",isbaoyou),
                                   new SqlParameter("@pic1",pic1),
                                   new SqlParameter("@pic2",pic2),
                                   new SqlParameter("@pic3",pic3),
                                   new SqlParameter("@picda",picda),
                                   new SqlParameter("@xiangxi",xiangxi),
                                   new SqlParameter("@isorcolor",isorcolor),
                                   new SqlParameter("@isororther",isororther),
                                   new SqlParameter("@comid",comid)};
            sqlHelper.ExecuteCommand(sql, CommandType.Text, p);
        } 

        /// <summary>
        /// 返回数据库中所有的商品
        /// </summary>
        /// <returns></returns>
        public DataTable allcommodity()
        {
            string sql = "select * from commodity";
            return sqlHelper.ExecutedataTable(sql, CommandType.Text, null);
        }

        /// <summary>
        /// 专门为给买家呈现的
        /// </summary>
        /// <returns></returns>
        public DataTable selldecommdity()
        { 
            string sql = "select name 商品名,shoujia 售价,isbaoyou 包邮,kuadi 快递,kucun 库存,yuexiaoliang 月销量,scd 生产地 from commodity";
            return sqlHelper.ExecutedataTable(sql, CommandType.Text, null);
        }


    }
}

