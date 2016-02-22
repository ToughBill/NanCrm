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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductList));
            this.objList = new Nan.Controls.ObjectGrid();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.objList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 438);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 438);
            // 
            // objList
            // 
            this.objList.BOID = Nan.BusinessObjects.BOIDEnum.Invalid;
            this.objList.FullRowSelect = true;
            this.objList.GridLines = true;
            this.objList.HideSelection = false;
            this.objList.LastHitInfo = null;
            this.objList.Location = new System.Drawing.Point(12, 13);
            this.objList.Name = "objList";
            this.objList.RemovedObject = null;
            this.objList.RemovedObjects = ((System.Collections.IList)(resources.GetObject("objList.RemovedObjects")));
            this.objList.ShowAddRowMenu = false;
            this.objList.ShowDeleteRowMenu = false;
            this.objList.ShowRowNumber = true;
            this.objList.ShowSysMenu = false;
            this.objList.Size = new System.Drawing.Size(652, 418);
            this.objList.TabIndex = 2;
            this.objList.UseAlternatingBackColors = true;
            this.objList.UseCompatibleStateImageBehavior = false;
            this.objList.View = System.Windows.Forms.View.Details;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(589, 438);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 30);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 472);
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
    }
}