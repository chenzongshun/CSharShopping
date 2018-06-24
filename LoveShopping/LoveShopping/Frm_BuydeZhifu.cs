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
using System.Data.SqlClient;
using System.Configuration;


namespace LoveShopping
{
    public partial class Frm_BuydeZhifu : Form
    {
        public Frm_BuydeZhifu()
        {
            InitializeComponent();
        }

        #region 左右悬浮动画
        //开始
        /// <summary>
        /// 在load方法写入此方法即可
        /// </summary>
        private void tiemzou()
        {
            lab_tip.Left = Width - (lab_tip.Width + 1);//记得要把控件的左边拉到窗体的左边，否则下面的方法不生效
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
            if (lab_tip.Left == lab_comname.Location.X-120)
            {
                t22222.Enabled = true;
                t33333.Enabled = false;
            }
            if (lab_tip.Right >= Width - 15)
            {
                t22222.Enabled = false;
                t33333.Enabled = true;
            }
        }
        //结束
        #endregion

        /// <summary>
        /// 查看是否购买成功了，如果交易成功将会变成true
        /// </summary>
        bool isorcg = false;

        SqlConnection shoppin = new SqlConnection(ConfigurationManager.ConnectionStrings["loveshopping"].ConnectionString);

        private void frm_buydeZhifu_Load(object sender, EventArgs e)
        {
            Frm_Login f = new Frm_Login();
            Icon = f.Icon;
            foreach (Control i in Controls)
            {
                i.Anchor = AnchorStyles.None;
            }
            //在Frm_Login窗体里给 id 登陆名下了一个定义  代码love.buyde_id = txt_username.Text;
            //string id = love.buyde_id;//获取到买家的账号id
            //string sql = string.Format("select b.username,c.name,c.shoujia,c.kuadi,b.zhenname,b.telephone,b.shouhuodizhi,b.yue,c.shoujia,c.picda  from commodity c,buyde b where comid={0} and b.username='{1}'",
            //    love.goumaiid == string.Empty ? "1" : love.goumaiid, love.denglu_username == string.Empty ? "b" : love.denglu_username);//这里的商品id记得到时候需要调

            string sql = string.Format("select b.username,c.name,c.shoujia,c.kuadi,b.zhenname,b.telephone,b.shouhuodizhi,b.yue,c.shoujia,c.picda  from commodity c,buyde b where comid={0}",
                love.goumaiid == string.Empty ? "1" : love.goumaiid);//这里的商品id记得到时候需要调

            DataTable d = sqlHelper.ExecutedataTable(sql, CommandType.Text, null);

            lab_Buyde_id.Text = d.Rows[0]["username"].ToString();//第一行的 列表名为“username”下面的内容
            lab_comname.Text = d.Rows[0]["name"].ToString();
            lab_shoujia.Text = d.Rows[0]["shoujia"].ToString();
            lab_kuaidi.Text = d.Rows[0]["kuadi"].ToString();
            txt_ZFbuydeName.Text = d.Rows[0]["zhenname"].ToString();
            txt_telephone.Text = d.Rows[0]["telephone"].ToString();
            txt_ZFShouhuoDZ.Text = d.Rows[0]["shouhuodizhi"].ToString();
            lab_buydeyue.Text = d.Rows[0]["yue"].ToString();
            lab_zfje.Text = d.Rows[0]["shoujia"].ToString();
            sqlHelper.imagechu(d.Rows[0]["picda"], pic_com);

            //Point point = new Point(lab_lo_or_location.Location.X, lab_lo_or_location.Location.Y + 45);//用收货地址下面的位置 
            Point point = new Point(lab_comname.Right + 30, lab_comname.Top);//用收货地址下面的位置 
            Label ll = new Label();
            if (love.goumaicolor != string.Empty)
            {
                ll.Location = point;
                Controls.Add(ll);
                ll.Width = 200;
                ll.Text = "所选颜色分类：" + love.goumaicolor + "色";
            }
            if (love.goumaiorther != string.Empty)
            {
                if (ll.Text.Length == 0)//说明没有颜色
                {
                    ll.Location = point;
                    Controls.Add(ll);
                    ll.Width = 200;
                    ll.Text = "你选择的商品分类为：\" " + love.goumaiorther + " \"";
                }
                else
                {
                    ll.Text += "、" + love.goumaiorther;
                }
            }
            else
            {
                Controls.Remove(ll);
            }
            ll.Anchor = AnchorStyles.None;
            love.goumaicolor = string.Empty;//用完就清空
            love.goumaiorther = string.Empty;//用完就清空

            love.meihua(this);

            lab_tip.Text = string.Format("亲爱的 {0} ╭(╯3╰)╮，最近有不法分子做假软件骗钱，注意保管你的财务。^-^", love.denglu_username == string.Empty ? "b" : love.denglu_username);

            tiemzou();

        }

