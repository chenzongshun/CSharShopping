using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace LoveShopping
{
    public partial class Frm_Backup : Form
    {
        public Frm_Backup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 点击了选择文件夹按钮之后就会把文件夹的目录存储起来
        /// </summary>
        string path = string.Empty;

        private void btn_path_Click(object sender, EventArgs e)//点击了选择文件夹的按钮
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "爱尚购的备份数据库" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".mdf";

            string ppp = Application.StartupPath; 
            //sfd.InitialDirectory = ppp.Substring(0, ppp.IndexOf("\\bin")) + "\\BbackupDatabase\\";
            sfd.InitialDirectory = Application.StartupPath;
            sfd.Title = "请选择备份文件的文件夹";
            sfd.Filter = "mdf数据库文件(*.mdf)|*.mdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FileName.Trim() != string.Empty)
                {
                    path = sfd.FileName;
                    txt_path.Text = sfd.FileName;
                }
            }

        }

        private void btn_ok_Click(object sender, EventArgs e)//点击了确定按钮
        {
            if (path.Trim() == string.Empty || txt_path.Text.Trim() == string.Empty)    //Trim() 去除两端空格
            {
                if (MessageBox.Show("您未选择文件路径，是否现在就选择文件路径？", "未选择路径提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btn_path_Click(sender, e);//点击了选择文件夹的按钮
                }
                else
                {
                    return;
                }
            }

            if (love_DAL.sqlHelper.BackupDateBase(path))
            {
                int d = path.LastIndexOf("\\");
                MessageBox.Show("备份成功,文件存放在\"" + path.Substring(0, d) + "\"这个目录下", "备份提示", MessageBoxButtons.OK, MessageBoxIcon.Information);   
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)//点击了清空按钮
        {
            path = txt_path.Text = string.Empty;//都清空路径
        }

        private void txt_path_Click(object sender, EventArgs e)//点击了路径文本框
        {
            btn_path_Click(sender, e);//点击了选择文件夹的按钮
        }

        private void Frm_Backup_Load(object sender, EventArgs e)
        {
            foreach (Control i in Controls)
            {
                i.Anchor = AnchorStyles.None;
            }
            tiemzou(); 
            Frm_Login f = new Frm_Login();
            Icon = f.Icon;
            foreach (Control item in Controls)
            {
                if (item is Label || item is CheckBox || item is PictureBox || item is GroupBox || item is Button || item is Panel)
                {
                    item.BackColor = Color.Transparent;
                }
            }
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
            if (lab_tip.Left < pictureBox1.Left)
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
