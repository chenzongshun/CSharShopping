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
    public partial class Frm_BuydeGoods : Form
    {
        public Frm_BuydeGoods()
        {
            InitializeComponent();
        }



        private void Frm_BuydeGoods_Load(object sender, EventArgs e)
        {
            Frm_Login f = new Frm_Login();
            Icon = f.Icon;
            foreach (Control i in Controls)
            {
                if (i == pan_goods) continue;
                i.Anchor = AnchorStyles.None;
            }
            sckjmen();
            foreach (Control item in Controls)
            {
                if (item is Label || item is CheckBox || item is PictureBox || item is GroupBox || item is Button || item is Panel)
                {
                    item.BackColor = Color.Transparent;
                }
            }
            tiemzou();
        }


        #region 左右悬浮动画
        //开始
        /// <summary>
        /// 在load方法写入此方法即可
        /// </summary>
        private void tiemzou()
        {
            lab_tip.Left = pan_goods.Width + 1 - lab_tip.Width;//记得要把控件的左边拉到窗体的左边，否则下面的方法不生效
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
            if (lab_tip.Left <= pan_goods.Left)
            {
                t22222.Enabled = true;
                t33333.Enabled = false;
            }
            if (lab_tip.Right >= pan_goods.Width - 20)      //=w的值已经被定死了，所以一改变窗体的大小就会失效
            {
                t22222.Enabled = false;
                t33333.Enabled = true;
            }
        }
        //结束
        #endregion

        /// <summary>
        /// 代码生成数据库中的订单数据
        /// </summary>
        void sckjmen()
        {
            for (int i = 0; i < 10; i++)//重新载入订单表需要清空生的控件们
            {
                foreach (Control item in pan_goods.Controls)
                {
                    if (item == lab_tip) continue;//除了悬浮提示外其它的都清除，然后重新再生成，达到刷新的效果
                    pan_goods.Controls.Remove(item);
                }
            }
            //查询有关于这个买家的数据
            string sql = string.Format("select * from goods where buydename = '{0}'", love.denglu_username == string.Empty ? "b" : love.denglu_username);
            DataTable d = sqlHelper.ExecutedataTable(sql, CommandType.Text, null);

            //查询总金额
            string fdas = string.Format("select sum(fkje) from goods where goods.buydename = '{0}'", love.denglu_username == string.Empty ? "b" : love.denglu_username);
            DataTable jlk = sqlHelper.ExecutedataTable(fdas, CommandType.Text, null);
            string zongjinge = string.Empty;//总金额
            try
            {
                zongjinge = jlk.Rows[0][0].ToString();//如果没有金额就会出错
                lab_tip.Text = string.Format("tip：亲爱的 {0} ，你总共购买了 {1} 件商品，总共交易金额 {2} 元", love.denglu_username == string.Empty ? "b" : love.denglu_username, d.Rows.Count.ToString(), zongjinge.ToString());
            }
            catch (Exception)
            {
                lab_tip.Text = string.Format("tip：亲爱的 {0} ，你总共购买了 {1} 件商品，总共交易金额 {2} 元", love.denglu_username == string.Empty ? "b" : love.denglu_username, d.Rows.Count.ToString(), 0);
                throw;
            }

            Point panzuixin = new Point();//用来记录下pannel的最新的位置，一个pannel一个商品订单
            bool bol = true;//如果pannel是第一次诞生那么他是true，否则会false
            for (int i = 0; i < d.Rows.Count; i++)//有多少个订单就循环多少次
            {
                Panel pan_gs = new Panel();//用来记录下最新的位置
                pan_goods.Controls.Add(pan_gs);
                pan_gs.BorderStyle = BorderStyle.FixedSingle;
                pan_gs.Size = new Size(pan_goods.Width - 80, 140);
                #region pan_gs的位置算法
                if (bol)//说明它是第一次诞生
                {
                    bol = false;//说明有过了第一个pannel
                    pan_gs.Location = new Point((pan_goods.Width - pan_gs.Width) / 2, pan_goods.Top + 20);//x等于平均，y等于最外的pannel，最外的自带内边距，y轴不加
                    Point poc = new Point(pan_gs.Location.X, pan_gs.Location.Y + pan_gs.Height + 20);//第一个pannel的x，y加20像素
                    panzuixin = poc;//把第一次的我位置传出去
                }
                else//如果不是第一次诞生就使用上次的位置y轴加20像素
                {
                    pan_gs.Location = panzuixin;
                    Point poc = new Point(pan_gs.Location.X, pan_gs.Location.Y + pan_gs.Height + 20);//第一个pannel的x，y加20像素
                    panzuixin = poc;//把最后一个pannel的位置传出去
                }
                #endregion 				

                PictureBox compic = new PictureBox();//商品图片
                compic.Name = "compic";
                compic.SizeMode = PictureBoxSizeMode.Zoom;
                compic.Size = new Size(120, 120);
                sqlHelper.imagechu(d.Rows[i]["compic"], compic);
                //compic.BorderStyle = BorderStyle.FixedSingle;
                compic.Location = new Point(25, (pan_gs.Height - compic.Height) / 2);


                Label comname = new Label();//商品名
                comname.AutoSize = true;
                comname.Text = "商品名称： " + d.Rows[i]["comname"].ToString();
                comname.Location = new Point(compic.Right + 30, compic.Top + 7);

                Label fkje = new Label();//付款金额
                fkje.AutoSize = true;
                fkje.Text = "付款金额： " + d.Rows[i]["fkje"].ToString();
                fkje.Location = new Point(comname.Left, comname.Bottom);

                Label fktime = new Label();//付款时间
                fktime.AutoSize = true;
                fktime.Text = "付款时间：" + d.Rows[i]["fktime"].ToString();
                fktime.Location = new Point(fkje.Left + 120, fkje.Top);

                Label cmid = new Label();//商品编号
                cmid.AutoSize = true;
                cmid.Text = "商品编号： " + d.Rows[i]["cmid"].ToString();
                cmid.Location = new Point(fkje.Left, fkje.Bottom);

                Label pjdh = new Label();//评价单号
                pjdh.AutoSize = true;
                pjdh.Text = "订单编号：" + d.Rows[i]["pjdh"].ToString();
                pjdh.Location = new Point(fktime.Left, cmid.Top);



                //获取昵称
                Label sellednicheng = new Label();//卖家昵称 
                sellednicheng.AutoSize = true;
                string nnc = string.Format("select nicheng from sellde where username = '{0}'", d.Rows[i]["selledname"].ToString());
                sellednicheng.Text = "卖家昵称：" + sqlHelper.ExecutedataTable(nnc, CommandType.Text, null).Rows[0][0].ToString();
                sellednicheng.Location = new Point(fktime.Right + 100, fktime.Location.Y);


                goods ggg = new goods();
                ggg.Pjdh = long.Parse(d.Rows[i]["pjdh"].ToString());
                if (ggg.isorneirong())//ture说明没有评价内容，也没有评价星级，那么就开始评价
                {
                    Label xj1 = new Label();
                    xj1.Text = "我想给";         //这里加1-5的小数框
                    xj1.Tag = "xj1";
                    xj1.AutoSize = true;
                    pan_gs.Controls.Add(xj1);
                    //                    xj1.Location = new Point(pjdh.Right + 30, pjdh.Top);
                    xj1.Location = new Point(sellednicheng.Left, pjdh.Top); 
                    NumericUpDown num = new NumericUpDown();
                    num.AutoSize = true;
                    pan_gs.Controls.Add(num);
                    num.Maximum = 5;
                    num.Width = 13;
                    num.Location = new Point(xj1.Right, xj1.Top - 4);

                    Label xj2 = new Label();
                    xj2.AutoSize = true;
                    xj2.Text = "颗星星的评价";
                    xj2.Tag = "xj2";
                    xj2.Location = new Point(num.Right, xj1.Top);
                    pan_gs.Controls.Add(xj2);

                    Label nrts = new Label();
                    pan_gs.Controls.Add(nrts);
                    nrts.Text = "评价内容：";
                    nrts.AutoSize = true;
                    //nrts.Font = new Font(nrts.Font.FontFamily, 25);
                    nrts.Location = new Point(cmid.Left, cmid.Bottom);

                    TextBox pj = new TextBox();
                    pan_gs.Controls.Add(pj);
                    pj.Multiline = true;
                    pj.Size = new Size(350, 40);
                    pj.ScrollBars = ScrollBars.Vertical;
                    pj.Location = new Point(nrts.Right, nrts.Top);


                    Button submit = new Button();
                    submit.Name = d.Rows[i]["pjdh"].ToString();//用按钮记录下单号 
                    submit.Text = "立即评价";
                    pan_gs.Controls.Add(submit);
                    submit.Location = new Point(pj.Right + 20, pj.Top + (pj.Height - submit.Height) / 2);
                    //submit.Size = new Size(submit.Size.Width, submit.Size.Height + 1);
                    submit.Click += new EventHandler(submit_Click);
                }
                else//说明评价完星级和内容了，可以开始直接显示了
                {
                    Label pjxj = new Label();
                    pan_gs.Controls.Add(pjxj);
                    pjxj.AutoSize = true;
                    pjxj.Location = new Point(cmid.Left, cmid.Bottom);
                    pjxj.Text = "评价星级：";//后面记得加上数据库的星级
                    //查询数据库的星级然后循环出对应的星星数量
                    bool diyicixx = true;//判断是否第一次产生星星
                    Point pinxx = new Point();//存储星星的最新位置
                    DataTable tabxj = sqlHelper.ExecutedataTable(string.Format("select xingji,neirong from goods where pjdh = {0}", d.Rows[i]["pjdh"].ToString()), CommandType.Text, null);
                    int jkx = int.Parse(tabxj.Rows[0]["xingji"].ToString());
                    for (int forxx = 0; forxx < jkx; forxx++)
                    {
                        PictureBox xx = new PictureBox();//星级放到评价单号的右边
                        pan_gs.Controls.Add(xx);
                        xx.Size = new Size(19, 19);//图片为19，正好盛放
                        xx.Image = Image.FromFile(Application.StartupPath + "\\image\\haop.png");//好评图片
                        if (diyicixx)
                        {
                            xx.Location = new Point(pjxj.Right, pjxj.Top - 4);
                            pinxx = new Point(xx.Right + xx.Width + 10, xx.Top);
                            diyicixx = false;//执行后说明它不是第一次运行
                        }
                        else
                        {
                            xx.Location = pinxx;
                            Point temp = new Point(xx.Right + xx.Width + 10, xx.Top);
                            pinxx = temp;
                        }
                    }


                    Label pjtime = new Label();
                    pjtime.AutoSize = true;
                    pjtime.Text = "评价时间：" + d.Rows[0]["pjtime"].ToString();
                    pjtime.Location = new Point(sellednicheng.Left, pjxj.Top);
                    pan_gs.Controls.Add(pjtime);


                    Label neirong = new Label();//评价内容
                    neirong.AutoSize = true;
                    neirong.Text = "评价内容：" + tabxj.Rows[0]["neirong"].ToString();
                    neirong.Location = new Point(pjxj.Left, pjxj.Bottom + pjxj.Height);
                    pan_gs.Controls.Add(neirong);
                }
                Control[] ctl = { pjdh, cmid, sellednicheng, comname, compic, fkje, fktime };
                pan_gs.Controls.AddRange(ctl);

                Button bbb = new Button();
                pan_goods.Controls.Add(bbb);
                bbb.Location = new Point(100, 100);//让它来承载焦点，否则将会自动把焦点赋予给星级框
                bbb.Focus();

                foreach (Control item in pan_gs.Controls)
                {
                    if (item is Button)
                    {
                        Button bb = (Button)item;
                        SetBtnStyle(bb);
                    }
                }
            }//订单循环结束 
        }


        void submit_Click(object sender, EventArgs e)//按下提交的按钮
        {

            //因为这个事按钮的事件，按钮的name被设置成为了编号，而TextBox文本框又是唯一的，所以不冲突
            //((Control)sender).Name//获取到id
            int xj = 0;//存储星级
            long pjdh = long.Parse(((Control)sender).Name);//存储订单的id
            string neirong = string.Empty;//存储评价的内容

            foreach (var item in ((Control)sender).Parent.Controls)
            {
                if (item is TextBox)
                {
                    TextBox t = (TextBox)item;
                    neirong = t.Text;//给内容赋值
                }
                if (item is NumericUpDown)//获取星级
                {
                    NumericUpDown num = (NumericUpDown)item;
                    if (num.Value == 0)
                    {
                        MessageBox.Show("不能评价为0颗星哦!", "评价星级提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    xj = int.Parse(num.Value.ToString());
                }
            }

            if (neirong.Trim() == string.Empty)
            {
                MessageBox.Show("评价内容不能为空哦！", "评价提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (neirong.Trim().Length < 5)
            {
                MessageBox.Show("评价内容不能少于5个字！", "评价提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("亲爱的客官<(￣3￣)> !只能评价一次哦，请确认好后再评价噢", "评价提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.Cancel) return;//阻止评价
            //走到这里来说明要得元素都已经要到了，该确认的也都确认了，那么就开始插入数据库
            goods gs = new goods();
            gs.Neirong = neirong;
            gs.Xingji = xj;
            gs.Pjdh = pjdh;
            gs.pjnrsjxj();//开始插入到数据库
            MessageBox.Show("亲爱的客官<(￣3￣)> !评价成功，祝您下次购物愉快", "评价提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            sckjmen();


        }


        /// <summary>  
        /// 设置透明按钮样式  
        /// </summary>  
        private void SetBtnStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;//样式  
            //btn.ForeColor = Color.Transparent;//前景  
            btn.BackColor = Color.Transparent;//去背景  
            btn.Font = new Font(btn.Font.FontFamily, btn.Font.Size, FontStyle.Bold);
            btn.FlatAppearance.BorderSize = 1;//去边线  

            //btn.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过  
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下  
        }

   
    }
}
