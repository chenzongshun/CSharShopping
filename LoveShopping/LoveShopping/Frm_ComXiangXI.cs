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

namespace LoveShopping
{
    public partial class Frm_ComXiangXI : Form
    {
        public Frm_ComXiangXI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 在load时记录下灰灰色的字体
        /// </summary>
        Color hui;

        /// <summary>
        /// 记录着当前正在浏览的的id，记得没有浏览商品的时候要清空它
        /// </summary>
        string dangqianid = "";

        private void Frm_ComXiangXI_Load(object sender, EventArgs e)
        {
            MinimumSize = new Size(1087, 637);//因为它小于这个值显示不好
            foreach (Control i in Controls)
            {
                i.Anchor = AnchorStyles.None;
            }
            Frm_Login f = new Frm_Login();
            Icon = f.Icon;
            update_dgv();//刷新商品表数据

            //为combox物流公司填入信息
            string[] wuliu ={
            "请选择","顺丰","中通","圆通","申通","韵达","汇通","天天","中国邮政","EMS","宅急送","德邦物流","国通快递","佳吉快运","中铁快运","速尔快递",
            "中邮物流","能达速递","全峰快递","快捷速递","联邦快递FedEx","DHL","优速快递","天地华宇","全日通快递","信丰物流","新邦物流","UPS快递",
            "TNT国际快递","盛辉物流","中外运全一","佳怡物流","飞康达物流","联昊通快递"};
            cmb_wuliugongsi.Items.AddRange(wuliu);

            cmb_wuliugongsi.FlatStyle = FlatStyle.Popup;
            //cmb_wuliugongsi.DropDownStyle = ComboBoxStyle.DropDownList;
            dgv_data.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//行居中
            dgv_data.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//列居中
            dgv_data.AllowUserToResizeColumns = false;//不允许更改列宽 
            hui = txt_orther.ForeColor;//记录下灰色字体 

            dgv_data.AutoResizeColumn(7);//时间列指定自动适应宽度

            lab_daico.Visible = lab_pic_xiao1.Visible = lab_pic_xiao2.Visible = lab_pic_xiao3.Visible = false;

            foreach (Control item in Controls)
            {
                if (item is Label || item is CheckBox || item is PictureBox || item is GroupBox || item is Button || item is Panel)
                {
                    item.BackColor = Color.Transparent;
                }
                if (item is PictureBox)
                {
                    PictureBox bbb = (PictureBox)item;
                    bbb.BorderStyle = BorderStyle.None;
                }
                if (item is Button)
                {
                    Button bbb = (Button)item;
                    SetBtnStyle(bbb);
                }
            }

            SetBtnStyle(btn_addorther);
            SetBtnStyle(btn_allcolor);
            SetBtnStyle(btn_list_clear);  
        }

        /// <summary>  
        /// 设置透明按钮样式  
        /// </summary>  
        private void SetBtnStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;//样式  
            //btn.ForeColor = Color.Transparent;//前景   
            //btn.BackColor = Color.Transparent;//去背景  
            btn.FlatAppearance.BorderSize = 1;//去边线  
            
            //btn.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过  
            //btn.FlatAppearance.MouseOverBackColor = Color.Black;
           
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下  
        }  

        /// <summary>
        /// 存储着商品拥有的颜色
        /// </summary>
        List<string> commditycolor = new List<string>();

        /// <summary>
        /// 存储着商品的其它属性
        /// </summary>
        List<string> commdityorther = new List<string>();

        /// <summary>
        /// 刷新商品表格dgv的数据
        /// </summary>
        public void update_dgv()
        {
            commodity c = new commodity();
            c.Username = love.denglu_username == string.Empty ? "a" : love.denglu_username;//如果为null说明它不是登陆进来的，而是调试过程中产生的
            dgv_data.DataSource = c.selectall();
        }

