namespace LoveShopping
{
    partial class Frm_Restore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Restore));
            this.pic_huifu = new System.Windows.Forms.PictureBox();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_path = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.lab_tip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_huifu)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_huifu
            // 
            this.pic_huifu.Image = ((System.Drawing.Image)(resources.GetObject("pic_huifu.Image")));
            this.pic_huifu.Location = new System.Drawing.Point(38, 164);
            this.pic_huifu.Name = "pic_huifu";
            this.pic_huifu.Size = new System.Drawing.Size(232, 185);
            this.pic_huifu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_huifu.TabIndex = 9;
            this.pic_huifu.TabStop = false;
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(343, 230);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(237, 21);
            this.txt_path.TabIndex = 0;
            this.txt_path.Click += new System.EventHandler(this.btn_path_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(277, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 68);
            this.label1.TabIndex = 7;
            this.label1.Text = "恢复数据";
            // 
            // btn_ok
            // 
            this.btn_ok.Image = ((System.Drawing.Image)(resources.GetObject("btn_ok.Image")));
            this.btn_ok.Location = new System.Drawing.Point(342, 313);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "确定(&O)";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Image = ((System.Drawing.Image)(resources.GetObject("btn_clear.Image")));
            this.btn_clear.Location = new System.Drawing.Point(491, 313);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 3;
            this.btn_clear.Text = "清空(&C)";
            this.btn_clear.UseVisualStyleBackColor = true;
            // 
            // btn_path
            // 
            this.btn_path.Location = new System.Drawing.Point(599, 228);
            this.btn_path.Name = "btn_path";
            this.btn_path.Size = new System.Drawing.Size(112, 23);
            this.btn_path.TabIndex = 1;
            this.btn_path.Text = "选择要恢复的文件";
            this.btn_path.UseVisualStyleBackColor = true;
            this.btn_path.Click += new System.EventHandler(this.btn_path_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_exit.Image")));
            this.btn_exit.Location = new System.Drawing.Point(636, 313);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 11;
            this.btn_exit.Text = "退出(&T)";
            this.btn_exit.UseVisualStyleBackColor = true;
            // 
            // lab_tip
            // 
            this.lab_tip.AutoSize = true;
            this.lab_tip.BackColor = System.Drawing.Color.Transparent;
            this.lab_tip.Location = new System.Drawing.Point(185, 129);
            this.lab_tip.Name = "lab_tip";
            this.lab_tip.Size = new System.Drawing.Size(557, 12);
            this.lab_tip.TabIndex = 10;
            this.lab_tip.Text = "此功能将会删除掉现有数据库然后恢复以前的数据库，恢复成功后将会退回到登陆界面，本功能谨慎使用";
            // 
            // Frm_Restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(764, 423);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.lab_tip);
            this.Controls.Add(this.pic_huifu);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_path);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(780, 462);
            this.Name = "Frm_Restore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "恢复数据库";
            this.Load += new System.EventHandler(this.Frm_Restore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_huifu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_huifu;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_path;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label lab_tip;

    }
}