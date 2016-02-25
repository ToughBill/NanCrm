﻿namespace NanCrm.Setup
{
    partial class frmProductGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductGroup));
            this.objList = new Nan.Controls.ObjectGrid();
            this.olvcID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcDesc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.objList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 399);
            this.btnOk.Clicking += new Nan.Controls.ClickingEvent(this.btnOk_Clicking);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 399);
            // 
            // objList
            // 
            this.objList.AllColumns.Add(this.olvcID);
            this.objList.AllColumns.Add(this.olvcName);
            this.objList.AllColumns.Add(this.olvcDesc);
            this.objList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.objList.BOID = Nan.BusinessObjects.BOIDEnum.Invalid;
            this.objList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.objList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcName,
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
            this.objList.ShowGroups = false;
            this.objList.ShowRowNumber = true;
            this.objList.ShowSysMenu = true;
            this.objList.Size = new System.Drawing.Size(614, 381);
            this.objList.TabIndex = 2;
            this.objList.UseAlternatingBackColors = true;
            this.objList.UseCompatibleStateImageBehavior = false;
            this.objList.View = System.Windows.Forms.View.Details;
            // 
            // olvcID
            // 
            this.olvcID.AspectName = "ID";
            this.olvcID.Groupable = false;
            this.olvcID.IsRowNumberColumn = false;
            this.olvcID.IsVisible = false;
            // 
            // olvcName
            // 
            this.olvcName.AspectName = "Name";
            this.olvcName.Groupable = false;
            this.olvcName.IsRowNumberColumn = false;
            this.olvcName.Text = "名称";
            this.olvcName.Width = 180;
            // 
            // olvcDesc
            // 
            this.olvcDesc.AspectName = "Desc";
            this.olvcDesc.Groupable = false;
            this.olvcDesc.IsRowNumberColumn = false;
            this.olvcDesc.Text = "描述";
            this.olvcDesc.Width = 350;
            // 
            // frmProductGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 431);
            this.Controls.Add(this.objList);
            this.Name = "frmProductGroup";
            this.Text = "产品分组";
            this.Load += new System.EventHandler(this.frmProductGroup_Load);
            this.Controls.SetChildIndex(this.objList, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.objList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nan.Controls.ObjectGrid objList;
        private BrightIdeasSoftware.OLVColumn olvcID;
        private BrightIdeasSoftware.OLVColumn olvcName;
        private BrightIdeasSoftware.OLVColumn olvcDesc;
    }
}