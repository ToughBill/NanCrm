﻿namespace NanCrm.Setup
{
    partial class frmKeyWordList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKeyWordList));
            this.objList = new Nan.Controls.ObjectGrid();
            this.olvcName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcKwyWrods = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcDesc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.objList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 417);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 417);
            // 
            // objList
            // 
            this.objList.AllColumns.Add(this.olvcName);
            this.objList.AllColumns.Add(this.olvcKwyWrods);
            this.objList.AllColumns.Add(this.olvcDesc);
            this.objList.AllColumns.Add(this.olvcID);
            this.objList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.objList.AutoAddEmptyRow = false;
            this.objList.BOID = Nan.BusinessObjects.BOIDEnum.Invalid;
            this.objList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcName,
            this.olvcKwyWrods,
            this.olvcDesc});
            this.objList.DataSourceType = null;
            this.objList.EmptyObject = null;
            this.objList.FullRowSelect = true;
            this.objList.GridLines = true;
            this.objList.HideSelection = false;
            this.objList.LastHitInfo = null;
            this.objList.Location = new System.Drawing.Point(12, 11);
            this.objList.Name = "objList";
            this.objList.RemovedObject = null;
            this.objList.RemovedObjects = ((System.Collections.IList)(resources.GetObject("objList.RemovedObjects")));
            this.objList.ShowAddRowMenu = false;
            this.objList.ShowDeleteRowMenu = false;
            this.objList.ShowGroups = false;
            this.objList.ShowRowNumber = true;
            this.objList.ShowSysMenu = false;
            this.objList.Size = new System.Drawing.Size(692, 400);
            this.objList.TabIndex = 2;
            this.objList.UseAlternatingBackColors = true;
            this.objList.UseCompatibleStateImageBehavior = false;
            this.objList.View = System.Windows.Forms.View.Details;
            // 
            // olvcName
            // 
            this.olvcName.AspectName = "Name";
            this.olvcName.Groupable = false;
            this.olvcName.IsRowNumberColumn = false;
            this.olvcName.Text = "列表名称";
            this.olvcName.Width = 129;
            // 
            // olvcKwyWrods
            // 
            this.olvcKwyWrods.AspectName = "KeyWords";
            this.olvcKwyWrods.Groupable = false;
            this.olvcKwyWrods.IsRowNumberColumn = false;
            this.olvcKwyWrods.Text = "关键词";
            this.olvcKwyWrods.Width = 308;
            // 
            // olvcDesc
            // 
            this.olvcDesc.AspectName = "Desc";
            this.olvcDesc.Groupable = false;
            this.olvcDesc.IsRowNumberColumn = false;
            this.olvcDesc.Text = "描述";
            this.olvcDesc.Width = 199;
            // 
            // olvcID
            // 
            this.olvcID.AspectName = "ID";
            this.olvcID.DisplayIndex = 4;
            this.olvcID.Groupable = false;
            this.olvcID.IsRowNumberColumn = false;
            this.olvcID.IsVisible = false;
            this.olvcID.Text = "ID";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(629, 417);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 28);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmKeyWordList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 449);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.objList);
            this.Name = "frmKeyWordList";
            this.Text = "关键字列表";
            this.Load += new System.EventHandler(this.frmKeyWordList_Load);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.objList, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            ((System.ComponentModel.ISupportInitialize)(this.objList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nan.Controls.ObjectGrid objList;
        private BrightIdeasSoftware.OLVColumn olvcName;
        private BrightIdeasSoftware.OLVColumn olvcKwyWrods;
        private BrightIdeasSoftware.OLVColumn olvcDesc;
        private BrightIdeasSoftware.OLVColumn olvcID;
        private System.Windows.Forms.Button btnNew;
    }
}