using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;

namespace love_DAL
{
    /// <summary>
    /// 爱尚的帮助类，里面存放了一些公共字段，通常他们都可以
    /// </summary>
    public static class love//加public，让大家都可以访问到
    {

        /// <summary>
        /// 用来判断是否填写了详细信息，没有填写默认为false
        /// </summary>
        public static bool user_orther = false;

        /// <summary>
        /// 登陆成功的时候就会给这个变量赋值，它记录下了这个用户名
        /// </summary>
        public static string denglu_username = string.Empty;

        /// <summary>
        /// 登陆成功的时候就会给这个变量赋值，它记录下了这个用户名的密码
        /// </summary>
        public static string denglu_password = string.Empty;

        /// <summary>
        /// 注册成功的时候就会给这个变量赋值，它记录下了这个用户名
        /// </summary>
        public static string zhuce_username = string.Empty;

        /// <summary>
        /// 在登陆成功的时候记录下了这个用户是买家还是卖家
        /// </summary>
        public static string denglu_IsSelldeOrBuyde = string.Empty;

        /// <summary>
        /// 记录下是否在集成窗口按下退出按钮，如果是的话返回true，默认为false
        /// </summary>
        public static bool WindowsIsExit = false;

        /// <summary>
        /// 记录下是否在登陆窗体按下登陆，如果是的话返回true，默认为false
        /// </summary>
        public static bool isloginexit = false;

        /// <summary>
        /// 记录下注册页是否注册成功，如果是的话返回true，默认为false
        /// </summary>
        public static bool iszhucecg = false;

        /// <summary>
        /// 记录下修改密码是否成功，注意不是找回密码的，如果是的话返回true，默认为false
        /// </summary>
        public static bool isorupdatepwd = false;

        /// <summary>
        /// 在购买页面点击购买就记录下商品的id
        /// </summary>
        public static string goumaiid = string.Empty;

        /// <summary>
        /// 在购买页面点击购买就记录下选择的商品颜色，用完记得清空
        /// </summary>
        public static string goumaicolor = string.Empty;

        /// <summary>
        /// 在购买页面点击购买就记录下选择的商品其它选项，用完记得清空
        /// </summary>
        public static string goumaiorther = string.Empty;

        public static string buyde_id = "";

        /// <summary>
        /// 清空  登陆时的用户名  是买家还是卖家  是否填写详细信息   注册成功的用户名   选择好的商品颜色、其它  这几个变量
        /// 作用:如果用户点击了返回登陆就goto到第一个run，如果这个时候变量没有回去的话那么将会导致窗体乱开或者打不开等状况
        /// </summary>
        public static void clear()
        {
            love.denglu_IsSelldeOrBuyde = string.Empty;
            love.denglu_username = string.Empty;
            love.user_orther = false;
            zhuce_username = string.Empty;
            goumaicolor = string.Empty;
            goumaiorther = string.Empty;
        }

        /// <summary>
        /// 用于美化，透明
        /// </summary>
        /// <param name="f"></param>
        public static void meihua(Form f)
        {
            foreach (Control item in f.Controls)
            {
                if (item is Label || item is CheckBox || item is PictureBox || item is Button || item is Panel|| item is GroupBox )
                {
                    item.BackColor = Color.Transparent;
                }
                if (item is Panel|| item is GroupBox)
                {
                    //foreach (Control i in item.Controls)
                    //{
                    //    i.BackColor = Color.Transparent;
                    //}
                }
            }
        }


        #region 左右悬浮动画
        ////开始
        ///// <summary>
        ///// 在load方法写入此方法即可
        ///// </summary>
        //private void tiemzou()
        //{
        //    lab_tip1.Left = -1;//记得要把控件的左边拉到窗体的左边，否则下面的方法不生效
        //    t1.Enabled = true;
        //    t2.Enabled = false;
        //    t3.Enabled = false;
        //    t1.Interval = 1;
        //    t2.Interval = 1;
        //    t3.Interval = 1;
        //    t1.Tick += new EventHandler(t1_Tick);
        //    t2.Tick += new EventHandler(t2_Tick);
        //    t3.Tick += new EventHandler(t3_Tick);
        //}

        //Timer t1 = new Timer(); Timer t2 = new Timer(); Timer t3 = new Timer();

        //void t3_Tick(object sender, EventArgs e) { right(lab_tip1); }
        //void t2_Tick(object sender, EventArgs e) { left(lab_tip1); }
        //public static void left(Label l) { l.Left += 1; }
        //public static void right(Label l) { l.Left -= 1; }

        //void t1_Tick(object sender, EventArgs e)
        //{
        //    if (lab_tip1.Left <= Left)
        //    {
        //        t2.Enabled = true;
        //        t3.Enabled = false;
        //    }
        //    if (lab_tip1.Right >= Width)      //=w的值已经被定死了，所以一改变窗体的大小就会失效
        //    {
        //        t2.Enabled = false;
        //        t3.Enabled = true;
        //    }
        //}
        ////结束
        #endregion


        /// <summary>
        /// 代码添加数据库
        /// </summary>
        /// <param name="dbname">数据库名</param>
        /// <param name="mdf">数据库mdf磁盘文件地址</param>
        /// <param name="ldf">数据库ldf磁盘文件地址</param>
        public static void fujiadatabase(string n1, string n2)
        {
            SqlConnection Server = new SqlConnection("Data Source=.;Initial Catalog=master;Integrated Security=True");
            Server.Open();

            string sql1 = @"use master";    //不过不能在字符串里加入go语句，会提示go附近有语法错误
            SqlCommand cmd1 = new SqlCommand(sql1, Server);
            cmd1.ExecuteNonQuery();

            string sql = string.Format(
                            @" 
declare @flg int 
declare @tip varchar(50)  
declare @dbname varchar(20), @dbmdf varchar(100), @dbldf varchar(100)
set @dbname = N'LoveShopping'		--数据库文件名
if db_id(@dbname) is null
    begin
        set @dbmdf = N'{0}'		--文件地址1
        set @dbldf = N'{1}'		--文件地址2
        execute @flg = sp_attach_db  @dbname,
        @filename1 = @dbmdf,
        @filename2 = @dbldf
        if @flg = 0
        set @tip = '附加数据库'+'【'+ @dbname + '】'+'成功' 
        else
        set @tip = '附加数据库'+'【'+ @dbname + '】'+'失败'
        print @tip
    end", n1, n2);
            SqlCommand cmd = new SqlCommand(sql, Server);
            cmd.ExecuteNonQuery();
            Server.Close();
        }


    }
}
