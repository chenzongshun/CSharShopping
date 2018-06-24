using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using love_DAL;

namespace LoveShopping
{
    public partial class Frm_Main_Buyde : Form
    {
        public Frm_Main_Buyde()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 刷新金额
        /// </summary>
        public void sxje(object sender, EventArgs e)
        {
            tolab_yue.Text = "您的余额：" + sqlHelper.ExecutedataTable(string.Format("select yue from buyde where username = '{0}'", love.denglu_username == string.Empty ? "b" : love.denglu_username), CommandType.Text, null).Rows[0][0].ToString();
        }

        /// <summary>
        /// 刷新头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void tjtx(object sender, EventArgs e)
        {
            string sql = string.Format("select photo from buyde where username='{0}'", love.denglu_username == String.Empty ? "b" : love.denglu_username);
            sqlHelper.imagechu(sql, pic_touxiang);
        }
 

        private void Frm_Main_Buyde_Load(object sender, EventArgs e)
        {
            //toolStrip1.ForeColor = Color.Transparent; 

            Frm_Login f = new Frm_Login();
            Icon = f.Icon;

            //添加头像 
            tjtx(sender, e);

            //Frm_LiuLanComPa ff = new Frm_LiuLanComPa();
            //create_window("Frm_LiuLanCom", ff);

            tolab_UserName.Text = love.denglu_username == string.Empty ? "欢迎 b " : "欢迎 " + love.denglu_username + " 回来";
            time.Enabled = true;
            tolab_dltime.Text = "登陆时间：" + DateTime.Now.ToString();
            time.Tick += new EventHandler(time_Tick);
            //locx = pan_windows.Location.X;
            //locy = pan_windows.Location.Y;

            //love.meihua(this);
            Frm_LiuLanComDat fff = new Frm_LiuLanComDat();
            fff.Dock = DockStyle.Fill;
            create_window("Frm_LiuLanComDat", fff);

            //写上余额    
            sxje(sender, e);
            //库存
           
        }

        void time_Tick(object sender, EventArgs e)//代码添加时间到底部
        {
            tolab_time.Text = "系统时间：" + DateTime.Now.ToString();
        }

        Timer time = new Timer();

        private void tobtn_wjpwd_Click(object sender, EventArgs e)//点击了忘记密码的按钮
        {
            Frm_UpdatePwd f = new Frm_UpdatePwd();
            create_window("Frm_UpdatePwd", f);
        }

        /// <summary>
        /// 传入一个窗体name来限制开启的数目
        /// </summary>
        /// <param name="windowname">>窗体的name，记得要用复制</param>
        /// <param name="yaoqidongname">要启动的name名</param>
        void create_window(string windowname, Form yaoqidongname)
        {
            #region 计算开了几个窗口
            int count = 0;
            foreach (Control i in pan_windows.Controls)
            {
                if (i.Name == windowname && i is Form)
                {
                    count++;
                }
            }
            #endregion
            foreach (Control i in pan_windows.Controls)
            {
                if (!(i is Form)) continue;
                if (i.Name == windowname)
                {
                    string tip = "你已经开了 " + count.ToString() + " 个\"" + i.Text + "\"的窗口了哦，你确定要再次开启一个吗？";


                    if (DialogResult.Yes == MessageBox.Show(tip, "窗口提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        yaoqidongname.TopLevel = false;//降低窗体f的等级不是顶级 
                        yaoqidongname.Parent = pan_windows;
                        yaoqidongname.BringToFront();//把当前子窗体设置父窗体里面所有子窗口为最顶层 
                        //yaoqidongname.StartPosition = FormStartPosition.CenterScreen;
                        //yaoqidongname.WindowState = FormWindowState.Maximized;
                        yaoqidongname.Show();
                        return;//创建一个窗体后再次结束，不然每循环一次都要询问是否要开
                    }
                    else
                    {
                        foreach (Control ii in pan_windows.Controls)
                        {
                            if (!(i is Form)) continue;
                            if (ii.Name == windowname)
                            {
                                ii.BringToFront();
                            }
                        }
                        return;
                    }
                }
            }
            yaoqidongname.TopLevel = false;//降低窗体f的等级不是顶级
            yaoqidongname.Show();
            yaoqidongname.Parent = pan_windows;
            yaoqidongname.BringToFront();//把当前子窗体设置父窗体里面所有子窗口为最顶层
        }

        private void tobtn_backup_Click(object sender, EventArgs e)//点击了备份数据库的按钮
        {
            Frm_Backup f = new Frm_Backup();
            create_window("Frm_Backup", f);
        }

        private void tobtn_Restore_Click(object sender, EventArgs e)//点击了恢复数据库的按钮
        {
            Frm_Restore f = new Frm_Restore();
            create_window("Frm_Restore", f);
        }

        private void tobtn_exitdenglu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你真的要重新登陆吗？", "退出提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                love.WindowsIsExit = true;
                Close();//会跑到program代码里goto从头再来
            }
        }

        private void tobtn_updatepwd_Click(object sender, EventArgs e)//点击了修改密码的按钮
        {

            Frm_UpdatePwd f = new Frm_UpdatePwd();
            create_window("Frm_UpdatePwd", f);

        }

        private void Frm_Main_Buyde_StyleChanged(object sender, EventArgs e)//主窗体的样式改变事件
        {
            if (WindowState != FormWindowState.Maximized)
            {
                StartPosition = FormStartPosition.CenterScreen;
            }
        }

        private void tobtn_liulanshangping_Click(object sender, EventArgs e)//点击了浏览商品的按钮
        {
            Frm_LiuLanComDat f = new Frm_LiuLanComDat();
            create_window("Frm_LiuLanComDat", f);
        }

        private void tobtn_shezhi_Click(object sender, EventArgs e)//点击了设置按钮
        {
            Frm_UserSheZhi f = new Frm_UserSheZhi();
            f.tjtx += new EventHandler(tjtx);
            create_window("Frm_UserSheZhi", f);
        }

        private void tobtn_goods_Click(object sender, EventArgs e)//查看订单
        {
            Frm_BuydeGoods f = new Frm_BuydeGoods();
            create_window("Frm_BuydeGoods", f);
        }

        private void Frm_Main_Buyde_Paint(object sender, PaintEventArgs e)//窗体重绘时
        {
            if (love.isorupdatepwd)
            {
                pan_windows.Left++;
                Close();
            }
            //foreach (Form i in pan_windows.Controls)
            //{
            //    if (i.Name == "Frm_BuydeZhifu")
            //    {
            //        MessageBox.Show("fjkld");
            //    }
            //}
        }

        private void tobtn_chongzhi_Click(object sender, EventArgs e)//点击了充值
        {
            Frm_ChongZhi f = new Frm_ChongZhi();
            f.sxmaindeje += new EventHandler(sxje);//把本页的刷新金额方法传进去
            create_window("Frm_ChongZhi", f);
        }

        private void tobtn_guanyuwomen_Click(object sender, EventArgs e)//点击了关于我们的按钮
        {
            MessageBox.Show("本程序由 刘洁 范丽珍   陈宗顺  刘慧敏  共同制作完成", "关于我们", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tobtn_yulancom_Click(object sender, EventArgs e)//点击预览商品
        {
            Frm_LiuLanComPa f = new Frm_LiuLanComPa();
            create_window("Frm_LiuLanComPa", f);
        }

    }
}
