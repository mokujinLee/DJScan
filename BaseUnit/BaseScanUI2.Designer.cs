namespace DJScan
{
    partial class BaseScanUI2
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
            this.pictureBoxTopDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // ucImageView1
            // 
            this.ucImageView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucImageView1.Location = new System.Drawing.Point(920, 0);
            this.ucImageView1.Size = new System.Drawing.Size(93, 566);
            // 
            // pictureBoxTopDisplay
            // 
            this.pictureBoxTopDisplay.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxTopDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTopDisplay.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTopDisplay.Name = "pictureBoxTopDisplay";
            this.pictureBoxTopDisplay.Size = new System.Drawing.Size(920, 566);
            this.pictureBoxTopDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTopDisplay.TabIndex = 21;
            this.pictureBoxTopDisplay.TabStop = false;
            // 
            // BaseScanUI2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxTopDisplay);
            this.Name = "BaseScanUI2";
            this.Size = new System.Drawing.Size(1013, 566);
            this.Controls.SetChildIndex(this.ucImageView1, 0);
            this.Controls.SetChildIndex(this.pictureBoxTopDisplay, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBoxTopDisplay;
    }
}
