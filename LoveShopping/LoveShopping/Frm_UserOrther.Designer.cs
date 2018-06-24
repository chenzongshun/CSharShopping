namespace LoveShopping
{
    partial class Frm_UserOrther
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_UserOrther));
            this.txt_sfzh = new System.Windows.Forms.TextBox();
            this.txt_telephone = new System.Windows.Forms.TextBox();
            this.txt_mibaowenti = new System.Windows.Forms.TextBox();
            this.txt_mibaodaan = new System.Windows.Forms.TextBox();
            this.txt_zhenname = new System.Windows.Forms.TextBox();
            this.txt_nicheng = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lab_dizhi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rad_man = new System.Windows.Forms.RadioButton();
            this.rad_woman = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.lab_datishi = new System.Windows.Forms.Label();
            this.cmb_sheng = new System.Windows.Forms.ComboBox();
            this.cmb_shi = new System.Windows.Forms.ComboBox();
            this.cmb_xiangzhen = new System.Windows.Forms.ComboBox();
            this.txt_xiangxidizhi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.txt_yanzhengma = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lab_y4 = new System.Windows.Forms.Label();
            this.lab_y3 = new System.Windows.Forms.Label();
            this.lab_y2 = new System.Windows.Forms.Label();
            this.lab_y1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_sfzh
            // 
            this.txt_sfzh.Location = new System.Drawing.Point(135, 281);
            this.txt_sfzh.Name = "txt_sfzh";
            this.txt_sfzh.Size = new System.Drawing.Size(188, 21);
            this.txt_sfzh.TabIndex = 4;
            // 
            // txt_telephone
            // 
            this.txt_telephone.Location = new System.Drawing.Point(135, 345);
            this.txt_telephone.Name = "txt_telephone";
            this.txt_telephone.Size = new System.Drawing.Size(188, 21);
            this.txt_telephone.TabIndex = 5;
            this.txt_telephone.Validating += new System.ComponentModel.CancelEventHandler(this.txt_telephone_Validating);
            // 
            // txt_mibaowenti
            // 
            this.txt_mibaowenti.ForeColor = System.Drawing.Color.Silver;
            this.txt_mibaowenti.Location = new System.Drawing.Point(453, 263);
            this.txt_mibaowenti.Multiline = true;
            this.txt_mibaowenti.Name = "txt_mibaowenti";
            this.txt_mibaowenti.Size = new System.Drawing.Size(224, 67);
            this.txt_mibaowenti.TabIndex = 10;
            this.txt_mibaowenti.Text = "    当你忘记密码的时候可以通过这个问题的答案来判定是否为你本人，然后进行找回密码。";
            this.txt_mibaowenti.TextChanged += new System.EventHandler(this.txt_mibaowenti_TextChanged);
            this.txt_mibaowenti.Leave += new System.EventHandler(this.txt_mibaowenti_Leave);
            this.txt_mibaowenti.Enter += new System.EventHandler(this.txt_mibaowenti_Enter);
            // 
            // txt_mibaodaan
            // 
            this.txt_mibaodaan.Location = new System.Drawing.Point(453, 354);
            this.txt_mibaodaan.Multiline = true;
            this.txt_mibaodaan.Name = "txt_mibaodaan";
            this.txt_mibaodaan.Size = new System.Drawing.Size(224, 67);
            this.txt_mibaodaan.TabIndex = 11;
            this.txt_mibaodaan.Text = "    上面密保的答案。";
            this.txt_mibaodaan.TextChanged += new System.EventHandler(this.txt_mibaodaan_TextChanged);
            this.txt_mibaodaan.Leave += new System.EventHandler(this.txt_mibaodaan_Leave);
            this.txt_mibaodaan.Enter += new System.EventHandler(this.txt_mibaodaan_Enter);
            // 
            // txt_zhenname
            // 
            this.txt_zhenname.Location = new System.Drawing.Point(135, 157);
            this.txt_zhenname.Name = "txt_zhenname";
            this.txt_zhenname.Size = new System.Drawing.Size(100, 21);
            this.txt_zhenname.TabIndex = 1;
            // 
            // txt_nicheng
            // 
            this.txt_nicheng.Location = new System.Drawing.Point(135, 90);
            this.txt_nicheng.Name = "txt_nicheng";
            this.txt_nicheng.Size = new System.Drawing.Size(100, 21);
            this.txt_nicheng.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "昵称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "真实姓名";
            // 
            // lab_dizhi
            // 
            this.lab_dizhi.AutoSize = true;
            this.lab_dizhi.Location = new System.Drawing.Point(366, 90);
            this.lab_dizhi.Name = "lab_dizhi";
            this.lab_dizhi.Size = new System.Drawing.Size(53, 12);
            this.lab_dizhi.TabIndex = 1;
            this.lab_dizhi.Text = "发货地址";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "身份证号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 348);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "电话号码";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(367, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "密保问题";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(367, 357);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "密保答案";
            // 
            // rad_man
            // 
            this.rad_man.AutoSize = true;
            this.rad_man.BackColor = System.Drawing.Color.Transparent;
            this.rad_man.Location = new System.Drawing.Point(135, 226);
            this.rad_man.Name = "rad_man";
            this.rad_man.Size = new System.Drawing.Size(35, 16);
            this.rad_man.TabIndex = 2;
            this.rad_man.TabStop = true;
            this.rad_man.Text = "男";
            this.rad_man.UseVisualStyleBackColor = false;
            // 
            // rad_woman
            // 
            this.rad_woman.AutoSize = true;
            this.rad_woman.BackColor = System.Drawing.Color.Transparent;
            this.rad_woman.Location = new System.Drawing.Point(200, 226);
            this.rad_woman.Name = "rad_woman";
            this.rad_woman.Size = new System.Drawing.Size(35, 16);
            this.rad_woman.TabIndex = 3;
            this.rad_woman.TabStop = true;
            this.rad_woman.Text = "女";
            this.rad_woman.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "您的性别";
            // 
            // lab_datishi
            // 
            this.lab_datishi.AutoSize = true;
            this.lab_datishi.Font = new System.Drawing.Font("幼圆", 25F);
            this.lab_datishi.Location = new System.Drawing.Point(99, 19);
            this.lab_datishi.Name = "lab_datishi";
            this.lab_datishi.Size = new System.Drawing.Size(508, 34);
            this.lab_datishi.TabIndex = 1;
            this.lab_datishi.Text = "亲爱的卖家,请填写您的详细信息";
            // 
            // cmb_sheng
            // 
            this.cmb_sheng.FormattingEnabled = true;
            this.cmb_sheng.Location = new System.Drawing.Point(456, 87);
            this.cmb_sheng.Name = "cmb_sheng";
            this.cmb_sheng.Size = new System.Drawing.Size(65, 20);
            this.cmb_sheng.TabIndex = 6;
            // 
            // cmb_shi
            // 
            this.cmb_shi.FormattingEnabled = true;
            this.cmb_shi.Location = new System.Drawing.Point(534, 87);
            this.cmb_shi.Name = "cmb_shi";
            this.cmb_shi.Size = new System.Drawing.Size(65, 20);
            this.cmb_shi.TabIndex = 7;
            // 
            // cmb_xiangzhen
            // 
            this.cmb_xiangzhen.FormattingEnabled = true;
            this.cmb_xiangzhen.Location = new System.Drawing.Point(612, 87);
            this.cmb_xiangzhen.Name = "cmb_xiangzhen";
            this.cmb_xiangzhen.Size = new System.Drawing.Size(65, 20);
            this.cmb_xiangzhen.TabIndex = 8;
            // 
            // txt_xiangxidizhi
            // 
            this.txt_xiangxidizhi.Location = new System.Drawing.Point(453, 163);
            this.txt_xiangxidizhi.Multiline = true;
            this.txt_xiangxidizhi.Name = "txt_xiangxidizhi";
            this.txt_xiangxidizhi.Size = new System.Drawing.Size(224, 67);
            this.txt_xiangxidizhi.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(366, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "详细地址";
            // 
            // btn_submit
            // 
            this.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_submit.ForeColor = System.Drawing.Color.Black;
            this.btn_submit.Location = new System.Drawing.Point(85, 479);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 23);
            this.btn_submit.TabIndex = 12;
            this.btn_submit.Text = "提交(&O)";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.ForeColor = System.Drawing.Color.Black;
            this.btn_clear.Location = new System.Drawing.Point(297, 479);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 13;
            this.btn_clear.Text = "清空(&C)";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.ForeColor = System.Drawing.Color.Black;
            this.btn_exit.Location = new System.Drawing.Point(532, 479);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 14;
            this.btn_exit.Text = "退出(&T)";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // txt_yanzhengma
            // 
            this.txt_yanzhengma.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_yanzhengma.Location = new System.Drawing.Point(135, 387);
            this.txt_yanzhengma.Multiline = true;
            this.txt_yanzhengma.Name = "txt_yanzhengma";
            this.txt_yanzhengma.Size = new System.Drawing.Size(88, 44);
            this.txt_yanzhengma.TabIndex = 12;
            this.txt_yanzhengma.Text = "FGXY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "输入验证码";
            // 
            // lab_y4
            // 
            this.lab_y4.AutoSize = true;
            this.lab_y4.BackColor = System.Drawing.Color.Transparent;
            this.lab_y4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_y4.ForeColor = System.Drawing.Color.DarkBlue;
            this.lab_y4.Location = new System.Drawing.Point(359, 387);
            this.lab_y4.Name = "lab_y4";
            this.lab_y4.Size = new System.Drawing.Size(46, 46);
            this.lab_y4.TabIndex = 8;
            this.lab_y4.Text = "Y";
            this.lab_y4.Click += new System.EventHandler(this.lab_y1_Click);
            // 
            // lab_y3
            // 
            this.lab_y3.AutoSize = true;
            this.lab_y3.BackColor = System.Drawing.Color.Transparent;
            this.lab_y3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_y3.ForeColor = System.Drawing.Color.Crimson;
            this.lab_y3.Location = new System.Drawing.Point(314, 387);
            this.lab_y3.Name = "lab_y3";
            this.lab_y3.Size = new System.Drawing.Size(47, 46);
            this.lab_y3.TabIndex = 9;
            this.lab_y3.Text = "X";
            this.lab_y3.Click += new System.EventHandler(this.lab_y1_Click);
            // 
            // lab_y2
            // 
            this.lab_y2.AutoSize = true;
            this.lab_y2.BackColor = System.Drawing.Color.Transparent;
            this.lab_y2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_y2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lab_y2.Location = new System.Drawing.Point(265, 387);
            this.lab_y2.Name = "lab_y2";
            this.lab_y2.Size = new System.Drawing.Size(51, 46);
            this.lab_y2.TabIndex = 6;
            this.lab_y2.Text = "G";
            this.lab_y2.Click += new System.EventHandler(this.lab_y1_Click);
            // 
            // lab_y1
            // 
            this.lab_y1.AutoSize = true;
            this.lab_y1.BackColor = System.Drawing.Color.Transparent;
            this.lab_y1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_y1.ForeColor = System.Drawing.Color.Coral;
            this.lab_y1.Location = new System.Drawing.Point(223, 387);
            this.lab_y1.Name = "lab_y1";
            this.lab_y1.Size = new System.Drawing.Size(44, 46);
            this.lab_y1.TabIndex = 7;
            this.lab_y1.Text = "F";
            this.lab_y1.Click += new System.EventHandler(this.lab_y1_Click);
            // 
            // Frm_UserOrther
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(726, 532);
            this.Controls.Add(this.lab_y4);
            this.Controls.Add(this.lab_y3);
            this.Controls.Add(this.lab_y2);
            this.Controls.Add(this.lab_y1);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_xiangzhen);
            this.Controls.Add(this.cmb_shi);
            this.Controls.Add(this.cmb_sheng);
            this.Controls.Add(this.rad_woman);
            this.Controls.Add(this.rad_man);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lab_datishi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lab_dizhi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_nicheng);
            this.Controls.Add(this.txt_zhenname);
            this.Controls.Add(this.txt_mibaodaan);
            this.Controls.Add(this.txt_xiangxidizhi);
            this.Controls.Add(this.txt_mibaowenti);
            this.Controls.Add(this.txt_yanzhengma);
            this.Controls.Add(this.txt_telephone);
            this.Controls.Add(this.txt_sfzh);
            this.HelpButton = true;
            this.Name = "Frm_UserOrther";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "填写您详细信息";
            this.Load += new System.EventHandler(this.Frm_UserOrther_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_UserOrther_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_sfzh;
        private System.Windows.Forms.TextBox txt_telephone;
        private System.Windows.Forms.TextBox txt_mibaowenti;
        private System.Windows.Forms.TextBox txt_mibaodaan;
        private System.Windows.Forms.TextBox txt_zhenname;
        private System.Windows.Forms.TextBox txt_nicheng;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab_dizhi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rad_man;
        private System.Windows.Forms.RadioButton rad_woman;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lab_datishi;
        private System.Windows.Forms.ComboBox cmb_sheng;
        private System.Windows.Forms.ComboBox cmb_shi;
        private System.Windows.Forms.ComboBox cmb_xiangzhen;
        private System.Windows.Forms.TextBox txt_xiangxidizhi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.TextBox txt_yanzhengma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lab_y4;
        private System.Windows.Forms.Label lab_y3;
        private System.Windows.Forms.Label lab_y2;
        private System.Windows.Forms.Label lab_y1;
    }
}