namespace DJScan
{
    partial class BaseScanButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseScanButton));
            this.panelScanControl = new System.Windows.Forms.Panel();
            this.buttonScan = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonSelectScan = new System.Windows.Forms.Button();
            this.buttonBarCodeOK = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelScanControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelScanControl
            // 
            this.panelScanControl.Controls.Add(this.buttonScan);
            this.panelScanControl.Controls.Add(this.buttonImport);
            this.panelScanControl.Controls.Add(this.buttonSelectScan);
            this.panelScanControl.Controls.Add(this.buttonBarCodeOK);
            this.panelScanControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScanControl.Location = new System.Drawing.Point(0, 0);
            this.panelScanControl.Name = "panelScanControl";
            this.panelScanControl.Size = new System.Drawing.Size(688, 64);
            this.panelScanControl.TabIndex = 25;
            // 
            // buttonScan
            // 
            this.buttonScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonScan.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonScan.Image = global::DJScan.Properties.Resources.Scanner_icon;
            this.buttonScan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonScan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonScan.Location = new System.Drawing.Point(0, 0);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(243, 64);
            this.buttonScan.TabIndex = 1;
            this.buttonScan.Text = "掃    描";
            this.buttonScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonImport.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonImport.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonImport.Image = ((System.Drawing.Image)(resources.GetObject("buttonImport.Image")));
            this.buttonImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonImport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonImport.Location = new System.Drawing.Point(243, 0);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(147, 64);
            this.buttonImport.TabIndex = 2;
            this.buttonImport.Text = "匯入文件";
            this.buttonImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonSelectScan
            // 
            this.buttonSelectScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSelectScan.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSelectScan.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSelectScan.Image = ((System.Drawing.Image)(resources.GetObject("buttonSelectScan.Image")));
            this.buttonSelectScan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSelectScan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSelectScan.Location = new System.Drawing.Point(390, 0);
            this.buttonSelectScan.Name = "buttonSelectScan";
            this.buttonSelectScan.Size = new System.Drawing.Size(154, 64);
            this.buttonSelectScan.TabIndex = 0;
            this.buttonSelectScan.Text = "選擇掃描器";
            this.buttonSelectScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSelectScan.UseVisualStyleBackColor = true;
            this.buttonSelectScan.Visible = false;
            this.buttonSelectScan.Click += new System.EventHandler(this.buttonSelectScan_Click);
            // 
            // buttonBarCodeOK
            // 
            this.buttonBarCodeOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBarCodeOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonBarCodeOK.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonBarCodeOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonBarCodeOK.Image")));
            this.buttonBarCodeOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBarCodeOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonBarCodeOK.Location = new System.Drawing.Point(544, 0);
            this.buttonBarCodeOK.Name = "buttonBarCodeOK";
            this.buttonBarCodeOK.Size = new System.Drawing.Size(144, 64);
            this.buttonBarCodeOK.TabIndex = 19;
            this.buttonBarCodeOK.Tag = "";
            this.buttonBarCodeOK.Text = "確  定";
            this.buttonBarCodeOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonBarCodeOK.UseVisualStyleBackColor = true;
            this.buttonBarCodeOK.Click += new System.EventHandler(this.buttonBarCodeOK_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "圖檔|*.jpg;*.jpeg";
            this.openFileDialog1.Multiselect = true;
            // 
            // BaseScanButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelScanControl);
            this.Name = "BaseScanButton";
            this.Size = new System.Drawing.Size(688, 64);
            this.Load += new System.EventHandler(this.BaseScanButton_Load);
            this.panelScanControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelScanControl;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonSelectScan;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Button buttonBarCodeOK;
    }
}
