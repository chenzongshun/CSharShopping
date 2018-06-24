namespace LoveShopping
{
    partial class Frm_Backup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Backup));
            this.btn_path = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.lab_tip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_path
            // 
            this.btn_path.Image = ((System.Drawing.Image)(resources.GetObject("btn_path.Image")));
            this.btn_path.Location = new System.Drawing.Point(638, 203);
            this.btn_path.Name = "btn_path";
            this.btn_path.Size = new System.Drawing.Size(76, 23);
            this.btn_path.TabIndex = 1;
            this.btn_path.Text = "选择文件夹";
            this.btn_path.UseVisualStyleBackColor = true;
            this.btn_path.Click += new System.EventHandler(this.btn_path_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(276, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "备份数据库";
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(427, 205);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(194, 21);
            this.txt_path.TabIndex = 0;
            this.txt_path.Click += new System.EventHandler(this.txt_path_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 143);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 183);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.SystemColors.Info;
            this.btn_clear.Image = ((System.Drawing.Image)(resources.GetObject("btn_clear.Image")));
            this.btn_clear.Location = new System.Drawing.Point(544, 281);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 3;
            this.btn_clear.Text = "清空";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.SystemColors.Info;
            this.btn_ok.Image = ((System.Drawing.Image)(resources.GetObject("btn_ok.Image")));
            this.btn_ok.Location = new System.Drawing.Point(428, 281);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // lab_tip
            // 
            this.lab_tip.AutoSize = true;
            this.lab_tip.Location = new System.Drawing.Point(501, 100);
            this.lab_tip.Name = "lab_tip";
            this.lab_tip.Size = new System.Drawing.Size(185, 12);
            this.lab_tip.TabIndex = 4;
            this.lab_tip.Text = "tip:将会备份数据库到指定的路径";
            // 
            // Frm_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(766, 384);
            this.Controls.Add(this.lab_tip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_path);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(782, 423);
            this.MinimumSize = new System.Drawing.Size(782, 423);
            this.Name = "Frm_Backup";
            this.Text = "备份数据库";
            this.Load += new System.EventHandler(this.Frm_Backup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label lab_tip;
    }
}