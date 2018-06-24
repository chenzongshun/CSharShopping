using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using love_DAL;
using love_BLL;
using System.IO;

namespace LoveShopping
{
    public partial class Frm_AddCommdodity : Form
    {
        public Frm_AddCommdodity()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 记录下txt_xiangxi最初的字体颜色，这里设置为后面的半显示效果做前奏
        /// </summary>
        Color txt_xiangxi_forecolor = new Color();

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=LoveShopping;Integrated Security=True");

        /// <summary>
        /// 存储着商品拥有的颜色
        /// </summary>
        List<string> commditycolor = new List<string>();

        /// <summary>
        /// 存储着商品的其它属性
        /// </summary>
        List<string> commdityorther = new List<string>();

        /// <summary>
        /// 在点击了添加商品的按钮之后就会把商品id号记录到此变量中来，当不小心删除了id框中的id时做智能提示用
        /// </summary>
        int comididid = 0;

        private void Form1_Load(object sender, EventArgs e)//窗体诞生的时候
        {
            AcceptButton = btn_addcom;//默认enter为添加商品
            foreach (Control i in Controls)
            {
                i.Anchor = AnchorStyles.None;
            }
            Frm_Login f = new Frm_Login();
            Icon = f.Icon;

            txt_xiangxi_forecolor = txt_xiangxi.ForeColor;
            txt_orther.ForeColor = txt_xiangxi_forecolor;

            //ckb_isorcolor.Checked = true;
            //ckb_isororther.Checked = true;

            //测试期间先填入图片，以减少测试期间的选择图片的时间
            //pic_daico.Image = Image.FromFile(Application.StartupPath + "\\image\\陈奕迅_陪你度过漫长岁月_4.jpg");
            //pic_xiao1.Image = pic_daico.Image;
            //pic_xiao2.Image = pic_daico.Image;
            //pic_xiao3.Image = pic_daico.Image;


            //为combox物流公司填入信息
            string[] wuliu ={
            "请选择","顺丰","中通","圆通","申通","韵达","汇通","天天","中国邮政","EMS","宅急送","德邦物流","国通快递","佳吉快运","中铁快运","速尔快递",
            "中邮物流","能达速递","全峰快递","快捷速递","联邦快递FedEx","DHL","优速快递","天地华宇","全日通快递","信丰物流","新邦物流","UPS快递",
            "TNT国际快递","盛辉物流","中外运全一","佳怡物流","飞康达物流","联昊通快递"};
            cmb_wuliugongsi.Items.AddRange(wuliu);
            cmb_wuliugongsi.FlatStyle = FlatStyle.Popup;
            cmb_wuliugongsi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_wuliugongsi.SelectedIndex = 0;

            if (ckb_isororther.Checked == false)
            {
                list_orther.Items.Clear();
                list_orther.ForeColor = txt_xiangxi_forecolor;

                list_orther.Font = new Font(list_orther.Font.FontFamily, 15);

                string[] sx = { "没", "有", "任", "何", "属", "性" };
                List<string> lsx = new List<string>();
                lsx.AddRange(sx);

                foreach (var item in lsx)
                {
                    list_orther.ItemHeight = 255;
                    list_orther.Items.Add("");//提升行距
                    list_orther.Items.Add("    " + item);
                    list_orther.Items.Add("");//提升行距 
                }
            }

            foreach (Control item in Controls)
            {
                if (item is Label || item is CheckBox || item is PictureBox || item is GroupBox || item is Button || item is Panel)
                {
                    item.BackColor = Color.Transparent;
                }
                //if (item is PictureBox)
                //{
                //    PictureBox bbb = (PictureBox)item;
                //    bbb.BorderStyle = BorderStyle.None;
                //} 
            }
        }

 

