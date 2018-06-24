namespace LoveShopping
{
    partial class Frm_Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.btn_denlu = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.lab_dl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pan_denglu = new System.Windows.Forms.Panel();
            this.txt_zc_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_zhuce = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_zc_clear = new System.Windows.Forms.Button();
            this.btn_zc_tuichu = new System.Windows.Forms.Button();
            this.txt_zc_pwd1 = new System.Windows.Forms.TextBox();
            this.txt_zc_pwd2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pan_zhuce = new System.Windows.Forms.Panel();
            this.lab_xuanzetouxiang = new System.Windows.Forms.Label();
            this.ckb_isfanhuidenglu = new System.Windows.Forms.CheckBox();
            this.rad_buyde = new System.Windows.Forms.RadioButton();
            this.rad_sellde = new System.Windows.Forms.RadioButton();
            this.btn_pic = new System.Windows.Forms.Button();
            this.pic_photo = new System.Windows.Forms.PictureBox();
            this.lkb_xinyonhu = new System.Windows.Forms.LinkLabel();
            this.lab_tip = new System.Windows.Forms.Label();
            this.lkb_wangjipwd = new System.Windows.Forms.LinkLabel();
            this.lab_zc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Love_Shopping = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pan_denglu.SuspendLayout();
            this.pan_zhuce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_photo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_denlu
            // 
            this.btn_denlu.Location = new System.Drawing.Point(40, 161);
            this.btn_denlu.Name = "btn_denlu";
            this.btn_denlu.Size = new System.Drawing.Size(80, 23);
            this.btn_denlu.TabIndex = 2;
            this.btn_denlu.Text = "登陆(&O)";
            this.btn_denlu.UseVisualStyleBackColor = true;
            this.btn_denlu.Click += new System.EventHandler(this.btn_denlu_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(205, 161);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(80, 23);
            this.btn_clear.TabIndex = 3;
            this.btn_clear.Text = "清空(&C)";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(370, 161);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(80, 23);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "退出(&T)";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(177, 43);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(216, 21);
            this.txt_username.TabIndex = 0;
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(177, 100);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(216, 21);
            this.txt_password.TabIndex = 1;
            // 
            // lab_dl
            // 
            this.lab_dl.AutoSize = true;
            this.lab_dl.BackColor = System.Drawing.SystemColors.Control;
            this.lab_dl.Font = new System.Drawing.Font("幼圆", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_dl.Location = new System.Drawing.Point(420, 24);
            this.lab_dl.Name = "lab_dl";
            this.lab_dl.Size = new System.Drawing.Size(217, 40);
            this.lab_dl.TabIndex = 2;
            this.lab_dl.Text = "登陆爱尚购";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "密  码";
            // 
            // pan_denglu
            // 
            this.pan_denglu.BackColor = System.Drawing.Color.Snow;
            this.pan_denglu.Controls.Add(this.txt_username);
            this.pan_denglu.Controls.Add(this.label3);
            this.pan_denglu.Controls.Add(this.btn_denlu);
            this.pan_denglu.Controls.Add(this.label2);
            this.pan_denglu.Controls.Add(this.btn_clear);
            this.pan_denglu.Controls.Add(this.btn_exit);
            this.pan_denglu.Controls.Add(this.txt_password);
            this.pan_denglu.Location = new System.Drawing.Point(264, 139);
            this.pan_denglu.Name = "pan_denglu";
            this.pan_denglu.Size = new System.Drawing.Size(472, 208);
            this.pan_denglu.TabIndex = 4;
            // 
            // txt_zc_name
            // 
            this.txt_zc_name.Location = new System.Drawing.Point(286, 29);
            this.txt_zc_name.Name = "txt_zc_name";
            this.txt_zc_name.Size = new System.Drawing.Size(206, 21);
            this.txt_zc_name.TabIndex = 0;
            this.txt_zc_name.Leave += new System.EventHandler(this.txt_zc_name_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "密  码";
            // 
            // btn_zhuce
            // 
            this.btn_zhuce.Location = new System.Drawing.Point(157, 203);
            this.btn_zhuce.Name = "btn_zhuce";
            this.btn_zhuce.Size = new System.Drawing.Size(80, 23);
            this.btn_zhuce.TabIndex = 7;
            this.btn_zhuce.Text = "注册";
            this.btn_zhuce.UseVisualStyleBackColor = true;
            this.btn_zhuce.Click += new System.EventHandler(this.btn_zhuce_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "用户名";
            // 
            // btn_zc_clear
            // 
            this.btn_zc_clear.Location = new System.Drawing.Point(307, 203);
            this.btn_zc_clear.Name = "btn_zc_clear";
            this.btn_zc_clear.Size = new System.Drawing.Size(80, 23);
            this.btn_zc_clear.TabIndex = 8;
            this.btn_zc_clear.Text = "清空";
            this.btn_zc_clear.UseVisualStyleBackColor = true;
            this.btn_zc_clear.Click += new System.EventHandler(this.btn_zc_clear_Click);
            // 
            // btn_zc_tuichu
            // 
            this.btn_zc_tuichu.Location = new System.Drawing.Point(457, 203);
            this.btn_zc_tuichu.Name = "btn_zc_tuichu";
            this.btn_zc_tuichu.Size = new System.Drawing.Size(80, 23);
            this.btn_zc_tuichu.TabIndex = 9;
            this.btn_zc_tuichu.Text = "退出";
            this.btn_zc_tuichu.UseVisualStyleBackColor = true;
            this.btn_zc_tuichu.Click += new System.EventHandler(this.btn_zc_tuichu_Click);
            // 
            // txt_zc_pwd1
            // 
            this.txt_zc_pwd1.Location = new System.Drawing.Point(286, 71);
            this.txt_zc_pwd1.Name = "txt_zc_pwd1";
            this.txt_zc_pwd1.Size = new System.Drawing.Size(206, 21);
            this.txt_zc_pwd1.TabIndex = 1;
            // 
            // txt_zc_pwd2
            // 
            this.txt_zc_pwd2.Location = new System.Drawing.Point(286, 113);
            this.txt_zc_pwd2.Name = "txt_zc_pwd2";
            this.txt_zc_pwd2.Size = new System.Drawing.Size(206, 21);
            this.txt_zc_pwd2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(209, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "确认密码";
            // 
            // pan_zhuce
            // 
            this.pan_zhuce.BackColor = System.Drawing.Color.Snow;
            this.pan_zhuce.Controls.Add(this.lab_xuanzetouxiang);
            this.pan_zhuce.Controls.Add(this.ckb_isfanhuidenglu);
            this.pan_zhuce.Controls.Add(this.rad_buyde);
            this.pan_zhuce.Controls.Add(this.rad_sellde);
            this.pan_zhuce.Controls.Add(this.btn_pic);
            this.pan_zhuce.Controls.Add(this.pic_photo);
            this.pan_zhuce.Controls.Add(this.label5);
            this.pan_zhuce.Controls.Add(this.txt_zc_name);
            this.pan_zhuce.Controls.Add(this.txt_zc_pwd1);
            this.pan_zhuce.Controls.Add(this.label6);
            this.pan_zhuce.Controls.Add(this.txt_zc_pwd2);
            this.pan_zhuce.Controls.Add(this.label4);
            this.pan_zhuce.Controls.Add(this.btn_zc_tuichu);
            this.pan_zhuce.Controls.Add(this.btn_zhuce);
            this.pan_zhuce.Controls.Add(this.btn_zc_clear);
            this.pan_zhuce.Location = new System.Drawing.Point(217, 126);
            this.pan_zhuce.Name = "pan_zhuce";
            this.pan_zhuce.Size = new System.Drawing.Size(541, 233);
            this.pan_zhuce.TabIndex = 12;
            // 
            // lab_xuanzetouxiang
            // 
            this.lab_xuanzetouxiang.AutoSize = true;
            this.lab_xuanzetouxiang.Location = new System.Drawing.Point(61, 86);
            this.lab_xuanzetouxiang.Name = "lab_xuanzetouxiang";
            this.lab_xuanzetouxiang.Size = new System.Drawing.Size(77, 12);
            this.lab_xuanzetouxiang.TabIndex = 13;
            this.lab_xuanzetouxiang.Text = "点击选择头像";
            this.lab_xuanzetouxiang.Click += new System.EventHandler(this.pic_photo_Click);
            // 
            // ckb_isfanhuidenglu
            // 
            this.ckb_isfanhuidenglu.AutoSize = true;
            this.ckb_isfanhuidenglu.Checked = true;
            this.ckb_isfanhuidenglu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_isfanhuidenglu.Location = new System.Drawing.Point(375, 161);
            this.ckb_isfanhuidenglu.Name = "ckb_isfanhuidenglu";
            this.ckb_isfanhuidenglu.Size = new System.Drawing.Size(120, 16);
            this.ckb_isfanhuidenglu.TabIndex = 5;
            this.ckb_isfanhuidenglu.Text = "注册成功返回登陆";
            this.ckb_isfanhuidenglu.UseVisualStyleBackColor = true;
            // 
            // rad_buyde
            // 
            this.rad_buyde.AutoSize = true;
            this.rad_buyde.Location = new System.Drawing.Point(289, 161);
            this.rad_buyde.Name = "rad_buyde";
            this.rad_buyde.Size = new System.Drawing.Size(47, 16);
            this.rad_buyde.TabIndex = 4;
            this.rad_buyde.TabStop = true;
            this.rad_buyde.Text = "买家";
            this.rad_buyde.UseVisualStyleBackColor = true;
            // 
            // rad_sellde
            // 
            this.rad_sellde.AutoSize = true;
            this.rad_sellde.Location = new System.Drawing.Point(210, 161);
            this.rad_sellde.Name = "rad_sellde";
            this.rad_sellde.Size = new System.Drawing.Size(47, 16);
            this.rad_sellde.TabIndex = 3;
            this.rad_sellde.TabStop = true;
            this.rad_sellde.Text = "卖家";
            this.rad_sellde.UseVisualStyleBackColor = true;
            // 
            // btn_pic
            // 
            this.btn_pic.Location = new System.Drawing.Point(7, 203);
            this.btn_pic.Name = "btn_pic";
            this.btn_pic.Size = new System.Drawing.Size(80, 23);
            this.btn_pic.TabIndex = 6;
            this.btn_pic.Text = "选择头像";
            this.btn_pic.UseVisualStyleBackColor = true;
            this.btn_pic.Click += new System.EventHandler(this.btn_pic_Click);
            // 
            // pic_photo
            // 
            this.pic_photo.Location = new System.Drawing.Point(33, 15);
            this.pic_photo.Name = "pic_photo";
            this.pic_photo.Size = new System.Drawing.Size(126, 160);
            this.pic_photo.TabIndex = 12;
            this.pic_photo.TabStop = false;
            this.pic_photo.Click += new System.EventHandler(this.pic_photo_Click);
            // 
            // lkb_xinyonhu
            // 
            this.lkb_xinyonhu.AutoSize = true;
            this.lkb_xinyonhu.Location = new System.Drawing.Point(693, 362);
            this.lkb_xinyonhu.Name = "lkb_xinyonhu";
            this.lkb_xinyonhu.Size = new System.Drawing.Size(65, 12);
            this.lkb_xinyonhu.TabIndex = 13;
            this.lkb_xinyonhu.TabStop = true;
            this.lkb_xinyonhu.Text = "我是新用户";
            this.lkb_xinyonhu.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkb_xinyonhu_LinkClicked);
            // 
            // lab_tip
            // 
            this.lab_tip.AutoSize = true;
            this.lab_tip.BackColor = System.Drawing.SystemColors.Control;
            this.lab_tip.Location = new System.Drawing.Point(438, 104);
            this.lab_tip.Name = "lab_tip";
            this.lab_tip.Size = new System.Drawing.Size(209, 12);
            this.lab_tip.TabIndex = 14;
            this.lab_tip.Text = "程序将会自动判断账号是卖家还是买家";
            // 
            // lkb_wangjipwd
            // 
            this.lkb_wangjipwd.AutoSize = true;
            this.lkb_wangjipwd.Location = new System.Drawing.Point(588, 362);
            this.lkb_wangjipwd.Name = "lkb_wangjipwd";
            this.lkb_wangjipwd.Size = new System.Drawing.Size(53, 12);
            this.lkb_wangjipwd.TabIndex = 15;
            this.lkb_wangjipwd.TabStop = true;
            this.lkb_wangjipwd.Text = "忘记密码";
            this.lkb_wangjipwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkb_wangjipwd_LinkClicked);
            // 
            // lab_zc
            // 
            this.lab_zc.AutoSize = true;
            this.lab_zc.BackColor = System.Drawing.SystemColors.Control;
            this.lab_zc.Font = new System.Drawing.Font("幼圆", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_zc.Location = new System.Drawing.Point(380, 24);
            this.lab_zc.Name = "lab_zc";
            this.lab_zc.Size = new System.Drawing.Size(297, 40);
            this.lab_zc.TabIndex = 2;
            this.lab_zc.Text = "注册爱尚购账号";
            this.lab_zc.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(-10, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1081, 27);
            this.label1.TabIndex = 16;
            this.label1.Text = "本页这几个lable控件的背景通过代码设置成背景一样的颜色，运行时此提示不会显示出来";
            this.label1.Visible = false;
            // 
            // Love_Shopping
            // 
            this.Love_Shopping.AutoSize = true;
            this.Love_Shopping.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Love_Shopping.Location = new System.Drawing.Point(0, -1);
            this.Love_Shopping.Name = "Love_Shopping";
            this.Love_Shopping.Size = new System.Drawing.Size(286, 46);
            this.Love_Shopping.TabIndex = 17;
            this.Love_Shopping.Text = "Love Shopping";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(773, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(269, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "提示：卖家端账号密码为a、a，而买家端的为b、b";
            // 
            // Frm_Login
            // 
            this.AcceptButton = this.btn_denlu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1065, 524);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Love_Shopping);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lkb_wangjipwd);
            this.Controls.Add(this.lab_tip);
            this.Controls.Add(this.lkb_xinyonhu);
            this.Controls.Add(this.pan_zhuce);
            this.Controls.Add(this.pan_denglu);
            this.Controls.Add(this.lab_zc);
            this.Controls.Add(this.lab_dl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1073, 551);
            this.MinimumSize = new System.Drawing.Size(1073, 551);
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登陆爱尚购";
            this.Load += new System.EventHandler(this.Frm_login_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Login_FormClosing);
            this.pan_denglu.ResumeLayout(false);
            this.pan_denglu.PerformLayout();
            this.pan_zhuce.ResumeLayout(false);
            this.pan_zhuce.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_photo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_denlu;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label lab_dl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pan_denglu;
        private System.Windows.Forms.TextBox txt_zc_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_zhuce;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_zc_clear;
        private System.Windows.Forms.Button btn_zc_tuichu;
        private System.Windows.Forms.TextBox txt_zc_pwd1;
        private System.Windows.Forms.TextBox txt_zc_pwd2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pan_zhuce;
        private System.Windows.Forms.Button btn_pic;
        private System.Windows.Forms.PictureBox pic_photo;
        private System.Windows.Forms.LinkLabel lkb_xinyonhu;
        private System.Windows.Forms.RadioButton rad_buyde;
        private System.Windows.Forms.RadioButton rad_sellde;
        private System.Windows.Forms.Label lab_tip;
        private System.Windows.Forms.CheckBox ckb_isfanhuidenglu;
        private System.Windows.Forms.LinkLabel lkb_wangjipwd;
        private System.Windows.Forms.Label lab_xuanzetouxiang;
        private System.Windows.Forms.Label lab_zc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Love_Shopping;
        private System.Windows.Forms.Label label7;
    }
}

