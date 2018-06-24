using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using love_BLL;
using love_DAL;

namespace LoveShopping
{
    public partial class Frm_UserOrther : Form
    {
        public Frm_UserOrther()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 在窗体诞生的时候就记录下密保问题框灰灰色的字体颜色
        /// </summary>
        Color hui = new Color();

        private void Frm_UserOrther_Load(object sender, EventArgs e)//窗口诞生就会这里面的代码，load装入
        {
            //#region 测试期间为控件们赋值
            //foreach (Control i in Controls)
            //{
            //    if (i is TextBox)
            //    {
            //        if (i.Name == "txt_telephone")
            //        {
            //            i.Text = "123";
            //            continue;
            //        }
            //        i.Text = "测试期间为控件们赋值";
            //    }
            //}
            //#endregion
            foreach (Control i in Controls)
            {
                i.Anchor = AnchorStyles.None;
            }
            love.meihua(this);

            hui = txt_mibaowenti.ForeColor;//记录下灰色字体
            txt_mibaodaan.ForeColor = hui;//让答案框的字体和问题框也一样

            Frm_Login f = new Frm_Login();
            Icon = f.Icon;

            rad_man.Checked = true;//默认选中了男性
            if (love_DAL.love.denglu_IsSelldeOrBuyde == "卖")       //判断是买家还是卖家
            {
                lab_dizhi.Text = "发货地址";
            }
            else
            {
                lab_dizhi.Text = "收货地址";
                lab_datishi.Text = "亲爱的买家,请填写您的详细信息";
            }

            //下面只是简单的初始化
            string[] shen = { "湖南省", "北京" };
            string[] shi = { "娄底市", "湘潭市" };
            string[] xiangzheng = { "娄星区", "其它" };
            cmb_sheng.Items.AddRange(shen);
            cmb_shi.Items.AddRange(shi);
            cmb_xiangzhen.Items.AddRange(xiangzheng);

            cmb_sheng.SelectedIndex = 0;//设置显示的是第几个选项
            cmb_shi.SelectedIndex = 0;
            cmb_xiangzhen.SelectedIndex = 0;

            updateyzm();//验证码赋值
        }

        #region 刷新验证码
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
        #endregion

        private void btn_submit_Click(object sender, EventArgs e)//点击了提交按钮
        {
            //查看验证码是否正确           测试期间把验证码关闭   
            string yzm = lab_y1.Text + lab_y2.Text + lab_y3.Text + lab_y4.Text;
            if (yzm.ToUpper() != txt_yanzhengma.Text.ToUpper())//两个内容转化为大写之后如果不一致的话
            {
                MessageBox.Show("验证码错误", "验证码输入提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_yanzhengma.Focus();
                updateyzm();
                txt_yanzhengma.SelectAll();
                return;
            }


            //下面的文本框不允许为空
            foreach (Control item in Controls)
            {
                if (item is TextBox)        //如果它是一个文本框
                {
                    if (item.Text.Trim() == "")     //Trim()去除字符串两端的空格
                    {
                        MessageBox.Show("请为此文本框输入内容", "文本框输入提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item.Focus();
                        return;
                    }
                }
            }

            /*没有插入的字段	nicheng	zhenname	sex	fahuodizhi	sfzh	telephone	mibaowt	mibaodan	zhucetime*/
            sellde s = new sellde();
            s.Nicheng = txt_nicheng.Text;
            s.Zhenname = txt_zhenname.Text;

            s.Sex = rad_man.Checked ? "男" : "女"; 
            s.Fahuodizhi = cmb_sheng.Text.Trim() + " " + cmb_shi.Text.Trim() + " " + cmb_xiangzhen.Text.Trim() + " " + txt_xiangxidizhi.Text.Trim();//三个combox框内容加上详细地址组成发货地址或者收货地址
            s.Sfzh = txt_sfzh.Text;
            s.Telephone = long.Parse(txt_telephone.Text);
            s.Mibaowt = txt_mibaowenti.Text == "    当你忘记密码的时候可以通过这个问题的答案来判定是否为你本人，然后进行找回密码。" ? "" : txt_mibaowenti.Text;
            s.Mibaodan = txt_mibaodaan.Text == "    上面密保的答案。" ? "" : txt_mibaodaan.Text;
            s.Username = love.denglu_username;
            s.zhuceselldeOrther();//执行插入其它详细信息
            MessageBox.Show("详细信息填写成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            love.iszhucecg = true;//注册成功会引发关闭事件

            //既然详细信息填写成功了，那么就开始判断是买家还是卖家，如果是卖家就进入商品管理的页面，否则那就是买家那么就进入到购物界面

            love.zhuce_username = love.denglu_username;
            love.user_orther = true;
            Close(); 
        }

        private void btn_clear_Click(object sender, EventArgs e)//点击了清空的按钮
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox)        //如果它是一个文本框
                {
                    if (item.Name == "txt_yan_yanzhengma")
                    {//因为验证码这个框里面的东西不用清空
                        continue;//结束本次循环开始循环下一个目标
                    }
                    item.Text = "";
                    item.Focus();
                    item.Select();

                }
                if (item is ComboBox)        //如果它是复选框
                {
                    cmb_sheng.Text = "湖南省";
                    cmb_shi.Text = "娄底市";
                    cmb_xiangzhen.Text = "娄星区";
                }
            }
        }

