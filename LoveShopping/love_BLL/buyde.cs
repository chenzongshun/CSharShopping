using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using love_DAL;//引用数据访问层，这样就可以在这个代码页中

namespace love_BLL
{
    public class buyde
    {
        string username = string.Empty;//用户名

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        string pwd = string.Empty;//密码

        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }
        string nicheng = string.Empty;//昵称

        public string Nicheng
        {
            get { return nicheng; }
            set { nicheng = value; }
        }
        string zhenname = string.Empty;//真实姓名

        public string Zhenname
        {
            get { return zhenname; }
            set { zhenname = value; }
        }
        byte[] photo = null;//头像

        public byte[] Photo
        {
            get { return photo; }
            set { photo = value; }
        }
        string sex = string.Empty;//性别

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        string shouhuodizhi = string.Empty;//收货地址

        public string Shouhuodizhi
        {
            get { return shouhuodizhi; }
            set { shouhuodizhi = value; }
        }
        decimal yue = 0;//余额        

        public decimal Yue
        {
            get { return yue; }
            set { yue = value; }
        }
        string sfzh = string.Empty;//收货地址

        public string Sfzh
        {
            get { return sfzh; }
            set { sfzh = value; }
        }
        long telephone = 0;//电话号码

        public long Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        string mibaowt = string.Empty;//密保问题

        public string Mibaowt
        {
            get { return mibaowt; }
            set { mibaowt = value; }
        }
        string mibaodan = string.Empty;//密保答案

        public string Mibaodan
        {
            get { return mibaodan; }
            set { mibaodan = value; }
        }
        DateTime zhucetime = DateTime.Now;//注册时间等于当前时间 





        /// <summary>
        /// 向数据执行插入命令，当做注册功能
        /// </summary> 
        public void zhucesellde()
        {
            string sql = string.Empty;//定义空的字符串

            //开始分辨注册的是卖家还是买家
            //if (love_DAL.love.isorsellde == true)//因为本身就是bool类型的
            if (love_DAL.love.denglu_IsSelldeOrBuyde == "卖")//如果等于true的话说明他是卖家
            {
                sql = "insert into buyde(username,pwd,photo) values(@username,@pwd,@photo)";        //@数据库中的变量意思
            }
            else
            {
                sql = "insert into buyde(username,pwd,photo) values(@username,@pwd,@photo)";        //@数据库中的变量意思
            }


            //int f = 0;//f就是一个变量，可以被赋值的就是变量

            SqlParameter[] p = {new SqlParameter("@username", SqlDbType.VarChar,20), //因为上面是数据库类型的变量，所以要定义SqlParameter类型的数组
                                new SqlParameter("@pwd", SqlDbType.VarChar,20),         //其实Parameter就是参数的意思
                                new SqlParameter("@photo", SqlDbType.Image)};
            p[0].Value = username;//开始赋值        其实Value就是值的意思
            p[1].Value = pwd;
            p[2].Value = photo;

            sqlHelper.ExecuteCommand(sql, CommandType.Text, p);

        }

        /// <summary>
        /// 通过是否有性别来判断是否填写了详细信息，如果返回的是false的话说明没有填写详细信息
        /// </summary>
        /// <returns></returns>
        public bool isorther()
        {
            string sql = string.Format("select sex from buyde where username = '{0}'", Username);
            DataTable d = sqlHelper.ExecutedataTable(sql, CommandType.Text, null);
            if (d.Rows[0]["sex"].ToString() == string.Empty)
            {//说明没有注册详细信息，因为没有查到任何记录
                return false;
            }
            else
            {
                return true;
            }
        }



        /// <summary>
        /// 主界面点击设置中心用的
        /// </summary>
        public void upxiugaiziliao()
        {
            string sqlupdate = "update buyde set nicheng=@nicheng,telephone=@telephone ,shouhuodizhi=@shouhuodizhi,mibaowt=@mibaowt,mibaodan=@mibaodan,photo=@photo where username = @username";
            SqlParameter[] p = { new SqlParameter("@nicheng",nicheng),
                               new SqlParameter("@telephone",telephone),
                                   new SqlParameter("@shouhuodizhi",shouhuodizhi),
                                   new SqlParameter("@mibaowt",mibaowt),
                               new SqlParameter ("@mibaodan",mibaodan),
                               new SqlParameter("@photo",photo),
                               new SqlParameter ("@username",username)};
            sqlHelper.ExecuteCommand(sqlupdate, CommandType.Text, p);
        }

         

    }
}
