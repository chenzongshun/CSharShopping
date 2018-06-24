namespace LoveShopping
{
    partial class Frm_BuydeGoods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_BuydeGoods));
            this.pan_goods = new System.Windows.Forms.Panel();
            this.lab_tip = new System.Windows.Forms.Label();
            this.pan_goods.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_goods
            // 
            this.pan_goods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pan_goods.AutoScroll = true;
            this.pan_goods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_goods.Controls.Add(this.lab_tip);
            this.pan_goods.Location = new System.Drawing.Point(25, 18);
            this.pan_goods.Name = "pan_goods";
            this.pan_goods.Size = new System.Drawing.Size(785, 518);
            this.pan_goods.TabIndex = 0;
            // 
            // lab_tip
            // 
            this.lab_tip.AutoSize = true;
            this.lab_tip.Location = new System.Drawing.Point(359, 14);
            this.lab_tip.Name = "lab_tip";
            this.lab_tip.Size = new System.Drawing.Size(437, 12);
            this.lab_tip.TabIndex = 0;
            this.lab_tip.Text = "此控件来回漂浮，本页绝大多数是代码生成控件，请不要动此控件，否则漂浮失败";
            // 
            // Frm_BuydeGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(834, 540);
            this.Controls.Add(this.pan_goods);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(850, 579);
            this.MinimumSize = new System.Drawing.Size(850, 579);
            this.Name = "Frm_BuydeGoods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看订单";
            this.Load += new System.EventHandler(this.Frm_BuydeGoods_Load);
            this.pan_goods.ResumeLayout(false);
            this.pan_goods.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_goods;
        private System.Windows.Forms.Label lab_tip;






    }
}