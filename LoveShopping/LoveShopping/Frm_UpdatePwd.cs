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
    public partial class Frm_UpdatePwd : Form
    {
        public Frm_UpdatePwd()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)//点击了确认修改
        {
            //确认验证码是否正确了
            string yzm = lab_y1.Text + lab_y2.Text + lab_y3.Text + lab_y4.Text;
            if (yzm.ToUpper() != txt_yzm.Text.ToUpper())
            {
                MessageBox.Show("验证码错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_yzm.Clear();
                txt_yzm.Focus();
                updateyzm();
                return;
                //刷新验证码
            }

            DataTable ddd;
            if (love.denglu_IsSelldeOrBuyde == "卖")
            {
                ddd = sqlHelper.ExecutedataTable(string.Format("select pwd from sellde where username= '{0}'", love.denglu_username), CommandType.Text, null);
            }
            else
            {
                ddd = sqlHelper.ExecutedataTable(string.Format("select pwd from buyde where username= '{0}'", love.denglu_username), CommandType.Text, null);
            }


            //确认原密码是否正确
            if (txt_jiupwd.Text != ddd.Rows[0][0].ToString())
            {
                MessageBox.Show("原密码错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_yzm.Clear();
                updateyzm();
                txt_jiupwd.Clear();
                txt_jiupwd.Focus();
                return;
            }

            if (txt_newpwd.Text.Trim() == string.Empty)
            {
                MessageBox.Show("新密码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_yzm.Clear();
                updateyzm();
                txt_newpwd.Focus();
                txt_newpwd.SelectAll();
                return;
            }

            if (txt_okpwd.Text.Trim() == string.Empty)
            {
                MessageBox.Show("确认密码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_yzm.Clear();
                updateyzm();
                txt_okpwd.Focus();
                txt_okpwd.SelectAll();
                return;
            }


            if (txt_newpwd.Text.Trim() != txt_okpwd.Text.Trim())
            {
                MessageBox.Show("两次密码不一致", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_yzm.Clear();
                updateyzm();
                txt_okpwd.Focus();
                txt_okpwd.SelectAll();
                return;
            }

            //开始修改密码
            if (love.denglu_IsSelldeOrBuyde == "卖")
            {
                if (MessageBox.Show("你真的要修改密码？修改成功将会退出登陆，届时将要求你重新输入账号和密码。", "修改提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                string sql = string.Format("update sellde set pwd = '{0}' where username = '{1}'", txt_okpwd.Text.Trim(), txt_username.Text);
                sqlHelper.ExecuteCommand(sql, CommandType.Text, null);
                love.isorupdatepwd = true;
                MessageBox.Show("密码修改成功", "点击重新登陆", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                if (MessageBox.Show("你真的要修改密码？", "修改提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                string sql = string.Format("update buyde set pwd = '{0}' where username = '{1}'", txt_okpwd.Text.Trim(), txt_username.Text);
                sqlHelper.ExecuteCommand(sql, CommandType.Text, null);
                MessageBox.Show("密码修改成功", "点击重新登陆", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void Frm_WangJiPwd_Load(object sender, EventArgs e)//初始化窗体事件
        {
            txt_username.Text = love.denglu_username;
            foreach (Control i in Controls)
            {
                i.Anchor = AnchorStyles.None;
            }
            Frm_Login f = new Frm_Login();
            Icon = f.Icon;
            txt_okpwd.PasswordChar = '*';
            txt_newpwd.PasswordChar = '*';
            updateyzm(); //刷新验证码
        }

        /// <summary>
        /// 刷新验证码
        /// </summary>
        private void updateyzm()
        {
            string[] s1 = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };//字符列表
            Random rand = new Random();//实例化随机数  
            lab_y1.Text = s1[rand.Next(0, s1.Length)];
            lab_y2.Text = s1[rand.Next(0, s1.Length)];
            lab_y3.Text = s1[rand.Next(0, s1.Length)];
            lab_y4.Text = s1[rand.Next(0, s1.Length)];
        }

        private void lab_y1_Click(object sender, EventArgs e)
        {
            updateyzm();
        }
 
        private void btn_cancle_Click(object sender, EventArgs e)//点击了清空的按钮
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                }
            }
        }

        private void txt_username_Leave(object sender, EventArgs e)//离开用户名文本框的时候
        {
            string sql1 = string.Format("select mibaowt,mibaodan from sellde where username='{0}'", txt_username.Text);
            string sql2 = string.Format("select mibaowt,mibaodan from buyde where username='{0}'", txt_username.Text);
            DataTable d1 = sqlHelper.ExecutedataTable(sql1, CommandType.Text, null);
            DataTable d2 = sqlHelper.ExecutedataTable(sql2, CommandType.Text, null);

            int count = d1.Rows.Count + d2.Rows.Count;

            if (count == 0)//说明没找到数据
            {
                //MessageBox.Show("用户名不存在! 只有正确的用户名才会出现出密保的问题。", "用户名错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //lab_wenti.Text = "用户名不存在，填写正确后将会显示出密保的问题。";
                //txt_username.Focus();
                txt_username.SelectAll();
            }
        }

    }
}
