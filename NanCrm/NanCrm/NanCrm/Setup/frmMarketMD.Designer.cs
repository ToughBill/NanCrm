namespace NanCrm.Setup
{
    partial class frmMarketMD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMarketMD));
            this.txtName = new Nan.Controls.TextBoxEx();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtId = new Nan.Controls.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.objList = new Nan.Controls.ObjectGrid();
            this.olvcID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcFName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcAlias = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcCapital = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTxtDesc = new Nan.Controls.RichTextBoxEx();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.objList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 423);
            this.btnOk.Clicking += new Nan.Controls.ClickingEvent(this.btnOk_Clicking);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 423);
            // 
            // txtName
            // 
            this.txtName.BOField = "Name";
            this.txtName.BOID = Nan.BusinessObjects.BOIDEnum.Market;
            this.txtName.Location = new System.Drawing.Point(66, 11);
            this.txtName.Name = "txtName";
            this.txtName.ShowChoose = false;
            this.txtName.ShowLink = false;
            this.txtName.Size = new System.Drawing.Size(170, 18);
            this.txtName.TabIndex = 5;
            this.txtName.TableSource = null;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(7, 17);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(29, 12);
            this.lblCode.TabIndex = 4;
            this.lblCode.Text = "市场";
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.BOField = "ID";
            this.txtId.BOID = Nan.BusinessObjects.BOIDEnum.Market;
            this.txtId.Location = new System.Drawing.Point(507, 11);
            this.txtId.Name = "txtId";
            this.txtId.ShowChoose = false;
            this.txtId.ShowLink = false;
            this.txtId.Size = new System.Drawing.Size(170, 18);
            this.txtId.TabIndex = 7;
            this.txtId.TableSource = null;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "编号";
            // 
            // objList
            // 
            this.objList.AllColumns.Add(this.olvcID);
            this.objList.AllColumns.Add(this.olvcName);
            this.objList.AllColumns.Add(this.olvcFName);
            this.objList.AllColumns.Add(this.olvcAlias);
            this.objList.AllColumns.Add(this.olvcCapital);
            this.objList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.objList.BOID = Nan.BusinessObjects.BOIDEnum.Country;
            this.objList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.objList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcName,
            this.olvcFName,
            this.olvcAlias,
            this.olvcCapital});
            this.objList.FullRowSelect = true;
            this.objList.GridLines = true;
            this.objList.HideSelection = false;
            this.objList.Location = new System.Drawing.Point(10, 57);
            this.objList.Name = "objList";
            this.objList.OwnerDraw = true;
            this.objList.ShowAddRowMenu = true;
            this.objList.ShowDeleteRowMenu = true;
            this.objList.ShowRowNumber = true;
            this.objList.ShowSysMenu = true;
            this.objList.Size = new System.Drawing.Size(667, 250);
            this.objList.TabIndex = 8;
            this.objList.UseAlternatingBackColors = true;
            this.objList.UseCompatibleStateImageBehavior = false;
            this.objList.View = System.Windows.Forms.View.Details;
            this.objList.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.objList_CellClick);
            // 
            // olvcID
            // 
            this.olvcID.AspectName = "ID";
            this.olvcID.Groupable = false;
            this.olvcID.IsRowNumberColumn = false;
            this.olvcID.IsVisible = false;
            this.olvcID.Text = "ID";
            // 
            // olvcName
            // 
            this.olvcName.AspectName = "Name";
            this.olvcName.Groupable = false;
            this.olvcName.IsRowNumberColumn = false;
            this.olvcName.Text = "国家";
            this.olvcName.Width = 169;
            // 
            // olvcFName
            // 
            this.olvcFName.AspectName = "ForeName";
            this.olvcFName.Groupable = false;
            this.olvcFName.IsRowNumberColumn = false;
            this.olvcFName.Text = "外文名";
            this.olvcFName.Width = 182;
            // 
            // olvcAlias
            // 
            this.olvcAlias.AspectName = "Alias";
            this.olvcAlias.Groupable = false;
            this.olvcAlias.IsRowNumberColumn = false;
            this.olvcAlias.Text = "简称";
            this.olvcAlias.Width = 85;
            // 
            // olvcCapital
            // 
            this.olvcCapital.AspectName = "Capital";
            this.olvcCapital.Groupable = false;
            this.olvcCapital.IsRowNumberColumn = false;
            this.olvcCapital.Text = "首都";
            this.olvcCapital.Width = 161;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "包含国家：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "备注：";
            // 
            // richTxtDesc
            // 
            this.richTxtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTxtDesc.BOField = "Desc";
            this.richTxtDesc.BOID = Nan.BusinessObjects.BOIDEnum.Market;
            this.richTxtDesc.Location = new System.Drawing.Point(10, 332);
            this.richTxtDesc.Name = "richTxtDesc";
            this.richTxtDesc.Size = new System.Drawing.Size(667, 85);
            this.richTxtDesc.TabIndex = 11;
            this.richTxtDesc.Text = "";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ButtonChoose.png");
            // 
            // frmMarketMD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BOID = Nan.BusinessObjects.BOIDEnum.Market;
            this.ClientSize = new System.Drawing.Size(689, 462);
            this.Controls.Add(this.richTxtDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.objList);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblCode);
            this.Name = "frmMarketMD";
            this.Text = "市场";
            this.Load += new System.EventHandler(this.frmMarketMD_Load);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblCode, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtId, 0);
            this.Controls.SetChildIndex(this.objList, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.richTxtDesc, 0);
            ((System.ComponentModel.ISupportInitialize)(this.objList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nan.Controls.TextBoxEx txtName;
        private System.Windows.Forms.Label lblCode;
        private Nan.Controls.TextBoxEx txtId;
        private System.Windows.Forms.Label label1;
        private Nan.Controls.ObjectGrid objList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Nan.Controls.RichTextBoxEx richTxtDesc;
        private BrightIdeasSoftware.OLVColumn olvcID;
        private BrightIdeasSoftware.OLVColumn olvcName;
        private BrightIdeasSoftware.OLVColumn olvcFName;
        private BrightIdeasSoftware.OLVColumn olvcAlias;
        private BrightIdeasSoftware.OLVColumn olvcCapital;
        private System.Windows.Forms.ImageList imageList;
    }
}