        private void ckb_iscolor_CheckedChanged(object sender, EventArgs e)//点击了是否有颜色的复选框
        {
            if (ckb_isorcolor.Checked)
            {
                pan_iscolor.Enabled = true;
                //btn_clearcolor.Enabled = true;
            }
            else
            {
                pan_iscolor.Enabled = false;
                //btn_clearcolor.Enabled = false;
                foreach (var item in pan_iscolor.Controls)
                {//否的话就要清除所有的颜色
                    if (item is CheckBox)
                    {
                        CheckBox c = (CheckBox)item;
                        c.Checked = false;
                    }
                }
                btn_allcolor.Text = "选择所有颜色";
            }
        }

        private void btn_allcolor_Click(object sender, EventArgs e)//点击了选择所有颜色的按钮
        {
            if (btn_allcolor.Text == "选择所有颜色")
            {
                ckb_isorcolor.Checked = true;
                pan_iscolor.Enabled = true;
                foreach (var item in pan_iscolor.Controls)
                {
                    if (item is CheckBox)
                    {
                        CheckBox c = (CheckBox)item;
                        c.Checked = true;
                    }
                }
                btn_allcolor.Text = "清除所有颜色";
            }
            else
            {
                foreach (var item in pan_iscolor.Controls)
                {
                    if (item is CheckBox)
                    {
                        CheckBox c = (CheckBox)item;
                        c.Checked = false;
                    }
                }
                btn_allcolor.Text = "选择所有颜色";
            }
        }

