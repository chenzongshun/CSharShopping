using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.Sql;
using love_BLL;
using love_DAL;
using System.IO;

namespace LoveShopping
{
    public partial class Frm_Main_Sellde : Form
    {
        public Frm_Main_Sellde()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void tjtx(object sender, EventArgs e)
        {
            string username = love.denglu_username == String.Empty ? "a" : love.denglu_username;
            string sql = "select photo from sellde where username='" + username + "'";
            sqlHelper.imagechu(sql, pic_touxiang);
        }

        /// <summary>
        /// 刷新金额的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void sxje(object sender, EventArgs e)
        {
            tolab_yue.Text = "您的余额：" + sqlHelper.ExecutedataTable(string.Format("select yue from sellde where username = '{0}'", love.denglu_username == string.Empty ? "a" : love.denglu_username), CommandType.Text, null).Rows[0][0].ToString();
        }

        /// <summary>
        /// 刷新库存数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public void sxspcount(object sender, EventArgs e)
        //{
        //    string sql = string.Format("select COUNT(*) from commodity where username = '{0}'", love.denglu_username);
        //    lab_shoumai.Text ="您正在出售 "+ sqlHelper.ExecutedataTable(sql, CommandType.Text, null).Rows[0][0].ToString() +" 件商品";
        //}

        private void Frm_Main_Sellde_Load(object sender, EventArgs e)
        {
            Frm_Login f = new Frm_Login();
            Icon = f.Icon;

            //添加头像
            tjtx(sender, e);

            love.meihua(this);


            tolab_UserName.Text = love.denglu_username == string.Empty ? "欢迎 a " : "欢迎 " + love.denglu_username + " 回来";
            time.Enabled = true;
            tolab_dltime.Text = "登陆时间：" + DateTime.Now.ToString();
            time.Tick += new EventHandler(time_Tick);

            //写上余额
            sxje(sender, e);//刷新金额

            Frm_ComXiangXI fff = new Frm_ComXiangXI();
            fff.Dock = DockStyle.Fill;
            create_window("Frm_ComXiangXI", fff);

        }


        void time_Tick(object sender, EventArgs e)//代码添加时间到底部
        {
            tolab_time.Text = "北京时间：" + DateTime.Now.ToString();
        }

        Timer time = new Timer();

        private void tobtn_updatepwd_Click(object sender, EventArgs e)//点击了修改密码的按钮
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

        private void pan_windows_Paint(object sender, PaintEventArgs e)//pan_Windows控件需要重新绘制的时候
        {
            if (love.isorupdatepwd)//如果修改密码成功就关闭goto重新再来
            {
                Close();
            }
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

        private void tobtn_yulancom_Click(object sender, EventArgs e)//点击了预览商品的按钮
        {
            Frm_ComYuLan f = new Frm_ComYuLan();
            create_window("Frm_ComYuLan", f);
        }

        private void tobtn_addcom_Click(object sender, EventArgs e)//点击了添加商品的按钮
        {
            Frm_AddCommdodity f = new Frm_AddCommdodity();
            create_window("Frm_AddCommdodity", f);
        }

        private void tobtn_exitdenglu_Click(object sender, EventArgs e)//点击了退出重新登陆额的按钮
        {
            if (MessageBox.Show("你真的要重新登陆吗？", "退出提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                love.WindowsIsExit = true;
                Close();//会跑到program代码里goto从头再来
            }
        }

        private void tobtn_shezhi_Click(object sender, EventArgs e)//点击了设置的按钮
        {
            Frm_UserSheZhi f = new Frm_UserSheZhi();
            f.tjtx += new EventHandler(tjtx);
            create_window("Frm_UserSheZhi", f);
        }

        private void tobtn_comxinagqin_Click(object sender, EventArgs e)//点击了商品详细的按钮
        {
            Frm_ComXiangXI f = new Frm_ComXiangXI();
            create_window("Frm_ComXiangXI", f);
        }

        private void tobtn_guanyuwomen_Click(object sender, EventArgs e)//点击了关于我们的按钮
        {
            MessageBox.Show("本程序由 刘洁 范丽珍   陈宗顺  刘慧敏  共同制作完成", "关于我们", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tobtn_liulanshangping_Click(object sender, EventArgs e)//点击了浏览商品的按钮
        {
            Frm_LiuLanComPa f = new Frm_LiuLanComPa();
            create_window("Frm_LiuLanComPa", f);
        }

        private void tobtn_goods_Click(object sender, EventArgs e)//点击了查看订单
        {
            Frm_SelldeGoods f = new Frm_SelldeGoods();
            create_window("Frm_SelldeGoods", f);
        }

        private void tobtn_chongzhi_Click(object sender, EventArgs e)//点击了充值
        {
            Frm_ChongZhi f = new Frm_ChongZhi();
            f.sxmaindeje += new EventHandler(sxje);
            create_window("Frm_ChongZhi", f);
        }
    }
}
