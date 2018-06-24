using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;
using love_BLL;
using love_DAL;

namespace LoveShopping
{
    public partial class Frm_LiuLanComPa : Form
    {
        public Frm_LiuLanComPa()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 记录着pannel最新的location
        /// </summary>
        Point new_pannel_location = new Point(20, 20);

        /// <summary>
        /// 记录着pannel2最新的location
        /// </summary>
        Point new_pannel2_location = new Point(440, 20);


        private void Frm_LiuLanCom_Load(object sender, EventArgs e)
        {
            btn_add.Visible = false;

            foreach (Control i in Controls)
            {
                i.Anchor = AnchorStyles.None;
            }
            Frm_Login f = new Frm_Login();
            Icon = f.Icon;
            AutoScroll = true;

            commodity commodity = new commodity();
            DataTable d = commodity.allcommodity();
            allcount = d.Rows.Count;//记录下商品的总行数
            for (int i = 0; i < allcount; i++)
            {
                comrows.Add(i);//循环添加行数到商品行号集合
            }
            //Text = comrows.Count.ToString();//查看行数

            //程序进来就给看一个商品
            //Random sjs = new Random();
            //int dangqian = sjs.Next(0, comrows.Count);//记录下随机到的行号
            //yigecom(comrows[dangqian]);//pannel控件显示某行的商品
            //comrows.Remove(comrows[dangqian]);//每次都要把用过的值给清理掉
            while (log)
            {
                btn_add_Click(sender, e);
            }
        }

        /// <summary>
        /// 存储商品的行号，一行就是一个商品
        /// </summary>
        List<int> comrows = new List<int>();

        /// <summary>
        /// 记录下商品在数据库中的总行数
        /// </summary>
        int allcount = 0;

        bool log = true;

        private void btn_add_Click(object sender, EventArgs e)//点击了添加按钮
        {
            if (comrows.Count == 0)
            {
                log = false;
                //MessageBox.Show("没有更多数据");
                return;//显示完了没有数据可以显示了，那么就要把它终止掉，不然会让下面移除代码comrows.Remove(comrows[dangqian]);程序bug掉，因为没有这个值可以移除了
            }

            Random sjs = new Random();
            int dangqian = sjs.Next(0, comrows.Count);//记录下随机到的行号
            yigecom(comrows[dangqian]);//pannel控件显示某行的商品
            comrows.Remove(comrows[dangqian]);//每次都要把用过的值给清理掉

            int dangqian2 = sjs.Next(0, comrows.Count);//记录下随机到的行号
            yigecom1(comrows[dangqian2]);//pannel控件显示某行的商品
            comrows.Remove(comrows[dangqian2]);//每次都要把用过的值给清理掉





            //MessageBox.Show(comrows.Count.ToString());
        }

