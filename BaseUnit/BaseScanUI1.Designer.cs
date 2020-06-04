namespace DJScan
{
    partial class BaseScanUI1
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ucImageView1 = new DJScan.ucImageView();
            this.SuspendLayout();
            // 
            // ucImageView1
            // 
            this.ucImageView1.AutoSize = true;
            this.ucImageView1.BackColor = System.Drawing.Color.Black;
            this.ucImageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucImageView1.Location = new System.Drawing.Point(0, 0);
            this.ucImageView1.Margin = new System.Windows.Forms.Padding(2);
            this.ucImageView1.Name = "ucImageView1";
            this.ucImageView1.ReadOnlyMode = false;
            this.ucImageView1.Size = new System.Drawing.Size(461, 615);
            this.ucImageView1.TabIndex = 20;
            // 
            // BaseScanUI1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucImageView1);
            this.Name = "BaseScanUI1";
            this.Size = new System.Drawing.Size(461, 615);
            this.Load += new System.EventHandler(this.BaseScanUI1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected ucImageView ucImageView1;
    }
}
