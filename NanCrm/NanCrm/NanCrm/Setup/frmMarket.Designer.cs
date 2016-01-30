namespace NanCrm.Setup
{
    partial class frmMarket
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
            this.olvId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcDesc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.objList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Clicking += new Nan.Controls.ClickingEvent(this.btnOk_Clicking);
            // 
            // objList
            // 
            this.objList.AllColumns.Add(this.olvId);
            this.objList.AllColumns.Add(this.olvcName);
            this.objList.AllColumns.Add(this.olvcDesc);
            this.objList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.objList.BOID = Nan.BusinessObjects.BOIDEnum.Market;
            this.objList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.objList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvId,
            this.olvcName,
            this.olvcDesc});
            this.objList.Location = new System.Drawing.Point(12, 12);
            this.objList.Name = "objList";
            this.objList.Size = new System.Drawing.Size(542, 287);
            this.objList.TabIndex = 2;
            this.objList.UseCompatibleStateImageBehavior = false;
            this.objList.View = System.Windows.Forms.View.Details;
            // 
            // olvId
            // 
            this.olvId.AspectName = "ID";
            this.olvId.Groupable = false;
            this.olvId.Text = "#";
            // 
            // olvcName
            // 
            this.olvcName.AspectName = "Name";
            this.olvcName.Text = "名称";
            this.olvcName.Width = 156;
            // 
            // olvcDesc
            // 
            this.olvcDesc.AspectName = "Desc";
            this.olvcDesc.Groupable = false;
            this.olvcDesc.Text = "描述";
            this.olvcDesc.Width = 300;
            // 
            // frmMarket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 337);
            this.Controls.Add(this.objList);
            this.Name = "frmMarket";
            this.Text = "Market";
            this.Load += new System.EventHandler(this.Market_Load);
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
    }
}