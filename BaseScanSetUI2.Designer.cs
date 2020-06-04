namespace DJScan
{
    partial class BaseScanSetUI2
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ucSetManager2 = new DJScan.ucSetManager();
            this.panelScanControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelScanControl
            // 
            this.panelScanControl.Location = new System.Drawing.Point(0, 512);
            this.panelScanControl.Size = new System.Drawing.Size(1136, 116);
            // 
            // buttonBarCodeOK
            // 
            this.buttonBarCodeOK.Location = new System.Drawing.Point(979, 0);
            // 
            // ucSetManager2
            // 
            this.ucSetManager2.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucSetManager2.Location = new System.Drawing.Point(848, 0);
            this.ucSetManager2.Name = "ucSetManager2";
            this.ucSetManager2.Size = new System.Drawing.Size(131, 512);
            this.ucSetManager2.TabIndex = 26;
            // 
            // BaseScanSetUI2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucSetManager2);
            this.Name = "BaseScanSetUI2";
            this.Size = new System.Drawing.Size(1136, 628);
            this.Controls.SetChildIndex(this.panelScanControl, 0);
            this.Controls.SetChildIndex(this.ucSetManager2, 0);
            this.panelScanControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucSetManager ucSetManager2;
    }
}