        private void dgv_data_CellEnter(object sender, DataGridViewCellEventArgs e)//数据表获得焦点
        {
            // isorcolor	isororther	 	picda	pic1	pic2	pic3
            DataGridViewRow dgvr = dgv_data.CurrentRow;
            string id = dgvr.Cells[0].Value.ToString();
            dangqianid = id.ToString();
            string sql = string.Format("select * from commodity where comid = {0}", id);
            DataTable d = sqlHelper.ExecutedataTable(sql, CommandType.Text, null);
            lab_comid.Text = d.Rows[0]["comid"].ToString();
            txt_name.Text = d.Rows[0]["name"].ToString();
            txt_shoujia.Text = d.Rows[0]["shoujia"].ToString();
            dtp_adddatetime.Value = (DateTime)d.Rows[0]["adddatetime"];
            txt_kucun.Text = d.Rows[0]["kucun"].ToString();
            txt_scd.Text = d.Rows[0]["scd"].ToString();
            cmb_wuliugongsi.Text = d.Rows[0]["kuadi"].ToString();
            if (d.Rows[0]["isbaoyou"].ToString() == "是")
            {
                ckb_isbaoyou.Checked = true;

            }
            else
            {
                ckb_isbaoyou.Checked = false;
            }
            sqlHelper.imagechu(string.Format("select picda from commodity where comid = {0}", lab_comid.Text), pic_daico);
            sqlHelper.imagechu(string.Format("select pic1 from commodity where comid = {0}", lab_comid.Text), pic_xiao1);
            sqlHelper.imagechu(string.Format("select pic2 from commodity where comid = {0}", lab_comid.Text), pic_xiao2);
            sqlHelper.imagechu(string.Format("select pic3 from commodity where comid = {0}", lab_comid.Text), pic_xiao3);
            txt_xiangxi.Text = d.Rows[0]["xiangxi"].ToString();
            if (d.Rows[0]["isororther"].ToString() == "有")
            {
                ckb_isororther.Checked = true;
                #region 为listbox加入数据库中的选项
                string color = string.Format("select * from comorther where comid = {0}", id);
                DataTable dt = sqlHelper.ExecutedataTable(color, CommandType.Text, null);

                list_orther.Items.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list_orther.ItemHeight = 255;
                    list_orther.Items.Add("");//提升行距
                    list_orther.Items.Add("   " + dt.Rows[i][1].ToString());
                    list_orther.Items.Add("");//提升行距 
                }
                #endregion
                list_orther.ForeColor = label12.ForeColor;
                list_orther.Font = new Font(list_orther.Font.FontFamily, 9);
            }
            else
            {
                list_orther.Items.Clear();
                list_orther.ForeColor = hui;

                if (txt_orther.Text == "比如说商品的尺寸")//因为第一次出现时它的颜色并不是灰灰色
                {
                    list_orther.ForeColor = txt_orther.ForeColor;
                }

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
            if (d.Rows[0]["isorcolor"].ToString() == "有")
            {
                //foreach (Control i in pan_iscolor.Controls)//首先清空所有颜色，不然下一个商品的颜色会
                //{
                //    if (i is CheckBox)
                //    {
                //        CheckBox ck = (CheckBox)i;
                //        ck.Checked = false;
                //    }
                //}                
                ckb_isorcolor.Checked = true;
                #region 选中数据库中拥有的颜色
                //如果有的话那么就要查看哪些颜色被选择了
                string color = string.Format("select * from comcolor where comid = {0}", id);
                DataTable dt = sqlHelper.ExecutedataTable(color, CommandType.Text, null);

                List<string> sqlcomdcolor = new List<string>();//存储数据库中拥有的颜色

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sqlcomdcolor.Add(dt.Rows[i][1].ToString());
                }

                foreach (Control i in pan_iscolor.Controls)
                {
                    if (i is CheckBox)//循环所有的复选框
                    {
                        CheckBox ck = (CheckBox)i;
                        if (sqlcomdcolor.Contains(ck.Text))//如果有这个选项就选中它
                        {
                            ck.Checked = true;
                        }
                        else
                        {
                            ck.Checked = false;
                        }
                    }
                }
                #endregion
            }
            else
            {
                ckb_isorcolor.Checked = false;
                foreach (Control i in pan_iscolor.Controls)
                {
                    if (i is CheckBox)//循环所有的复选框
                    {
                        CheckBox ck = (CheckBox)i;
                        ck.Checked = false;
                    }
                }
            }

