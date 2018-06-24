using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using System.Data.SqlClient;
using System.IO;
using love_BLL;
using love_DAL;

namespace LoveShopping
{
    public partial class Frm_LiuLanComDat : Form
    {
        public Frm_LiuLanComDat()
        {
            InitializeComponent();
        }

        //有时间添加右键

        /// <summary>
        /// datagrideview获得焦点的时候就记录下当前行的id
        /// </summary>
        string commodityid = string.Empty;

        /// <summary>
        /// 没有筛选时的所有商品
        /// </summary>
        string suoyou = "select name 商品名,shoujia 售价,isbaoyou 包邮,kuadi 快递,kucun 库存,yuexiaoliang 月销量,scd 生产地 from commodity";

        /// <summary>
        /// 默认一页显示的行数
        /// </summary>
        int hangshu = 12;

        SqlConnection server = new SqlConnection(ConfigurationManager.ConnectionStrings["loveshopping"].ConnectionString);

        private void Frm_LiuLanComDat_Load(object sender, EventArgs e)
        {

            //dgv_com.RowHeadersVisible = false;//不出现开头的空白边
            //dgv_com.ColumnHeadersVisible = false;//不出现开头的空白边
            totxt_yeshu.Text = hangshu.ToString();
            string[] y = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
            //tocmb_yeshu.Items.AddRange(y);
            //tocmb_yeshu.DropDownStyle = ComboBoxStyle.DropDownList;
            //tocmb_yeshu.SelectedIndex = 9;
            //tocmb_yeshu.FlatStyle = FlatStyle.Standard;

            btn_dgv_wushujutip.Visible = false;

            Frm_Login f = new Frm_Login();
            Icon = f.Icon;

            MinimumSize = new Size(1132, 607);
            foreach (Control item in Controls)
            {
                item.Anchor = AnchorStyles.None;
            }

            rab_xiangxi.ReadOnly = true;//不允许更改卖家介绍
            rab_xiangxi.BorderStyle = BorderStyle.FixedSingle;
            commodity com = new commodity();
            dgv_com.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_com.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_com.DataSource = com.selldecommdity();

            dgv_com.AutoGenerateColumns = false;
            dgv_com.AllowUserToResizeColumns = false;
            dgv_com.AllowUserToDeleteRows = false;
            dgv_com.AllowUserToAddRows = false;
            dgv_com.ReadOnly = true;
            dgv_com.MultiSelect = false;

            //下面分页的行、页记得不要放到分页方法里面去，因为每次执行都会初始化
            CurrentRow = 0;//当前行为0
            CurrentPage = 1;//当前页为1

            fenyegongneng();

            dgv_com.Columns[0].HeaderText = "商品名";
            dgv_com.Columns[1].HeaderText = "售价";
            dgv_com.Columns[2].HeaderText = "包邮";
            dgv_com.Columns[3].HeaderText = "快递";
            dgv_com.Columns[4].HeaderText = "库存";
            dgv_com.Columns[5].HeaderText = "月销量";
            dgv_com.Columns[6].HeaderText = "生产地";

            love.meihua(this);
        }

        BindingSource Source = new BindingSource();//创建一个数据源对象
        SqlDataAdapter da;//创建一个数据适配器对象
        DataSet ds = new DataSet();//创建一个数据集

        int PageCount = 0;//总页数 = 总行数 / 一页的行数
        int PageSize = 0;//一页的行数
        int DataSize = 0;//数据库的总记录行数
        int CurrentRow = 0;//当前行
        int CurrentPage = 0;//当前页
        DataTable dsTemp = new DataTable();//创建一个下面需要用到的数据表

        /// <summary>
        /// 使用分页的功能
        /// </summary>
        private void fenyegongneng()
        {            //如果是没有筛选的话就是所有的商品
            ds.Clear();//启用商品的搜索功能必须清除


            da = new SqlDataAdapter(suoyou, server);//将查询语句转入到适配器中，然后带回数据


            da.Fill(ds, "TTT");//将数据装入到ds数据集中去，并且为其取名为TTT
            Source.DataSource = ds.Tables["TTT"];//将数据源绑定到ds数据集的TTT表中
            DataSize = Source.Count;//数据的总行数 = 数据源的总记录行数


            PageSize = hangshu;//每一页分配12项显示
            PageCount = DataSize % PageSize == 0 ? DataSize / PageSize : DataSize / PageSize + 1;//总页数 = 总行数 / 一页的行数
            tolab_tip.Text = string.Format("第{0}页  共{1}页", CurrentPage, PageCount);//将显示的行数显示到工具栏中去
            if (DataSize > 0)           //如果数据总数大于0
            {
                int start, end = 0;//初始化开始结束
                dsTemp = ds.Tables["TTT"].Clone();//克隆TTT表的结构，注意并没有克隆TTT里面的数据  
                if (CurrentPage == PageCount)       //如果当前页 = 页的总数
                    end = DataSize;             //结束等于数据行的总行数
                else
                    end = PageSize * CurrentPage;     //结束 = 页大小 * 当前页
                start = CurrentRow;//开始 = 当前行
                for (int i = start; i < end; i++)
                {
                    CurrentRow++;       //每循环一次就要自增一次活动的单元格
                    dsTemp.ImportRow(ds.Tables["TTT"].Rows[i]); //将TTT中i这一行的数据复制到临时表中去
                }
                Source.DataSource = dsTemp;//数据源它绑定的数据为临时表  绑定几行
                dgv_com.DataSource = Source;//DataGridView控件显示的数据为Source
                bindingNavigator1.BindingSource = Source;//导航栏绑定的数据源绑定到Source
            }

        }

