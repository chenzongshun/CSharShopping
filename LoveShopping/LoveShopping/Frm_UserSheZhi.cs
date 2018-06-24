using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using love_DAL;
using love_BLL;
using System.Data.SqlClient;

namespace LoveShopping
{
    public partial class Frm_UserSheZhi : Form
    {
        public Frm_UserSheZhi()
        {
            InitializeComponent();
        }

        public event EventHandler tjtx;//刷新主界面的头像

        private void frm_SheZhi_Load(object sender, EventArgs e)
        {
            Frm_Login f = new Frm_Login();
            Icon = f.Icon;
            foreach (Control i in Controls)
            {
                i.Anchor = AnchorStyles.None;
            }
            if (love.denglu_IsSelldeOrBuyde == "卖")
            {
                string sql1 = string.Format("select * from sellde where username ='{0}'", love.denglu_username == string.Empty ? "a" : love.denglu_username);
                DataTable d = sqlHelper.ExecutedataTable(sql1, CommandType.Text, null);
                //	pwd	nicheng	zhenname	photo	sex	fahuodizhi	yue	sfzh			mibaodan	zhucetime
                txt_Ni.Text = d.Rows[0]["nicheng"].ToString();
                txt_telephon.Text = d.Rows[0]["telephone"].ToString();

                #region 获取发货地址
                string fhd = d.Rows[0]["fahuodizhi"].ToString();//获得发货地址的字符串

                string sheng = fhd.Substring(0, fhd.IndexOf(" ")).Trim();//从发货地址的字符串中取得省位
                cmd_Sheng.Text = sheng;//把获得的省给commbox赋值

                string shi = fhd.Substring(fhd.IndexOf(sheng) + sheng.Length, fhd.IndexOf(" ") + 1).Trim();//从发货地址的字符串中取得市位
                cmd_Shi.Text = shi;//上面巧用sheng，取得它的字符串的索引位，然后索引数加上它本身的长度来作为截取字符串的起点，直到下一个空格中的数就是省位，下面的原理一样

                string xiangzheng = fhd.Substring(fhd.IndexOf(shi) + shi.Length, fhd.IndexOf(" ") + 1).Trim();//从发货地址的字符串中取得乡镇位
                cmd_Xiang.Text = xiangzheng;

                string xiangxidizhi = fhd.Substring(fhd.IndexOf(xiangzheng) + xiangzheng.Length).Trim();//从发货地址的字符串中取得最后的详细位
                txt_xiangxidizhi.Text = xiangxidizhi;
                #endregion
                lab_yuanmibaowenti.Text = d.Rows[0]["mibaowt"].ToString();
                //新密保保留

                string pic = string.Format("select photo from sellde where username ='{0}'", love.denglu_username == string.Empty ? "a" : love.denglu_username);
                sqlHelper.imagechu(pic, pic_touxiang);

                foreach (Control item in Controls)
                {
                    if (item is Label)
                    {
                        item.BackColor = Color.Transparent;
                    }
                }
            }
            else//说明是买家
            {
                string sql1 = string.Format("select * from buyde where username ='{0}'", love.denglu_username == string.Empty ? "b" : love.denglu_username);
                DataTable d = sqlHelper.ExecutedataTable(sql1, CommandType.Text, null);
                //	pwd	nicheng	zhenname	photo	sex	fahuodizhi	yue	sfzh			mibaodan	zhucetime
                txt_Ni.Text = d.Rows[0]["nicheng"].ToString();
                txt_telephon.Text = d.Rows[0]["telephone"].ToString();

                #region 获取发货地址
                string shd = d.Rows[0]["shouhuodizhi"].ToString();//获得发货地址的字符串

                string sheng = shd.Substring(0, shd.IndexOf(" ")).Trim();//从发货地址的字符串中取得省位
                cmd_Sheng.Text = sheng;//把获得的省给commbox赋值

                string shi = shd.Substring(shd.IndexOf(sheng) + sheng.Length, shd.IndexOf(" ") + 1).Trim();//从发货地址的字符串中取得市位
                cmd_Shi.Text = shi;//上面巧用sheng，取得它的字符串的索引位，然后索引数加上它本身的长度来作为截取字符串的起点，直到下一个空格中的数就是省位，下面的原理一样

                string xiangzheng = shd.Substring(shd.IndexOf(shi) + shi.Length, shd.IndexOf(" ") + 1).Trim();//从发货地址的字符串中取得乡镇位
                cmd_Xiang.Text = xiangzheng;

                string xiangxidizhi = shd.Substring(shd.IndexOf(xiangzheng) + xiangzheng.Length).Trim();//从发货地址的字符串中取得最后的详细位
                txt_xiangxidizhi.Text = xiangxidizhi;
                #endregion
                lab_yuanmibaowenti.Text = d.Rows[0]["mibaowt"].ToString();
                //新密保保留

                string pic = string.Format("select photo from buyde where username ='{0}'", love.denglu_username == string.Empty ? "b" : love.denglu_username);
                sqlHelper.imagechu(pic, pic_touxiang);

                foreach (Control item in Controls)
                {
                    if (item is Label)
                    {
                        item.BackColor = Color.Transparent;
                    }
                }




            }
        }



