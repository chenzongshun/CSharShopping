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
    public partial class Frm_SelldeGoods : Form
    {
        public Frm_SelldeGoods()
        {
            InitializeComponent();
        }

        private void Frm_SelldeGoods_Load(object sender, EventArgs e)
        {
            Frm_Login f = new Frm_Login();
            Icon = f.Icon;
            foreach (Control i in Controls)
            {
                if (i == pan_goods) continue;
                i.Anchor = AnchorStyles.None;
            }
            sckjmen();
            tiemzou();
            //tiemzou2();
            lab_tip1.Left = pan_goods.Left;
            love.meihua(this);
            lab_tip1.Text = string.Format("爱尚购公告：亲爱的 {0} ，多添加商品可以增添收益噢！Ｏ(≧口≦)Ｏ", love.denglu_username == string.Empty ? "a" : love.denglu_username);

            //pan_goods.BackColor = Color.Transparent;
 
        }

        #region 左右悬浮动画
        //开始
        /// <summary>
        /// 在load方法写入此方法即可
        /// </summary>
        private void tiemzou()
        {
            lab_tip.Location = new Point(pan_goods.Width + 1 - lab_tip.Width, lab_tip.Location.Y);//记得要把控件的左边拉到窗体的左边，否则下面的方法不生效
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
            if (lab_tip.Left < pan_goods.Left)
            {
                t22222.Enabled = true;
                t33333.Enabled = false;
            }
            if (lab_tip.Right >= pan_goods.Width - 30)      //=w的值已经被定死了，所以一改变窗体的大小就会失效
            {
                t22222.Enabled = false;
                t33333.Enabled = true;
            }
        }
        //结束
        #endregion

        #region 左右悬浮动画
        //开始
        /// <summary>
        /// 在load方法写入此方法即可
        /// </summary>
        private void tiemzou2()
        {
            lab_tip1.Left = -1;//记得要把控件的左边拉到窗体的左边，否则下面的方法不生效
            t1.Enabled = true;
            t2.Enabled = false;
            t3.Enabled = false;
            t1.Interval = 1;
            t2.Interval = 1;
            t3.Interval = 1;
            t1.Tick += new EventHandler(t1_Tick);
            t2.Tick += new EventHandler(t2_Tick);
            t3.Tick += new EventHandler(t3_Tick);
        }

        Timer t1 = new Timer(); Timer t2 = new Timer(); Timer t3 = new Timer();

        void t3_Tick(object sender, EventArgs e) { right1(lab_tip1); }
        void t2_Tick(object sender, EventArgs e) { left1(lab_tip1); }
        public static void left1(Label l) { l.Left += 1; }
        public static void right1(Label l) { l.Left -= 1; }

        void t1_Tick(object sender, EventArgs e)
        {
            if (lab_tip1.Left <= Left)
            {
                t2.Enabled = true;
                t3.Enabled = false;
            }
            if (lab_tip1.Right >= Width)      //=w的值已经被定死了，所以一改变窗体的大小就会失效
            {
                t2.Enabled = false;
                t3.Enabled = true;
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
            //查询有关于这个卖家的数据
            string sql = string.Format("select * from goods where selledname = '{0}'", love.denglu_username == string.Empty ? "a" : love.denglu_username);
            DataTable d = sqlHelper.ExecutedataTable(sql, CommandType.Text, null);

            //查询总金额
            string fdas = string.Format("select sum(fkje) from goods where goods.selledname = '{0}'", love.denglu_username == string.Empty ? "a" : love.denglu_username);
            DataTable jlk = sqlHelper.ExecutedataTable(fdas, CommandType.Text, null);
            string zongjinge = string.Empty;//总金额
            try
            {
                zongjinge = jlk.Rows[0][0].ToString();//如果没有金额就会出错
                lab_tip.Text = string.Format("tip：亲爱的 {0} （づ￣3￣）づ╭❤～，你总共售出了 {1} 件商品，总共获得盈利 {2} 元，再接再厉哦！", love.denglu_username == string.Empty ? "a" : love.denglu_username, d.Rows.Count.ToString(), zongjinge.ToString());
            }
            catch (Exception)
            {
                lab_tip.Text = string.Format("tip：亲爱的 {0} （づ￣3￣）づ╭❤～，你总共售出了 {1} 件商品，总共获得盈利 {2} 元，再接再厉哦！", love.denglu_username == string.Empty ? "a" : love.denglu_username, d.Rows.Count.ToString(), 0);
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
                    pan_gs.Location = new Point((pan_goods.Width - pan_gs.Width) / 2, pan_goods.Top + 5);//x等于平均，y等于最外的pannel，最外的自带内边距，y轴不加
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
                //					

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
                fktime.Location = new Point(fkje.Left + 150, fkje.Top);

                Label cmid = new Label();//商品编号
                cmid.AutoSize = true;
                cmid.Text = "商品编号： " + d.Rows[i]["cmid"].ToString();
                cmid.Location = new Point(fkje.Left, fkje.Bottom);

                Label pjdh = new Label();//评价单号
                pjdh.AutoSize = true;
                pjdh.Text = "订单编号：" + d.Rows[i]["pjdh"].ToString();
                pjdh.Location = new Point(cmid.Left + 150, cmid.Top);

                goods ggg = new goods();
                ggg.Pjdh = long.Parse(d.Rows[i]["pjdh"].ToString());
                if (ggg.isorneirong())//ture说明没有评价内容，也没有评价星级，那么就开始评价
                {
                    //开始获取买家的昵称
                    string strnc = string.Format("select nicheng from buyde where username= '{0}'", d.Rows[i]["buydename"].ToString());
                    DataTable dtnc = sqlHelper.ExecutedataTable(strnc, CommandType.Text, null);

                    Label pjren = new Label();//评价人的昵称
                    pjren.Text = "买家名称： " + dtnc.Rows[0]["nicheng"].ToString();
                    pjren.Tag = "pjren";
                    pjren.AutoSize = true;
                    pan_gs.Controls.Add(pjren);
                    pjren.Location = new Point(cmid.Left, cmid.Bottom);


                    Label pjnr = new Label();//评价者的
                    pjnr.Text = "买家 " + dtnc.Rows[0]["nicheng"].ToString() + " 对此次交易暂时未给出评价";
                    pjnr.Tag = "pjnr";
                    pjnr.AutoSize = true;
                    pan_gs.Controls.Add(pjnr);
                    pjnr.Location = new Point(pjren.Left, pjren.Bottom + pjren.Height);

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
                    pjtime.Location = new Point(pjxj.Right + 240, pjxj.Top);//240五颗星位置
                    pan_gs.Controls.Add(pjtime);


                    Label neirong = new Label();//评价内容
                    neirong.AutoSize = true;
                    neirong.Text = "评价内容：" + tabxj.Rows[0]["neirong"].ToString();
                    neirong.Location = new Point(pjxj.Left, pjxj.Bottom + pjxj.Height);
                    pan_gs.Controls.Add(neirong);

                    //开始获取买家的昵称
                    string strnc = string.Format("select nicheng from buyde where username= '{0}'", d.Rows[i]["buydename"].ToString());
                    DataTable dtnc = sqlHelper.ExecutedataTable(strnc, CommandType.Text, null);

                    Label pjren = new Label();//评价人的昵称
                    pjren.Text = "买家名称： " + dtnc.Rows[0]["nicheng"].ToString();
                    pjren.Tag = "pjren";
                    pjren.AutoSize = true;
                    pan_gs.Controls.Add(pjren);
                    pjren.Location = new Point(pjdh.Right + 50, pjdh.Top);



                }
                //pan_gs.ForeColor = Color.Transparent;
                Control[] ctl = { pjdh, cmid, comname, compic, fkje, fktime };
                pan_gs.Controls.AddRange(ctl);

                Button bbb = new Button();
                pan_goods.Controls.Add(bbb);
                bbb.Location = new Point(100, 100);//让它来承载焦点，否则将会自动把焦点赋予给星级框
                bbb.Focus();


            }//订单循环结束 
        }
    }
}
