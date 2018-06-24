namespace LoveShopping
{
    partial class Frm_ComYuLan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ComYuLan));
            this.dgv_yulan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lab_id = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_shoujia = new System.Windows.Forms.TextBox();
            this.cmb_kuaidi = new System.Windows.Forms.ComboBox();
            this.txt_kucun = new System.Windows.Forms.TextBox();
            this.rad_shi = new System.Windows.Forms.RadioButton();
            this.rad_fou = new System.Windows.Forms.RadioButton();
            this.txt_yuexiaoliang = new System.Windows.Forms.TextBox();
            this.dtp_addtime = new System.Windows.Forms.DateTimePicker();
            this.txt_scd = new System.Windows.Forms.TextBox();
            this.btn_updata = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_addcommodity = new System.Windows.Forms.Button();
            this.btn_shuaxin = new System.Windows.Forms.Button();
            this.btn_xiangxi = new System.Windows.Forms.Button();
            this.Love_Shopping = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_yulan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_yulan
            // 
            this.dgv_yulan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_yulan.Location = new System.Drawing.Point(245, 79);
            this.dgv_yulan.MultiSelect = false;
            this.dgv_yulan.Name = "dgv_yulan";
            this.dgv_yulan.ReadOnly = true;
            this.dgv_yulan.RowTemplate.Height = 23;
            this.dgv_yulan.Size = new System.Drawing.Size(660, 284);
            this.dgv_yulan.TabIndex = 0;
            this.dgv_yulan.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_yulan_CellEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(415, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "商品大致预览表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "商品的id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "商品名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "售价";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "快递";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "库存";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 393);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "是否包邮?";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 393);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "月销量";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(472, 393);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "添加时间";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(705, 393);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "生产地";
            // 
            // lab_id
            // 
            this.lab_id.AutoSize = true;
            this.lab_id.Location = new System.Drawing.Point(106, 79);
            this.lab_id.Name = "lab_id";
            this.lab_id.Size = new System.Drawing.Size(17, 12);
            this.lab_id.TabIndex = 3;
            this.lab_id.Text = "id";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(106, 140);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(100, 21);
            this.txt_name.TabIndex = 0;
            // 
            // txt_shoujia
            // 
            this.txt_shoujia.Location = new System.Drawing.Point(106, 203);
            this.txt_shoujia.Name = "txt_shoujia";
            this.txt_shoujia.Size = new System.Drawing.Size(100, 21);
            this.txt_shoujia.TabIndex = 1;
            this.txt_shoujia.Validating += new System.ComponentModel.CancelEventHandler(this.txt_shoujia_Validating);
            // 
            // cmb_kuaidi
            // 
            this.cmb_kuaidi.FormattingEnabled = true;
            this.cmb_kuaidi.Location = new System.Drawing.Point(106, 265);
            this.cmb_kuaidi.Name = "cmb_kuaidi";
            this.cmb_kuaidi.Size = new System.Drawing.Size(100, 20);
            this.cmb_kuaidi.TabIndex = 2;
            // 
            // txt_kucun
            // 
            this.txt_kucun.Location = new System.Drawing.Point(106, 330);
            this.txt_kucun.Name = "txt_kucun";
            this.txt_kucun.Size = new System.Drawing.Size(100, 21);
            this.txt_kucun.TabIndex = 3;
            // 
            // rad_shi
            // 
            this.rad_shi.AutoSize = true;
            this.rad_shi.BackColor = System.Drawing.Color.Transparent;
            this.rad_shi.Location = new System.Drawing.Point(106, 391);
            this.rad_shi.Name = "rad_shi";
            this.rad_shi.Size = new System.Drawing.Size(35, 16);
            this.rad_shi.TabIndex = 4;
            this.rad_shi.TabStop = true;
            this.rad_shi.Text = "是";
            this.rad_shi.UseVisualStyleBackColor = false;
            // 
            // rad_fou
            // 
            this.rad_fou.AutoSize = true;
            this.rad_fou.BackColor = System.Drawing.Color.Transparent;
            this.rad_fou.Location = new System.Drawing.Point(174, 391);
            this.rad_fou.Name = "rad_fou";
            this.rad_fou.Size = new System.Drawing.Size(35, 16);
            this.rad_fou.TabIndex = 5;
            this.rad_fou.Text = "否";
            this.rad_fou.UseVisualStyleBackColor = false;
            // 
            // txt_yuexiaoliang
            // 
            this.txt_yuexiaoliang.Location = new System.Drawing.Point(315, 389);
            this.txt_yuexiaoliang.Name = "txt_yuexiaoliang";
            this.txt_yuexiaoliang.Size = new System.Drawing.Size(100, 21);
            this.txt_yuexiaoliang.TabIndex = 6;
            // 
            // dtp_addtime
            // 
            this.dtp_addtime.Location = new System.Drawing.Point(544, 389);
            this.dtp_addtime.Name = "dtp_addtime";
            this.dtp_addtime.Size = new System.Drawing.Size(100, 21);
            this.dtp_addtime.TabIndex = 7;
            // 
            // txt_scd
            // 
            this.txt_scd.Location = new System.Drawing.Point(772, 389);
            this.txt_scd.Name = "txt_scd";
            this.txt_scd.Size = new System.Drawing.Size(100, 21);
            this.txt_scd.TabIndex = 8;
            // 
            // btn_updata
            // 
            this.btn_updata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_updata.Location = new System.Drawing.Point(39, 449);
            this.btn_updata.Name = "btn_updata";
            this.btn_updata.Size = new System.Drawing.Size(79, 23);
            this.btn_updata.TabIndex = 13;
            this.btn_updata.Text = "修改(&U)";
            this.btn_updata.UseVisualStyleBackColor = true;
            this.btn_updata.Click += new System.EventHandler(this.btn_updata_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Location = new System.Drawing.Point(193, 449);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(79, 23);
            this.btn_delete.TabIndex = 14;
            this.btn_delete.Text = "删除(&D)";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Location = new System.Drawing.Point(347, 449);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(79, 23);
            this.btn_clear.TabIndex = 15;
            this.btn_clear.Text = "清空(&C)";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_addcommodity
            // 
            this.btn_addcommodity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addcommodity.Location = new System.Drawing.Point(655, 449);
            this.btn_addcommodity.Name = "btn_addcommodity";
            this.btn_addcommodity.Size = new System.Drawing.Size(79, 23);
            this.btn_addcommodity.TabIndex = 16;
            this.btn_addcommodity.Text = "添加商品(&A)";
            this.btn_addcommodity.UseVisualStyleBackColor = true;
            this.btn_addcommodity.Click += new System.EventHandler(this.btn_addcommodity_Click);
            // 
            // btn_shuaxin
            // 
            this.btn_shuaxin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_shuaxin.Location = new System.Drawing.Point(501, 449);
            this.btn_shuaxin.Name = "btn_shuaxin";
            this.btn_shuaxin.Size = new System.Drawing.Size(79, 23);
            this.btn_shuaxin.TabIndex = 17;
            this.btn_shuaxin.Text = "刷新(&S)";
            this.btn_shuaxin.UseVisualStyleBackColor = true;
            this.btn_shuaxin.Click += new System.EventHandler(this.btn_shuaxin_Click);
            // 
            // btn_xiangxi
            // 
            this.btn_xiangxi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xiangxi.Location = new System.Drawing.Point(809, 449);
            this.btn_xiangxi.Name = "btn_xiangxi";
            this.btn_xiangxi.Size = new System.Drawing.Size(79, 23);
            this.btn_xiangxi.TabIndex = 18;
            this.btn_xiangxi.Text = "查看详细(&B)";
            this.btn_xiangxi.UseVisualStyleBackColor = true;
            this.btn_xiangxi.Click += new System.EventHandler(this.btn_xiangxi_Click);
            // 
            // Love_Shopping
            // 
            this.Love_Shopping.AutoSize = true;
            this.Love_Shopping.Font = new System.Drawing.Font("幼圆", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Love_Shopping.Location = new System.Drawing.Point(0, 0);
            this.Love_Shopping.Name = "Love_Shopping";
            this.Love_Shopping.Size = new System.Drawing.Size(277, 40);
            this.Love_Shopping.TabIndex = 19;
            this.Love_Shopping.Text = "Love Shopping";
            // 
            // Frm_ComYuLan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(934, 507);
            this.Controls.Add(this.Love_Shopping);
            this.Controls.Add(this.btn_xiangxi);
            this.Controls.Add(this.btn_shuaxin);
            this.Controls.Add(this.btn_addcommodity);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_updata);
            this.Controls.Add(this.dtp_addtime);
            this.Controls.Add(this.rad_fou);
            this.Controls.Add(this.rad_shi);
            this.Controls.Add(this.cmb_kuaidi);
            this.Controls.Add(this.txt_scd);
            this.Controls.Add(this.txt_yuexiaoliang);
            this.Controls.Add(this.txt_kucun);
            this.Controls.Add(this.txt_shoujia);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.lab_id);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_yulan);
            this.MinimumSize = new System.Drawing.Size(942, 534);
            this.Name = "Frm_ComYuLan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品预览表";
            this.Load += new System.EventHandler(this.Frm_Sellde_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_yulan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_yulan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lab_id;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_shoujia;
        private System.Windows.Forms.ComboBox cmb_kuaidi;
        private System.Windows.Forms.TextBox txt_kucun;
        private System.Windows.Forms.RadioButton rad_shi;
        private System.Windows.Forms.RadioButton rad_fou;
        private System.Windows.Forms.TextBox txt_yuexiaoliang;
        private System.Windows.Forms.DateTimePicker dtp_addtime;
        private System.Windows.Forms.TextBox txt_scd;
        private System.Windows.Forms.Button btn_updata;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_addcommodity;
        private System.Windows.Forms.Button btn_shuaxin;
        private System.Windows.Forms.Button btn_xiangxi;
        private System.Windows.Forms.Label Love_Shopping;
    }
}