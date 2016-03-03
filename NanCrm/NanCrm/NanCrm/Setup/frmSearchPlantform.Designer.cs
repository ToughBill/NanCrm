namespace NanCrm.Setup
{
    partial class frmSearchPlantform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchPlantform));
            this.objectGrid1 = new Nan.Controls.ObjectGrid();
            ((System.ComponentModel.ISupportInitialize)(this.objectGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // objectGrid1
            // 
            this.objectGrid1.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.objectGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectGrid1.AutoAddEmptyRow = false;
            this.objectGrid1.BOID = Nan.BusinessObjects.BOIDEnum.Invalid;
            this.objectGrid1.DataSourceType = null;
            this.objectGrid1.EmptyObject = null;
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
            this.objectGrid1.ShowGroups = false;
            this.objectGrid1.ShowRowNumber = true;
            this.objectGrid1.ShowSysMenu = false;
            this.objectGrid1.Size = new System.Drawing.Size(542, 287);
            this.objectGrid1.TabIndex = 2;
            this.objectGrid1.UseAlternatingBackColors = true;
            this.objectGrid1.UseCompatibleStateImageBehavior = false;
            this.objectGrid1.View = System.Windows.Forms.View.Details;
            // 
            // frmSearchPlantform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 337);
            this.Controls.Add(this.objectGrid1);
            this.Name = "frmSearchPlantform";
            this.Text = "搜索平台";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.objectGrid1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.objectGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nan.Controls.ObjectGrid objectGrid1;
    }
}