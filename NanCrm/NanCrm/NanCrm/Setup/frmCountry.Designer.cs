﻿namespace NanCrm.Setup
{
    partial class frmCountry
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
            this.objList = new Nan.Controls.ObjectGrid();
            this.olvcID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcFName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcAlias = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcCaptial = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.objList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 326);
            this.btnOk.Clicking += new Nan.Controls.ClickingEvent(this.btnOk_Clicking);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 326);
            // 
            // objList
            // 
            this.objList.AllColumns.Add(this.olvcID);
            this.objList.AllColumns.Add(this.olvcName);
            this.objList.AllColumns.Add(this.olvcFName);
            this.objList.AllColumns.Add(this.olvcAlias);
            this.objList.AllColumns.Add(this.olvcCaptial);
            this.objList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.objList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.objList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcID,
            this.olvcName,
            this.olvcFName,
            this.olvcAlias,
            this.olvcCaptial});
            this.objList.HideSelection = false;
            this.objList.Location = new System.Drawing.Point(12, 11);
            this.objList.Name = "objList";
            this.objList.Size = new System.Drawing.Size(573, 310);
            this.objList.TabIndex = 0;
            this.objList.UseCompatibleStateImageBehavior = false;
            this.objList.View = System.Windows.Forms.View.Details;
            this.objList.CellEditValidating += new BrightIdeasSoftware.CellEditEventHandler(this.objList_CellEditValidating);
            // 
            // olvcID
            // 
            this.olvcID.AspectName = "ID";
            this.olvcID.Groupable = false;
            this.olvcID.Text = "#";
            this.olvcID.Width = 36;
            // 
            // olvcName
            // 
            this.olvcName.AspectName = "Name";
            this.olvcName.Groupable = false;
            this.olvcName.Text = "国家";
            this.olvcName.Width = 137;
            // 
            // olvcFName
            // 
            this.olvcFName.AspectName = "ForeName";
            this.olvcFName.Groupable = false;
            this.olvcFName.Text = "外文名";
            this.olvcFName.Width = 178;
            // 
            // olvcAlias
            // 
            this.olvcAlias.AspectName = "Alias";
            this.olvcAlias.Groupable = false;
            this.olvcAlias.Text = "简写";
            this.olvcAlias.Width = 85;
            // 
            // olvcCaptial
            // 
            this.olvcCaptial.AspectName = "Capital";
            this.olvcCaptial.Groupable = false;
            this.olvcCaptial.Text = "首都";
            this.olvcCaptial.Width = 114;
            // 
            // Country
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 358);
            this.Controls.Add(this.objList);
            this.Name = "Country";
            this.Text = "Country";
            this.Load += new System.EventHandler(this.Country_Load);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.objList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.objList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nan.Controls.ObjectGrid objList;
        private BrightIdeasSoftware.OLVColumn olvcID;
        private BrightIdeasSoftware.OLVColumn olvcName;
        private BrightIdeasSoftware.OLVColumn olvcFName;
        private BrightIdeasSoftware.OLVColumn olvcAlias;
        private BrightIdeasSoftware.OLVColumn olvcCaptial;
    }
}