        private void btn_addorther_Click(object sender, EventArgs e)//点击添加其它按钮
        {
            //判断是否已经添加过该属性
            foreach (var item in list_orther.Items)
            {
                //其它框如果等于其它的这个文本框
                if (txt_orther.Text.Trim() == item.ToString().Trim())
                {
                    MessageBox.Show("该属性已经添加过了", "属性提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txt_orther.Focus();
                    txt_orther.SelectAll();
                    return;
                }
            }


            //判断其它这个文本框是否为空，为空不进行操作
            if (txt_orther.Text.Trim() == string.Empty || txt_orther.Text == "比如说商品的尺寸")
            {
                txt_orther.Focus();
                MessageBox.Show("请输入内容再操作", "添加属性提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int orthercount = 0;
            foreach (var item in list_orther.Items)
            {
                if (item.ToString().Trim() != string.Empty)
                {
                    orthercount++;
                }
            }
            if (orthercount == 10)
            {
                MessageBox.Show("最大支持输入10个属性", "属性提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string ss = string.Empty;//循环判断是否是没有添加任何属性如果是的话就要删除那几个字
            foreach (var item in list_orther.Items)
            {
                if (item.ToString().Trim() != string.Empty)
                {
                    ss += item.ToString().Trim();
                }
            }
            if (ss == "没有任何属性")
            {
                list_orther.Items.Clear();
                list_orther.Font = new Font(list_orther.Font.FontFamily, 9);
                list_orther.ForeColor = label11.ForeColor;
            }

            list_orther.ItemHeight = 255;
            list_orther.Items.Add("");//提升行距
            list_orther.Items.Add("   " + txt_orther.Text);
            list_orther.Items.Add("");//提升行距
            ckb_isororther.Checked = true;//因为属性有值了所以要选中它
            txt_orther.Text = "";//清空
        }

        private void btn_list_clear_Click(object sender, EventArgs e)//点击清空所有属性按钮
        {
            //list_orther.Items.Clear();

            list_orther.Items.Clear();
            list_orther.ForeColor = txt_xiangxi_forecolor;

            list_orther.Font = new Font(list_orther.Font.FontFamily, 15);

            string[] sx = { "没", "有", "任", "何", "属", "性" };
            List<string> lsx = new List<string>();
            lsx.AddRange(sx);

            foreach (var item in lsx)
            {
                list_orther.ItemHeight = 255;
                list_orther.Items.Add("");//提升行距
                list_orther.Items.Add("    " + item);
                list_orther.Items.Add("");//提升行距 
            }

            ckb_isororther.Checked = false;


        }

        private void txt_orther_TextChanged(object sender, EventArgs e)//txt_orther控件内的文字发生该便的时候
        {
            txt_orther.ForeColor = label7.ForeColor;
            if (txt_orther.Text.Trim() == "比如说商品的尺寸")
            {
                txt_orther.ForeColor = txt_xiangxi_forecolor;
            }
        }

        private void txt_orther_Enter(object sender, EventArgs e)//txt_orther获得焦点的时候
        {
            if (txt_orther.Text.Trim() == "比如说商品的尺寸")
            {
                txt_orther.Text = string.Empty;
            }
            AcceptButton = btn_addorther;//默认enter为添加属性
        }

        private void txt_orther_Leave(object sender, EventArgs e)//txt_orther不再是焦点的时候
        {
            if (txt_orther.Text.Trim() == string.Empty)
            {
                txt_orther.Text = "比如说商品的尺寸";
            }
            AcceptButton = btn_addcom;//默认enter为添加商品
        }

        /// <summary>
        /// 当选择第一图片后，这个变量将会记录着这个图片的路径，然后每次检测它是否为空，
        /// 空的话就是默认路径，不是的话采用这个路径，达到浏览上次目录的效果
        /// </summary>
        string yuanpath = string.Empty;

        /// <summary>
        /// 因为此方法将会重复调用，所以写成方法，注意：第一次的文件路径为指定路径。
        /// 当选择第一图片后，这个变量将会记录着这个图片的路径，然后每次检测它是否为空， 
        /// 空的话就是默认路径，不是的话采用这个路径，达到浏览上次目录的效果
        /// </summary>
        /// <param name="pic">要装入的图片框的name</param>
        /// <param name="lab">要隐藏的label提示</param>
        /// <param name="btn">要改变button上面的button</param>
        private void pic_de_yuanpath(PictureBox pic, Label lab,Button btn)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择图片";
            ofd.Filter = "所有文件(*.*)|*.*|图片文件(*.jpg)|*.jpg|图片文件(*.png)|*.png|图片文件(*.bmp)|*.bmp";
            ofd.FilterIndex = 2;
            if (string.Empty == yuanpath)
            {
                ofd.InitialDirectory = Application.StartupPath + "\\image\\";
            }
            else
            {
                ofd.InitialDirectory = yuanpath;
            }

            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                yuanpath = ofd.FileName.Substring(0, ofd.FileName.LastIndexOf("\\"));
                pic.Image = Image.FromFile(ofd.FileName);
                lab.Visible = false;
                pic.BorderStyle = BorderStyle.None;
                btn.Text = "重选大图";
            }
        }

        private void btn_picda_Click(object sender, EventArgs e)//点击选择大图的按钮
        {
            pic_de_yuanpath(pic_daico, lab_daico,btn_picda);//调用浏览目录方法
        }

        private void btn_picx1_Click(object sender, EventArgs e)//点击了选择小图1的按钮
        { 
            pic_de_yuanpath(pic_xiao1, lab_pic_xiao1,btn_picx1);//调用浏览目录方法
        }

        private void btn_picx2_Click(object sender, EventArgs e)//点击了选择小图2的按钮
        {
             pic_de_yuanpath(pic_xiao2, lab_pic_xiao2,btn_picx2);//调用浏览目录方法
        }

        private void btn_picx3_Click(object sender, EventArgs e)//点击了选择小图3的按钮
        {
             pic_de_yuanpath(pic_xiao3, lab_pic_xiao3,btn_picx3);//调用浏览目录方法
        }




        private void btn_addcom_Click(object sender, EventArgs e)//点击了添加商品的按钮
        {
            //判断快递公司
            if (cmb_wuliugongsi.Text == "请选择")
            {
                MessageBox.Show("请选择商品的物流公司", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmb_wuliugongsi.Focus();
                return;
            }


            //判断库存是否正确
            int s = 0;
            if (!int.TryParse(txt_kucun.Text, out s))
            {
                MessageBox.Show("请正确输入不带负数0-9的阿拉伯数字", "库存提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_kucun.Focus();
                txt_kucun.SelectAll();
                return;
            }
            //判断售价是否正确
            try
            {
                Convert.ToDecimal(txt_shoujia.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("非法字符！请正确输入价格,应为 0 -- 9 包括一个小数点的数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_shoujia.SelectAll();
                txt_shoujia.Focus();
                return;
            }


            //判断是否还有未添加的属性
            if (txt_orther.Text.Trim() != string.Empty && txt_orther.Text != "比如说商品的尺寸")
            {
                DialogResult result = MessageBox.Show("该商品存在未添加属性\"" + txt_orther.Text + "\"请问你是想立即添加吗？", "属性提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    btn_addorther_Click(sender, e);
                }
            }
            //在插入数据库之前先判断商品是否已经存在过
            string sqlcunzai = "select * from commodity where comid = " + Convert.ToInt32(txt_comid.Text);
            if (sqlHelper.ExecutChaXun(sqlcunzai) >= 1)
            {
                MessageBox.Show("商品已经存在了，你可以选择点击修改商品信息按钮", "添加商品提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comididid = int.Parse(txt_comid.Text);
                return;
            }

            #region 检查图片是否都装进去了
            foreach (Control item in Controls)
            {
                if (item is PictureBox)
                {
                    PictureBox p = (PictureBox)item;
                    if (p.Image == null)
                    {
                        MessageBox.Show("请选择好商品的图片", "图片提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            #endregion

            insertcommdity();//直接调用插入商品  此方法舍弃，因为下面使用了三层架构

            MessageBox.Show(string.Format("商品“{0}”添加成功", txt_name.Text), "添加商品提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            comididid = int.Parse(txt_comid.Text);
        }

        /// <summary>
        /// 添加到商品库的方法，供给添加商品还有更新商品用的
        /// </summary>
        public void insertcommdity()// 添加到商品库的方法
        {
            #region 三层架构插入商品数据
            commodity c = new commodity();
            c.Comid = int.Parse(txt_comid.Text);
            c.Username = love.denglu_username == string.Empty ? "a" : love.denglu_username;//如果这个是空的话说明这个是在软件的测试阶段，不是空的话说明它是通过了登陆键来赋值的
            c.Name = txt_name.Text;
            c.Shoujia = int.Parse(txt_shoujia.Text);
            c.Kuadi = cmb_wuliugongsi.Text;
            c.Kucun = int.Parse(txt_kucun.Text);
            c.Isbaoyou = ckb_isbaoyou.Checked ? "是" : "否";
            c.Yuexiaoliang = int.Parse(num_yuexiaoliang.Value.ToString());
            //c.Adddatetime    自动使用日期时间
            c.Scd = txt_scd.Text;
            #region c.Isorcolor赋值  判断是否选择了有颜色pannel，并且有颜色chekbox被选中了，然后才赋值
            int colorcount = 0;
            foreach (Control item in pan_iscolor.Controls)
            {
                if (item is CheckBox)
                {
                    CheckBox ck = (CheckBox)item;
                    if (ck.Checked)
                    {
                        colorcount++;
                    }
                }
            }
            if (ckb_isorcolor.Checked && colorcount != 0)
            {
                c.Isorcolor = "有";
            }
            else
            {
                c.Isorcolor = "无";
            }
            #endregion
            #region c.Isororther赋值   判断是否选择了有其它pannel，并且有其它色chekbox被选中了，然后才赋值
            int orthercount = 0;
            foreach (var item in list_orther.Items)
            {
                if (item.ToString().Trim() != string.Empty)
                {
                    orthercount++;
                }
            }
            if (ckb_isororther.Checked && orthercount != 0)
            {
                c.Isororther = "有";
            }
            else
            {
                c.Isororther = "无";
            }
            #endregion
            c.Xiangxi = txt_xiangxi.Text == "这里键入你的产品介绍，或者你想对买家说的话。" ? "" : txt_xiangxi.Text;
            c.Picda = sqlHelper.tiqupic(pic_daico, Application.StartupPath + @"\image\a.jpg");
            c.Pic1 = sqlHelper.tiqupic(pic_xiao1, Application.StartupPath + @"\image\a.jpg");
            c.Pic2 = sqlHelper.tiqupic(pic_xiao2, Application.StartupPath + @"\image\a.jpg");
            c.Pic3 = sqlHelper.tiqupic(pic_xiao3, Application.StartupPath + @"\image\a.jpg");
            c.addcommodity();//执行业务层插入的方法
            #region 循环添加颜色
            if (c.Isorcolor == "有")
            {
                commditycolor.Clear();//首先清除颜色的集合
                foreach (Control item in pan_iscolor.Controls)
                {
                    if (item is CheckBox)
                    {
                        CheckBox ck = (CheckBox)item;
                        if (ck.Checked)
                        {
                            commditycolor.Add(ck.Text);
                        }
                    }
                }
                foreach (var item in commditycolor)
                {
                    comcolor co = new comcolor();
                    co.Comid = int.Parse(txt_comid.Text);
                    co.Color = item.ToString();
                    co.insertcolor();//执行插入
                }
            }
            #endregion
            #region 循环添加其它
            if (c.Isororther == "有")
            {
                commdityorther.Clear();
                foreach (var item in list_orther.Items)
                {
                    if (item.ToString().Trim() != string.Empty)
                    {
                        commdityorther.Add(item.ToString().Trim());
                    }
                }
                foreach (var item in commdityorther)
                {
                    comorther ct = new comorther();
                    ct.Comid = int.Parse(txt_comid.Text);
                    ct.Orther = item;
                    ct.insertorther();
                }
            }
            #endregion
            #endregion
        }

        private void btn_delete_Click(object sender, EventArgs e)//点击了删除商品的按钮
        {
            string sql = string.Format("select * from commodity where comid = '{0}'", int.Parse(txt_comid.Text));
            DataTable d = sqlHelper.ExecutedataTable(sql, CommandType.Text, null);
            if (d.Rows.Count == 0)      //首先判断是否添加过商品，这个值初始值为0，点击添加商品的时候会被赋值
            {
                MessageBox.Show(string.Format("请先添加商品\"{0}\"之后才能进行删除操作", txt_comid.Text), "删除商品提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //注意删除商品是根据商品的id来进行判断的
            //在插入数据库之前先判断商品是否已经存在过 


            if (txt_comid.Text.Trim() == string.Empty)
            {
                DialogResult result = MessageBox.Show
                    ("没有对应的商品id！不能删除这个哟，\r想要删除请填写好商品对应的id号\r程序已经在你按下提交到商品库的就捕获了您的商品id号，\r是否想要智能填写？",
                    "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    txt_comid.Text = comididid.ToString();
                }
                return;
            }

            if (comididid != 0)
            {
                DialogResult delresult = MessageBox.Show("你真的要删除商品 " + comididid.ToString() + " 吗?", "删除警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (delresult == DialogResult.Yes)//在删除之前询问是否真的要删除
                {
                    string sqldecolor = "delete comcolor where comid = " + comididid;//先删除颜色
                    sqlHelper.ExecuteCommand(sqldecolor, CommandType.Text, null);
                    string sqldeorhter = "delete comorther where comid = " + comididid;//再删除其它
                    sqlHelper.ExecuteCommand(sqldeorhter, CommandType.Text, null);
                    string sqldeletecommodity = "delete commodity where comid = " + comididid;//然后才能删除商品，因为商品是上面两个的主键
                    sqlHelper.ExecuteCommand(sqldeletecommodity, CommandType.Text, null);
                    MessageBox.Show("商品 " + comididid.ToString() + " 已经删除", "删除商品提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("商品 " + comididid.ToString() + " 没有删除哦", "删除商品提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)//点击了清空所有的按钮
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                else if (item is PictureBox)
                {
                    PictureBox p = (PictureBox)item;
                    p.Image = null;
                }
                else if (item is Label)
                {
                    item.Visible = true;
                }
            }
            ckb_isbaoyou.Checked = false;
            ckb_isorcolor.Checked = false;
            txt_orther.Text = string.Empty;
            txt_xiangxi.Text = string.Empty;
            txt_orther.Text = "比如说商品的尺寸";
            list_orther.Items.Clear();

            list_orther.Items.Clear();
            list_orther.ForeColor = txt_xiangxi_forecolor;

            list_orther.Font = new Font(list_orther.Font.FontFamily, 15);

            string[] sx = { "没", "有", "任", "何", "属", "性" };
            List<string> lsx = new List<string>();
            lsx.AddRange(sx);

            foreach (var item in lsx)
            {
                list_orther.ItemHeight = 255;
                list_orther.Items.Add("");//提升行距
                list_orther.Items.Add("    " + item);
                list_orther.Items.Add("");//提升行距 
            }


        }

        private void btn_update_Click(object sender, EventArgs e)//点击了修改商品的按钮
        {

            //判断库存是否正确
            int s = 0;
            if (!int.TryParse(txt_kucun.Text, out s))
            {
                MessageBox.Show("请正确输入不带负数0-9的阿拉伯数字", "库存提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_kucun.Focus();
                txt_kucun.SelectAll();
                return;
            }
            //判断售价是否正确
            try
            {
                Convert.ToDecimal(txt_shoujia.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("非法字符！请正确输入价格,应为 0 -- 9 包括一个小数点的数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_shoujia.SelectAll();
                txt_shoujia.Focus();
                return;
            }

            //判断快递公司
            if (cmb_wuliugongsi.Text == "请选择")
            {
                MessageBox.Show("请选择商品的物流公司", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmb_wuliugongsi.Focus();
                return;
            }

            if (comididid != 0 && comididid != int.Parse(txt_comid.Text))
            {
                MessageBox.Show("不能修改商品的id，因为它是唯一的，现在已经为你还原", "属性提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                txt_comid.Text = comididid.ToString();
                txt_comid.Focus();
                txt_comid.SelectAll();
                return;
            }

            #region 检查图片是否都装进去了
            foreach (Control item in Controls)
            {
                if (item is PictureBox)
                {
                    PictureBox p = (PictureBox)item;
                    if (p.Image == null)
                    {
                        MessageBox.Show("请选择图片", "图片未选择提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
            }
            #endregion
            //先删除后添加达到更新的效果
            commodity cm = new commodity();
            cm.Comid = int.Parse(txt_comid.Text);
            cm.delete();

            insertcommdity();//直接调用插入商品
            MessageBox.Show(string.Format("修改“{0}”商品成功", txt_name.Text), "修改提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            comididid = int.Parse(txt_comid.Text);
        }
        private void txt_comid_Leave(object sender, EventArgs e)//离开价id本框的时候
        {
            try
            {
                Convert.ToInt32(txt_comid.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("非法字符！请正确输入 0 -- 9 的数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_comid.SelectAll();
                txt_comid.Focus();
            }
        }

        private void txt_xiangxi_Enter(object sender, EventArgs e)//txt_xiangxi文本框获得焦点
        {
            if (txt_xiangxi.Text == "这里键入你的产品介绍，或者你想对买家说的话。")
            {
                txt_xiangxi.Text = "";
                txt_xiangxi.ForeColor = label1.ForeColor;
            }
        }

        private void txt_xiangxi_Leave(object sender, EventArgs e)//txt_xiangxi文本框失去焦点
        {
            if (txt_xiangxi.Text.Trim() == string.Empty)
            {
                txt_xiangxi.Text = "这里键入你的产品介绍，或者你想对买家说的话。";
                txt_xiangxi.ForeColor = txt_xiangxi_forecolor;
            }
        }

        private void btn_clearallpic_Click(object sender, EventArgs e)//点击了重选所有图片的按钮
        {
            foreach (Control item in Controls)
            {
                if (item is PictureBox)
                {
                    PictureBox p = (PictureBox)item;
                    p.Image = null;
                }
            }
            lab_daico.Visible = true;
            lab_pic_xiao1.Visible = true;
            lab_pic_xiao2.Visible = true;
            lab_pic_xiao3.Visible = true;
        }

        private void btn_cleda_Click(object sender, EventArgs e)//点击了清空大图的按钮
        {
            pic_daico.Image = null;
            pic_daico.BorderStyle = BorderStyle.FixedSingle;
            lab_daico.Visible = true;
            btn_picda.Text = "选择大图";
        }

        private void btn_chopic1_Click(object sender, EventArgs e)//点击了清空小图1的按钮
        {
            pic_xiao1.Image = null;
            pic_xiao1.BorderStyle = BorderStyle.FixedSingle;
            lab_pic_xiao1.Visible = true;
            btn_picx1.Text = "选择详图";
        }

        private void btn_clearpic2_Click(object sender, EventArgs e)//点击了清空小图2的按钮
        {
            pic_xiao2.Image = null; 
            pic_xiao2.BorderStyle = BorderStyle.FixedSingle;
            lab_pic_xiao2.Visible = true;
            btn_picx2.Text = "选择详图";
        }

        private void btn_clearpic3_Click(object sender, EventArgs e)//点击了清空小图3的按钮
        {
            pic_xiao3.Image = null;
            pic_xiao3.BorderStyle = BorderStyle.FixedSingle;
            lab_pic_xiao3.Visible = true;
            btn_picx3.Text = "选择详图";
        }

        private void ckb_isororther_CheckedChanged(object sender, EventArgs e)//是否有其它的checked
        {
            //if (ckb_isororther.Checked)
            //{
            //    pan_orther.Enabled = true;
            //}
            //else
            //{
            //    pan_orther.Enabled = false;
            //}
            if (ckb_isororther.Checked == false)
            {
                list_orther.Items.Clear();
                list_orther.ForeColor = txt_xiangxi_forecolor;

                list_orther.Font = new Font(list_orther.Font.FontFamily, 15);

                string[] sx = { "没", "有", "任", "何", "属", "性" };
                List<string> lsx = new List<string>();
                lsx.AddRange(sx);

                foreach (var item in lsx)
                {
                    list_orther.ItemHeight = 255;
                    list_orther.Items.Add("");//提升行距
                    list_orther.Items.Add("    " + item);
                    list_orther.Items.Add("");//提升行距 
                }
            }
        }

        private void txt_kucun_Validating(object sender, CancelEventArgs e)//库存框的验证事件
        {

        }

        private void txt_comid_TextChanged(object sender, EventArgs e)//id框的验证事件
        {
            if (txt_comid.Text.ToString().IndexOf("0") == 0)
            {
                MessageBox.Show("不能以0开头", "id提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_comid.Focus();
                txt_comid.SelectAll();
                txt_comid.Text = txt_comid.Text.Substring(1); //减去0
                return;
            }

            int s = 0;
            if (!int.TryParse(txt_comid.Text, out s))
            {
                MessageBox.Show("请正确输入不带负数0-9不带小数点的阿拉伯数字", "库存提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_comid.Focus();
                txt_comid.SelectAll();

            }
        }

        private void txt_xiangxi_TextChanged(object sender, EventArgs e)//详细框字体改变
        {
            //if (txt_xiangxi.Text=="这里键入你的产品介绍，或者你想对买家说的话。")
            //{
            //    txt_xiangxi.ForeColor = txt_xiangxi_forecolor;

            //}
        }

        private void txt_name_Leave(object sender, EventArgs e)//离开商品名文本框的事件
        {
            if (txt_name.Text.Length>30)
            {
                MessageBox.Show("商品名字不能超过30个字哦！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_name.Focus();
                txt_name.SelectAll();
            }
        }

    }
}