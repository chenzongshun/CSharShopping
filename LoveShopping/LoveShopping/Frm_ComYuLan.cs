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
    public partial class Frm_ComYuLan : Form
    {
        public Frm_ComYuLan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 每当单元格收到焦点的时候就会记录下这个单元格(商品)的持有者(用户名)
        /// </summary>
        string uname = string.Empty;

        private void Frm_Sellde_Load(object sender, EventArgs e)//窗体诞生时就会执行的函数
        {
            //cmb_kuaidi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_kuaidi.FlatStyle = FlatStyle.Flat; 

            foreach (Control i in Controls)
            {
                i.Anchor = AnchorStyles.None;
            }
            Frm_Login f = new Frm_Login();
            Icon = f.Icon;

            //string sql = "select comid,name,shoujia,kuadi,kucun,isbaoyou from commodity";
            string sql = "select comid 商品ID,name 商品名,shoujia 售价,isbaoyou 是否包邮,kuadi 快递,kucun 库存 from commodity";
            DataTable d = sqlHelper.ExecutedataTable(sql, CommandType.Text, null);
            dgv_yulan.DataSource = d;

            dgv_yulan.AllowUserToAddRows = false;//不允许用户添加行

            //在这个地方把快递的列表给初始化一下
            string[] kuadi = { "顺丰", "中国邮政", "EMS", "中通", "圆通", "申通", "韵达", "汇通", "天天", "宅急送", "其它比较知名快递", " 德邦物流", "国通快递", "佳吉快运", "中铁快运", "速尔快递", "中邮物流", "能达速递", "全峰快递快捷速递", "联邦快递FedEx", "DHL", "优速快递", "天地华宇", "全日通快递", "信丰物流", "新邦物流", "UPS快递", "TNT国际快递", "盛辉物流", "中外运全一", "佳怡物流", "飞康达物流", "联昊通快递" };
            cmb_kuaidi.Items.AddRange(kuadi);//添加好上面的快递到列表选项里面去
            //cmb_kuaidi.SelectedIndex = 0;


            if (d.Rows.Count == 0)
            {
                btn_clear_Click(sender, e);
                lab_id.Visible = false;
            }
            //tiemzou();//启动左右循环动画

            dgv_yulan.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//行居中
            dgv_yulan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//列居中
            dgv_yulan.AllowUserToResizeColumns = false;//不允许更改列宽 

            

            love.meihua(this);


        }


        /// <summary>
        /// 即时更新数据
        /// </summary>
        private void update_dgv()
        {
            //string sql = "select comid,name,shoujia,kuadi,kucun,isbaoyou from commodity";
            string sql = "select comid 商品ID,name 商品名,shoujia 售价,isbaoyou 是否包邮,kuadi 快递,kucun 库存 from commodity";
            DataTable d = sqlHelper.ExecutedataTable(sql, CommandType.Text, null);
            dgv_yulan.DataSource = d;
        }


        #region 左右悬浮动画
        //开始
        /// <summary>
        /// 在load方法写入此方法即可
        /// </summary>
        private void tiemzou()
        {
            dgv_yulan.Left = -1;//记得要把控件的左边拉到窗体的左边，否则下面的方法不生效
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

        void t33333_Tick(object sender, EventArgs e) { right(dgv_yulan); }
        void t22222_Tick(object sender, EventArgs e) { left(dgv_yulan); }
        public static void left(DataGridView l) { l.Left += 1; }
        public static void right(DataGridView l) { l.Left -= 1; }

        void t11111_Tick(object sender, EventArgs e)
        {
            if (dgv_yulan.Left < 0)
            {
                t22222.Enabled = true;
                t33333.Enabled = false;
            }
            if (dgv_yulan.Right >= Width - 15)      //=w的值已经被定死了，所以一改变窗体的大小就会失效
            {
                t22222.Enabled = false;
                t33333.Enabled = true;
            }
        }
        //结束
        #endregion


        //private void 关于我们ToolStripMenuItem_Click(object sender, EventArgs e)//点击了关于我们的按钮
        //{
        //    MessageBox.Show("显示关于我们");
        //}

        private void dgv_yulan_CellEnter(object sender, DataGridViewCellEventArgs e)//datagridview表格中的任意单元格获得焦点时触发的事件
        {
            lab_id.Visible = true;
            DataGridViewRow dgvr = dgv_yulan.CurrentRow;//获取到当前行的数据  Current：当前 row：行
            string id = dgvr.Cells[0].Value.ToString();//获取到该商品的id
            string sql = string.Format("select c.*,s.fahuodizhi from commodity c join sellde s on c.username=s.username where c.comid={0}", id);
            DataTable d = sqlHelper.ExecutedataTable(sql, CommandType.Text, null);//带回一个datatable数据表

            lab_id.Text = d.Rows[0]["comid"].ToString();//第一行的 列表名为“comid”下面的内容

            txt_name.Text = d.Rows[0]["name"].ToString();
            txt_shoujia.Text = d.Rows[0]["shoujia"].ToString();
            cmb_kuaidi.Text = d.Rows[0]["kuadi"].ToString();
            txt_kucun.Text = d.Rows[0]["kucun"].ToString();

            uname = d.Rows[0]["username"].ToString();//获取到最新的用户名==商品的持有者

            if (d.Rows[0]["isbaoyou"].ToString() == "是")
            {
                rad_shi.Checked = true;
            }
            else
            {
                rad_fou.Checked = true;
            }
            txt_yuexiaoliang.Text = d.Rows[0]["yuexiaoliang"].ToString();
            dtp_addtime.Text = d.Rows[0]["adddatetime"].ToString();
            txt_scd.Text = d.Rows[0]["scd"].ToString();


        }

        private void txt_shoujia_Validating(object sender, CancelEventArgs e)//售价单元格的验证时事件
        {
            try             //可能错误的代码片段
            {
                Convert.ToDecimal(txt_shoujia.Text);
            }
            catch             //如果try里面的代码错误的话，那么就会执行catch里面的代码
            {
                //MessageBox.Show("请输入数字0-9", "电话号码错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_shoujia.Focus();
                txt_shoujia.SelectAll();
                return;
            }
        }

        /// <summary>
        /// 这两个值用来对比新值和老值是否一样，然后就能对比判断是否修改了数据
        /// </summary>
        string lao, xin = string.Empty;

        private void btn_updata_Click(object sender, EventArgs e)//点击了修改的按钮
        {
            string sql = "select comid,name,shoujia,kuadi,kucun,isbaoyou from commodity";
            DataTable d = sqlHelper.ExecutedataTable(sql, CommandType.Text, null);
            //dgv_yulan.DataSource = d;
            if (d.Rows.Count == 0)//如果删除的没有数据了那么就要清空，不然点击修改会出错
            {
                btn_clear_Click(sender, e);
                DialogResult result = MessageBox.Show("没有可以供修改的商品，你想要添加商品吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    btn_addcommodity_Click(sender, e);//执行添加商品的按钮
                }
                return;
            }


            #region xin值
            xin = string.Empty;

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    xin += item.Text;
                }
                if (item is ComboBox)
                {
                    xin += item.Text;
                }
                if (item is RadioButton)
                {
                    RadioButton r = (RadioButton)item;
                    if (r.Checked)
                    {
                        xin += r.Text;
                    }
                }
                if (item is DateTimePicker)
                {
                    xin += item.Text;
                }
            }
            #endregion

            //if (xin == lao)
            //{
            //    MessageBox.Show("你没有修改任何数据");
            //    return;
            //}

            //判断金额是否填写正确
            try
            {
                Convert.ToDecimal(txt_shoujia.Text);

                string sj = txt_shoujia.Text;//获取到售价
                int dian = sj.IndexOf(".");//找到了就获取到 . 的索引

                if (dian != -1 && sj.Length - dian > 2)//找到了点 并且  价格的长度减去.的索引 > 2
                {
                    MessageBox.Show("小数位不能超过1位", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_shoujia.Focus();
                    txt_shoujia.SelectAll();
                    return;
                }

            }
            catch
            {
                MessageBox.Show("请输入正确的金额", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_shoujia.Focus();
                txt_shoujia.SelectAll();
                return;
            }

            //判断库存数是否填写正确
            try
            {
                Convert.ToInt32(txt_kucun.Text);
            }
            catch
            {
                MessageBox.Show("请输入包括0-9之间的数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_kucun.Focus();
                txt_kucun.SelectAll();
                return;
            }

            //判断月销量是否填写正确
            try
            {
                Convert.ToInt32(txt_yuexiaoliang.Text);

            }
            catch
            {
                MessageBox.Show("请输入包括0-9之间的数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_yuexiaoliang.Focus();
                txt_yuexiaoliang.SelectAll();
                return;
            }

            commodity c = new commodity();
            c.Name = txt_name.Text;
            c.Comid = int.Parse(lab_id.Text);
            c.Shoujia = Convert.ToDecimal(txt_shoujia.Text);
            c.Kuadi = cmb_kuaidi.Text;
            c.Kucun = int.Parse(txt_kucun.Text);
            c.Isbaoyou = rad_shi.Checked == true ? "是" : "否";
            c.Yuexiaoliang = int.Parse(txt_yuexiaoliang.Text);
            c.Adddatetime = dtp_addtime.Value;
            c.Scd = txt_scd.Text;

            c.Username = uname;

            c.IsYuLanupdate();


            MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #region lao值
            lao = string.Empty;
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    lao += item.Text;
                }
                if (item is ComboBox)
                {
                    lao += item.Text;
                }
                if (item is RadioButton)
                {
                    RadioButton r = (RadioButton)item;
                    if (r.Checked)
                    {
                        lao += r.Text;
                    }
                }
                if (item is DateTimePicker)
                {
                    lao += item.Text;
                }
            }
            #endregion

            update_dgv();
        }




        private void btn_delete_Click(object sender, EventArgs e)//点击了删除的按钮
        {
            string sql = "select comid,name,shoujia,kuadi,kucun,isbaoyou from commodity";
            DataTable d = sqlHelper.ExecutedataTable(sql, CommandType.Text, null);

            if (d.Rows.Count == 0)
            {
                btn_clear_Click(sender, e);
                lab_id.Visible = false;
                DialogResult result = MessageBox.Show("已经没有商品可以删除了，你想要添加商品吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    btn_addcommodity_Click(sender, e);//执行添加商品的按钮
                }
                else
                {
                    return;
                }
            }

            commodity c = new commodity();
            c.Comid = int.Parse(lab_id.Text);
            c.delete();
            update_dgv();
            MessageBox.Show("删除成功", "删除商品", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dgv_yulan.Rows.Count == 0)
            {
                foreach (Control i in Controls)
                {
                    if (i is TextBox || i is ComboBox)
                    {
                        i.Text = string.Empty;
                    }
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)//点击了清空的按钮
        {
            lab_id.Visible = false;
            xin = string.Empty;

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
                if (item is RadioButton)
                {
                    RadioButton r = (RadioButton)item;
                    r.Checked = false;
                }
                if (item is DateTimePicker)
                {
                    DateTimePicker d = (DateTimePicker)item;
                    d.Value = DateTime.Now;
                }
            }
        }

        private void btn_addcommodity_Click(object sender, EventArgs e)//点击了添加商品的按钮
        {
            //try//如果是在集成窗口中的话就可以判断打开否则运行就会出错
            //{
            //    Parent.Parent.Hide();
            //    Frm_AddCommdodity f = new Frm_AddCommdodity();
            //    f.ShowDialog();
            //    Parent.Parent.Show();
            //}
            //catch { }                
            if (this.Parent != null)
            {
                Frm_AddCommdodity f = new Frm_AddCommdodity();
                f.TopLevel = false;
                f.Parent = this.Parent;
                f.Show();
                f.BringToFront();
            }
            else
            {
                Hide();
                Frm_AddCommdodity f = new Frm_AddCommdodity();
                f.ShowDialog();
                Show();
            }

        }

        private void btn_shuaxin_Click(object sender, EventArgs e)//点击了刷新的按钮
        {
            update_dgv();
        }

        private void btn_xiangxi_Click(object sender, EventArgs e)//点击了点击了详细的按钮
        {
            //try//如果是在集成窗口中的话就可以判断打开否则运行就会出错
            //{
            //    Parent.Parent.Hide();
            //    Frm_ComXiangXI f = new Frm_ComXiangXI();
            //    f.ShowDialog();
            //    Parent.Parent.Show();
            //}
            //catch { }

            if (this.Parent != null)
            {
                Frm_ComXiangXI f = new Frm_ComXiangXI();
                f.TopLevel = false;
                f.Parent = this.Parent;
                f.Show();
                f.BringToFront();
            }
            else
            {
                Hide();
                Frm_ComXiangXI f = new Frm_ComXiangXI();
                f.ShowDialog();
                Show();
            }
        }


    }
}
