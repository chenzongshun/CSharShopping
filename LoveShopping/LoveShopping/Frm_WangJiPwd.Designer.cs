namespace LoveShopping
{
    partial class Frm_WangJiPwd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_WangJiPwd));
            this.btn_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_daan = new System.Windows.Forms.TextBox();
            this.lab_wenti = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_newpwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_okpwd = new System.Windows.Forms.TextBox();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.btn_exitdenglu = new System.Windows.Forms.Button();
            this.ckb_isordneglu = new System.Windows.Forms.CheckBox();
            this.lab_y1 = new System.Windows.Forms.Label();
            this.lab_y2 = new System.Windows.Forms.Label();
            this.lab_y3 = new System.Windows.Forms.Label();
            this.lab_y4 = new System.Windows.Forms.Label();
            this.txt_yzm = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ok.BackgroundImage")));
            this.btn_ok.Location = new System.Drawing.Point(69, 407);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "提交";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(169, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "找回密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密保问题";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密保答案";
            // 
            // txt_daan
            // 
            this.txt_daan.Location = new System.Drawing.Point(180, 193);
            this.txt_daan.Name = "txt_daan";
            this.txt_daan.Size = new System.Drawing.Size(297, 21);
            this.txt_daan.TabIndex = 1;
            // 
            // lab_wenti
            // 
            this.lab_wenti.AutoSize = true;
            this.lab_wenti.Location = new System.Drawing.Point(178, 149);
            this.lab_wenti.Name = "lab_wenti";
            this.lab_wenti.Size = new System.Drawing.Size(89, 12);
            this.lab_wenti.TabIndex = 2;
            this.lab_wenti.Text = "这个是一个问题";
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(179, 100);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(297, 21);
            this.txt_username.TabIndex = 0;
            this.txt_username.TextChanged += new System.EventHandler(this.txt_username_TextChanged);
            this.txt_username.Leave += new System.EventHandler(this.txt_username_Leave);
            // 
            // txt_newpwd
            // 
            this.txt_newpwd.Location = new System.Drawing.Point(179, 238);
            this.txt_newpwd.Name = "txt_newpwd";
            this.txt_newpwd.PasswordChar = '*';
            this.txt_newpwd.Size = new System.Drawing.Size(297, 21);
            this.txt_newpwd.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "用户名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "新密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "确认密码";
            // 
            // txt_okpwd
            // 
            this.txt_okpwd.Location = new System.Drawing.Point(179, 283);
            this.txt_okpwd.Name = "txt_okpwd";
            this.txt_okpwd.PasswordChar = '*';
            this.txt_okpwd.Size = new System.Drawing.Size(297, 21);
            this.txt_okpwd.TabIndex = 3;
            // 
            // btn_cancle
            // 
            this.btn_cancle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_cancle.BackgroundImage")));
            this.btn_cancle.Location = new System.Drawing.Point(268, 407);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 6;
            this.btn_cancle.Text = "清空";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_exitdenglu
            // 
            this.btn_exitdenglu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_exitdenglu.BackgroundImage")));
            this.btn_exitdenglu.Location = new System.Drawing.Point(454, 407);
            this.btn_exitdenglu.Name = "btn_exitdenglu";
            this.btn_exitdenglu.Size = new System.Drawing.Size(75, 23);
            this.btn_exitdenglu.TabIndex = 7;
            this.btn_exitdenglu.Text = "返回登陆";
            this.btn_exitdenglu.UseVisualStyleBackColor = true;
            this.btn_exitdenglu.Click += new System.EventHandler(this.btn_exitdenglu_Click);
            // 
            // ckb_isordneglu
            // 
            this.ckb_isordneglu.AutoSize = true;
            this.ckb_isordneglu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ckb_isordneglu.BackgroundImage")));
            this.ckb_isordneglu.Location = new System.Drawing.Point(418, 453);
            this.ckb_isordneglu.Name = "ckb_isordneglu";
            this.ckb_isordneglu.Size = new System.Drawing.Size(156, 16);
            this.ckb_isordneglu.TabIndex = 8;
            this.ckb_isordneglu.Text = "修改后成功返回登陆窗口";
            this.ckb_isordneglu.UseVisualStyleBackColor = true;
            // 
            // lab_y1
            // 
            this.lab_y1.AutoSize = true;
            this.lab_y1.BackColor = System.Drawing.Color.Transparent;
            this.lab_y1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_y1.ForeColor = System.Drawing.Color.Coral;
            this.lab_y1.Location = new System.Drawing.Point(280, 337);
            this.lab_y1.Name = "lab_y1";
            this.lab_y1.Size = new System.Drawing.Size(44, 46);
            this.lab_y1.TabIndex = 2;
            this.lab_y1.Text = "F";
            this.lab_y1.Click += new System.EventHandler(this.lab_y1_Click);
            // 
            // lab_y2
            // 
            this.lab_y2.AutoSize = true;
            this.lab_y2.BackColor = System.Drawing.Color.Transparent;
            this.lab_y2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_y2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lab_y2.Location = new System.Drawing.Point(320, 337);
            this.lab_y2.Name = "lab_y2";
            this.lab_y2.Size = new System.Drawing.Size(51, 46);
            this.lab_y2.TabIndex = 2;
            this.lab_y2.Text = "G";
            this.lab_y2.Click += new System.EventHandler(this.lab_y1_Click);
            // 
            // lab_y3
            // 
            this.lab_y3.AutoSize = true;
            this.lab_y3.BackColor = System.Drawing.Color.Transparent;
            this.lab_y3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_y3.ForeColor = System.Drawing.Color.Crimson;
            this.lab_y3.Location = new System.Drawing.Point(367, 337);
            this.lab_y3.Name = "lab_y3";
            this.lab_y3.Size = new System.Drawing.Size(47, 46);
            this.lab_y3.TabIndex = 2;
            this.lab_y3.Text = "X";
            this.lab_y3.Click += new System.EventHandler(this.lab_y1_Click);
            // 
            // lab_y4
            // 
            this.lab_y4.AutoSize = true;
            this.lab_y4.BackColor = System.Drawing.Color.Transparent;
            this.lab_y4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_y4.ForeColor = System.Drawing.Color.DarkBlue;
            this.lab_y4.Location = new System.Drawing.Point(410, 337);
            this.lab_y4.Name = "lab_y4";
            this.lab_y4.Size = new System.Drawing.Size(46, 46);
            this.lab_y4.TabIndex = 2;
            this.lab_y4.Text = "Y";
            this.lab_y4.Click += new System.EventHandler(this.lab_y1_Click);
            // 
            // txt_yzm
            // 
            this.txt_yzm.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_yzm.Location = new System.Drawing.Point(178, 339);
            this.txt_yzm.Multiline = true;
            this.txt_yzm.Name = "txt_yzm";
            this.txt_yzm.Size = new System.Drawing.Size(88, 43);
            this.txt_yzm.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(92, 357);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "验证码";
            // 
            // Frm_WangJiPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(579, 472);
            this.Controls.Add(this.txt_yzm);
            this.Controls.Add(this.ckb_isordneglu);
            this.Controls.Add(this.txt_okpwd);
            this.Controls.Add(this.txt_newpwd);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.lab_y4);
            this.Controls.Add(this.lab_y3);
            this.Controls.Add(this.lab_y2);
            this.Controls.Add(this.lab_y1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_daan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lab_wenti);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_exitdenglu);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_ok);
            this.Name = "Frm_WangJiPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "找回密码";
            this.Load += new System.EventHandler(this.Frm_WangJiPwd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_daan;
        private System.Windows.Forms.Label lab_wenti;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_newpwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_okpwd;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_exitdenglu;
        private System.Windows.Forms.CheckBox ckb_isordneglu;
        private System.Windows.Forms.Label lab_y1;
        private System.Windows.Forms.Label lab_y2;
        private System.Windows.Forms.Label lab_y3;
        private System.Windows.Forms.Label lab_y4;
        private System.Windows.Forms.TextBox txt_yzm;
        private System.Windows.Forms.Label label11;
    }
}