        private void tobtn_xia_Click(object sender, EventArgs e)//点击了下一页
        {
            if (CurrentPage == PageCount)//如果当前页等于最后一页
            {
                MessageBox.Show("已经到最后一页了", "随笔记提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;         //结束，避免下面的当前页自加
            }
            CurrentPage++;
            CurrentRow = PageSize * (CurrentPage - 1);//不管怎么样，当前行都必须为前一页的那个当前行，不然如果最后一页没有的话就会出错
            fenyegongneng();
        }

        private void tobtn_shang_Click(object sender, EventArgs e)//点击了上一页
        {
            if (CurrentPage == 1)//如果当前页等于1
            {
                MessageBox.Show("已经到第一页了", "随笔记提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;         //结束，避免下面的当前页自减
            }
            CurrentPage--;
            CurrentRow = PageSize * (CurrentPage - 1);// 当前行     = 页的行数 *   当前页数   - 1
            fenyegongneng();
        }

        private void dgv_com_CellEnter(object sender, DataGridViewCellEventArgs e)//dgv获得焦点
        {
            try
            {
                DataGridViewRow dgvr = dgv_com.CurrentRow;
                string huoquid = string.Empty;
                huoquid = string.Format("select top 1 comid from commodity where name = '{0}' and shoujia = '{1}' and isbaoyou= '{2}' and kuadi = '{3}' and kucun = '{4}'",
                        dgvr.Cells[0].Value.ToString(), dgvr.Cells[1].Value.ToString(), dgvr.Cells[2].Value.ToString(), dgvr.Cells[3].Value.ToString(),
                        dgvr.Cells[4].Value.ToString());
                //string huoquid = string.Format("select top 1 comid from commodity where name = '{0}' and shoujia = '{1}' and isbaoyou= '{2}' and kuadi = '{3}' and kucun = '{4}' and  yuexiaoliang = '{5}' and scd = '{6}'",
                //        dgvr.Cells[0].Value.ToString(), dgvr.Cells[1].Value.ToString(), dgvr.Cells[2].Value.ToString(), dgvr.Cells[3].Value.ToString(),
                //        dgvr.Cells[4].Value.ToString(), dgvr.Cells[5].Value.ToString(), dgvr.Cells[6].Value.ToString());
                DataTable d = sqlHelper.ExecutedataTable(huoquid, CommandType.Text, null);
                string comid = d.Rows[0][0].ToString();//首先获取到id
                commodityid = comid;
                string comm = string.Format("select * from commodity where comid = {0}", comid);
                DataTable commodity = sqlHelper.ExecutedataTable(comm, CommandType.Text, null);
                // 	isorcolor	isororther				pic2	pic3
                lab_name.Text = commodity.Rows[0]["name"].ToString();
                lab_shoujia.Text = commodity.Rows[0]["shoujia"].ToString();
                lab_kuadi.Text = commodity.Rows[0]["kuadi"].ToString();
                lab_kucun.Text = commodity.Rows[0]["kucun"].ToString();
                lab_isbaoyou.Text = commodity.Rows[0]["isbaoyou"].ToString();
                lab_yuexiaoliang.Text = commodity.Rows[0]["yuexiaoliang"].ToString();
                lab_scd.Text = commodity.Rows[0]["scd"].ToString();
                rab_xiangxi.Text = "卖家的介绍或说明：" + commodity.Rows[0]["xiangxi"].ToString();
                sqlHelper.imagechu(commodity.Rows[0]["picda"], pic_daico);
                sqlHelper.imagechu(commodity.Rows[0]["pic1"], pic_xiao1);
                sqlHelper.imagechu(commodity.Rows[0]["pic2"], pic_xiao2);
                sqlHelper.imagechu(commodity.Rows[0]["pic3"], pic_xiao3);
                string isorcolor = commodity.Rows[0]["isorcolor"].ToString();//有无颜色
                string isororther = commodity.Rows[0]["isororther"].ToString();
                #region 有无颜色
                if (isorcolor == "有")
                {
                    //显示之前记得先清除
                    for (int r = 0; r < 30; r++)//循环这么多是因为它清除不完全，可能VS2008有bug吧
                    {
                        foreach (Control i in grb_color.Controls)
                        {
                            if (i is RadioButton)
                            {
                                grb_color.Controls.Remove(i);
                            }
                        }
                        Update();
                    }
                    lab_color_tip.Visible = false;//关闭提示
                    string sql = "select * from comcolor where comid = " + comid;//这事enter事件里所以说这是当前选中的id
                    DataTable color = sqlHelper.ExecutedataTable(sql, CommandType.Text, null);
                    Point ppp = new Point(80, 30);
                    for (int i = 0; i < color.Rows.Count; i++)
                    {
                        RadioButton rad = new RadioButton();
                        grb_color.Controls.Add(rad);
                        rad.Text = color.Rows[i][1].ToString();
                        rad.Width = 100;
                        rad.Location = ppp;
                        Point p = new Point(ppp.X + rad.Width, ppp.Y);
                        ppp = p;
                    }
                }
                else
                {
                    lab_color_tip.Visible = true;//显示提示
                    for (int r = 0; r < 30; r++)//循环这么多是因为它清除不完全，可能VS2008有bug吧
                    {
                        foreach (Control i in grb_color.Controls)
                        {
                            if (i is RadioButton)
                            {
                                grb_color.Controls.Remove(i);
                            }
                        }
                        Update();
                    }
                }
                #endregion

                if (isororther == "有")
                {
                    //就是有其它
                    //首先清除其它
                    for (int r = 0; r < 30; r++)//循环这么多是因为它清除不完全，可能VS2008有bug吧
                    {
                        foreach (Control i in grb_orther.Controls)
                        {
                            if (i is RadioButton)
                            {
                                grb_orther.Controls.Remove(i);
                            }
                        }
                        Update();
                    }
                    lab_orther_tip.Visible = false;//隐藏提示
                    string sql = "select * from comorther where comid = " + comid;
                    DataTable orther = sqlHelper.ExecutedataTable(sql, CommandType.Text, null);
                    Point ppp = new Point(100, 35);
                    Point yuanppp = new Point(ppp.X, ppp.Y + 35);
                    for (int i = 0; i < orther.Rows.Count; i++)
                    {
                        RadioButton rad = new RadioButton();
                        grb_orther.Controls.Add(rad);
                        rad.Text = orther.Rows[i][1].ToString();
                        rad.Width = 100;
                        rad.Location = ppp;
                        Point p = new Point(ppp.X + rad.Width, ppp.Y);
                        ppp = p;


                        if (i % 2 == 0 && i != 0)//如果一行超过3个
                        {
                            Point p1 = yuanppp;
                            ppp = p1;
                        }
                    }
                }
                else
                {
                    //就是没有其它
                    lab_orther_tip.Visible = true;//隐藏提示                
                    for (int r = 0; r < 30; r++)//循环这么多是因为它清除不完全，可能VS2008有bug吧
                    {
                        foreach (Control i in grb_orther.Controls)
                        {
                            if (i is RadioButton)
                            {
                                grb_orther.Controls.Remove(i);
                            }
                        }
                        Update();
                    }
                }
            }
            catch { }
        }


        private void pic_daico_MouseMove(object sender, MouseEventArgs e)//悬浮到大图上面的时候做一个大图特效
        {

        }

        private void btn_goumai_Click(object sender, EventArgs e)//点击了购买的按钮
        {
            love.goumaiid = commodityid;
            love.goumaiorther = string.Empty;
            love.goumaicolor = string.Empty;
            string color = string.Empty, orther = string.Empty;//记录颜色和其它分类
            bool iscolor = false;//如果有颜色有其它将会变成true
            bool isorther = false;
            foreach (Control item in grb_color.Controls)
            {
                if (item is RadioButton)
                {
                    iscolor = true;
                    RadioButton b = (RadioButton)item;
                    if (b.Checked)
                    {
                        color = b.Text;
                        love.goumaicolor = color;
                    }
                }
            }
            foreach (Control item in grb_orther.Controls)
            {
                if (item is RadioButton)
                {
                    isorther = true;
                    RadioButton b = (RadioButton)item;
                    if (b.Checked)
                    {
                        orther = b.Text;
                        love.goumaiorther = orther;
                    }
                }
            }

            if (love.goumaicolor.Trim() == string.Empty && iscolor)
            {
                MessageBox.Show("你还没有选择好颜色分类咯!", "选择提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (love.goumaiorther.Trim() == string.Empty && isorther)
            {
                MessageBox.Show("你还没有选择好其它分类咯!", "选择提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
        }

        private void btn_dgv_wushujutip_Click(object sender, EventArgs e)//当数据表没有数据时点击到它时
        {
            suoyou = "select name 商品名,shoujia 售价,isbaoyou 包邮,kuadi 快递,kucun 库存,yuexiaoliang 月销量,scd 生产地 from commodity";
            btn_dgv_wushujutip.Visible = false;
            totxt_sousuo.Text = string.Empty;//清空搜索
            fenyegongneng();
        }

        private void btn_clearAllcooth_Click(object sender, EventArgs e)//点击了清空颜色分类其它的按钮
        {
            foreach (Control i in grb_color.Controls)
            {
                if (i is RadioButton)
                {
                    RadioButton r = (RadioButton)i;
                    r.Checked = false;
                }
            }
            foreach (Control i in grb_orther.Controls)
            {
                if (i is RadioButton)
                {
                    RadioButton r = (RadioButton)i;
                    r.Checked = false;
                }
            }
        }

        private void tobtn_sousuo_Click(object sender, EventArgs e)//点击了搜索的按钮，这个方法不能自动用name属性给命名
        {
            totxt_sousuo.Focus();
            totxt_sousuo.SelectAll();
            sousuoshijian();
        }

        /// <summary>
        /// 因为这个在点击搜索和在搜索框里面按下enter都要执行，所以写成方法
        /// </summary>
        void sousuoshijian()
        {
            if (totxt_sousuo.Text.Trim() == string.Empty)
            {
                suoyou = "select name 商品名,shoujia 售价,isbaoyou 包邮,kuadi 快递,kucun 库存,yuexiaoliang 月销量,scd 生产地 from commodity";
            }
            else
            {
                suoyou = string.Format("select name 商品名,shoujia 售价,isbaoyou 包邮,kuadi 快递,kucun 库存,yuexiaoliang 月销量,scd 生产地 from commodity where name like '%{0}%'", totxt_sousuo.Text);
            }
            //记得初始化，否则失败
            CurrentRow = 0;//当前行为0
            CurrentPage = 1;//当前页为1
            fenyegongneng();
            if (dgv_com.Rows.Count == 0)
            {
                btn_dgv_wushujutip.Visible = true;
            }
            else
            {
                btn_dgv_wushujutip.Visible = false;
            }
        }

        /// <summary>
        /// 因为这个在点击确定页数和在页数框里面按下enter都要执行，所以写成方法
        /// </summary>
        void yeshushijian()
        {
            int ys = 0;
            int.TryParse(totxt_yeshu.Text, out ys);
            if (ys > 30)
            {
                MessageBox.Show("不能超出30哦!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                totxt_yeshu.Focus();
                totxt_yeshu.SelectAll();
                return;
            }
            if (ys < 3)
            {
                MessageBox.Show("最少显示3行哦!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                totxt_yeshu.Focus();
                totxt_yeshu.SelectAll();
                return;
            }
            //记得初始化，否则失败
            CurrentRow = 0;//当前行为0
            CurrentPage = 1;//当前页为1
            hangshu = ys;
            totxt_yeshu.Focus();
            fenyegongneng();
        }

        private void tobtn_ye_Click(object sender, EventArgs e)//点击了修改页数的按钮
        {
            totxt_yeshu.Focus();
            totxt_yeshu.SelectAll();
            yeshushijian();
        }

        private void totxt_sousuo_KeyPress(object sender, KeyPressEventArgs e)//在搜索框中按下键
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                sousuoshijian();
            }
        }

        private void totxt_yeshu_KeyPress(object sender, KeyPressEventArgs e)//在页数框中按下键
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                yeshushijian();
            }
        }

        private void totxt_sousuo_KeyUp(object sender, KeyEventArgs e)//搜索文本框中按下
        {
            if (e.KeyCode == Keys.Enter)
            {
                tobtn_sousuo_Click(sender, e);//执行搜索按钮
                totxt_sousuo.SelectAll();
            }
        }

        private void totxt_yeshu_KeyUp(object sender, KeyEventArgs e)//页数文本框中按下
        {
            if (e.KeyCode == Keys.Enter)
            {
                tobtn_ye_Click(sender, e);//点击了修改页数的按钮
                totxt_yeshu.SelectAll();
            }
        }

        private void dgv_com_DataError(object sender, DataGridViewDataErrorEventArgs e)//dataerror事件
        {
            Text = Text;
            
        } 
    }
}
