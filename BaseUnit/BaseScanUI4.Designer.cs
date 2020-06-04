namespace DJScan
{
    partial class BaseScanUI4
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
            this.pictureBoxTo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelScanControl
            // 
            this.panelScanControl.Location = new System.Drawing.Point(0, 497);
            this.panelScanControl.Size = new System.Drawing.Size(1079, 61);
            // 
            // pictureBoxTopDisplay
            // 
            this.pictureBoxTopDisplay.Image = global::DJScan.Properties.Resources._151110_chandick_07;
            this.pictureBoxTopDisplay.Location = new System.Drawing.Point(0, 20);
            this.pictureBoxTopDisplay.Size = new System.Drawing.Size(1079, 477);
            // 
            // ucImageView1
            // 
            this.ucImageView1.Location = new System.Drawing.Point(674, 20);
            this.ucImageView1.Size = new System.Drawing.Size(93, 477);
            // 
            // pictureBoxTo
            // 
            this.pictureBoxTo.BackColor = System.Drawing.Color.Black;
            this.pictureBoxTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxTo.Location = new System.Drawing.Point(767, 20);
            this.pictureBoxTo.Name = "pictureBoxTo";
            this.pictureBoxTo.Size = new System.Drawing.Size(312, 477);
            this.pictureBoxTo.TabIndex = 24;
            this.pictureBoxTo.TabStop = false;
            // 
            // BaseScanUI4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxTo);
            this.Name = "BaseScanUI4";
            this.Size = new System.Drawing.Size(1079, 558);
            this.Controls.SetChildIndex(this.panelScanControl, 0);
            this.Controls.SetChildIndex(this.pictureBoxTopDisplay, 0);
            this.Controls.SetChildIndex(this.pictureBoxTo, 0);
            this.Controls.SetChildIndex(this.ucImageView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTo;
    }
}
