namespace NanCrm.Setup
{
    partial class frmMarketList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMarketList));
            this.objList = new Nan.Controls.ObjectGrid();
            this.olvId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCties = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcDesc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.objList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 432);
            this.btnOk.Clicking += new Nan.Controls.ClickingEvent(this.btnOk_Clicking);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 432);
            // 
            // objList
            // 
            this.objList.AllColumns.Add(this.olvId);
            this.objList.AllColumns.Add(this.olvcName);
            this.objList.AllColumns.Add(this.olvColCties);
            this.objList.AllColumns.Add(this.olvcDesc);
            this.objList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.objList.BOID = Nan.BusinessObjects.BOIDEnum.Market;
            this.objList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.objList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcName,
            this.olvColCties,
            this.olvcDesc});
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
            this.objList.ShowRowNumber = true;
            this.objList.ShowSysMenu = true;
            this.objList.Size = new System.Drawing.Size(734, 414);
            this.objList.TabIndex = 2;
            this.objList.UseAlternatingBackColors = true;
            this.objList.UseCompatibleStateImageBehavior = false;
            this.objList.View = System.Windows.Forms.View.Details;
            this.objList.RowNumberDblClick += new Nan.Controls.DeleRowNoColumnClick(this.objList_RowNumberDblClick);
            // 
            // olvId
            // 
            this.olvId.AspectName = "ID";
            this.olvId.DisplayIndex = 1;
            this.olvId.Groupable = false;
            this.olvId.IsRowNumberColumn = false;
            this.olvId.IsVisible = false;
            this.olvId.Text = "ID";
            // 
            // olvcName
            // 
            this.olvcName.AspectName = "Name";
            this.olvcName.Groupable = false;
            this.olvcName.IsRowNumberColumn = false;
            this.olvcName.Text = "名称";
            this.olvcName.Width = 156;
            // 
            // olvColCties
            // 
            this.olvColCties.AspectName = "Countries";
            this.olvColCties.Groupable = false;
            this.olvColCties.IsRowNumberColumn = false;
            this.olvColCties.Text = "国家";
            this.olvColCties.Width = 254;
            // 
            // olvcDesc
            // 
            this.olvcDesc.AspectName = "Desc";
            this.olvcDesc.Groupable = false;
            this.olvcDesc.IsRowNumberColumn = false;
            this.olvcDesc.Text = "描述";
            this.olvcDesc.Width = 250;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(671, 432);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 28);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmMarketList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 464);
            this.Controls.Add(this.objList);
            this.Controls.Add(this.btnNew);
            this.Name = "frmMarketList";
            this.Text = "市场列表";
            this.Load += new System.EventHandler(this.Market_Load);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.objList, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.objList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nan.Controls.ObjectGrid objList;
        private BrightIdeasSoftware.OLVColumn olvId;
        private BrightIdeasSoftware.OLVColumn olvcName;
        private BrightIdeasSoftware.OLVColumn olvcDesc;
        private BrightIdeasSoftware.OLVColumn olvColCties;
        private System.Windows.Forms.Button btnNew;
    }
}