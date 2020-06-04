namespace DJScan
{
    partial class ucImageView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucImageView));
            this.contextMenuStripDel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDelOne = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelAll = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.flowLayoutPanelImageIcon = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxEmpty = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStripDel.SuspendLayout();
            this.flowLayoutPanelImageIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripDel
            // 
            this.contextMenuStripDel.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripDel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDelOne,
            this.ToolStripMenuItemDelAll});
            this.contextMenuStripDel.Name = "contextMenuStripDel";
            this.contextMenuStripDel.Size = new System.Drawing.Size(199, 93);
            this.contextMenuStripDel.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripDel_Opening);
            // 
            // toolStripMenuItemDelOne
            // 
            this.toolStripMenuItemDelOne.Name = "toolStripMenuItemDelOne";
            this.toolStripMenuItemDelOne.Size = new System.Drawing.Size(198, 28);
            this.toolStripMenuItemDelOne.Text = "刪除";
            this.toolStripMenuItemDelOne.Visible = false;
            this.toolStripMenuItemDelOne.Click += new System.EventHandler(this.toolStripMenuItemDelOne_Click);
            // 
            // ToolStripMenuItemDelAll
            // 
            this.ToolStripMenuItemDelAll.Name = "ToolStripMenuItemDelAll";
            this.ToolStripMenuItemDelAll.Size = new System.Drawing.Size(198, 28);
            this.ToolStripMenuItemDelAll.Text = "全部刪除";
            this.ToolStripMenuItemDelAll.Click += new System.EventHandler(this.ToolStripMenuItemDelAll_Click);
            // 
            // flowLayoutPanelImageIcon
            // 
            this.flowLayoutPanelImageIcon.AutoSize = true;
            this.flowLayoutPanelImageIcon.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.flowLayoutPanelImageIcon.Controls.Add(this.checkBoxEmpty);
            this.flowLayoutPanelImageIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelImageIcon.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelImageIcon.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelImageIcon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanelImageIcon.Name = "flowLayoutPanelImageIcon";
            this.flowLayoutPanelImageIcon.Size = new System.Drawing.Size(250, 592);
            this.flowLayoutPanelImageIcon.TabIndex = 1;
            this.flowLayoutPanelImageIcon.DoubleClick += new System.EventHandler(this.flowLayoutPanel1_DoubleClick);
            // 
            // checkBoxEmpty
            // 
            this.checkBoxEmpty.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkBoxEmpty.BackgroundImage")));
            this.checkBoxEmpty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkBoxEmpty.Location = new System.Drawing.Point(4, 4);
            this.checkBoxEmpty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxEmpty.Name = "checkBoxEmpty";
            this.checkBoxEmpty.Size = new System.Drawing.Size(130, 158);
            this.checkBoxEmpty.TabIndex = 0;
            this.checkBoxEmpty.Text = "空白文件";
            this.checkBoxEmpty.UseVisualStyleBackColor = true;
            this.checkBoxEmpty.CheckedChanged += new System.EventHandler(this.checkBoxEmpty_CheckedChanged);
            this.checkBoxEmpty.MouseEnter += new System.EventHandler(this.ImgIcon_MouseEnter);
            this.checkBoxEmpty.MouseLeave += new System.EventHandler(this.checkBoxEmpty_MouseLeave);
            // 
            // ucImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.flowLayoutPanelImageIcon);
            this.Name = "ucImageView";
            this.Size = new System.Drawing.Size(250, 592);
            this.contextMenuStripDel.ResumeLayout(false);
            this.flowLayoutPanelImageIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripDel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelOne;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelAll;
        private System.Windows.Forms.CheckBox checkBoxEmpty;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImageIcon;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
