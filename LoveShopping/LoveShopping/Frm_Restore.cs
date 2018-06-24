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

namespace LoveShopping
{
    public partial class Frm_Restore : Form
    {
        public Frm_Restore()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 点击了选择文件按钮之后就会把文件的目录存储起来
        /// </summary>
        string path = string.Empty;

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (path.Trim() == string.Empty)
            {
                if (MessageBox.Show("你没有选择路径，是否现在就选择", "路径提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    btn_path_Click(sender, e);//模拟点击选择路径
                    return;
                }
                else
                {
                    return;
                }
            }

            DialogResult result = MessageBox.Show(@"你真的确定要删除掉现有数据库然后恢复以前的数据库吗？
注意：这将会是一个不可逆的操作!恢复成功将会为你回退到登陆界面！
所以建议在你执行这个操作之前强烈建议您先备份好这个当前这个数据库", "恢复数据库提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                MessageBox.Show("你取消了恢复数据库", "恢复数据库提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return;
            }

            //首先把数据库的数据库删除掉

            //try   //万一数据库本身里面没有附加数据库，那么将会删除失败，失败下面的代码就会出错，所以就不要删除，因为没有东西可以删除了
            //{
            //    //love_DAL.sqlHelper.ExecuteCommand(sql, CommandType.Text, null); 

            //    SqlConnection Server = new SqlConnection("Data Source=.;Initial Catalog=LoveShopping;Integrated Security=True");
            //    //string sql = "use master drop database LoveShopping";
            //    string sql = "use master drop database LoveShopping";
            //    if (Server.State == ConnectionState.Closed) Server.Open();
            //    SqlCommand cmd = new SqlCommand(sql, Server);
            //    cmd.ExecuteNonQuery();

            //    MessageBox.Show("请先分离或者删除对应的数据库");
            //    return;
            //}
            //catch { }


            if (path.Trim() == string.Empty || txt_path.Text.Trim() == string.Empty)    //Trim() 去除两端空格
            {
                if (MessageBox.Show("您未选择恢复的数据库文件，是否现在就选择文件？", "未选择文件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btn_path_Click(sender, e);//点击了选择文件的按钮
                }
                else
                {
                    return;
                }
            }

            if (love_DAL.sqlHelper.RestoreDateBase(path))
            {
                MessageBox.Show("数据恢复成功", "恢复提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }


        private void btn_path_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "数据库文件(*.mdf)|*.mdf|所有文件(*.*)|*.*";
            string ppp = Application.StartupPath;
            //ofd.InitialDirectory = ppp.Substring(0, ppp.IndexOf("\\bin")) + "\\BbackupDatabase\\";
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Title = "请选择恢复的数据库文件";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                txt_path.Text = ofd.FileName;
            }
        }

        private void Frm_Restore_Load(object sender, EventArgs e)
        {
            MinimumSize = new Size(780, 462);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            foreach (Control i in Controls)
            {
                i.Anchor = AnchorStyles.None;
            }
            Frm_Login f = new Frm_Login();
            Icon = f.Icon;
            tiemzou();
        }
        #region 左右悬浮动画
        //开始
        /// <summary>
        /// 在load方法写入此方法即可
        /// </summary>
        private void tiemzou()
        {
            lab_tip.Left = Width + 1;//记得要把控件的左边拉到窗体的左边，否则下面的方法不生效
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
            if (lab_tip.Left == pic_huifu.Left)
            {
                t22222.Enabled = true;
                t33333.Enabled = false;
            }
            if (lab_tip.Right >= Width - 15)      //=w的值已经被定死了，所以一改变窗体的大小就会失效
            {
                t22222.Enabled = false;
                t33333.Enabled = true;
            }
        }
        //结束
        #endregion
 
    }
}