        private void txt_Ni_TextChanged(object sender, EventArgs e)
        {
            string sql1 = string.Format("select mibaowt,mibaodan from sellde where username='{0}'", txt_Ni.Text);
            string sql2 = string.Format("select mibaowt,mibaodan from buyde where username='{0}'", txt_telephon.Text);
            DataTable d1 = sqlHelper.ExecutedataTable(sql1, CommandType.Text, null);
            DataTable d2 = sqlHelper.ExecutedataTable(sql2, CommandType.Text, null);

            if (d1.Rows.Count != 0)//说明找到数据了
            {

                label1.Text = d1.Rows[0][0].ToString();
                label2.Text = d1.Rows[0][1].ToString();
            }
            if (d2.Rows.Count != 0)//说明找到数据了
            {

                txt_Ni.Text = d2.Rows[0][0].ToString();
                txt_telephon.Text = d2.Rows[0][1].ToString();
            }
        }
        private void txt_telephon_Validating(object sender, CancelEventArgs e)//电话框的验证事件
        {
            try
            {
                long.Parse(txt_telephon.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入不包括小数点的阿拉伯数字 0 -- 9 ");
                txt_telephon.Focus();
                txt_telephon.SelectAll();
            }
        }

        private void txt_yuanmibaodaan_Validating(object sender, CancelEventArgs e)//密保答案验证时的事件
        {


            //开始核对密保答案
            string sql = string.Empty;
            DataTable ddd;
            if (love.denglu_IsSelldeOrBuyde == "卖")
            {
                string aaaaaa = string.Format("select mibaodan from sellde where username = '{0}'", love.denglu_username == string.Empty ? "b" : love.denglu_username);
                ddd = sqlHelper.ExecutedataTable(aaaaaa, CommandType.Text, null);
            }
            else
            {
                string aaaaaa = string.Format("select mibaodan from buyde where username = '{0}'", love.denglu_username == string.Empty ? "b" : love.denglu_username);
                ddd = sqlHelper.ExecutedataTable(aaaaaa, CommandType.Text, null);
            }

            string mibaodan = ddd.Rows[0][0].ToString();
            if (mibaodan.Trim() != txt_yuanmibaodaan.Text.Trim())
            {
                txt_yuanmibaodaan.SelectAll();
                txt_yuanmibaodaan.Focus();
                MessageBox.Show("密保答案不正确，我们必须通过密保答案来确定是否是您本人在进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void pic_touxiang_Click(object sender, EventArgs e)//点击了图片的按钮
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择图片";
            ofd.Filter = "所有文件|*.*|图片文件|*jpg";
            ofd.FilterIndex = 2;
            ofd.InitialDirectory = Application.StartupPath + "\\image\\";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                pic_touxiang.Image = Image.FromFile(ofd.FileName);

            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)//点击确定按钮
        { 
            foreach (Control i in Controls)
            {
                if (i is TextBox)
                {
                    if (i.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("请输入内容再进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        i.Focus();
                        return;
                    }
                }
            }

            try
            {
                long.Parse(txt_telephon.Text);
            }
            catch
            {
                MessageBox.Show("电话格式不正确，请检查后重新操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_telephon.Focus();
                txt_telephon.SelectAll();
                return;
            }


            string shi = cmd_Shi.Text;
            string xiang = cmd_Xiang.Text;
            string xiangxi = txt_xiangxidizhi.Text;
            string nicheng = txt_Ni.Text;
            long telephong = long.Parse(txt_telephon.Text);
            string sheng = cmd_Sheng.Text;
            string quanbudizhi = sheng + " " + shi + " " + xiang + " " + xiangxi;
            string mibaowenti = txt_Xinmibao.Text;
            string mibaodaan = txt_mibaodaan.Text;

            if (love.denglu_IsSelldeOrBuyde == "卖")
            {
                sellde s = new sellde();
                s.Username = love.denglu_username == string.Empty ? "a" : love.denglu_username;
                s.Nicheng = txt_Ni.Text;
                s.Telephone = long.Parse(txt_telephon.Text);
                s.Fahuodizhi = quanbudizhi;
                s.Mibaowt = txt_Xinmibao.Text;
                s.Mibaodan = txt_mibaodaan.Text;

                s.Photo = sqlHelper.tiqupic(pic_touxiang, Application.StartupPath + "\\a.jpg");
                s.upxiugaiziliao();
            }
            else
            {
                buyde s = new buyde();
                s.Username = love.denglu_username == string.Empty ? "a" : love.denglu_username;
                s.Nicheng = txt_Ni.Text;
                s.Telephone = long.Parse(txt_telephon.Text);
                s.Shouhuodizhi = quanbudizhi;
                s.Mibaowt = txt_Xinmibao.Text;
                s.Mibaodan = txt_mibaodaan.Text;

                s.Photo = sqlHelper.tiqupic(pic_touxiang, Application.StartupPath + "\\a.jpg");
                s.upxiugaiziliao();
            }
            MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tjtx(sender, e); 
        }

        private void btn_cancel_Click(object sender, EventArgs e)//点击取消按钮
        {
            this.Close();
        }

        private void txt_Ni_Validating(object sender, CancelEventArgs e)//昵称的验证事件
        {

        }
    }

}

