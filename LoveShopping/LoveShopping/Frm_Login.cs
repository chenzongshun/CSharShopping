using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;//引用
using System.Configuration;
using System.IO;//因为这里要涉及到文件的操作
using love_BLL;
using love_DAL;


namespace LoveShopping//                        这个是登陆的界面
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        #region 左右悬浮动画
        //开始
        /// <summary>
        /// 在load方法写入此方法即可
        /// </summary>
        private void tiemzou()
        {
            lab_tip.Left = -1;//记得要把控件的左边拉到窗体的左边，否则下面的方法不生效
            t11111.Enabled = true;
            t22222.Enabled = false;
            t33333.Enabled = false;
            t11111.Interval = 1;
            t22222.Interval = 1;
            t33333.Interval = 1;
            t11111.Tick += new EventHandler(t11111_Tick);
            t22222.Tick += new EventHandler(t22222_Tick);
            t33333.Tick += new EventHandler(t33333_Tick);
        }


        Timer t11111 = new Timer(); Timer t22222 = new Timer(); Timer t33333 = new Timer();

        void t33333_Tick(object sender, EventArgs e) { right(lab_tip); }
        void t22222_Tick(object sender, EventArgs e) { left(lab_tip); }
        public static void left(Label l) { l.Left += 1; }
        public static void right(Label l) { l.Left -= 1; }

        void t11111_Tick(object sender, EventArgs e)
        {
            if (lab_tip.Left < 0)
            {
                t22222.Enabled = true;
                t33333.Enabled = false;
            }
            if (lab_tip.Right >= Width - 15)      //=w的值已经被定死了，所以一改变窗体的大小就会失效
            {
                t22222.Enabled = false;
                t33333.Enabled = true;
            }
        }
        //结束
        #endregion

        private void Frm_login_Load(object sender, EventArgs e)//窗体诞生之前就会执行的方法     //Load:装入
        {
            if (File.Exists(Application.StartupPath + "\\zhmmdll"))
            {
                //创建文件流
                FileStream fs = new FileStream(Application.StartupPath + "\\zhmmdll", FileMode.Open);
                StreamReader sr = new StreamReader(fs);//打算阅读它
                string dz = sr.ReadToEnd();//收集到文件流中的所有数据 
                txt_username.Text = dz.Substring(dz.IndexOf("zh") + 2, dz.LastIndexOf("zh")-2);
                txt_password.Text = dz.Substring(dz.IndexOf("mm") + 2);
                sr.Close(); fs.Close();//记得先关闭阅读流，然后在关闭文件流，两个都要关闭，不要浪费系统的内存
            }

            //lab_tip.BackColor = Color.FromArgb(255, 253, 238);
            //lab_dl.BackColor = lab_tip.BackColor;
            //lab_zc.BackColor = lab_tip.BackColor;
            //lkb_wangjipwd.BackColor = lab_tip.BackColor;
            //lkb_xinyonhu.BackColor = lab_tip.BackColor;
            //Love_Shopping.BackColor = lab_tip.BackColor;

            btn_clear.BackColor = Color.FromArgb(255, 253, 238);
            btn_denlu.BackColor = btn_clear.BackColor;
            btn_zhuce.BackColor = btn_clear.BackColor;
            btn_zc_tuichu.BackColor = btn_clear.BackColor;
            btn_pic.BackColor = btn_clear.BackColor;
            btn_exit.BackColor = btn_clear.BackColor;
            btn_zc_tuichu.BackColor = btn_clear.BackColor;
            btn_zc_clear.BackColor = btn_clear.BackColor;

            foreach (Control item in Controls)
            {
                if (item is Label || item is CheckBox || item is PictureBox || item is GroupBox || item is Button || item is Panel)
                {
                    item.BackColor = Color.Transparent;
                }
            }

            love.buyde_id = txt_username.Text;
            foreach (Control i in Controls)
            {
                i.Anchor = AnchorStyles.None;
            }

            Frm_Login f = new Frm_Login();
            Icon = f.Icon;

            //txt_password.Text = txt_username.Text = "b";
            pan_zhuce.Visible = false;//首先把注册界面隐藏
            pic_photo.BorderStyle = BorderStyle.Fixed3D;//头像边框为三维边框
            rad_sellde.Checked = true;//默认注册成为卖家
            txt_password.PasswordChar = '*';//遮挡密码
            txt_zc_pwd1.PasswordChar = txt_password.PasswordChar;
            txt_zc_pwd2.PasswordChar = txt_password.PasswordChar;
            tiemzou();


        }



        private void btn_denlu_Click(object sender, EventArgs e)//点击了登陆的按钮
        {
            love.isloginexit = true;
            #region 判断是否已经输入了账号还有密码
            if (txt_username.Text.Trim() == "")
            {
                MessageBox.Show("请确保你输入了账号", "账号提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_username.Focus();
                return;
            }
            if (txt_password.Text.Trim() == "")
            {
                MessageBox.Show("请确保你输入了密码", "密码提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_password.Focus();
                return;
            }
            #endregion
            string sql1 = "select * from sellde where username=@u and pwd = @p";
            string sql2 = "select * from buyde where username=@u and pwd = @p";
            //不要共用参数数组，会提示     另一个 SqlParameterCollection 中已包含 SqlParameter。
            SqlParameter[] p = { new SqlParameter("@u", txt_username.Text), new SqlParameter("@p", txt_password.Text) };
            SqlParameter[] p1 = { new SqlParameter("@u", txt_username.Text), new SqlParameter("@p", txt_password.Text) };
            DataTable sellde = sqlHelper.ExecutedataTable(sql1, CommandType.Text, p);
            DataTable buyde = sqlHelper.ExecutedataTable(sql2, CommandType.Text, p1);
            #region 说明他是卖家
            if (sellde.Rows.Count != 0)
            {
                Text = "卖";
                love.denglu_IsSelldeOrBuyde = "卖";
                love.denglu_username = txt_username.Text;
                love.denglu_password = txt_password.Text;

                //开始判断它是否填写了详细信息   没有的话就让他填写 
                sellde s = new sellde();
                s.Username = txt_username.Text;
                if (s.isorther() == false)
                {//说明没有注册详细信息，因为没有查到任何记录
                    love.isloginexit = false;//没有查到就把它改为false这样在登陆页按退出才能出现退出提示
                    Hide();
                    Frm_UserOrther f = new Frm_UserOrther();
                    f.ShowDialog();
                    Show();
                    if (love.user_orther)
                    {
                        Close();
                    }
                }
                else
                {
                    love.user_orther = true;
                    Close();
                }

                //开始把账号密码写进去 
                //创建文件流，写入文件路径(文件夹先创建好)和文件名  打开方式为写入
                FileStream fs = new FileStream(Application.StartupPath + "\\zhmmdll", FileMode.Create);
                string sss = "zh" + love.denglu_username.Trim() + "zh\r\nmm" + love.denglu_password.Trim();
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                //StreamWriter sw = new StreamWriter(fs );
                sw.Write(sss);
                sw.Close();//记得先关闭阅读流
                fs.Close();//关闭文件流，两个都要关闭


            }
            #endregion

            #region 说明他是买家
            else if (buyde.Rows.Count != 0)
            {
                //select * from buyde
                Text = "买";
                love.denglu_username = txt_username.Text;
                love.denglu_password = txt_password.Text;
                love.denglu_IsSelldeOrBuyde = "买";

                //开始判断它是否填写了详细信息   没有的话就让他填写

                buyde b = new buyde();
                b.Username = txt_username.Text;
                if (b.isorther() == false)
                {//说明没有注册详细信息，因为没有查到任何记录
                    love.isloginexit = false;//没有查到就把它改为false这样在登陆页按退出才能出现退出提示
                    Hide();
                    Frm_UserOrther f = new Frm_UserOrther();
                    f.ShowDialog();
                    Show();
                    if (love.user_orther)
                    {
                        Close();
                    }
                }
                else
                {
                    love.user_orther = true;
                    Close();
                }
                //开始把账号密码写进去 
                //创建文件流，写入文件路径(文件夹先创建好)和文件名  打开方式为写入
                FileStream fs = new FileStream(Application.StartupPath + "\\zhmmdll", FileMode.Create);
                string sss = "zh" + love.denglu_username.Trim() + "zh\r\nmm" + love.denglu_password.Trim();
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                //StreamWriter sw = new StreamWriter(fs );
                sw.Write(sss);
                sw.Close();//记得先关闭阅读流
                fs.Close();//关闭文件流，两个都要关闭
            }
            #endregion

            else
            {
                MessageBox.Show("请检查账号密码的正确性", "登陆提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)//点击了清空的按钮
        {
            //txt_password.Text = txt_username.Text = "";
            txt_password.Text = txt_username.Text = string.Empty;//标准写法，清空这两个文本框的内容
        }

        private void btn_exit_Click(object sender, EventArgs e)//点击了退出的按钮
        {
            this.Close();//关闭窗体        这个可以关闭绝大多数关于这个程序的线程
            //Application.Exit();
            //Application.ExitThread();     //在程序窗口无法正常关闭的时候用这个，直接关死关于这个程序上的所有线程
        }

        /// <summary>
        /// 此事件用来切换注册登录界面
        /// </summary>
        void qiehuan()
        {
            if (pan_zhuce.Visible)
            {
                pan_zhuce.Visible = false;//是否可见
                pan_denglu.Visible = true;
                lkb_xinyonhu.Text = "我是新用户";
                lab_tip.Text = "程序将会自动判断账号是卖家还是买家";

                lab_dl.Visible = true;
                lab_zc.Visible = false;

                //设置tab顺序焦点
                txt_username.TabIndex = 0;
                txt_password.TabIndex = 1;
                btn_denlu.TabIndex = 2;
                btn_clear.TabIndex = 3;
                btn_exit.TabIndex = 4;
                lkb_wangjipwd.TabIndex = 5;
                lkb_xinyonhu.TabIndex = 6;

                AcceptButton = btn_denlu;

            }
            else
            {
                lab_dl.Visible = false;
                lab_zc.Visible = true;

                pan_zhuce.Visible = true;
                pan_denglu.Visible = false;
                lkb_xinyonhu.Text = "返回登陆";
                lab_tip.Text = "欢迎注册爱尚购账号";

                txt_zc_name.Text = txt_zc_pwd1.Text = txt_zc_pwd2.Text = string.Empty;
                pic_photo.Image = null;
                lab_xuanzetouxiang.Visible = true;
                pic_photo.BorderStyle = BorderStyle.FixedSingle;


                //设置tab顺序焦点
                txt_zc_name.TabIndex = 0;
                txt_zc_pwd1.TabIndex = 1;
                txt_zc_pwd2.TabIndex = 2;
                rad_sellde.TabIndex = 3;
                rad_buyde.TabIndex = 4;
                ckb_isfanhuidenglu.TabIndex = 5;
                btn_pic.TabIndex = 6;
                btn_zhuce.TabIndex = 7;
                btn_clear.TabIndex = 8;
                btn_zc_tuichu.TabIndex = 9;
                lkb_wangjipwd.TabIndex = 10;
                lkb_xinyonhu.TabIndex = 11;

                AcceptButton = btn_zhuce;

            }
        }

        private void lkb_xinyonhu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//点击了我是新用户的linklable控件
        {
            qiehuan();
        }

        private void btn_pic_Click(object sender, EventArgs e)//点击了选择图片的按钮
        {
            OpenFileDialog ofd = new OpenFileDialog();//创建一个打开文件对话框
            ofd.Title = "请选择头像";//文件对话框的标题
            ofd.Filter = "图片文件(*.jpg)|*.jpg|所有文件(*.*)|*.*";//筛选文件的类型
            ofd.InitialDirectory = Application.StartupPath + "\\image";//程序所在的开始位置加上image文件夹下面作为初始目录
            DialogResult dr = ofd.ShowDialog();//显示对话框
            if (dr == DialogResult.OK)//说明选择了文件
            {
                pic_photo.SizeMode = PictureBoxSizeMode.Zoom;//按照原有图片等比例缩放
                pic_photo.BorderStyle = BorderStyle.None;
                pic_photo.Image = Image.FromFile(ofd.FileName);//头像框等于选择的图片
                btn_pic.Text = "重新选择";
                lab_xuanzetouxiang.Visible = false;
            }
        }

        private void btn_zc_clear_Click(object sender, EventArgs e)//点击了注册里面的清空按钮
        {
            // 类型为Control   i代表每次循环的控件    从     注册pannel这个控件里面的所有
            foreach (Control i in pan_zhuce.Controls)    // Control:控件         循环所有的控件
            {
                if (i is TextBox)//如果i是文本框
                {
                    i.Text = string.Empty;
                }
                if (i is PictureBox)//如果i是图片框
                {
                    //i.image    当点不出想要的属性时就使用下面这个方法
                    PictureBox p = (PictureBox)i;//创建一个图片，它等于当前循环的i这个图片  记得把i强制转换成为这个类型
                    p.Image = null;//清空
                    p.BorderStyle = BorderStyle.Fixed3D;
                    btn_pic.Text = "选择头像";
                }
            }
            lab_xuanzetouxiang.Visible = true;
        }

        private void btn_zc_tuichu_Click(object sender, EventArgs e)//点击了注册里面的退出按钮
        {
            btn_exit_Click(sender, e);//这个是登陆界面的退出按钮，现在调用一下就好了
        }

        private void btn_zhuce_Click(object sender, EventArgs e)//点击了注册的按钮
        {
            //开始判断该用户名是否已经存在了
            string user = "select * from buyde where username = '" + txt_zc_name.Text + "'";//这里是连接法直接用原始的+号连接
            string user2 = string.Format("select * from sellde where username = '{0}'", txt_zc_name.Text);
            //上面两个出来的字符串都是一模一样的
            int s1 = sqlHelper.ExecutChaXun(user);
            int s2 = sqlHelper.ExecutChaXun(user2);
            if (s1 > 0 || s2 > 0)
            {
                //说明数据库中存在了该账号
                MessageBox.Show("该账号已经存在", "文本框提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_zc_name.Focus();
                txt_zc_name.SelectAll();
                return;
            }

            //判断是否输入了所有的信息
            foreach (Control item in pan_zhuce.Controls)
            {
                if (item is TextBox)
                {
                    if (item.Text.Trim() == string.Empty)      //Trim()去除字符串两端的空格     string.Empty == ""      都是空的意思
                    {
                        TextBox a = (TextBox)item;
                        MessageBox.Show("此文本框未输入内容,请输入", "文本框提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        a.Focus();//让此框获得焦点==光标==鼠标
                        a.SelectAll();//选择这个文本框的全部
                        return;//提前结束此方法
                    }
                }
            }

            //开始判断是否插入了图片
            if (pic_photo.Image == null)
            {
                DialogResult result = MessageBox.Show("没有选择头像，是否立刻选择？", "图片提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    btn_pic_Click(sender, e);//执行点击了选择头像的按钮
                }
                return;
            }

            //开始判断两个密码是否一致
            if (txt_zc_pwd1.Text != txt_zc_pwd2.Text)
            {
                //说明密码不一致
                MessageBox.Show("两次密码不一致,请重新输入", "密码错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_zc_pwd2.Focus();//让此框获得焦点==光标==鼠标
                txt_zc_pwd2.SelectAll();//选择这个文本框的全部
                return;//结束本方法，不让注册
            }

            //开始分辨注册的到底是卖家还是买家
            if (rad_buyde.Checked)//如果这个按钮是选中了，那么说明它是买家
            {
                love.denglu_IsSelldeOrBuyde = "买";
            }
            else
            {
                love.denglu_IsSelldeOrBuyde = "卖";
            }
            //下面是为变量们赋值，然后调用业务逻辑层的插入命令，达到注册目的
            sellde s = new sellde();//实例化一个卖家
            s.Username = txt_zc_name.Text;//用户名为注册的名字
            s.Pwd = txt_zc_pwd1.Text;//密码等于密码 

            if (pic_photo.Image == null)//如果图片框为空那么就赋值为空
            {
                s.Photo = null;
            }
            else
            {
                string path = Application.StartupPath + @"\image\a.jpg";//创建一个文件的路径，包含文件名
                pic_photo.Image.Save(path);//保存图片框，它的路径名字为上面定义的path
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);//创建一个文件流，把这个文件作为流，打开方式为打开，文件的访问权限为阅读
                byte[] image = new byte[fs.Length];//定义一个byte(字节)数组   长度为文件流fs的长度。length：长度
                fs.Read(image, 0, image.Length);//文件流读取到image这个数组里面去,从 0 开始，一直到文件流的最大长度  -- 其实就是读取所有
                s.Photo = image;//正式把数组赋值到业务逻辑层的photo数组
                fs.Close();//吸取经验，记得关闭，以保证下一次处理文件    关闭文件流
                File.Delete(path);//删除磁盘文件
            }
            s.zhucesellde();//这个是业务逻辑层里面的注册功能方法
            MessageBox.Show("注册成功了", "注册提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txt_username.Text = txt_zc_name.Text;//成功后给登陆框的账号赋值
            txt_password.Text = "";
            //pic_photo.Image = null;
            //txt_zc_name.Text = txt_zc_pwd1.Text = txt_zc_pwd2.Text = "";//成功后清空


            if (ckb_isfanhuidenglu.Checked)
            {
                qiehuan();
            }
  
        }

        private void pic_photo_Click(object sender, EventArgs e)//点击了头像的事件
        {
            btn_pic_Click(sender, e);//重复调用点击了选择图片的按钮
        }

        private void txt_zc_name_Leave(object sender, EventArgs e)
        {
            //ErrorProvider ero = new ErrorProvider();
            //if (txt_zc_name.Text.Length <= 10)
            //{
            //    ero.SetError(txt_zc_name, "长度不能小于10！" + txt_zc_name.Text.Length);
            //    txt_zc_name.Focus();
            //    txt_zc_name.SelectAll(); 
            //}
            //else
            //{
            //    ero.Clear();
            //}
        }

        private void lkb_wangjipwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//点击了忘记密码
        {

            Hide();

            Frm_WangJiPwd f = new Frm_WangJiPwd();
            f.ShowDialog();

            Show();

        }

        private void Frm_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (love.isloginexit)//如果是在登陆窗口按下的登陆按钮就不允许退出，因为登陆成功后需要退出登陆窗口给其它变量赋值以此来打开集成窗口
            {
                love.isloginexit = false;
                return;
            }

            if (love.zhuce_username != string.Empty)//说明注册成功，所以要来提示
            {
                //开始判断它是否填写了详细信息   没有的话就让他填写 
                sellde s = new sellde();
                s.Username = love.zhuce_username;
                if (s.isorther() == true)
                {
                    return;
                }
            }


            if (MessageBox.Show("你真的要退出爱尚购吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}