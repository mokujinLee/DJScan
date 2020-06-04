namespace DJScan
{
    partial class BaseScanUI3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseScanUI3));
            this.panelScanControl = new System.Windows.Forms.Panel();
            this.buttonScan = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonSelectScan = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopDisplay)).BeginInit();
            this.panelScanControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxTopDisplay
            // 
            this.pictureBoxTopDisplay.Size = new System.Drawing.Size(785, 509);
            // 
            // ucImageView1
            // 
            this.ucImageView1.Location = new System.Drawing.Point(785, 0);
            this.ucImageView1.Size = new System.Drawing.Size(93, 509);
            // 
            // panelScanControl
            // 
            this.panelScanControl.Controls.Add(this.buttonScan);
            this.panelScanControl.Controls.Add(this.buttonImport);
            this.panelScanControl.Controls.Add(this.buttonSelectScan);
            this.panelScanControl.Controls.Add(this.buttonCancel);
            this.panelScanControl.Controls.Add(this.buttonOK);
            this.panelScanControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelScanControl.Location = new System.Drawing.Point(0, 509);
            this.panelScanControl.Name = "panelScanControl";
            this.panelScanControl.Size = new System.Drawing.Size(878, 61);
            this.panelScanControl.TabIndex = 23;
            // 
            // buttonScan
            // 
            this.buttonScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonScan.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonScan.Image = ((System.Drawing.Image)(resources.GetObject("buttonScan.Image")));
            this.buttonScan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonScan.Location = new System.Drawing.Point(0, 0);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(172, 61);
            this.buttonScan.TabIndex = 1;
            this.buttonScan.Text = "掃  描";
            this.buttonScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonImport.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonImport.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonImport.Image = ((System.Drawing.Image)(resources.GetObject("buttonImport.Image")));
            this.buttonImport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonImport.Location = new System.Drawing.Point(172, 0);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(246, 61);
            this.buttonImport.TabIndex = 2;
            this.buttonImport.Text = "匯入文件(多選)";
            this.buttonImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonSelectScan
            // 
            this.buttonSelectScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSelectScan.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSelectScan.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSelectScan.Image = ((System.Drawing.Image)(resources.GetObject("buttonSelectScan.Image")));
            this.buttonSelectScan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSelectScan.Location = new System.Drawing.Point(418, 0);
            this.buttonSelectScan.Name = "buttonSelectScan";
            this.buttonSelectScan.Size = new System.Drawing.Size(169, 61);
            this.buttonSelectScan.TabIndex = 0;
            this.buttonSelectScan.Text = "選擇掃描器";
            this.buttonSelectScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSelectScan.UseVisualStyleBackColor = true;
            this.buttonSelectScan.Visible = false;
            this.buttonSelectScan.Click += new System.EventHandler(this.buttonSelectScan_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCancel.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonCancel.Image = global::DJScan.Properties.Resources._1_left;
            this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCancel.Location = new System.Drawing.Point(587, 0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(134, 61);
            this.buttonCancel.TabIndex = 20;
            this.buttonCancel.Tag = "";
            this.buttonCancel.Text = "取消";
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonOK.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Image")));
            this.buttonOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonOK.Location = new System.Drawing.Point(721, 0);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(157, 61);
            this.buttonOK.TabIndex = 19;
            this.buttonOK.Tag = "";
            this.buttonOK.Text = "確  定";
            this.buttonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "圖檔|*.jpg;*.jpeg;*.bmp";
            this.openFileDialog1.Multiselect = true;
            // 
            // BaseScanUI3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelScanControl);
            this.Name = "BaseScanUI3";
            this.Size = new System.Drawing.Size(878, 570);
            this.Load += new System.EventHandler(this.BaseScanUI3_Load);
            this.Controls.SetChildIndex(this.panelScanControl, 0);
            this.Controls.SetChildIndex(this.ucImageView1, 0);
            this.Controls.SetChildIndex(this.pictureBoxTopDisplay, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopDisplay)).EndInit();
            this.panelScanControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonSelectScan;
        public System.Windows.Forms.Panel panelScanControl;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonCancel;
    }
}
