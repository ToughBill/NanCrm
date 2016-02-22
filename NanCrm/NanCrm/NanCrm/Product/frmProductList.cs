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

namespace NanCrm.Product
{
    public partial class frmProductList : FormBase
    {
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
                BOProduct proBo = (BOProduct)m_bo;
                IList listObj = proBo.GetDataList();
                objList.SetObjects(listObj);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmProduct frmMktMd = new frmProduct(BOIDEnum.Market);
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
    }
}