        private void txt_telephone_Leave(object sender, EventArgs e)//离开电话文本框的事件
        {
            try
            {
                long.Parse(txt_telephone.Text);
            }
            catch
            {
                MessageBox.Show("请正确输入手机号码", "手机号错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_telephone.Focus();
                txt_telephone.SelectAll();
            }
        }

        public event EventHandler zjbz;//申明事件

        private void btn_OK_Click(object sender, EventArgs e)//点击了付款的按钮
        {
            if (isorcg)//判断是否交易成功了
            {
                DialogResult dr = MessageBox.Show("亲！你已经付款成功了哟！是否返回订单表查看你的订单信息？", "付款提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    //打开订单表
                    //Hide();
                    Frm_BuydeGoods f = new Frm_BuydeGoods();
                    f.ShowDialog();
                    //Show();
                }
                else
                {
                    Close();//订单表被关闭后关闭此页回到商品表
                }
                return;
            }
            //开始判断金额是否足够
            if (decimal.Parse(lab_buydeyue.Text) < decimal.Parse(lab_zfje.Text))
            {
                MessageBox.Show("余额不足，请充值(๑•﹏•)。", "余额不足提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;//不让它执行数据库插入动作
            }

            //开始确认订单
            //订单信息
            string ddxx = string.Format(@"

商品名称：{0}

物流公司：{1}

收 货 人：{2}

收货电话：{3}

收货地址：{4}

你的余额：{5}

应付金额：{6}

交易后的余额：{7}", 
           
           lab_comname.Text, lab_kuaidi.Text, txt_ZFbuydeName.Text, txt_telephone.Text, txt_ZFShouhuoDZ.Text,
           lab_buydeyue.Text, lab_shoujia.Text, decimal.Parse(lab_buydeyue.Text) - decimal.Parse(lab_shoujia.Text));
            DialogResult qrdd = MessageBox.Show(ddxx, "确认订单信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (qrdd == DialogResult.No)
            {
                return;
            }
 
            //下面开始为两家数据库的余额进行操作
            if (shoppin.State == ConnectionState.Closed) shoppin.Open();
            SqlTransaction st = shoppin.BeginTransaction();
            SqlCommand cmd1 = new SqlCommand(string.Format("update buyde set yue-={0} where username = 'b'", lab_shoujia.Text), shoppin);
            SqlCommand cmd2 = new SqlCommand(string.Format("update sellde set yue+={0}  where username = 'a'", lab_shoujia.Text), shoppin);
            cmd1.Transaction = st;
            cmd2.Transaction = st;
            if (cmd1.ExecuteNonQuery() + cmd2.ExecuteNonQuery() == 2)
            {
                st.Commit();
                isorcg = true;
                MessageBox.Show("购买成功！╭(╯3╰)╮", "交易提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //下面开始插入订单表数据库            
                goods g = new goods();
                g.Cmid = long.Parse(love.goumaiid == string.Empty ? "1" : love.goumaiid);//商品id
                g.Comname = lab_comname.Text;//商品名
                //查到商品的持有者
                string username = string.Format("select username from commodity where comid = {0}", g.Cmid);
                DataTable d = sqlHelper.ExecutedataTable(username, CommandType.Text, null);
                g.Selledname = d.Rows[0][0].ToString();//用户名
                g.Buydename = lab_Buyde_id.Text;//买家名
                g.Fkje = decimal.Parse(lab_zfje.Text);//应该付款金额
                g.Compic = sqlHelper.tiqupic(pic_com, Application.StartupPath + "\\image\\jfkljfklsdjkflsdjflksajdkfj.jpg");
                g.insertgoods();//插入到订单表，插入到数据库
                //开始刷新余额
                lab_buydeyue.Text = sqlHelper.ExecutedataTable(string.Format("select yue from buyde where username = '{0}'", lab_Buyde_id.Text), CommandType.Text, null).Rows[0][0].ToString();

                //直接进入订单表
 
 
                if (this.Parent != null)
                {
                    Frm_BuydeZhifu f = new Frm_BuydeZhifu();
                    f.TopLevel = false;
                    f.Parent = this.Parent;
                    f.Show();
                    f.BringToFront();
                }
                else
                {
                    Hide();
                    Frm_BuydeZhifu f = new Frm_BuydeZhifu();
                    f.ShowDialog();
                    Show();
                }
                 
                //Show(); 

            }
            else        
            {
                MessageBox.Show("出错，请稍后重试","提示", MessageBoxButtons.OK,MessageBoxIcon.Error);
                st.Rollback();//回滚事务
            }

        }

        private void btn_cancle_Click(object sender, EventArgs e)//点击了取消付款的按钮
        {
            Close();
        }

        private void Frm_BuydeZhifu_Deactivate(object sender, EventArgs e)//窗体被停用就关闭它
        {
            Close();
        }
    }
}
