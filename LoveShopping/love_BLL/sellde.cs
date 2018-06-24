using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using love_DAL;//引用数据访问层，这样就可以在这个代码页中


namespace love_BLL          //这个是业务逻辑层
{
    public class sellde            //这个就是叫本类
    {
        //private：私有的---只能够在本类中访问到   public：公共的---大家都可以访问到

        private string username = string.Empty;//用户名

        public string Username
        {
            get     //读取
            {
                return username;
            }
            set     //写入  value等于传入的值       假设这个是男女值
            {
                //if (value != "男" && value != "女")
                //{
                //    return;       //如果不男不女那么就不给私有变量赋值
                //}
                username = value;
            }
        }

        string pwd = string.Empty;//密码

        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }
        string nicheng = string.Empty;//用户的昵称

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
        byte[] photo = null;//用byte字节类型来存储头像

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
        string dizhi = string.Empty;//发货地址

        public string Fahuodizhi
        {
            get { return dizhi; }
            set { dizhi = value; }
        }
        decimal yue = 0;//decimal专门存钱的类型，精度高，余额

        public decimal Yue
        {
            get { return yue; }
            set { yue = value; }
        }
        string sfzh = string.Empty;//长整形，就是int的加长版

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

        DateTime zhucetime = DateTime.Now;//注册时间用当前计算机上面的时间   now：当前


        /// <summary>
        /// 向数据执行插入命令，当做注册功能
        /// </summary> 
        public void zhucesellde()
        {
            string sql = string.Empty;//定义空的字符串

            //开始分辨注册的是卖家还是买家  
            if (love_DAL.love.denglu_IsSelldeOrBuyde == "卖")//说明他是卖家
            {
                sql = "insert into sellde(username,pwd,photo) values(@username,@pwd,@photo)";        //@数据库中的变量意思
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
        /// 注册了账号之后仅仅只在数据库中插入了用户名密码还有头像，这个方法用来插入其它数据
        /// </summary>
        public void zhuceselldeOrther()
        {
            /*没有插入的字段	nicheng	zhenname	sex	fahuodizhi	yue	sfzh	telephone	mibaowt	mibaodan	zhucetime*/
            string sql = string.Empty;
            if (love_DAL.love.denglu_IsSelldeOrBuyde == "卖")
            {
                sql = string.Format(@" update sellde set
                            nicheng = '{0}',
                            zhenname = '{1}',
                            sex='{2}',
                            fahuodizhi='{3}',
                            yue={4},
                            telephone={5},
                            mibaowt='{6}',
                            mibaodan='{7}',
                            zhucetime=GETDATE(),			--使用数据库中的方法，计算机本地的时间（并非网络上的北京时间）
                            sfzh='{8}'
                            where username = '{9}'",
                    nicheng, zhenname, sex, dizhi, 0, telephone, mibaowt, mibaodan, Sfzh, username);
            }
            else
            {
                sql = string.Format(@" update buyde set
                            nicheng = '{0}',
                            zhenname = '{1}',
                            sex='{2}',
                            shouhuodizhi='{3}',
                            yue={4},
                            telephone={5},
                            mibaowt='{6}',
                            mibaodan='{7}',
                            zhucetime=GETDATE(),			--使用数据库中的方法，计算机本地的时间（并非网络上的北京时间）,
                            sfzh='{8}'
                            where username = '{9}'",
                    nicheng, zhenname, sex, dizhi, 0, telephone, mibaowt, mibaodan, Sfzh, username);
            }
            sqlHelper.ExecuteCommand(sql, CommandType.Text, null);
        }



        /// <summary>
        /// 通过是否有性别来判断是否填写了详细信息，如果返回的是false的话说明没有填写详细信息
        /// </summary>
        /// <returns></returns>
        public bool isorther()
        {
            string sql = "";
            if (love.denglu_IsSelldeOrBuyde == "卖")
            {
                sql = string.Format("select sex from sellde where username = '{0}'", Username);
            }
            else
            {
                sql = string.Format("select sex from buyde where username = '{0}'", Username);
            }

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
            string sqlupdate = "update sellde set nicheng=@nicheng,telephone=@telephone ,fahuodizhi=@fahuodizhi,mibaowt=@mibaowt,mibaodan=@mibaodan,photo=@photo where username = @username";
            SqlParameter[] p = { new SqlParameter("@nicheng",nicheng),
                               new SqlParameter("@telephone",telephone),
                                   new SqlParameter("@fahuodizhi",Fahuodizhi),
                                   new SqlParameter("@mibaowt",mibaowt),
                               new SqlParameter ("@mibaodan",mibaodan),
                               new SqlParameter("@photo",photo),
                               new SqlParameter ("@username",username)};
            sqlHelper.ExecuteCommand(sqlupdate, CommandType.Text, p);
        }


    }
}
