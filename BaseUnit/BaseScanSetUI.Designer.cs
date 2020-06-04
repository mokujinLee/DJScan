namespace DJScan
{
    partial class BaseScanSetUI
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
            this.ucSetManager1 = new DJScan.ucSetManager();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxOption = new System.Windows.Forms.ComboBox();
            this.panelScanControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelScanControl
            // 
            this.panelScanControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelScanControl.Location = new System.Drawing.Point(0, 513);
            this.panelScanControl.Size = new System.Drawing.Size(859, 60);
            // 
            // buttonBarCodeOK
            // 
            this.buttonBarCodeOK.Location = new System.Drawing.Point(702, 0);
            this.buttonBarCodeOK.Size = new System.Drawing.Size(157, 60);
            this.buttonBarCodeOK.Click += new System.EventHandler(this.buttonBarCodeOK_Click);
            // 
            // ucSetManager1
            // 
            this.ucSetManager1.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucSetManager1.Location = new System.Drawing.Point(702, 0);
            this.ucSetManager1.Name = "ucSetManager1";
            this.ucSetManager1.Size = new System.Drawing.Size(157, 513);
            this.ucSetManager1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(702, 493);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // comboBoxOption
            // 
            this.comboBoxOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxOption.FormattingEnabled = true;
            this.comboBoxOption.Items.AddRange(new object[] {
            "式憑原則"});
            this.comboBoxOption.Location = new System.Drawing.Point(0, 0);
            this.comboBoxOption.Name = "comboBoxOption";
            this.comboBoxOption.Size = new System.Drawing.Size(702, 20);
            this.comboBoxOption.TabIndex = 26;
            this.comboBoxOption.Visible = false;
            this.comboBoxOption.SelectedIndexChanged += new System.EventHandler(this.comboBoxOption_SelectedIndexChanged);
            // 
            // BaseScanSetUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBoxOption);
            this.Controls.Add(this.ucSetManager1);
            this.Name = "BaseScanSetUI";
            this.Size = new System.Drawing.Size(859, 573);
            this.Controls.SetChildIndex(this.panelScanControl, 0);
            this.Controls.SetChildIndex(this.ucSetManager1, 0);
            this.Controls.SetChildIndex(this.comboBoxOption, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.panelScanControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        public ucSetManager ucSetManager1;
        private System.Windows.Forms.ComboBox comboBoxOption;
    }
}
