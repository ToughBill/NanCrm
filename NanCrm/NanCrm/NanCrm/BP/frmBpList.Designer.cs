namespace NanCrm.BP
{
    partial class frmBpList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBpList));
            this.objList = new Nan.Controls.ObjectGrid();
            this.olvcId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcCty = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcCtPerson = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcEmail = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcPhone = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcSite = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcRemark = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.objList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 467);
            this.btnOk.Clicking += new Nan.Controls.ClickingEvent(this.btnOk_Clicking);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 467);
            // 
            // objList
            // 
            this.objList.AllColumns.Add(this.olvcId);
            this.objList.AllColumns.Add(this.olvcCode);
            this.objList.AllColumns.Add(this.olvcName);
            this.objList.AllColumns.Add(this.olvcType);
            this.objList.AllColumns.Add(this.olvcCty);
            this.objList.AllColumns.Add(this.olvcCtPerson);
            this.objList.AllColumns.Add(this.olvcEmail);
            this.objList.AllColumns.Add(this.olvcPhone);
            this.objList.AllColumns.Add(this.olvcSite);
            this.objList.AllColumns.Add(this.olvcRemark);
            this.objList.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.objList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objList.AutoAddEmptyRow = false;
            this.objList.BOID = Nan.BusinessObjects.BOIDEnum.Invalid;
            this.objList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcCode,
            this.olvcName,
            this.olvcType,
            this.olvcCty,
            this.olvcCtPerson,
            this.olvcEmail,
            this.olvcPhone,
            this.olvcSite,
            this.olvcRemark});
            this.objList.DataSourceType = null;
            this.objList.EmptyObject = null;
            this.objList.FullRowSelect = true;
            this.objList.GridLines = true;
            this.objList.HideSelection = false;
            this.objList.LastHitInfo = null;
            this.objList.Location = new System.Drawing.Point(12, 12);
            this.objList.Name = "objList";
            this.objList.RemovedObject = null;
            this.objList.RemovedObjects = ((System.Collections.IList)(resources.GetObject("objList.RemovedObjects")));
            this.objList.ShowAddRowMenu = false;
            this.objList.ShowDeleteRowMenu = true;
            this.objList.ShowGroups = false;
            this.objList.ShowRowNumber = true;
            this.objList.ShowSysMenu = true;
            this.objList.Size = new System.Drawing.Size(819, 449);
            this.objList.TabIndex = 2;
            this.objList.UseAlternatingBackColors = true;
            this.objList.UseCompatibleStateImageBehavior = false;
            this.objList.View = System.Windows.Forms.View.Details;
            this.objList.RowNumberDblClick += new Nan.Controls.DeleRowNoColumnClick(this.objList_RowNumberDblClick);
            // 
            // olvcId
            // 
            this.olvcId.AspectName = "ID";
            this.olvcId.DataSource = null;
            this.olvcId.DisplayIndex = 1;
            this.olvcId.EditAsCombBox = false;
            this.olvcId.Groupable = false;
            this.olvcId.IsRowNumberColumn = false;
            this.olvcId.IsVisible = false;
            this.olvcId.Sortable = false;
            this.olvcId.Text = "Id";
            // 
            // olvcCode
            // 
            this.olvcCode.AspectName = "Code";
            this.olvcCode.DataSource = null;
            this.olvcCode.EditAsCombBox = false;
            this.olvcCode.Groupable = false;
            this.olvcCode.IsRowNumberColumn = false;
            this.olvcCode.Sortable = false;
            this.olvcCode.Text = "客户编码";
            this.olvcCode.Width = 128;
            // 
            // olvcName
            // 
            this.olvcName.AspectName = "Name";
            this.olvcName.DataSource = null;
            this.olvcName.EditAsCombBox = false;
            this.olvcName.Groupable = false;
            this.olvcName.IsRowNumberColumn = false;
            this.olvcName.Sortable = false;
            this.olvcName.Text = "客户名称";
            this.olvcName.Width = 149;
            // 
            // olvcType
            // 
            this.olvcType.AspectName = "Type";
            this.olvcType.DataSource = null;
            this.olvcType.EditAsCombBox = true;
            this.olvcType.Groupable = false;
            this.olvcType.IsRowNumberColumn = false;
            this.olvcType.Sortable = false;
            this.olvcType.Text = "类型";
            this.olvcType.Width = 77;
            // 
            // olvcCty
            // 
            this.olvcCty.AspectName = "Country";
            this.olvcCty.DataSource = null;
            this.olvcCty.EditAsCombBox = true;
            this.olvcCty.Groupable = false;
            this.olvcCty.IsRowNumberColumn = false;
            this.olvcCty.Sortable = false;
            this.olvcCty.Text = "国家";
            this.olvcCty.Width = 96;
            // 
            // olvcCtPerson
            // 
            this.olvcCtPerson.AspectName = "CtPeson";
            this.olvcCtPerson.DataSource = null;
            this.olvcCtPerson.EditAsCombBox = false;
            this.olvcCtPerson.Groupable = false;
            this.olvcCtPerson.IsRowNumberColumn = false;
            this.olvcCtPerson.Sortable = false;
            this.olvcCtPerson.Text = "联系人";
            this.olvcCtPerson.Width = 128;
            // 
            // olvcEmail
            // 
            this.olvcEmail.AspectName = "Email";
            this.olvcEmail.DataSource = null;
            this.olvcEmail.EditAsCombBox = false;
            this.olvcEmail.Groupable = false;
            this.olvcEmail.IsRowNumberColumn = false;
            this.olvcEmail.Sortable = false;
            this.olvcEmail.Text = "电子邮件";
            this.olvcEmail.Width = 120;
            // 
            // olvcPhone
            // 
            this.olvcPhone.AspectName = "Phone";
            this.olvcPhone.DataSource = null;
            this.olvcPhone.EditAsCombBox = false;
            this.olvcPhone.Groupable = false;
            this.olvcPhone.IsRowNumberColumn = false;
            this.olvcPhone.Sortable = false;
            this.olvcPhone.Text = "联系号码";
            this.olvcPhone.Width = 87;
            // 
            // olvcSite
            // 
            this.olvcSite.AspectName = "Site";
            this.olvcSite.DataSource = null;
            this.olvcSite.EditAsCombBox = false;
            this.olvcSite.Groupable = false;
            this.olvcSite.IsRowNumberColumn = false;
            this.olvcSite.Sortable = false;
            this.olvcSite.Text = "网址";
            // 
            // olvcRemark
            // 
            this.olvcRemark.AspectName = "Remark";
            this.olvcRemark.DataSource = null;
            this.olvcRemark.EditAsCombBox = false;
            this.olvcRemark.Groupable = false;
            this.olvcRemark.IsRowNumberColumn = false;
            this.olvcRemark.Sortable = false;
            this.olvcRemark.Text = "备注";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(756, 467);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 28);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmBpList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 499);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.objList);
            this.Name = "frmBpList";
            this.Text = "客户列表";
            this.Load += new System.EventHandler(this.frmBpList_Load);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.objList, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            ((System.ComponentModel.ISupportInitialize)(this.objList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nan.Controls.ObjectGrid objList;
        private System.Windows.Forms.Button btnNew;
        private BrightIdeasSoftware.OLVColumn olvcId;
        private BrightIdeasSoftware.OLVColumn olvcCode;
        private BrightIdeasSoftware.OLVColumn olvcName;
        private BrightIdeasSoftware.OLVColumn olvcCty;
        private BrightIdeasSoftware.OLVColumn olvcSite;
        private BrightIdeasSoftware.OLVColumn olvcEmail;
        private BrightIdeasSoftware.OLVColumn olvcCtPerson;
        private BrightIdeasSoftware.OLVColumn olvcPhone;
        private BrightIdeasSoftware.OLVColumn olvcRemark;
        private BrightIdeasSoftware.OLVColumn olvcType;
    }
}