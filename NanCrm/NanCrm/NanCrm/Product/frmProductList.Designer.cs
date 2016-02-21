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
            this.objectGrid1 = new Nan.Controls.ObjectGrid();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.objectGrid1)).BeginInit();
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
            // objectGrid1
            // 
            this.objectGrid1.BOID = Nan.BusinessObjects.BOIDEnum.Invalid;
            this.objectGrid1.FullRowSelect = true;
            this.objectGrid1.GridLines = true;
            this.objectGrid1.HideSelection = false;
            this.objectGrid1.LastHitInfo = null;
            this.objectGrid1.Location = new System.Drawing.Point(12, 12);
            this.objectGrid1.Name = "objectGrid1";
            this.objectGrid1.RemovedObject = null;
            this.objectGrid1.RemovedObjects = ((System.Collections.IList)(resources.GetObject("objectGrid1.RemovedObjects")));
            this.objectGrid1.ShowAddRowMenu = false;
            this.objectGrid1.ShowDeleteRowMenu = false;
            this.objectGrid1.ShowRowNumber = true;
            this.objectGrid1.ShowSysMenu = false;
            this.objectGrid1.Size = new System.Drawing.Size(652, 386);
            this.objectGrid1.TabIndex = 2;
            this.objectGrid1.UseAlternatingBackColors = true;
            this.objectGrid1.UseCompatibleStateImageBehavior = false;
            this.objectGrid1.View = System.Windows.Forms.View.Details;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(589, 404);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 28);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // frmProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 436);
            this.Controls.Add(this.objectGrid1);
            this.Controls.Add(this.btnNew);
            this.Name = "frmProductList";
            this.Text = "产品列表";
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.objectGrid1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.objectGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nan.Controls.ObjectGrid objectGrid1;
        private System.Windows.Forms.Button btnNew;
    }
}