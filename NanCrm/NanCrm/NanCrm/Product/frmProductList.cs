using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nan.BusinessObjects.BO;
using Nan.BusinessObjects;
using System.Collections;
using NanCrm.Global;

namespace NanCrm.Product
{
    public partial class frmProductList : FormBase
    {
        private BOProduct m_proList;
        public frmProductList()
        {
            InitializeComponent();
        }

        private void frmProductList_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            olvcTexture.DataSource = BOFactory.GetBO(BOIDEnum.Texture).GetValieValue("ID","Name");
            olvcGroup.DataSource= BOFactory.GetBO(BOIDEnum.ProductGroup).GetValieValue("ID", "Name");

            m_proList = (BOProduct)BOFactory.GetBO(BOIDEnum.Product);
            List<ProductMD> listObj = Utilities.ConvertList<ProductMD>(m_proList.GetDataList());
            objList.SetObjects(listObj);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmProduct frmMktMd = new frmProduct(BOIDEnum.Product);
            frmMktMd.MdiParent = this.MdiParent;
            FormExchangeParams param = new FormExchangeParams();
            param.Mode = FormMode.Add;
            param.ReturnProc = NewProductMDRetProc;
            frmMktMd.SetFormExchangeParams(param);
            frmMktMd.Show();
        }

        private void NewProductMDRetProc(Form form, object data)
        {
            BOProduct proBo = (BOProduct)data;
            if (proBo == null)
            {
                return;
            }
            ProductMD proMd = (ProductMD)proBo.GetBOTable();
            objList.AddObject(proMd);
        }

        private void objList_RowNumberDblClick(BrightIdeasSoftware.OlvListViewHitTestInfo hti)
        {
            frmProduct frmPro = new frmProduct(BOIDEnum.Product);
            frmPro.MdiParent = this.MdiParent;
            FormExchangeParams args = new FormExchangeParams();
            args.Data = hti.RowObject;
            args.Mode = FormMode.Ok;
            args.ReturnProc = UpdateProMdRetProc;
            frmPro.SetFormExchangeParams(args);
            frmPro.Show();
        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            IList list = (IList)objList.Objects;
            m_proList.SetDataList(list,objList.RemovedObjects);
            return m_proList.UpdateBatch();
        }
        private void UpdateProMdRetProc(Form form, object data)
        {
            BOProduct proBo = (BOProduct)data;
            if (proBo == null)
            {
                return;
            }
            ProductMD proMd = (ProductMD)proBo.GetBOTable();
            IList list = (IList)objList.Objects;
            ProductMD md = (ProductMD)list[objList.LastHitInfo.RowIndex];
            md.CopyFrom(proMd);
            objList.RefreshObject(md);
        }
    }
}
