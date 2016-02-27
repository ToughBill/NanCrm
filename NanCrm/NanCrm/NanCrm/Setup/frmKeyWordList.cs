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
using System.Collections;
using BrightIdeasSoftware;

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
            BOKWList bo = (BOKWList)data;
            if (bo == null)
                return;
            KWListMD tb = (KWListMD)bo.GetBOTable();
            KWListDetailMD dtb = new KWListDetailMD(tb);
            dtb.KeyWords = bo.GetKetWordString();
            objList.AddObject(dtb);
        }

        private void objList_RowNumberDblClick(BrightIdeasSoftware.OlvListViewHitTestInfo hti)
        {
            KWListDetailMD obj = (KWListDetailMD)hti.RowObject;
            frmKeyWordListMD frmKw = new frmKeyWordListMD(BOIDEnum.KeyWordList);
            frmKw.MdiParent = this.MdiParent;
            FormExchangeParams param = new FormExchangeParams();
            param.Mode = NanCrm.FormMode.Ok;
            param.ReturnProc = KWLMDRetProc;
            param.Data = (KWListDetailMD)hti.RowObject;
            frmKw.SetFormExchangeParams(param);
            //frmKw.SetBOTable(((KWListDetailMD)hti.RowObject).GetOrignalMD());
            frmKw.Show();
        }

        private void KWLMDRetProc(Form form, object data)
        {
            BOKWList kwlBo = (BOKWList)data;
            KWListDetailMD detailedKwl = new KWListDetailMD((KWListMD)kwlBo.GetBOTable());
            //List<CountryMD> cty = mktBo.GetMktCountry();
            detailedKwl.KeyWords = kwlBo.GetKetWordString();
            OLVListItem olv = objList.GetItem(objList.LastHitInfo.RowIndex);
            olv.RowObject = detailedKwl;
            objList.RefreshItem(olv);
            //objList.AddObject(detailedKwl);
        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            List<KWListMD> list = objList.Objects.Cast<KWListDetailMD>().Select(x => x.GetOrignalMD()).ToList();
            List<KWListMD> removedList = objList.RemovedObjects.Cast<KWListDetailMD>().Select(x => x.GetOrignalMD()).ToList();
            m_kwlBo.SetDataList(list, removedList);
            return m_kwlBo.UpdateBatch();
        } 
    }
}
