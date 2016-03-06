using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nan.Controls;
using Nan.BusinessObjects.BO;
using Nan.BusinessObjects;

namespace NanCrm.BP
{
    public partial class frmBP : FormBase
    {
        public frmBP(BOIDEnum boid):base(boid)
        {
            InitializeComponent();
        }

        private void frmBP_Load(object sender, EventArgs e)
        {
            BOBP bpBo = (BOBP)m_bo;
            cmbType.DataSource = bpBo.GetBPTypeValidValue();
            cmbType.ValueMember = "Value";
            cmbType.DisplayMember = "Description";

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
                    BPMD md = (BPMD)this.ExchangeParam.Data;
                    bpBo.SetBOTable(md);
                }
                if (this.ExchangeParam.ReturnProc != null)
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
                GetStatusBar().DisplayMessage(MessageType.Error, "客户编号不能为空！");
                result = false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                GetStatusBar().DisplayMessage(MessageType.Error, "客户名称不能为空！");
                result = false;
            }
            return result;
        }
    }
}
