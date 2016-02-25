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
using NanCrm.Global;

namespace NanCrm.Setup
{
    public partial class frmKeyWordList : FormBase
    {
        private BOKWList m_kwlBo;
        public frmKeyWordList()
        {
            InitializeComponent();
        }

        private void frmKeyWordList_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }
        private void LoadGridData()
        {
            m_kwlBo = (BOKWList)BOFactory.GetBO(BOIDEnum.KeyWordList);
            List<KWListDetailMD> listObj = m_kwlBo.GetDetialedMD();
            objList.SetObjects(listObj);
            //objList.DataSourceType = typeof(KWListMD);
            //objList.AddEmptyRow();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmKeyWordListMD frmmd = new frmKeyWordListMD(BOIDEnum.KeyWordList);
            frmmd.MdiParent = this.MdiParent;
            FormExchangeParams param = new FormExchangeParams();
            param.Mode = NanCrm.FormMode.Add;
            param.ReturnProc = KWListRetProc;
            frmmd.SetFormExchangeParams(param);
            frmmd.Show();
        }

        private void KWListRetProc(Form form, object data)
        {

        }
    }
}
