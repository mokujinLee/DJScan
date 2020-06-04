using System.ComponentModel;
using djeOpen.Model;

namespace djeOpen.Usercontrols
{
    [ToolboxItem(false)]
    public class ucCustdataMW : ucDataControl<s_custdata>
    {
        public ucCustdataMW()
        {

        }
    }

    partial class ucCustdata
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
            System.Windows.Forms.Label bIRTHDATELabel;
            System.Windows.Forms.Label cUSTIDLabel;
            System.Windows.Forms.Label cUSTTYPELabel;
            System.Windows.Forms.Label eNGNAMELabel;
            System.Windows.Forms.Label jOBTITLELabel;
            System.Windows.Forms.Label jOBTYPELabel;
            System.Windows.Forms.Label mARIAGELabel;
            System.Windows.Forms.Label nAMELabel;
            System.Windows.Forms.Label nOTELabel;
            System.Windows.Forms.Label sEXLabel;
            System.Windows.Forms.Label tITPLACELabel;
            this.bIRTHDATEDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cUSTIDTextBox = new System.Windows.Forms.TextBox();
            this.cUSTTYPEComboBox = new System.Windows.Forms.ComboBox();
            this.eNGNAMETextBox = new System.Windows.Forms.TextBox();
            this.jOBTITLEComboBox = new System.Windows.Forms.ComboBox();
            this.jOBTYPEComboBox = new System.Windows.Forms.ComboBox();
            this.mARIAGEComboBox = new System.Windows.Forms.ComboBox();
            this.nAMETextBox = new System.Windows.Forms.TextBox();
            this.nOTETextBox = new System.Windows.Forms.TextBox();
            this.sEXComboBox = new System.Windows.Forms.ComboBox();
            this.tITPLACETextBox = new System.Windows.Forms.TextBox();
            this.s_contactbookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.s_contactbookDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            bIRTHDATELabel = new System.Windows.Forms.Label();
            cUSTIDLabel = new System.Windows.Forms.Label();
            cUSTTYPELabel = new System.Windows.Forms.Label();
            eNGNAMELabel = new System.Windows.Forms.Label();
            jOBTITLELabel = new System.Windows.Forms.Label();
            jOBTYPELabel = new System.Windows.Forms.Label();
            mARIAGELabel = new System.Windows.Forms.Label();
            nAMELabel = new System.Windows.Forms.Label();
            nOTELabel = new System.Windows.Forms.Label();
            sEXLabel = new System.Windows.Forms.Label();
            tITPLACELabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_contactbookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_contactbookDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnDelete.Location = new System.Drawing.Point(422, 298);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.Location = new System.Drawing.Point(503, 299);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(584, 298);
            // 
            // dataBindingSource
            // 
            this.dataBindingSource.DataSource = typeof(djeOpen.Model.s_custdata);
            // 
            // bIRTHDATELabel
            // 
            bIRTHDATELabel.AutoSize = true;
            bIRTHDATELabel.Location = new System.Drawing.Point(261, 18);
            bIRTHDATELabel.Name = "bIRTHDATELabel";
            bIRTHDATELabel.Size = new System.Drawing.Size(29, 12);
            bIRTHDATELabel.TabIndex = 0;
            bIRTHDATELabel.Text = "生日";
            // 
            // cUSTIDLabel
            // 
            cUSTIDLabel.AutoSize = true;
            cUSTIDLabel.Location = new System.Drawing.Point(49, 18);
            cUSTIDLabel.Name = "cUSTIDLabel";
            cUSTIDLabel.Size = new System.Drawing.Size(65, 12);
            cUSTIDLabel.TabIndex = 2;
            cUSTIDLabel.Text = "身份証編號";
            // 
            // cUSTTYPELabel
            // 
            cUSTTYPELabel.AutoSize = true;
            cUSTTYPELabel.Location = new System.Drawing.Point(61, 45);
            cUSTTYPELabel.Name = "cUSTTYPELabel";
            cUSTTYPELabel.Size = new System.Drawing.Size(53, 12);
            cUSTTYPELabel.TabIndex = 4;
            cUSTTYPELabel.Text = "客戶類別";
            // 
            // eNGNAMELabel
            // 
            eNGNAMELabel.AutoSize = true;
            eNGNAMELabel.Location = new System.Drawing.Point(53, 72);
            eNGNAMELabel.Name = "eNGNAMELabel";
            eNGNAMELabel.Size = new System.Drawing.Size(61, 12);
            eNGNAMELabel.TabIndex = 6;
            eNGNAMELabel.Text = "姓名(英文)";
            // 
            // jOBTITLELabel
            // 
            jOBTITLELabel.AutoSize = true;
            jOBTITLELabel.Location = new System.Drawing.Point(61, 99);
            jOBTITLELabel.Name = "jOBTITLELabel";
            jOBTITLELabel.Size = new System.Drawing.Size(53, 12);
            jOBTITLELabel.TabIndex = 8;
            jOBTITLELabel.Text = "工作職稱";
            // 
            // jOBTYPELabel
            // 
            jOBTYPELabel.AutoSize = true;
            jOBTYPELabel.Location = new System.Drawing.Point(61, 125);
            jOBTYPELabel.Name = "jOBTYPELabel";
            jOBTYPELabel.Size = new System.Drawing.Size(53, 12);
            jOBTYPELabel.TabIndex = 10;
            jOBTYPELabel.Text = "工作類型";
            // 
            // mARIAGELabel
            // 
            mARIAGELabel.AutoSize = true;
            mARIAGELabel.Location = new System.Drawing.Point(61, 151);
            mARIAGELabel.Name = "mARIAGELabel";
            mARIAGELabel.Size = new System.Drawing.Size(53, 12);
            mARIAGELabel.TabIndex = 12;
            mARIAGELabel.Text = "婚姻狀態";
            // 
            // nAMELabel
            // 
            nAMELabel.AutoSize = true;
            nAMELabel.Location = new System.Drawing.Point(53, 178);
            nAMELabel.Name = "nAMELabel";
            nAMELabel.Size = new System.Drawing.Size(61, 12);
            nAMELabel.TabIndex = 14;
            nAMELabel.Text = "姓名(中文)";
            // 
            // nOTELabel
            // 
            nOTELabel.AutoSize = true;
            nOTELabel.Location = new System.Drawing.Point(20, 260);
            nOTELabel.Name = "nOTELabel";
            nOTELabel.Size = new System.Drawing.Size(29, 12);
            nOTELabel.TabIndex = 16;
            nOTELabel.Text = "備註";
            // 
            // sEXLabel
            // 
            sEXLabel.AutoSize = true;
            sEXLabel.Location = new System.Drawing.Point(85, 205);
            sEXLabel.Name = "sEXLabel";
            sEXLabel.Size = new System.Drawing.Size(29, 12);
            sEXLabel.TabIndex = 18;
            sEXLabel.Text = "性別";
            // 
            // tITPLACELabel
            // 
            tITPLACELabel.AutoSize = true;
            tITPLACELabel.Location = new System.Drawing.Point(85, 232);
            tITPLACELabel.Name = "tITPLACELabel";
            tITPLACELabel.Size = new System.Drawing.Size(29, 12);
            tITPLACELabel.TabIndex = 20;
            tITPLACELabel.Text = "籍貫";
            // 
            // bIRTHDATEDateTimePicker
            // 
            this.bIRTHDATEDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dataBindingSource, "BIRTHDATE", true));
            this.bIRTHDATEDateTimePicker.Location = new System.Drawing.Point(296, 13);
            this.bIRTHDATEDateTimePicker.Name = "bIRTHDATEDateTimePicker";
            this.bIRTHDATEDateTimePicker.Size = new System.Drawing.Size(122, 22);
            this.bIRTHDATEDateTimePicker.TabIndex = 1;
            // 
            // cUSTIDTextBox
            // 
            this.cUSTIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataBindingSource, "CUSTID", true));
            this.cUSTIDTextBox.Location = new System.Drawing.Point(120, 13);
            this.cUSTIDTextBox.Name = "cUSTIDTextBox";
            this.cUSTIDTextBox.Size = new System.Drawing.Size(122, 22);
            this.cUSTIDTextBox.TabIndex = 3;
            // 
            // cUSTTYPEComboBox
            // 
            this.cUSTTYPEComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataBindingSource, "CUSTTYPE", true));
            this.cUSTTYPEComboBox.FormattingEnabled = true;
            this.cUSTTYPEComboBox.Location = new System.Drawing.Point(120, 41);
            this.cUSTTYPEComboBox.Name = "cUSTTYPEComboBox";
            this.cUSTTYPEComboBox.Size = new System.Drawing.Size(122, 20);
            this.cUSTTYPEComboBox.TabIndex = 5;
            // 
            // eNGNAMETextBox
            // 
            this.eNGNAMETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataBindingSource, "ENGNAME", true));
            this.eNGNAMETextBox.Location = new System.Drawing.Point(120, 67);
            this.eNGNAMETextBox.Name = "eNGNAMETextBox";
            this.eNGNAMETextBox.Size = new System.Drawing.Size(122, 22);
            this.eNGNAMETextBox.TabIndex = 7;
            // 
            // jOBTITLEComboBox
            // 
            this.jOBTITLEComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataBindingSource, "JOBTITLE", true));
            this.jOBTITLEComboBox.FormattingEnabled = true;
            this.jOBTITLEComboBox.Location = new System.Drawing.Point(120, 95);
            this.jOBTITLEComboBox.Name = "jOBTITLEComboBox";
            this.jOBTITLEComboBox.Size = new System.Drawing.Size(122, 20);
            this.jOBTITLEComboBox.TabIndex = 9;
            // 
            // jOBTYPEComboBox
            // 
            this.jOBTYPEComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataBindingSource, "JOBTYPE", true));
            this.jOBTYPEComboBox.FormattingEnabled = true;
            this.jOBTYPEComboBox.Items.AddRange(new object[] {
            "士",
            "農",
            "工",
            "商"});
            this.jOBTYPEComboBox.Location = new System.Drawing.Point(120, 121);
            this.jOBTYPEComboBox.Name = "jOBTYPEComboBox";
            this.jOBTYPEComboBox.Size = new System.Drawing.Size(122, 20);
            this.jOBTYPEComboBox.TabIndex = 11;
            // 
            // mARIAGEComboBox
            // 
            this.mARIAGEComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataBindingSource, "MARIAGE", true));
            this.mARIAGEComboBox.FormattingEnabled = true;
            this.mARIAGEComboBox.Items.AddRange(new object[] {
            "無",
            "未婚",
            "已婚"});
            this.mARIAGEComboBox.Location = new System.Drawing.Point(120, 147);
            this.mARIAGEComboBox.Name = "mARIAGEComboBox";
            this.mARIAGEComboBox.Size = new System.Drawing.Size(122, 20);
            this.mARIAGEComboBox.TabIndex = 13;
            // 
            // nAMETextBox
            // 
            this.nAMETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataBindingSource, "NAME", true));
            this.nAMETextBox.Location = new System.Drawing.Point(120, 173);
            this.nAMETextBox.Name = "nAMETextBox";
            this.nAMETextBox.Size = new System.Drawing.Size(122, 22);
            this.nAMETextBox.TabIndex = 15;
            // 
            // nOTETextBox
            // 
            this.nOTETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataBindingSource, "NOTE", true));
            this.nOTETextBox.Location = new System.Drawing.Point(55, 255);
            this.nOTETextBox.Name = "nOTETextBox";
            this.nOTETextBox.Size = new System.Drawing.Size(187, 22);
            this.nOTETextBox.TabIndex = 17;
            // 
            // sEXComboBox
            // 
            this.sEXComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataBindingSource, "SEX", true));
            this.sEXComboBox.FormattingEnabled = true;
            this.sEXComboBox.Items.AddRange(new object[] {
            "男",
            "女",
            "其他"});
            this.sEXComboBox.Location = new System.Drawing.Point(120, 201);
            this.sEXComboBox.Name = "sEXComboBox";
            this.sEXComboBox.Size = new System.Drawing.Size(122, 20);
            this.sEXComboBox.TabIndex = 19;
            // 
            // tITPLACETextBox
            // 
            this.tITPLACETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataBindingSource, "TITPLACE", true));
            this.tITPLACETextBox.Location = new System.Drawing.Point(120, 227);
            this.tITPLACETextBox.Name = "tITPLACETextBox";
            this.tITPLACETextBox.Size = new System.Drawing.Size(122, 22);
            this.tITPLACETextBox.TabIndex = 21;
            // 
            // s_contactbookBindingSource
            // 
            this.s_contactbookBindingSource.DataSource = typeof(djeOpen.Model.s_contactbook);
            // 
            // s_contactbookDataGridView
            // 
            this.s_contactbookDataGridView.AutoGenerateColumns = false;
            this.s_contactbookDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.s_contactbookDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.s_contactbookDataGridView.DataSource = this.s_contactbookBindingSource;
            this.s_contactbookDataGridView.Location = new System.Drawing.Point(263, 41);
            this.s_contactbookDataGridView.Name = "s_contactbookDataGridView";
            this.s_contactbookDataGridView.RowTemplate.Height = 24;
            this.s_contactbookDataGridView.Size = new System.Drawing.Size(380, 218);
            this.s_contactbookDataGridView.TabIndex = 25;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MethodName";
            this.dataGridViewTextBoxColumn2.HeaderText = "連絡方式";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MethodValue";
            this.dataGridViewTextBoxColumn3.HeaderText = "連絡辨法";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Target";
            this.dataGridViewTextBoxColumn4.HeaderText = "連絡人";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // ucCustdata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.s_contactbookDataGridView);
            this.Controls.Add(bIRTHDATELabel);
            this.Controls.Add(this.bIRTHDATEDateTimePicker);
            this.Controls.Add(cUSTIDLabel);
            this.Controls.Add(this.cUSTIDTextBox);
            this.Controls.Add(cUSTTYPELabel);
            this.Controls.Add(this.cUSTTYPEComboBox);
            this.Controls.Add(eNGNAMELabel);
            this.Controls.Add(this.eNGNAMETextBox);
            this.Controls.Add(jOBTITLELabel);
            this.Controls.Add(this.jOBTITLEComboBox);
            this.Controls.Add(jOBTYPELabel);
            this.Controls.Add(this.jOBTYPEComboBox);
            this.Controls.Add(mARIAGELabel);
            this.Controls.Add(this.mARIAGEComboBox);
            this.Controls.Add(nAMELabel);
            this.Controls.Add(this.nAMETextBox);
            this.Controls.Add(nOTELabel);
            this.Controls.Add(this.nOTETextBox);
            this.Controls.Add(sEXLabel);
            this.Controls.Add(this.sEXComboBox);
            this.Controls.Add(tITPLACELabel);
            this.Controls.Add(this.tITPLACETextBox);
            this.Name = "ucCustdata";
            this.Size = new System.Drawing.Size(664, 326);
            this.Controls.SetChildIndex(this.tITPLACETextBox, 0);
            this.Controls.SetChildIndex(tITPLACELabel, 0);
            this.Controls.SetChildIndex(this.sEXComboBox, 0);
            this.Controls.SetChildIndex(sEXLabel, 0);
            this.Controls.SetChildIndex(this.nOTETextBox, 0);
            this.Controls.SetChildIndex(nOTELabel, 0);
            this.Controls.SetChildIndex(this.nAMETextBox, 0);
            this.Controls.SetChildIndex(nAMELabel, 0);
            this.Controls.SetChildIndex(this.mARIAGEComboBox, 0);
            this.Controls.SetChildIndex(mARIAGELabel, 0);
            this.Controls.SetChildIndex(this.jOBTYPEComboBox, 0);
            this.Controls.SetChildIndex(jOBTYPELabel, 0);
            this.Controls.SetChildIndex(this.jOBTITLEComboBox, 0);
            this.Controls.SetChildIndex(jOBTITLELabel, 0);
            this.Controls.SetChildIndex(this.eNGNAMETextBox, 0);
            this.Controls.SetChildIndex(eNGNAMELabel, 0);
            this.Controls.SetChildIndex(this.cUSTTYPEComboBox, 0);
            this.Controls.SetChildIndex(cUSTTYPELabel, 0);
            this.Controls.SetChildIndex(this.cUSTIDTextBox, 0);
            this.Controls.SetChildIndex(cUSTIDLabel, 0);
            this.Controls.SetChildIndex(this.bIRTHDATEDateTimePicker, 0);
            this.Controls.SetChildIndex(bIRTHDATELabel, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.s_contactbookDataGridView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_contactbookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_contactbookDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker bIRTHDATEDateTimePicker;
        private System.Windows.Forms.TextBox cUSTIDTextBox;
        private System.Windows.Forms.ComboBox cUSTTYPEComboBox;
        private System.Windows.Forms.TextBox eNGNAMETextBox;
        private System.Windows.Forms.ComboBox jOBTITLEComboBox;
        private System.Windows.Forms.ComboBox jOBTYPEComboBox;
        private System.Windows.Forms.ComboBox mARIAGEComboBox;
        private System.Windows.Forms.TextBox nAMETextBox;
        private System.Windows.Forms.TextBox nOTETextBox;
        private System.Windows.Forms.ComboBox sEXComboBox;
        private System.Windows.Forms.TextBox tITPLACETextBox;
        private System.Windows.Forms.BindingSource s_contactbookBindingSource;
        private System.Windows.Forms.DataGridView s_contactbookDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
