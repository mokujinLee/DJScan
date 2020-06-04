namespace DJScan
{
    partial class BaseScanUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseScanUI));
            this.buttonScan = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonSelectScan = new System.Windows.Forms.Button();
            this.panelScanControl = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.djscan1 = new djScan.BaseScanUI2();
            this.textBoxNotify = new System.Windows.Forms.TextBox();
            this.pictureBoxCapture = new System.Windows.Forms.PictureBox();
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelScanControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonScan
            // 
            this.buttonScan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonScan.BackgroundImage")));
            this.buttonScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonScan.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonScan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonScan.Location = new System.Drawing.Point(0, 0);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(410, 68);
            this.buttonScan.TabIndex = 1;
            this.buttonScan.Text = "掃描";
            this.buttonScan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonImport.BackgroundImage")));
            this.buttonImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonImport.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonImport.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonImport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonImport.Location = new System.Drawing.Point(410, 0);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(105, 68);
            this.buttonImport.TabIndex = 2;
            this.buttonImport.Text = "匯入文件";
            this.buttonImport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonSelectScan
            // 
            this.buttonSelectScan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSelectScan.BackgroundImage")));
            this.buttonSelectScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSelectScan.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSelectScan.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonSelectScan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSelectScan.Location = new System.Drawing.Point(515, 0);
            this.buttonSelectScan.Name = "buttonSelectScan";
            this.buttonSelectScan.Size = new System.Drawing.Size(105, 68);
            this.buttonSelectScan.TabIndex = 0;
            this.buttonSelectScan.Text = "選擇掃描器";
            this.buttonSelectScan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSelectScan.UseVisualStyleBackColor = true;
            this.buttonSelectScan.Click += new System.EventHandler(this.buttonSelectScan_Click);
            // 
            // panelScanControl
            // 
            this.panelScanControl.Controls.Add(this.buttonScan);
            this.panelScanControl.Controls.Add(this.buttonImport);
            this.panelScanControl.Controls.Add(this.buttonSelectScan);
            this.panelScanControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScanControl.Location = new System.Drawing.Point(0, 0);
            this.panelScanControl.Name = "panelScanControl";
            this.panelScanControl.Size = new System.Drawing.Size(620, 68);
            this.panelScanControl.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panelScanControl);
            this.splitContainer2.Size = new System.Drawing.Size(620, 465);
            this.splitContainer2.SplitterDistance = 393;
            this.splitContainer2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.djscan1);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxNotify);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxCapture);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxBarcode);
            this.splitContainer1.Size = new System.Drawing.Size(620, 393);
            this.splitContainer1.SplitterDistance = 307;
            this.splitContainer1.TabIndex = 0;
            // 
            // djscan1
            // 
            this.djscan1.BackColor = System.Drawing.SystemColors.Control;
            this.djscan1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.djscan1.Location = new System.Drawing.Point(0, 46);
            this.djscan1.Name = "djscan1";
            this.djscan1.Size = new System.Drawing.Size(307, 347);
            this.djscan1.TabIndex = 0;
            // 
            // textBoxNotify
            // 
            this.textBoxNotify.BackColor = System.Drawing.Color.Black;
            this.textBoxNotify.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxNotify.Font = new System.Drawing.Font("新細明體", 24F);
            this.textBoxNotify.ForeColor = System.Drawing.Color.Red;
            this.textBoxNotify.Location = new System.Drawing.Point(0, 0);
            this.textBoxNotify.Name = "textBoxNotify";
            this.textBoxNotify.Size = new System.Drawing.Size(307, 46);
            this.textBoxNotify.TabIndex = 2;
            this.textBoxNotify.Text = "請放入掃描文件";
            this.textBoxNotify.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBoxCapture
            // 
            this.pictureBoxCapture.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCapture.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxCapture.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCapture.Name = "pictureBoxCapture";
            this.pictureBoxCapture.Size = new System.Drawing.Size(309, 328);
            this.pictureBoxCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCapture.TabIndex = 0;
            this.pictureBoxCapture.TabStop = false;
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBoxBarcode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxBarcode.Font = new System.Drawing.Font("新細明體", 36F);
            this.textBoxBarcode.Location = new System.Drawing.Point(0, 328);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(309, 65);
            this.textBoxBarcode.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "圖檔|*.jpg;*.jpeg;*.bmp";
            this.openFileDialog1.Multiselect = true;
            // 
            // BaseScanUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Name = "BaseScanUI";
            this.Size = new System.Drawing.Size(620, 465);
            this.panelScanControl.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonSelectScan;
        private System.Windows.Forms.Panel panelScanControl;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBoxNotify;
        private System.Windows.Forms.PictureBox pictureBoxCapture;
        private System.Windows.Forms.TextBox textBoxBarcode;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private djScan.BaseScanUI2 djscan1;
    }
}
