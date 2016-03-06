using Nan.BusinessObjects;
using Nan.BusinessObjects.BO;
using NanCrm.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NanCrm.BP
{
    public partial class frmBpList : FormBase
    {
        BOBP m_bpList;
        public frmBpList()
        {
            InitializeComponent();
        }

        private void frmBpList_Load(object sender, EventArgs e)
        {
            BusinessObject ctyBo = BOFactory.GetBO(BOIDEnum.Country);
            olvcCty.DataSource = ctyBo.GetValieValue("ID", "Name");

            BOBP bpBo = (BOBP)BOFactory.GetBO(BOIDEnum.BP);
            olvcType.DataSource = bpBo.GetBPTypeValidValue();

            LoadGrid();
        }

        private void LoadGrid()
        {
            m_bpList = (BOBP)BOFactory.GetBO(BOIDEnum.BP);
            List<BPMD> listObj = Utilities.ConvertList<BPMD>(m_bpList.GetDataList());
            objList.SetObjects(listObj);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmBP frmBp = new frmBP(BOIDEnum.BP);
            frmBp.MdiParent = this.MdiParent;
            FormExchangeParams param = new FormExchangeParams();
            param.Mode = FormMode.Add;
            param.ReturnProc = NewBPMDRetProc;
            frmBp.SetFormExchangeParams(param);
            frmBp.Show();
        }

        private void NewBPMDRetProc(Form form, object data)
        {
            BOBP bpBo = (BOBP)data;
            if (bpBo == null)
            {
                return;
            }
            BPMD bpMd = (BPMD)bpBo.GetBOTable();
            objList.AddObject(bpMd);
        }

        private void objList_RowNumberDblClick(BrightIdeasSoftware.OlvListViewHitTestInfo hti)
        {
            frmBP frmPro = new frmBP(BOIDEnum.BP);
            frmPro.MdiParent = this.MdiParent;
            FormExchangeParams args = new FormExchangeParams();
            args.Data = hti.RowObject;
            args.Mode = FormMode.Ok;
            args.ReturnProc = UpdateBPMdRetProc;
            frmPro.SetFormExchangeParams(args);
            frmPro.Show();
        }

        private void UpdateBPMdRetProc(Form form, object data)
        {
            BOBP bpBo = (BOBP)data;
            if (bpBo == null)
            {
                return;
            }
            BPMD proMd = (BPMD)bpBo.GetBOTable();
            IList list = (IList)objList.Objects;
            BPMD md = (BPMD)list[objList.LastHitInfo.RowIndex];
            md.CopyFrom(proMd);
            objList.RefreshObject(md);
        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            IList list = (IList)objList.Objects;
            m_bpList.SetDataList(list, objList.RemovedObjects);
            return m_bpList.UpdateBatch();
        }
    }
}
