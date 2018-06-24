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
    public partial class Frm_WangJiPwd : Form
    {
        public Frm_WangJiPwd()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)//点击了确认修改
        {

            //判断是卖家还是买家
            string sql1 = string.Format("select * from buyde where username = '{0}'", txt_username.Text);
            string sql2 = string.Format(" select * from sellde where username = '{0}'", txt_username.Text);
            DataTable d1 = sqlHelper.ExecutedataTable(sql1, CommandType.Text, null);
            DataTable d2 = sqlHelper.ExecutedataTable(sql2, CommandType.Text, null);
            string mm = string.Empty;//记录下卖还是买家
            if (d1.Rows.Count + d2.Rows.Count == 0)//根据用户名没有找到该用户，所以不让它往下开始忘记密码操作
            {
                MessageBox.Show("该用户名不存在，请检查是否输入错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_yzm.Clear();
                updateyzm();
                txt_username.Focus();
                txt_username.SelectAll();
                return;
            }
            else
            {
                if (d1.Rows.Count != 0)
                {
                    mm = "买";
                }
                else
                {
                    mm = "卖";
                }
            }



            //确认密保答案是否正确
            if (daan != txt_daan.Text)
            {
                MessageBox.Show("密保答案错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_yzm.Clear();
                updateyzm();
                txt_daan.Focus();
                txt_daan.SelectAll();
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


            //确认验证码是否正确了
            string yzm = lab_y1.Text + lab_y2.Text + lab_y3.Text + lab_y4.Text;
            if (yzm.ToUpper() != txt_yzm.Text.ToUpper())
            {
                MessageBox.Show("验证码错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_yzm.Clear();
                updateyzm();
                return;
                //刷新验证码
            }

            //开始修改答案
            string sql = string.Empty;
            if (mm=="卖")
            {
                sql = string.Format("update sellde set pwd = '{0}' where username = '{1}'", txt_okpwd.Text.Trim(), txt_username.Text);
            }
            else
            {
                sql = string.Format("update buyde set pwd = '{0}' where username = '{1}'", txt_okpwd.Text.Trim(), txt_username.Text);
            }
                

            sqlHelper.ExecuteCommand(sql, CommandType.Text, null);

            MessageBox.Show("密码修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (ckb_isordneglu.Checked)
            {
                Close();
            }

        }

        private void Frm_WangJiPwd_Load(object sender, EventArgs e)//初始化窗体事件
        {
            foreach (Control i in Controls)
            {
                i.Anchor = AnchorStyles.None;
            }
            txt_okpwd.PasswordChar = '*';
            txt_newpwd.PasswordChar = '*';
            updateyzm(); //刷新验证码
            Frm_Login f = new Frm_Login();
            Icon = f.Icon;
            ckb_isordneglu.Checked = true;
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
            updateyzm();// 刷新验证码
        }

        /// <summary>
        /// 记录下数据库中的答案
        /// </summary>
        string daan = string.Empty;//记录答案的

        private void txt_username_TextChanged(object sender, EventArgs e)//用户名文本改变的时候
        {
            string sql1 = string.Format("select mibaowt,mibaodan from sellde where username='{0}'", txt_username.Text);
            string sql2 = string.Format("select mibaowt,mibaodan from buyde where username='{0}'", txt_username.Text);
            DataTable d1 = sqlHelper.ExecutedataTable(sql1, CommandType.Text, null);
            DataTable d2 = sqlHelper.ExecutedataTable(sql2, CommandType.Text, null);

            if (d1.Rows.Count != 0)//说明找到数据了
            {
                lab_wenti.Text = d1.Rows[0][0].ToString();
                daan = d1.Rows[0][1].ToString();
            }
            else if (d2.Rows.Count != 0)//说明找到数据了
            {
                lab_wenti.Text = d2.Rows[0][0].ToString();
                daan = d2.Rows[0][1].ToString();
            }
            else
            {
                lab_wenti.Text = "用户名不存在，填写正确后将会显示出密保的问题。";
            }
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

            //ErrorProvider ee = new ErrorProvider();

            if (count == 0)//说明没找到数据
            {
                //MessageBox.Show("用户名不存在! 只有正确的用户名才会出现出密保的问题。", "用户名错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lab_wenti.Text = "用户名不存在，填写正确后将会显示出密保的问题。";
                //ee.SetError(txt_username, "用户名不存在");
                txt_username.Focus();
                txt_username.SelectAll();
            }
            else
            {
                //ee.Clear();
                //ee.Dispose();                
            }
        }

        private void btn_exitdenglu_Click(object sender, EventArgs e)//点击了返回登陆的按钮
        {
            Close();
        }
    }
}
