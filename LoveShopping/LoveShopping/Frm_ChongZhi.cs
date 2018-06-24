using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;
using love_BLL;
using love_DAL;

namespace LoveShopping
{
    public partial class Frm_ChongZhi : Form
    {
        //private static Frm_ChongZhi fcz = null;
        //public static Frm_ChongZhi FCZ()
        //{
        //    if (fcz == null)
        //        fcz = new Frm_ChongZhi();
        //    return fcz;
        //}

        public event EventHandler sxmaindeje;//申明一个刷新主界面的事件

        public Frm_ChongZhi()
        {
            InitializeComponent();
        }

        private void frm_ChongZhi_Load(object sender, EventArgs e)
        {
            Frm_Login f = new Frm_Login();
            Icon = f.Icon;
            updatejine();//刷新金额
            love.meihua(this);
            foreach (Control i in Controls)
            {
                i.Anchor = AnchorStyles.None;
            }
        }

        /// <summary>
        /// 刷新金额
        /// </summary>
        void updatejine()
        {            
            string sqlstr1=string.Empty;
            if (love.denglu_IsSelldeOrBuyde == "卖")
            {
                sqlstr1 = string.Format("select yue from sellde where username='{0}'",love.denglu_username==string.Empty?"a":love.denglu_username);
            }
            else
            {
                sqlstr1 = string.Format("select yue from buyde where username='{0}'",love.denglu_username==string.Empty?"b":love.denglu_username);
            }
             
            DataTable d = sqlHelper.ExecutedataTable(sqlstr1, CommandType.Text, null);
            lab_yue.Text = d.Rows[0][0].ToString();//把余额显示出来
        }

        private void btn_OK_Click(object sender, EventArgs e)//点击了充值按钮
        {
            string sql = string.Empty;
            if (love.denglu_IsSelldeOrBuyde == "卖")//为卖家充值
            {
                sql = string.Format("update sellde set yue = yue + {0} where username = '{1}'", txt_ChongZhi.Text,love.denglu_username);
            }
            else                                    //为买家充值
            {
                sql = string.Format("update buyde set yue = yue + {0} where username = '{1}'", txt_ChongZhi.Text, love.denglu_username);
            }

            sqlHelper.ExecuteCommand(sql, CommandType.Text, null); //刷新主页的金额
            sxmaindeje(sender, e);
            updatejine();//刷新金额 
            MessageBox.Show("充值成功╭(╯3╰)╮", "充值提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txt_ChongZhi_Leave(object sender, EventArgs e)//离开充值文本框的时候
        {
            try
            {
                decimal.Parse(txt_ChongZhi.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的金额", "金额提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_ChongZhi.Focus();
                txt_ChongZhi.SelectAll();
            }
        }
    }
}
