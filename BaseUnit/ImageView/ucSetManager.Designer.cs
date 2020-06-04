namespace DJScan
{
    partial class ucSetManager
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
            this.components = new System.ComponentModel.Container();
            this.ucImageView1 = new ucImageView();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSetManager));
            this.contextMenuStripAddition = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDelOneSet = new System.Windows.Forms.ToolStripMenuItem();
            this.全部清除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanelSetCounter = new System.Windows.Forms.FlowLayoutPanel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelMaxSealSet = new System.Windows.Forms.Label();
            this.flowLayoutPanelUserItem = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBtn = new System.Windows.Forms.Panel();
            this.buttonAddSet = new System.Windows.Forms.Button();
            this.flowLayoutPanelBtn = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonBarCodeOK = new System.Windows.Forms.Button();
            this.contextMenuStripAddition.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanelSetCounter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panelBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucImageView1
            // 
            this.ucImageView1._InnerTargetMouseClickEvent = null;
            this.ucImageView1.AutoSize = true;
            this.ucImageView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ucImageView1.boolShowIconPathHint = false;
            this.ucImageView1.ContextMenuStrip = this.contextMenuStripAddition;
            this.ucImageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucImageView1.IconFlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ucImageView1.Location = new System.Drawing.Point(0, 0);
            this.ucImageView1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ucImageView1.Name = "ucImageView1";
            this.ucImageView1.ReadOnlyMode = false;
            this.ucImageView1.Size = new System.Drawing.Size(188, 295);
            this.ucImageView1.TabIndex = 0;
            // 
            // contextMenuStripAddition
            // 
            this.contextMenuStripAddition.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripAddition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDelOneSet,
            this.全部清除ToolStripMenuItem});
            this.contextMenuStripAddition.Name = "contextMenuStripAddition";
            this.contextMenuStripAddition.Size = new System.Drawing.Size(153, 70);
            this.contextMenuStripAddition.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripAddition_Opening);
            // 
            // toolStripMenuItemDelOneSet
            // 
            this.toolStripMenuItemDelOneSet.Enabled = false;
            this.toolStripMenuItemDelOneSet.Name = "toolStripMenuItemDelOneSet";
            this.toolStripMenuItemDelOneSet.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemDelOneSet.Text = "清除此式";
            this.toolStripMenuItemDelOneSet.Click += new System.EventHandler(this.toolStripMenuItemDelOneSet_Click);
            // 
            // 全部清除ToolStripMenuItem
            // 
            this.全部清除ToolStripMenuItem.Name = "全部清除ToolStripMenuItem";
            this.全部清除ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.全部清除ToolStripMenuItem.Text = "全部清除";
            this.全部清除ToolStripMenuItem.Click += new System.EventHandler(this.全部清除ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanelSetCounter);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanelUserItem);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucImageView1);
            this.splitContainer1.Panel2.Controls.Add(this.panelBtn);
            this.splitContainer1.Size = new System.Drawing.Size(188, 547);
            this.splitContainer1.SplitterDistance = 83;
            this.splitContainer1.TabIndex = 1;
            // 
            // flowLayoutPanelSetCounter
            // 
            this.flowLayoutPanelSetCounter.BackColor = System.Drawing.Color.DimGray;
            this.flowLayoutPanelSetCounter.Controls.Add(this.numericUpDown1);
            this.flowLayoutPanelSetCounter.Controls.Add(this.labelMaxSealSet);
            this.flowLayoutPanelSetCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelSetCounter.Location = new System.Drawing.Point(0, 27);
            this.flowLayoutPanelSetCounter.Name = "flowLayoutPanelSetCounter";
            this.flowLayoutPanelSetCounter.Size = new System.Drawing.Size(188, 56);
            this.flowLayoutPanelSetCounter.TabIndex = 5;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.AutoSize = true;
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown1.Location = new System.Drawing.Point(3, 3);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(37, 36);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // labelMaxSealSet
            // 
            this.labelMaxSealSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMaxSealSet.AutoSize = true;
            this.labelMaxSealSet.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelMaxSealSet.Location = new System.Drawing.Point(46, 0);
            this.labelMaxSealSet.Name = "labelMaxSealSet";
            this.labelMaxSealSet.Size = new System.Drawing.Size(33, 42);
            this.labelMaxSealSet.TabIndex = 3;
            this.labelMaxSealSet.Text = " /1";
            // 
            // flowLayoutPanelUserItem
            // 
            this.flowLayoutPanelUserItem.BackColor = System.Drawing.Color.Silver;
            this.flowLayoutPanelUserItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelUserItem.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelUserItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanelUserItem.Name = "flowLayoutPanelUserItem";
            this.flowLayoutPanelUserItem.Size = new System.Drawing.Size(188, 27);
            this.flowLayoutPanelUserItem.TabIndex = 4;
            // 
            // panelBtn
            // 
            this.panelBtn.Controls.Add(this.buttonAddSet);
            this.panelBtn.Controls.Add(this.flowLayoutPanelBtn);
            this.panelBtn.Controls.Add(this.buttonBarCodeOK);
            this.panelBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBtn.Location = new System.Drawing.Point(0, 295);
            this.panelBtn.Name = "panelBtn";
            this.panelBtn.Size = new System.Drawing.Size(188, 165);
            this.panelBtn.TabIndex = 28;
            // 
            // buttonAddSet
            // 
            this.buttonAddSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAddSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddSet.Enabled = false;
            this.buttonAddSet.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold);
            this.buttonAddSet.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddSet.Image")));
            this.buttonAddSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddSet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonAddSet.Location = new System.Drawing.Point(0, 0);
            this.buttonAddSet.Name = "buttonAddSet";
            this.buttonAddSet.Size = new System.Drawing.Size(188, 62);
            this.buttonAddSet.TabIndex = 29;
            this.buttonAddSet.Tag = "";
            this.buttonAddSet.Text = "加入此式";
            this.buttonAddSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAddSet.UseVisualStyleBackColor = true;
            this.buttonAddSet.Click += new System.EventHandler(this.buttonOneSet_Click);
            // 
            // flowLayoutPanelBtn
            // 
            this.flowLayoutPanelBtn.BackColor = System.Drawing.Color.Silver;
            this.flowLayoutPanelBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelBtn.Location = new System.Drawing.Point(0, 62);
            this.flowLayoutPanelBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanelBtn.Name = "flowLayoutPanelBtn";
            this.flowLayoutPanelBtn.Size = new System.Drawing.Size(188, 57);
            this.flowLayoutPanelBtn.TabIndex = 5;
            // 
            // buttonBarCodeOK
            // 
            this.buttonBarCodeOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBarCodeOK.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonBarCodeOK.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold);
            this.buttonBarCodeOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonBarCodeOK.Image")));
            this.buttonBarCodeOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBarCodeOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonBarCodeOK.Location = new System.Drawing.Point(0, 119);
            this.buttonBarCodeOK.Name = "buttonBarCodeOK";
            this.buttonBarCodeOK.Size = new System.Drawing.Size(188, 46);
            this.buttonBarCodeOK.TabIndex = 27;
            this.buttonBarCodeOK.Tag = "";
            this.buttonBarCodeOK.Text = "確  定";
            this.buttonBarCodeOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonBarCodeOK.UseVisualStyleBackColor = true;
            this.buttonBarCodeOK.Visible = false;
            this.buttonBarCodeOK.Click += new System.EventHandler(this.buttonBarCodeOK_Click);
            // 
            // ucSetManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucSetManager";
            this.Size = new System.Drawing.Size(188, 547);
            this.contextMenuStripAddition.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanelSetCounter.ResumeLayout(false);
            this.flowLayoutPanelSetCounter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panelBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSetCounter;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelMaxSealSet;
        public ucImageView ucImageView1;
        private System.Windows.Forms.Panel panelBtn;
        public System.Windows.Forms.Button buttonBarCodeOK;
        public System.Windows.Forms.Button buttonAddSet;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAddition;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelOneSet;
        private System.Windows.Forms.ToolStripMenuItem 全部清除ToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUserItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBtn;
    }
}