        private void txt_telephone_Validating(object sender, CancelEventArgs e)//电话号码文本框的验证事件
        {
            try             //可能错误的代码片段
            {
                long.Parse(txt_telephone.Text);//错误电话号码11位  而int 10 位，转换不了，所以即便是电话也会出错，下面定义成为长整形就能超过10位数了
                //Convert.ToDouble(txt_telephone.Text);//非阿拉伯数字那么就绝对转换不了成为整数类型，转换不了就会出错，出错就跳转到catch代码片段

                //if (txt_telephone.Text.IndexOf(".") != -1)//如果找到了就会返回‘.’的位置     
                //{
                //    //txt_telephone.Text.IndexOf(".") != -1   找小数点
                //    //9651541   
                //    //0123456
                //    //找到了就返回它的索引，没找到就返回-1
                //    MessageBox.Show("电话号码中不存在小数点", "电话号码错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txt_telephone.Focus();
                //    txt_telephone.SelectAll();
                //    return;
                //}
                if (txt_telephone.Text.Trim().Length!=11)
                {
                    MessageBox.Show("电话号码长度应为11位，请注意检查", "电话号码错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_telephone.Focus();
                    txt_telephone.SelectAll();
                    return;
                }
            }
            catch             //如果try里面的代码错误的话，那么就会执行catch里面的代码
            {
                MessageBox.Show("请输入数字0-9", "电话号码错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_telephone.Focus();
                txt_telephone.SelectAll();
                return;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)//点击了退出的按钮
        {
            Close();//关闭此窗体 
        }

        private void lab_y1_Click(object sender, EventArgs e)
        {
            updateyzm();//验证码赋值
        }

        private void txt_mibaowenti_TextChanged(object sender, EventArgs e)//密保问题框文本改变事件
        {
            if (txt_mibaowenti.Text.Trim() != "    当你忘记密码的时候可以通过这个问题的答案来判定是否为你本人，然后进行找回密码。")
            {
                txt_mibaowenti.ForeColor = lab_datishi.ForeColor;
            }
            else
            {
                txt_mibaowenti.ForeColor = hui;
            }
        }

        private void txt_mibaowenti_Enter(object sender, EventArgs e)//密保问题框成为活动控件时
        {
            if (txt_mibaowenti.Text == "    当你忘记密码的时候可以通过这个问题的答案来判定是否为你本人，然后进行找回密码。")
            {
                txt_mibaowenti.Text = string.Empty;
            }
        }

        private void txt_mibaowenti_Leave(object sender, EventArgs e)//离开密保问题框时
        {
            if (txt_mibaowenti.Text.Trim() == string.Empty)
            {
                txt_mibaowenti.Text = "    当你忘记密码的时候可以通过这个问题的答案来判定是否为你本人，然后进行找回密码。";
                txt_mibaowenti.ForeColor = hui;
            }
        }


        private void txt_mibaodaan_TextChanged(object sender, EventArgs e)//密保答案框文本改变事件
        {
            if (txt_mibaodaan.Text.Trim() != "    上面密保的答案。")
            {
                txt_mibaodaan.ForeColor = lab_datishi.ForeColor;
            }
            else
            {
                txt_mibaodaan.ForeColor = hui;
            }
        }

        private void txt_mibaodaan_Enter(object sender, EventArgs e)//密保答案框成为活动控件时
        {
            if (txt_mibaodaan.Text == "    上面密保的答案。")
            {
                txt_mibaodaan.Text = string.Empty;
            }
        }

        private void txt_mibaodaan_Leave(object sender, EventArgs e)//离开答案框时
        {
            if (txt_mibaodaan.Text.Trim() == string.Empty)
            {
                txt_mibaodaan.Text = "    上面密保的答案。";
                txt_mibaodaan.ForeColor = hui;
            }
        }

        private void Frm_UserOrther_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (love.iszhucecg)//如果是注册成功的那就不要提示
            {
                return;
            }

            string zfc = string.Format("亲爱的 \"{0}\" 你还没有填写完详细信息，你确定要退出吗?", love.denglu_username == string.Empty ? "测试名" : love.denglu_username);
            DialogResult result = MessageBox.Show(zfc, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
