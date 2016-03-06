namespace NanCrm.BP
{
    partial class frmBP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtID = new Nan.Controls.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new Nan.Controls.TextBoxEx();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtName = new Nan.Controls.TextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEx2 = new Nan.Controls.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEx3 = new Nan.Controls.TextBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxEx4 = new Nan.Controls.TextBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEx5 = new Nan.Controls.TextBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbType = new Nan.Controls.ComboBoxEx();
            this.comboBoxEx2 = new Nan.Controls.ComboBoxEx();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBoxEx1 = new Nan.Controls.RichTextBoxEx();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 291);
            this.btnOk.Clicking += new Nan.Controls.ClickingEvent(this.btnOk_Clicking);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 291);
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtID.BOField = "ID";
            this.txtID.BOID = Nan.BusinessObjects.BOIDEnum.BP;
            this.txtID.Location = new System.Drawing.Point(366, 12);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.ShowChoose = false;
            this.txtID.ShowLink = false;
            this.txtID.Size = new System.Drawing.Size(204, 18);
            this.txtID.TabIndex = 27;
            this.txtID.TableSource = null;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "序号";
            // 
            // txtCode
            // 
            this.txtCode.BOField = "Code";
            this.txtCode.BOID = Nan.BusinessObjects.BOIDEnum.BP;
            this.txtCode.Location = new System.Drawing.Point(71, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = false;
            this.txtCode.ShowChoose = false;
            this.txtCode.ShowLink = false;
            this.txtCode.Size = new System.Drawing.Size(204, 18);
            this.txtCode.TabIndex = 25;
            this.txtCode.TableSource = null;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(12, 18);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(53, 12);
            this.lblCode.TabIndex = 24;
            this.lblCode.Text = "客户编号";
            // 
            // txtName
            // 
            this.txtName.BOField = "Name";
            this.txtName.BOID = Nan.BusinessObjects.BOIDEnum.BP;
            this.txtName.Location = new System.Drawing.Point(71, 36);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = false;
            this.txtName.ShowChoose = false;
            this.txtName.ShowLink = false;
            this.txtName.Size = new System.Drawing.Size(204, 18);
            this.txtName.TabIndex = 29;
            this.txtName.TableSource = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "客户名称";
            // 
            // textBoxEx2
            // 
            this.textBoxEx2.BOField = "CtPeson";
            this.textBoxEx2.BOID = Nan.BusinessObjects.BOIDEnum.BP;
            this.textBoxEx2.Location = new System.Drawing.Point(71, 105);
            this.textBoxEx2.Name = "textBoxEx2";
            this.textBoxEx2.ReadOnly = false;
            this.textBoxEx2.ShowChoose = false;
            this.textBoxEx2.ShowLink = false;
            this.textBoxEx2.Size = new System.Drawing.Size(204, 18);
            this.textBoxEx2.TabIndex = 31;
            this.textBoxEx2.TableSource = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "联络人";
            // 
            // textBoxEx3
            // 
            this.textBoxEx3.BOField = "Phone";
            this.textBoxEx3.BOID = Nan.BusinessObjects.BOIDEnum.BP;
            this.textBoxEx3.Location = new System.Drawing.Point(71, 129);
            this.textBoxEx3.Name = "textBoxEx3";
            this.textBoxEx3.ReadOnly = false;
            this.textBoxEx3.ShowChoose = false;
            this.textBoxEx3.ShowLink = false;
            this.textBoxEx3.Size = new System.Drawing.Size(204, 18);
            this.textBoxEx3.TabIndex = 33;
            this.textBoxEx3.TableSource = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "联系电话";
            // 
            // textBoxEx4
            // 
            this.textBoxEx4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEx4.BOField = "Email";
            this.textBoxEx4.BOID = Nan.BusinessObjects.BOIDEnum.BP;
            this.textBoxEx4.Location = new System.Drawing.Point(366, 105);
            this.textBoxEx4.Name = "textBoxEx4";
            this.textBoxEx4.ReadOnly = false;
            this.textBoxEx4.ShowChoose = false;
            this.textBoxEx4.ShowLink = false;
            this.textBoxEx4.Size = new System.Drawing.Size(204, 18);
            this.textBoxEx4.TabIndex = 35;
            this.textBoxEx4.TableSource = null;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(307, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "电子邮件";
            // 
            // textBoxEx5
            // 
            this.textBoxEx5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEx5.BOField = "Site";
            this.textBoxEx5.BOID = Nan.BusinessObjects.BOIDEnum.BP;
            this.textBoxEx5.Location = new System.Drawing.Point(366, 131);
            this.textBoxEx5.Name = "textBoxEx5";
            this.textBoxEx5.ReadOnly = false;
            this.textBoxEx5.ShowChoose = false;
            this.textBoxEx5.ShowLink = false;
            this.textBoxEx5.Size = new System.Drawing.Size(204, 18);
            this.textBoxEx5.TabIndex = 37;
            this.textBoxEx5.TableSource = null;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 36;
            this.label6.Text = "网站";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "国家";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 40;
            this.label8.Text = "类型";
            // 
            // cmbType
            // 
            this.cmbType.AddDefineNew = false;
            this.cmbType.AddEmptyRow = false;
            this.cmbType.BOField = "Type";
            this.cmbType.BOID = Nan.BusinessObjects.BOIDEnum.BP;
            this.cmbType.DataSourceBO = Nan.BusinessObjects.BOIDEnum.Invalid;
            this.cmbType.DefineNewProc = null;
            this.cmbType.DesField = null;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.KeyField = null;
            this.cmbType.Location = new System.Drawing.Point(71, 60);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(204, 20);
            this.cmbType.TabIndex = 41;
            // 
            // comboBoxEx2
            // 
            this.comboBoxEx2.AddDefineNew = true;
            this.comboBoxEx2.AddEmptyRow = true;
            this.comboBoxEx2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEx2.BOField = "Country";
            this.comboBoxEx2.BOID = Nan.BusinessObjects.BOIDEnum.BP;
            this.comboBoxEx2.DataSourceBO = Nan.BusinessObjects.BOIDEnum.Country;
            this.comboBoxEx2.DefineNewProc = null;
            this.comboBoxEx2.DesField = "Name";
            this.comboBoxEx2.FormattingEnabled = true;
            this.comboBoxEx2.KeyField = "ID";
            this.comboBoxEx2.Location = new System.Drawing.Point(366, 60);
            this.comboBoxEx2.Name = "comboBoxEx2";
            this.comboBoxEx2.Size = new System.Drawing.Size(204, 20);
            this.comboBoxEx2.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 43;
            this.label9.Text = "备注";
            // 
            // richTextBoxEx1
            // 
            this.richTextBoxEx1.BOField = "Remark";
            this.richTextBoxEx1.BOID = Nan.BusinessObjects.BOIDEnum.BP;
            this.richTextBoxEx1.Location = new System.Drawing.Point(12, 185);
            this.richTextBoxEx1.Name = "richTextBoxEx1";
            this.richTextBoxEx1.Size = new System.Drawing.Size(558, 82);
            this.richTextBoxEx1.TabIndex = 44;
            this.richTextBoxEx1.Text = "";
            // 
            // frmBP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 323);
            this.Controls.Add(this.richTextBoxEx1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxEx2);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxEx5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxEx4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxEx3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxEx2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Name = "frmBP";
            this.Text = "客户信息";
            this.Load += new System.EventHandler(this.frmBP_Load);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblCode, 0);
            this.Controls.SetChildIndex(this.txtCode, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtID, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.textBoxEx2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.textBoxEx3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.textBoxEx4, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.textBoxEx5, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cmbType, 0);
            this.Controls.SetChildIndex(this.comboBoxEx2, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.richTextBoxEx1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nan.Controls.TextBoxEx txtID;
        private System.Windows.Forms.Label label1;
        private Nan.Controls.TextBoxEx txtCode;
        private System.Windows.Forms.Label lblCode;
        private Nan.Controls.TextBoxEx txtName;
        private System.Windows.Forms.Label label2;
        private Nan.Controls.TextBoxEx textBoxEx2;
        private System.Windows.Forms.Label label3;
        private Nan.Controls.TextBoxEx textBoxEx3;
        private System.Windows.Forms.Label label4;
        private Nan.Controls.TextBoxEx textBoxEx4;
        private System.Windows.Forms.Label label5;
        private Nan.Controls.TextBoxEx textBoxEx5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Nan.Controls.ComboBoxEx cmbType;
        private Nan.Controls.ComboBoxEx comboBoxEx2;
        private System.Windows.Forms.Label label9;
        private Nan.Controls.RichTextBoxEx richTextBoxEx1;
    }
}