            //如果颜色是空的话那么就要变颜色给提示
            if (txt_xiangxi.Text.Trim() == string.Empty)
            {
                txt_xiangxi.Text = "这里键入你的产品介绍，或者你想对买家说的话。";
                txt_xiangxi.ForeColor = hui;
            }

        }

        private void btn_delete_Click(object sender, EventArgs e)//点击删除商品按钮
        {
            DialogResult delresult = MessageBox.Show("你真的要删除商品\" " + txt_name.Text.Trim() + " \"吗?", "删除警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (delresult == DialogResult.Yes)//在删除之前询问是否真的要删除
            {
                string sqldecolor = "delete comcolor where comid = " + dangqianid;//先删除颜色
                sqlHelper.ExecuteCommand(sqldecolor, CommandType.Text, null);
                string sqldeorhter = "delete comorther where comid = " + dangqianid;//再删除其它
                sqlHelper.ExecuteCommand(sqldeorhter, CommandType.Text, null);
                string sqldeletecommodity = "delete commodity where comid = " + dangqianid;//然后才能删除商品，因为商品是上面两个的主键
                sqlHelper.ExecuteCommand(sqldeletecommodity, CommandType.Text, null);
                MessageBox.Show("商品 " + dangqianid.ToString() + " 已经删除", "删除商品提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                update_dgv();
            }
            else
            {
                MessageBox.Show("商品 " + dangqianid.ToString() + " 没有删除哦", "删除商品提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btn_allcolor_Click(object sender, EventArgs e)//点击选择所有颜色的按钮
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
                ckb_isorcolor.Checked = false;
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

            list_orther.Font = new Font(list_orther.Font.FontFamily, 9);
            list_orther.ForeColor = label13.ForeColor;

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
            }

            //结束
            list_orther.ItemHeight = 255;
            list_orther.Items.Add("");//提升行距
            list_orther.Items.Add("   " + txt_orther.Text);
            list_orther.Items.Add("");//提升行距

            ckb_isororther.Checked = true;

            txt_orther.Text = "";//清空
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
        private void pic_de_yuanpath(PictureBox pic, Label lab, Button btn)
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
                btn.Text = "重选大图";
            }
        }

        private void btn_picda_Click(object sender, EventArgs e)//点击选择大图的按钮
        {
            pic_de_yuanpath(pic_daico, lab_daico, btn_picda);//调用浏览目录方法
        }

        private void btn_picx1_Click(object sender, EventArgs e)//点击了选择小图1的按钮
        {
            pic_de_yuanpath(pic_xiao1, lab_pic_xiao1, btn_picx1);//调用浏览目录方法
        }

        private void btn_picx2_Click(object sender, EventArgs e)//点击了选择小图2的按钮
        {
            pic_de_yuanpath(pic_xiao2, lab_pic_xiao2, btn_picx2);//调用浏览目录方法
        }

        private void btn_picx3_Click(object sender, EventArgs e)//点击了选择小图3的按钮
        {
            pic_de_yuanpath(pic_xiao3, lab_pic_xiao3, btn_picx3);//调用浏览目录方法
        }

        private void btn_clearpicda_Click(object sender, EventArgs e)//点击了清空大图的按钮
        {
            pic_daico.Image = null;
            lab_daico.Visible = true;
            btn_picda.Text = "选择大图";
        }

        private void btn_clearpic1_Click(object sender, EventArgs e)//点击了清空小图1的按钮
        {
            pic_xiao1.Image = null;
            lab_pic_xiao1.Visible = true;
            btn_picx1.Text = "选择详图";
        }

        private void btn_clearpic2_Click(object sender, EventArgs e)//点击了清空小图2的按钮
        {
            pic_xiao2.Image = null;
            lab_pic_xiao2.Visible = true;
            btn_picx2.Text = "选择详图";
        }

        private void btn_clearpic3_Click(object sender, EventArgs e)//点击了清空小图3的按钮
        {
            pic_xiao3.Image = null;
            lab_pic_xiao3.Visible = true;
            btn_picx3.Text = "选择详图";
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
                txt_xiangxi.ForeColor = hui;
            }
        }

        private void txt_orther_Leave(object sender, EventArgs e)//txt_orther不再是焦点的时候
        {
            if (txt_orther.Text.Trim() == string.Empty)
            {
                txt_orther.Text = "比如说商品的尺寸";
            }
            AcceptButton = btn_update;//默认enter为修改按钮
        }

        private void txt_orther_Enter(object sender, EventArgs e)//txt_orther获得焦点的时候
        {
            if (txt_orther.Text.Trim() == "比如说商品的尺寸")
            {
                txt_orther.Text = string.Empty;
            }
            AcceptButton = btn_addorther;//默认enter为添加属性
        }

        private void txt_orther_TextChanged(object sender, EventArgs e)//txt_orther控件内的文字发生该便的时候
        {
            txt_orther.ForeColor = label7.ForeColor;
            if (txt_orther.Text.Trim() == "比如说商品的尺寸")
            {
                txt_orther.ForeColor = hui;
            }
        }

        private void txt_xiangxi_TextChanged(object sender, EventArgs e)//详细框字体改变事件
        {
            if (txt_xiangxi.Text.Trim() != "这里键入你的产品介绍，或者你想对买家说的话。")
            {
                txt_xiangxi.ForeColor = label11.ForeColor;
            }
        }

        private void btn_shuaxin_Click(object sender, EventArgs e)//点击刷新的按钮
        {
            update_dgv();
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
        }

        private void btn_update_Click(object sender, EventArgs e)//点击了修改商品的按钮
        {

            //判断是否还有未添加的属性
            if (txt_orther.Text.Trim() != string.Empty && txt_orther.Text != "比如说商品的尺寸")
            {
                DialogResult result = MessageBox.Show("该商品存在未添加属性\"" + txt_orther.Text + "\"请问你是想立即添加吗？", "属性提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    btn_addorther_Click(sender, e);
                }
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

            updatecommodity();
            MessageBox.Show("商品 \"" + txt_name.Text + " \"的商品信息修改成功", "修改提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            update_dgv();
        }

        public void updatecommodity()// 修改商品的方法
        {
            commodity c = new commodity();
            c.Kucun = int.Parse(txt_kucun.Text);
            c.Name = txt_name.Text;
            c.Shoujia = decimal.Parse(txt_shoujia.Text);
            c.Scd = txt_scd.Text;
            c.Kuadi = cmb_wuliugongsi.Text;
            c.Adddatetime = dtp_adddatetime.Value;
            c.Isbaoyou = ckb_isbaoyou.Checked ? "是" : "否";
            c.Picda = sqlHelper.tiqupic(pic_daico, Application.StartupPath + "\\asdf.jpg");
            c.Pic1 = sqlHelper.tiqupic(pic_xiao1, Application.StartupPath + "\\asdf.jpg");
            c.Pic2 = sqlHelper.tiqupic(pic_xiao2, Application.StartupPath + "\\asdf.jpg");
            c.Pic3 = sqlHelper.tiqupic(pic_xiao3, Application.StartupPath + "\\asdf.jpg");
            c.Comid = int.Parse(dangqianid);
            c.Xiangxi = txt_xiangxi.Text == "这里键入你的产品介绍，或者你想对买家说的话。" ? "" : txt_xiangxi.Text;

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
            //判断是否写的是没有任何属性
            string ss = string.Empty;//循环判断是否是没有添加任何属性如果是的话就要赋值无
            foreach (var item in list_orther.Items)
            {
                if (item.ToString().Trim() != string.Empty)
                {
                    ss += item.ToString().Trim();
                }
            }
            //必须要选择了有其它并且在数量不等于1的情况下值不为 没有任何属性
            if ((ckb_isororther.Checked && orthercount != 0) && ss != "没有任何属性")
            {
                c.Isororther = "有";
            }
            else
            {
                c.Isororther = "无";
            }

            c.IsXiangXiupdate();
            #endregion

            #region 循环添加颜色
            if (c.Isorcolor == "有")
            {
                //首先删除所有颜色，然后再插入
                string sqldecolor = "delete comcolor where comid = " + dangqianid;//先删除颜色
                sqlHelper.ExecuteCommand(sqldecolor, CommandType.Text, null);

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
                    co.Comid = int.Parse(dangqianid);
                    co.Color = item.ToString();
                    co.insertcolor();//执行插入
                }
            }
            else
            {
                //既然没有颜色那么就要删除掉数据库中的所有颜色
                string sqldecolor = "delete comcolor where comid = " + dangqianid;//先删除颜色
                sqlHelper.ExecuteCommand(sqldecolor, CommandType.Text, null);
            }

            #endregion
            #region 循环添加其它
            if (c.Isororther == "有")
            {
                //首先删除所有其它，然后再插入
                string sqldeorhter = "delete comorther where comid = " + dangqianid;//再删除其它
                sqlHelper.ExecuteCommand(sqldeorhter, CommandType.Text, null);

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
                    ct.Comid = int.Parse(dangqianid);
                    ct.Orther = item;
                    ct.insertorther();
                }
            }
            else
            {
                //既然没有其它那么就要把其它从数据库中清空
                string sqldeorhter = "delete comorther where comid = " + dangqianid;//再删除其它
                sqlHelper.ExecuteCommand(sqldeorhter, CommandType.Text, null);
            }
            #endregion
        }

        private void ckb_isorcolor_CheckedChanged(object sender, EventArgs e)//点击了是否有颜色的复选框
        {
            if (ckb_isorcolor.Checked)
            {
                pan_iscolor.Enabled = true;
                //btn_clearcolor.Enabled = true;
            }
            else
            {
                //pan_iscolor.Enabled = false;
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

        private void ckb_isororther_CheckedChanged(object sender, EventArgs e)//点击了是否有其它分类的复选框
        {
            if (ckb_isororther.Checked)
            {
                pan_orther.Enabled = true;
            }
            else
            {
                //pan_orther.Enabled = false;
            }
            if (!ckb_isororther.Checked)
            {
                //list_orther.Items.Clear();
            }
        }

        private void btn_list_clear_Click(object sender, EventArgs e)//点击了清空其它的按钮
        {
            list_orther.Items.Clear();
            list_orther.ForeColor = hui;

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

        private void txt_name_Leave(object sender, EventArgs e)//离开商品名文本框的时候
        {
            if (txt_name.Text.Length > 30)
            {
                MessageBox.Show("商品名字的长度不能超过30哦！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_name.Focus();
                txt_name.SelectAll();
            }
        }

        private void ckb_cheng_Click(object sender, EventArgs e)//点击了橙色，所有颜色共用了这个事件
        {
            ckb_isorcolor.Checked = true;
        }  
    }
}
