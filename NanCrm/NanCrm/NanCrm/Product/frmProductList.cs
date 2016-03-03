﻿using System;
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
            param.ReturnProc = NewProductMDRetProc;
            frmMktMd.SetFormExchangeParams(param);
            frmMktMd.Show();
        }

        private void NewProductMDRetProc(Form form, object data)
        {
<<<<<<< .mine
            BOProduct bo = (BOProduct)data;
            if (bo == null)
                return;
            objList.AddObject((ProductMD)bo.GetBOTable());
||||||| .r30

=======
            BOProduct proBo = (BOProduct)data;
            if (proBo == null)
            {
                return;
            }
            ProductMD proMd = (ProductMD)proBo.GetBOTable();
            objList.AddObject(proMd);
>>>>>>> .r33
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
<<<<<<< .mine

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            IList list = (IList)objList.Objects;
            m_proList.SetDataList(list,objList.RemovedObjects);
            return m_proList.UpdateBatch();
        }
||||||| .r30
=======
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
>>>>>>> .r33
    }
}
