using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nan.Controls;
using Nan.BusinessObjects;
using Nan.BusinessObjects.BO;

namespace NanCrm.Product
{
    public partial class frmProduct : FormBase
    {
        public frmProduct(BOIDEnum boId)
            : base(boId)
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            BOProduct mktBo = (BOProduct)m_bo;
            if (this.ExchangeParam == null)
            {
                //mktBo.Init();
                this.FormMode = NanCrm.FormMode.Add;
            }
            else
            {
                this.FormMode = this.ExchangeParam.Mode;
                if (this.ExchangeParam.Data != null)
                {
                    ProductMD md = (ProductMD)this.ExchangeParam.Data;
                    mktBo.SetBOTable(md);
                }
                if(this.ExchangeParam.ReturnProc != null)
                {
                    this.ReturnProc = this.ExchangeParam.ReturnProc;
                }
            }
            UpdateData(false);
        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            if (!ValidateData())
                return false;
            if (!UpdateData())
            {
                return false;
            }
            bool result = true;
            if (this.FormMode == NanCrm.FormMode.Add)
            {
                result = m_bo.Add();
            }
            else if (this.FormMode == NanCrm.FormMode.Update)
            {
                result = m_bo.Update();
            }
            return result;
        }

        private bool ValidateData()
        {
            bool result = true;
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                GetStatusBar().DisplayMessage(MessageType.Error,"编号为空！");
                result = false;
            }
            return result;
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
