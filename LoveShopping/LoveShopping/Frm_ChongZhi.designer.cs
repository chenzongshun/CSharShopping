namespace LoveShopping
{
    partial class Frm_ChongZhi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ChongZhi));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_ChongZhi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lab_yue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_QuXiao = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_ChongZhi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lab_yue);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(95, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 191);
            this.panel1.TabIndex = 0;
            // 
            // txt_ChongZhi
            // 
            this.txt_ChongZhi.Location = new System.Drawing.Point(139, 112);
            this.txt_ChongZhi.Name = "txt_ChongZhi";
            this.txt_ChongZhi.Size = new System.Drawing.Size(100, 21);
            this.txt_ChongZhi.TabIndex = 3;
            this.txt_ChongZhi.Leave += new System.EventHandler(this.txt_ChongZhi_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "充值";
            // 
            // lab_yue
            // 
            this.lab_yue.AutoSize = true;
            this.lab_yue.Location = new System.Drawing.Point(137, 54);
            this.lab_yue.Name = "lab_yue";
            this.lab_yue.Size = new System.Drawing.Size(41, 12);
            this.lab_yue.TabIndex = 1;
            this.lab_yue.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "余额：";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(107, 313);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "充值(&O)";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_QuXiao
            // 
            this.btn_QuXiao.Location = new System.Drawing.Point(374, 313);
            this.btn_QuXiao.Name = "btn_QuXiao";
            this.btn_QuXiao.Size = new System.Drawing.Size(75, 23);
            this.btn_QuXiao.TabIndex = 2;
            this.btn_QuXiao.Text = "取消(&C)";
            this.btn_QuXiao.UseVisualStyleBackColor = true;
            // 
            // Frm_ChongZhi
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(556, 408);
            this.Controls.Add(this.btn_QuXiao);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(771, 529);
            this.MinimumSize = new System.Drawing.Size(572, 447);
            this.Name = "Frm_ChongZhi";
            this.Text = "余额充值";
            this.Load += new System.EventHandler(this.frm_ChongZhi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_ChongZhi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lab_yue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_QuXiao;
    }
}