        /// <summary>
        /// 返回一个带商品的pannel显示在窗体
        /// </summary>
        void yigecom1(int rows1)
        {
            //comid	username	name	shoujia	kuadi	kucun	isbaoyou	yuexiaoliang	adddatetime	scd	isorcolor	isororther	xiangxi	picda	pic1	pic2	pic3
            commodity commodity1 = new commodity();
            DataTable d1 = commodity1.allcommodity();

            Panel pn1 = new Panel();//负责装一个商品
            Controls.Add(pn1);
            pn1.BorderStyle = BorderStyle.FixedSingle;
            //pn.Location = new Point(20, 20);
            pn1.Location = new_pannel2_location;//使用最新的pannel
            pn1.Size = new Size(400, 140);

            PictureBox picda1 = new PictureBox();//商品的大图片
            picda1.SizeMode = PictureBoxSizeMode.Zoom;
            picda1.Size = new Size(100, 100);
            picda1.Location = new Point(20, 20);
            picda1.BorderStyle = BorderStyle.FixedSingle;
            pn1.Controls.Add(picda1);
            sqlHelper.imagechu(d1.Rows[rows1]["picda"], picda1);//显示出图片 

            Label name1 = new Label();//商品
            name1.Text = "商品：" + d1.Rows[rows1]["name"].ToString();
            name1.Location = new Point(picda1.Location.X + picda1.Width + 50, picda1.Location.Y + 20);
            pn1.Controls.Add(name1);//位置等于图片框的x坐标加上大图片宽家20像素，加图宽是因为它要显示在图片的右边，必须超出来，y坐标就是大图片框的y坐标加20

            Label yuexiaoliang1 = new Label();//月销量
            yuexiaoliang1.Text = "月销：" + d1.Rows[rows1]["yuexiaoliang"].ToString();
            yuexiaoliang1.Location = new Point(name1.Location.X, name1.Location.Y + name1.Height);
            pn1.Controls.Add(yuexiaoliang1);

            Label shoujia1 = new Label();//售价
            shoujia1.Text = "售价：" + d1.Rows[rows1]["shoujia"].ToString();
            shoujia1.Location = new Point(name1.Location.X, yuexiaoliang1.Location.Y + yuexiaoliang1.Height);
            pn1.Controls.Add(shoujia1);

            Label kuadi1 = new Label();//快递
            kuadi1.Text = "快递：" + d1.Rows[rows1]["kuadi"].ToString();
            kuadi1.Location = new Point(name1.Location.X + name1.Width + 5, name1.Location.Y);//开始第二行了，所有y直接用商品名的y
            pn1.Controls.Add(kuadi1);
            //comid	username isbaoyou adddatetime isorcolor	isororther	xiangxi	pic1	pic2	pic3

            Label kucun1 = new Label();//库存
            kucun1.Text = "库存：" + d1.Rows[rows1]["kucun"].ToString();
            kucun1.Location = new Point(kuadi1.Location.X, kuadi1.Location.Y + kuadi1.Height);
            pn1.Controls.Add(kucun1);

            Label scd1 = new Label();//生产地
            scd1.Text = "产地：" + d1.Rows[rows1]["scd"].ToString();
            scd1.Location = new Point(kucun1.Location.X, kucun1.Location.Y + kucun1.Height);
            pn1.Controls.Add(scd1);

            new_pannel2_location = pn1.Location;//记录下最新的location
            //Point ppp = new Point(panpo.X, panpo.Y + pn.Height + 20);//y轴加pannel高加20作为下一个pannel的位置
            Point ppp1 = new Point(new_pannel2_location.X, pn1.Location.Y + pn1.Height + 20);//y轴加pannel高加20作为下一个pannel的位置
            new_pannel2_location = ppp1;//这里不能直接new新位置所以只能用赋值的方式进行
 
            pn1.BackColor = Color.Transparent;
            picda1.BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// 返回一个带商品的pannel显示在窗体
        /// </summary>
        void yigecom(int rows)
        {
            //comid	username	name	shoujia	kuadi	kucun	isbaoyou	yuexiaoliang	adddatetime	scd	isorcolor	isororther	xiangxi	picda	pic1	pic2	pic3
            commodity commodity = new commodity();
            DataTable d = commodity.allcommodity();

            Panel pn = new Panel();//负责装一个商品
            Controls.Add(pn);
            pn.BorderStyle = BorderStyle.FixedSingle;
            //pn.Location = new Point(20, 20);
            pn.Location = new_pannel_location;//使用最新的pannel
            pn.Size = new Size(400, 140);

            PictureBox picda = new PictureBox();//商品的大图片
            picda.SizeMode = PictureBoxSizeMode.Zoom;
            picda.Size = new Size(100, 100);
            picda.Location = new Point(20, 20);
            picda.BorderStyle = BorderStyle.FixedSingle;
            pn.Controls.Add(picda);
            sqlHelper.imagechu(d.Rows[rows]["picda"], picda);//显示出图片 

            Label name = new Label();//商品
            name.Text = "商品：" + d.Rows[rows]["name"].ToString();
            name.Location = new Point(picda.Location.X + picda.Width + 50, picda.Location.Y + 20);
            pn.Controls.Add(name);//位置等于图片框的x坐标加上大图片宽家20像素，加图宽是因为它要显示在图片的右边，必须超出来，y坐标就是大图片框的y坐标加20

            Label yuexiaoliang = new Label();//月销量
            yuexiaoliang.Text = "月销：" + d.Rows[rows]["yuexiaoliang"].ToString();
            yuexiaoliang.Location = new Point(name.Location.X, name.Location.Y + name.Height);
            pn.Controls.Add(yuexiaoliang);

            Label shoujia = new Label();//售价
            shoujia.Text = "售价：" + d.Rows[rows]["shoujia"].ToString();
            shoujia.Location = new Point(name.Location.X, yuexiaoliang.Location.Y + yuexiaoliang.Height);
            pn.Controls.Add(shoujia);

            Label kuadi = new Label();//快递
            kuadi.Text = "快递：" + d.Rows[rows]["kuadi"].ToString();
            kuadi.Location = new Point(name.Location.X + name.Width + 5, name.Location.Y);//开始第二行了，所有y直接用商品名的y
            pn.Controls.Add(kuadi);
            //comid	username isbaoyou adddatetime isorcolor	isororther	xiangxi	pic1	pic2	pic3

            Label kucun = new Label();//库存
            kucun.Text = "库存：" + d.Rows[rows]["kucun"].ToString();
            kucun.Location = new Point(kuadi.Location.X, kuadi.Location.Y + kuadi.Height);
            pn.Controls.Add(kucun);

            Label scd = new Label();//生产地
            scd.Text = "产地：" + d.Rows[rows]["scd"].ToString();
            scd.Location = new Point(kucun.Location.X, kucun.Location.Y + kucun.Height);
            pn.Controls.Add(scd);

            new_pannel_location = pn.Location;//记录下最新的location
            //Point ppp = new Point(panpo.X, panpo.Y + pn.Height + 20);//y轴加pannel高加20作为下一个pannel的位置
            Point ppp = new Point(new_pannel_location.X, pn.Location.Y + pn.Height + 20);//y轴加pannel高加20作为下一个pannel的位置
            new_pannel_location = ppp;//这里不能直接new新位置所以只能用赋值的方式进行

            Label p = new Label();
            p.Text = d.Rows[rows]["comid"].ToString();
            pn.Controls.Add(p);
            p.Size = new Size(1000, 1000);
            p.Location = new Point(pn.Location.X - 100, pn.Location.Y - 100);


            pn.Name = d.Rows[rows]["comid"].ToString();
            pn.Click += new EventHandler(pn_Click);

            pn.BackColor = Color.Transparent;
            picda.BorderStyle = BorderStyle.None;



            foreach (Control item in pn.Controls)
            {
                item.Name= d.Rows[rows]["comid"].ToString();
                item.Click+=new EventHandler(pn_Click);
            }
        }


        void pn_Click(object sender, EventArgs e)
        {
            //((Control)sender).Name获取到商品id

        }
 




    }
}
