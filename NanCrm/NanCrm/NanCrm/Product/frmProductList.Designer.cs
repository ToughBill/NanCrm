namespace NanCrm.Product
{
    partial class frmProductList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductList));
            this.objList = new Nan.Controls.ObjectGrid();
            this.olvcCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcFName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcGroup = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcTexture = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcRefund = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcHeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcWidth = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcLength = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcWeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcRemark = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.objList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 404);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 404);
            // 
            // objList
            // 
            this.objList.AllColumns.Add(this.olvcCode);
            this.objList.AllColumns.Add(this.olvcName);
            this.objList.AllColumns.Add(this.olvcFName);
            this.objList.AllColumns.Add(this.olvcGroup);
            this.objList.AllColumns.Add(this.olvcTexture);
            this.objList.AllColumns.Add(this.olvcPrice);
            this.objList.AllColumns.Add(this.olvcRefund);
            this.objList.AllColumns.Add(this.olvcHeight);
            this.objList.AllColumns.Add(this.olvcWidth);
            this.objList.AllColumns.Add(this.olvcLength);
            this.objList.AllColumns.Add(this.olvcWeight);
            this.objList.AllColumns.Add(this.olvcRemark);
            this.objList.BOID = Nan.BusinessObjects.BOIDEnum.Invalid;
            this.objList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcCode,
            this.olvcName,
            this.olvcGroup,
            this.olvcTexture,
            this.olvcPrice,
            this.olvcRefund,
            this.olvcHeight,
            this.olvcWidth,
            this.olvcLength,
            this.olvcWeight,
            this.olvcRemark});
            this.objList.DataSourceType = null;
            this.objList.FullRowSelect = true;
            this.objList.GridLines = true;
            this.objList.HideSelection = false;
            this.objList.LastHitInfo = null;
            this.objList.Location = new System.Drawing.Point(12, 12);
            this.objList.Name = "objList";
            this.objList.RemovedObject = null;
            this.objList.RemovedObjects = ((System.Collections.IList)(resources.GetObject("objList.RemovedObjects")));
            this.objList.ShowAddRowMenu = false;
            this.objList.ShowDeleteRowMenu = false;
            this.objList.ShowGroups = false;
            this.objList.ShowRowNumber = true;
            this.objList.ShowSysMenu = false;
            this.objList.Size = new System.Drawing.Size(652, 386);
            this.objList.TabIndex = 2;
            this.objList.UseAlternatingBackColors = true;
            this.objList.UseCompatibleStateImageBehavior = false;
            this.objList.View = System.Windows.Forms.View.Details;
            this.objList.RowNumberDblClick += new Nan.Controls.DeleRowNoColumnClick(this.objList_RowNumberDblClick);
            // 
            // olvcCode
            // 
            this.olvcCode.AspectName = "Code";
            this.olvcCode.IsRowNumberColumn = false;
            this.olvcCode.Text = "产品编号";
            this.olvcCode.Width = 93;
            // 
            // olvcName
            // 
            this.olvcName.AspectName = "Name";
            this.olvcName.Groupable = false;
            this.olvcName.IsRowNumberColumn = false;
            this.olvcName.Text = "产品名称";
            this.olvcName.Width = 125;
            // 
            // olvcFName
            // 
            this.olvcFName.AspectName = "Fname";
            this.olvcFName.DisplayIndex = 3;
            this.olvcFName.Groupable = false;
            this.olvcFName.IsRowNumberColumn = false;
            this.olvcFName.IsVisible = false;
            this.olvcFName.Text = "外文名";
            // 
            // olvcGroup
            // 
            this.olvcGroup.AspectName = "Group";
            this.olvcGroup.IsRowNumberColumn = false;
            this.olvcGroup.Text = "产品分组";
            this.olvcGroup.Width = 84;
            // 
            // olvcTexture
            // 
            this.olvcTexture.AspectName = "Texture";
            this.olvcTexture.IsRowNumberColumn = false;
            this.olvcTexture.Text = "材质";
            this.olvcTexture.Width = 80;
            // 
            // olvcPrice
            // 
            this.olvcPrice.AspectName = "Price";
            this.olvcPrice.IsRowNumberColumn = false;
            this.olvcPrice.Text = "价格";
            this.olvcPrice.Width = 90;
            // 
            // olvcRefund
            // 
            this.olvcRefund.AspectName = "Refundrate";
            this.olvcRefund.IsRowNumberColumn = false;
            this.olvcRefund.Text = "退税率";
            this.olvcRefund.Width = 81;
            // 
            // olvcHeight
            // 
            this.olvcHeight.AspectName = "Height";
            this.olvcHeight.IsRowNumberColumn = false;
            this.olvcHeight.Text = "高度";
            // 
            // olvcWidth
            // 
            this.olvcWidth.AspectName = "Width";
            this.olvcWidth.IsRowNumberColumn = false;
            this.olvcWidth.Text = "宽度";
            // 
            // olvcLength
            // 
            this.olvcLength.AspectName = "Length";
            this.olvcLength.IsRowNumberColumn = false;
            this.olvcLength.Text = "长度";
            // 
            // olvcWeight
            // 
            this.olvcWeight.AspectName = "Weight";
            this.olvcWeight.IsRowNumberColumn = false;
            this.olvcWeight.Text = "宽度";
            // 
            // olvcRemark
            // 
            this.olvcRemark.AspectName = "Remark";
            this.olvcRemark.IsRowNumberColumn = false;
            this.olvcRemark.Text = "备注";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(589, 404);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 28);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 436);
            this.Controls.Add(this.objList);
            this.Controls.Add(this.btnNew);
            this.Name = "frmProductList";
            this.Text = "产品列表";
            this.Load += new System.EventHandler(this.frmProductList_Load);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.objList, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.objList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nan.Controls.ObjectGrid objList;
        private System.Windows.Forms.Button btnNew;
        private BrightIdeasSoftware.OLVColumn olvcCode;
        private BrightIdeasSoftware.OLVColumn olvcName;
        private BrightIdeasSoftware.OLVColumn olvcFName;
        private BrightIdeasSoftware.OLVColumn olvcGroup;
        private BrightIdeasSoftware.OLVColumn olvcTexture;
        private BrightIdeasSoftware.OLVColumn olvcPrice;
        private BrightIdeasSoftware.OLVColumn olvcRefund;
        private BrightIdeasSoftware.OLVColumn olvcHeight;
        private BrightIdeasSoftware.OLVColumn olvcWidth;
        private BrightIdeasSoftware.OLVColumn olvcLength;
        private BrightIdeasSoftware.OLVColumn olvcWeight;
        private BrightIdeasSoftware.OLVColumn olvcRemark;
    }
}