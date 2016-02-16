namespace NanCrm.Setup
{
    partial class frmTexture
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
            this.objGrid = new Nan.Controls.ObjectGrid();
            this.olvcName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcDesc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.objGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 339);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 339);
            // 
            // objGrid
            // 
            this.objGrid.AllColumns.Add(this.olvcName);
            this.objGrid.AllColumns.Add(this.olvcDesc);
            this.objGrid.AllColumns.Add(this.olvcID);
            this.objGrid.BOID = Nan.BusinessObjects.BOIDEnum.Invalid;
            this.objGrid.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcName,
            this.olvcDesc});
            this.objGrid.FullRowSelect = true;
            this.objGrid.GridLines = true;
            this.objGrid.HideSelection = false;
            this.objGrid.Location = new System.Drawing.Point(12, 12);
            this.objGrid.Name = "objGrid";
            this.objGrid.ShowRowNumber = true;
            this.objGrid.Size = new System.Drawing.Size(554, 321);
            this.objGrid.TabIndex = 2;
            this.objGrid.UseAlternatingBackColors = true;
            this.objGrid.UseCompatibleStateImageBehavior = false;
            this.objGrid.View = System.Windows.Forms.View.Details;
            // 
            // olvcName
            // 
            this.olvcName.AspectName = "Name";
            this.olvcName.Groupable = false;
            this.olvcName.IsRowNumberColumn = false;
            this.olvcName.Text = "类型";
            this.olvcName.Width = 144;
            // 
            // olvcDesc
            // 
            this.olvcDesc.AspectName = "Desc";
            this.olvcDesc.Groupable = false;
            this.olvcDesc.IsRowNumberColumn = false;
            this.olvcDesc.Text = "描述";
            this.olvcDesc.Width = 293;
            // 
            // olvcID
            // 
            this.olvcID.AspectName = "ID";
            this.olvcID.Groupable = false;
            this.olvcID.IsRowNumberColumn = false;
            this.olvcID.IsVisible = false;
            // 
            // frmTexture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 371);
            this.Controls.Add(this.objGrid);
            this.Name = "frmTexture";
            this.Text = "材质 - 设置";
            this.Load += new System.EventHandler(this.frmTexture_Load);
            this.Controls.SetChildIndex(this.objGrid, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.objGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nan.Controls.ObjectGrid objGrid;
        private BrightIdeasSoftware.OLVColumn olvcName;
        private BrightIdeasSoftware.OLVColumn olvcDesc;
        private BrightIdeasSoftware.OLVColumn olvcID;
    }
}