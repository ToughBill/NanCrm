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
            try
            {
                m_proList = (BOProduct)BOFactory.GetBO(BOIDEnum.Product);
                List<ProductMD> listObj = Utilities.ConvertList<ProductMD>(m_proList.GetDataList());
                objList.SetObjects(listObj);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmProduct frmMktMd = new frmProduct(BOIDEnum.Product);
            frmMktMd.MdiParent = this.MdiParent;
            FormExchangeParams param = new FormExchangeParams();
            param.Mode = FormMode.Add;
            param.ReturnProc = ProductMDRetProc;
            frmMktMd.SetFormExchangeParams(param);
            frmMktMd.Show();
        }

        private void ProductMDRetProc(Form form, object data)
        {

        }

        private void objList_RowNumberDblClick(BrightIdeasSoftware.OlvListViewHitTestInfo hti)
        {
            frmProduct frmPro = new frmProduct(BOIDEnum.Product);
            frmPro.MdiParent = this.MdiParent;
            FormExchangeParams args = new FormExchangeParams();
            args.Data = hti.RowObject;
            args.Mode = FormMode.Ok;
            frmPro.SetFormExchangeParams(args);
            frmPro.Show();

            //MarketDetaiedlMD obj = (MarketDetaiedlMD)hti.RowObject;
            //frmMarketMD frmMktMd = new frmMarketMD(BOIDEnum.Market);
            //frmMktMd.MdiParent = this.MdiParent;
            //frmMktMd.FormMode = NanCrm.FormMode.Ok;
            //frmMktMd.UpdateProc = MarketMDUpdateProc;
            ////int id = ((MarketDetaiedlMD)hti.RowObject).ID;
            ////frmMktMd.LoadDataById(id);
            //frmMktMd.SetBOTable(((MarketDetaiedlMD)hti.RowObject).GetOrignalMD());
            //frmMktMd.Show();
        }
    }
}
