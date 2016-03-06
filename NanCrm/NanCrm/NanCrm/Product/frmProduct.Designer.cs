namespace NanCrm.Product
{
    partial class frmProduct
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
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new Nan.Controls.TextBoxEx();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new Nan.Controls.TextBoxEx();
            this.txtFName = new Nan.Controls.TextBoxEx();
            this.lblFName = new System.Windows.Forms.Label();
            this.txtPrice = new Nan.Controls.TextBoxEx();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtRefund = new Nan.Controls.TextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWeight = new Nan.Controls.TextBoxEx();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblTexture = new System.Windows.Forms.Label();
            this.cmbTexture = new Nan.Controls.ComboBoxEx();
            this.txtHeight = new Nan.Controls.TextBoxEx();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtLength = new Nan.Controls.TextBoxEx();
            this.lblLength = new System.Windows.Forms.Label();
            this.txtWidth = new Nan.Controls.TextBoxEx();
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtID = new Nan.Controls.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtRemark = new Nan.Controls.RichTextBoxEx();
            this.cmbGroup = new Nan.Controls.ComboBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 328);
            this.btnOk.Clicking += new Nan.Controls.ClickingEvent(this.btnOk_Clicking);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 328);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(12, 15);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(53, 12);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "产品编码";
            // 
            // txtCode
            // 
            this.txtCode.BOField = "Code";
            this.txtCode.BOID = Nan.BusinessObjects.BOIDEnum.Product;
            this.txtCode.Location = new System.Drawing.Point(71, 9);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = false;
            this.txtCode.ShowChoose = false;
            this.txtCode.ShowLink = false;
            this.txtCode.Size = new System.Drawing.Size(204, 18);
            this.txtCode.TabIndex = 3;
            this.txtCode.TableSource = null;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 12);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "产品名字";
            // 
            // txtName
            // 
            this.txtName.BOField = "Name";
            this.txtName.BOID = Nan.BusinessObjects.BOIDEnum.Product;
            this.txtName.Location = new System.Drawing.Point(71, 33);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = false;
            this.txtName.ShowChoose = false;
            this.txtName.ShowLink = false;
            this.txtName.Size = new System.Drawing.Size(204, 18);
            this.txtName.TabIndex = 5;
            this.txtName.TableSource = null;
            // 
            // txtFName
            // 
            this.txtFName.BOField = "FName";
            this.txtFName.BOID = Nan.BusinessObjects.BOIDEnum.Product;
            this.txtFName.Location = new System.Drawing.Point(71, 57);
            this.txtFName.Name = "txtFName";
            this.txtFName.ReadOnly = false;
            this.txtFName.ShowChoose = false;
            this.txtFName.ShowLink = false;
            this.txtFName.Size = new System.Drawing.Size(204, 18);
            this.txtFName.TabIndex = 7;
            this.txtFName.TableSource = null;
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Location = new System.Drawing.Point(12, 63);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(53, 12);
            this.lblFName.TabIndex = 6;
            this.lblFName.Text = "外文名字";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.BOField = "Price";
            this.txtPrice.BOID = Nan.BusinessObjects.BOIDEnum.Product;
            this.txtPrice.Location = new System.Drawing.Point(386, 33);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = false;
            this.txtPrice.ShowChoose = false;
            this.txtPrice.ShowLink = false;
            this.txtPrice.Size = new System.Drawing.Size(213, 18);
            this.txtPrice.TabIndex = 9;
            this.txtPrice.TableSource = null;
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(327, 39);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(29, 12);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "价格";
            // 
            // txtRefund
            // 
            this.txtRefund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRefund.BOField = "Refundrate";
            this.txtRefund.BOID = Nan.BusinessObjects.BOIDEnum.Product;
            this.txtRefund.Location = new System.Drawing.Point(386, 57);
            this.txtRefund.Name = "txtRefund";
            this.txtRefund.ReadOnly = false;
            this.txtRefund.ShowChoose = false;
            this.txtRefund.ShowLink = false;
            this.txtRefund.Size = new System.Drawing.Size(213, 18);
            this.txtRefund.TabIndex = 11;
            this.txtRefund.TableSource = null;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "退税率";
            // 
            // txtWeight
            // 
            this.txtWeight.BOField = "Weight";
            this.txtWeight.BOID = Nan.BusinessObjects.BOIDEnum.Product;
            this.txtWeight.Location = new System.Drawing.Point(71, 130);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.ReadOnly = false;
            this.txtWeight.ShowChoose = false;
            this.txtWeight.ShowLink = false;
            this.txtWeight.Size = new System.Drawing.Size(204, 18);
            this.txtWeight.TabIndex = 13;
            this.txtWeight.TableSource = null;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(12, 136);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(29, 12);
            this.lblWeight.TabIndex = 12;
            this.lblWeight.Text = "重量";
            // 
            // lblTexture
            // 
            this.lblTexture.AutoSize = true;
            this.lblTexture.Location = new System.Drawing.Point(327, 89);
            this.lblTexture.Name = "lblTexture";
            this.lblTexture.Size = new System.Drawing.Size(29, 12);
            this.lblTexture.TabIndex = 14;
            this.lblTexture.Text = "材质";
            // 
            // cmbTexture
            // 
            this.cmbTexture.AddDefineNew = true;
            this.cmbTexture.AddEmptyRow = true;
            this.cmbTexture.BOField = "Texture";
            this.cmbTexture.BOID = Nan.BusinessObjects.BOIDEnum.Product;
            this.cmbTexture.DataSourceBO = Nan.BusinessObjects.BOIDEnum.Texture;
            this.cmbTexture.DefineNewProc = null;
            this.cmbTexture.DesField = "Name";
            this.cmbTexture.FormattingEnabled = true;
            this.cmbTexture.KeyField = "ID";
            this.cmbTexture.Location = new System.Drawing.Point(386, 81);
            this.cmbTexture.Name = "cmbTexture";
            this.cmbTexture.Size = new System.Drawing.Size(213, 20);
            this.cmbTexture.TabIndex = 15;
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeight.BOField = "Height";
            this.txtHeight.BOID = Nan.BusinessObjects.BOIDEnum.Product;
            this.txtHeight.Location = new System.Drawing.Point(386, 130);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = false;
            this.txtHeight.ShowChoose = false;
            this.txtHeight.ShowLink = false;
            this.txtHeight.Size = new System.Drawing.Size(213, 18);
            this.txtHeight.TabIndex = 17;
            this.txtHeight.TableSource = null;
            // 
            // lblHeight
            // 
            this.lblHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(327, 136);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(29, 12);
            this.lblHeight.TabIndex = 16;
            this.lblHeight.Text = "高度";
            // 
            // txtLength
            // 
            this.txtLength.BOField = "Length";
            this.txtLength.BOID = Nan.BusinessObjects.BOIDEnum.Product;
            this.txtLength.Location = new System.Drawing.Point(71, 154);
            this.txtLength.Name = "txtLength";
            this.txtLength.ReadOnly = false;
            this.txtLength.ShowChoose = false;
            this.txtLength.ShowLink = false;
            this.txtLength.Size = new System.Drawing.Size(204, 18);
            this.txtLength.TabIndex = 19;
            this.txtLength.TableSource = null;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(12, 160);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(29, 12);
            this.lblLength.TabIndex = 18;
            this.lblLength.Text = "长度";
            // 
            // txtWidth
            // 
            this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWidth.BOField = "Width";
            this.txtWidth.BOID = Nan.BusinessObjects.BOIDEnum.Product;
            this.txtWidth.Location = new System.Drawing.Point(386, 154);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = false;
            this.txtWidth.ShowChoose = false;
            this.txtWidth.ShowLink = false;
            this.txtWidth.Size = new System.Drawing.Size(213, 18);
            this.txtWidth.TabIndex = 21;
            this.txtWidth.TableSource = null;
            // 
            // lblWidth
            // 
            this.lblWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(327, 160);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(29, 12);
            this.lblWidth.TabIndex = 20;
            this.lblWidth.Text = "宽度";
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtID.BOField = "ID";
            this.txtID.BOID = Nan.BusinessObjects.BOIDEnum.Product;
            this.txtID.Location = new System.Drawing.Point(386, 9);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.ShowChoose = false;
            this.txtID.ShowLink = false;
            this.txtID.Size = new System.Drawing.Size(213, 18);
            this.txtID.TabIndex = 23;
            this.txtID.TableSource = null;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(327, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "序号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "备注";
            // 
            // rtxtRemark
            // 
            this.rtxtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtRemark.BOField = "Remark";
            this.rtxtRemark.BOID = Nan.BusinessObjects.BOIDEnum.Product;
            this.rtxtRemark.Location = new System.Drawing.Point(14, 217);
            this.rtxtRemark.Name = "rtxtRemark";
            this.rtxtRemark.Size = new System.Drawing.Size(587, 87);
            this.rtxtRemark.TabIndex = 25;
            this.rtxtRemark.Text = "";
            // 
            // cmbGroup
            // 
            this.cmbGroup.AddDefineNew = true;
            this.cmbGroup.AddEmptyRow = true;
            this.cmbGroup.BOField = "Group";
            this.cmbGroup.BOID = Nan.BusinessObjects.BOIDEnum.Product;
            this.cmbGroup.DataSourceBO = Nan.BusinessObjects.BOIDEnum.ProductGroup;
            this.cmbGroup.DefineNewProc = null;
            this.cmbGroup.DesField = "Name";
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.KeyField = "ID";
            this.cmbGroup.Location = new System.Drawing.Point(71, 81);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(204, 20);
            this.cmbGroup.TabIndex = 27;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "分组";
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 360);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtxtRemark);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.cmbTexture);
            this.Controls.Add(this.lblTexture);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.txtRefund);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.lblFName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblName);
            this.Name = "frmProduct";
            this.Text = "产品信息";
            this.Load += new System.EventHandler(this.frmProduct_Load);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.lblCode, 0);
            this.Controls.SetChildIndex(this.txtCode, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.lblFName, 0);
            this.Controls.SetChildIndex(this.txtFName, 0);
            this.Controls.SetChildIndex(this.lblPrice, 0);
            this.Controls.SetChildIndex(this.txtPrice, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtRefund, 0);
            this.Controls.SetChildIndex(this.lblWeight, 0);
            this.Controls.SetChildIndex(this.txtWeight, 0);
            this.Controls.SetChildIndex(this.lblTexture, 0);
            this.Controls.SetChildIndex(this.cmbTexture, 0);
            this.Controls.SetChildIndex(this.lblHeight, 0);
            this.Controls.SetChildIndex(this.txtHeight, 0);
            this.Controls.SetChildIndex(this.lblLength, 0);
            this.Controls.SetChildIndex(this.txtLength, 0);
            this.Controls.SetChildIndex(this.lblWidth, 0);
            this.Controls.SetChildIndex(this.txtWidth, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtID, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.rtxtRemark, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbGroup, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCode;
        private Nan.Controls.TextBoxEx txtCode;
        private System.Windows.Forms.Label lblName;
        private Nan.Controls.TextBoxEx txtName;
        private Nan.Controls.TextBoxEx txtFName;
        private System.Windows.Forms.Label lblFName;
        private Nan.Controls.TextBoxEx txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private Nan.Controls.TextBoxEx txtRefund;
        private System.Windows.Forms.Label label2;
        private Nan.Controls.TextBoxEx txtWeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblTexture;
        private Nan.Controls.ComboBoxEx cmbTexture;
        private Nan.Controls.TextBoxEx txtHeight;
        private System.Windows.Forms.Label lblHeight;
        private Nan.Controls.TextBoxEx txtLength;
        private System.Windows.Forms.Label lblLength;
        private Nan.Controls.TextBoxEx txtWidth;
        private System.Windows.Forms.Label lblWidth;
        private Nan.Controls.TextBoxEx txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Nan.Controls.RichTextBoxEx rtxtRemark;
        private Nan.Controls.ComboBoxEx cmbGroup;
        private System.Windows.Forms.Label label4;
    }
}