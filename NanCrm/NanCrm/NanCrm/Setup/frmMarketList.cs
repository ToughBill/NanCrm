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
using System.Collections;
using NanCrm.Global;

namespace NanCrm.Setup
{
    public partial class frmMarketList:FormBase
    {
        private BOMarket m_mktBO;
        public frmMarketList()
        {
            InitializeComponent();
            base.m_boId = BOIDEnum.Invalid;
        }

        private void Market_Load(object sender, EventArgs e)
        {
            LoadGridData();
            objList.RebuildColumns();
        }
        public void LoadGridData()
        {
            try
            {
                m_mktBO = (BOMarket)BOFactory.GetBO(BOIDEnum.Market);
                List<MarketDetaiedlMD> listObj = m_mktBO.GetDetailedMarketMD();
                //MarketMD newMkt = new MarketMD();
                //newMkt.ID = BusinessObject.GetBONextID(m_boId);
                //MarketDetaiedlMD newObj = new MarketDetaiedlMD(newMkt);
                //listObj.Add(newObj);

                objList.SetObjects(listObj);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            if (this.FormMode == NanCrm.FormMode.Ok)
                return true;
            IList obj = (IList)objList.Objects;
            //BOMarket objMkt = (BOMarket)m_bo;
            //m_mktBO.SetDataList(obj);
            List<MarketMD> mktList = obj.Cast<MarketDetaiedlMD>().Select(x => x.GetOrignalMD()).ToList();
            m_mktBO.SetDataList(mktList);

            m_mktBO.SetRemovedDataList(objList.RemovedObjects.Cast<MarketDetaiedlMD>().ToList().Select(x => x.GetOrignalMD()).ToList());
            return m_mktBO.UpdateBatch();
        }

        private void objList_RowNumberDblClick(BrightIdeasSoftware.OlvListViewHitTestInfo hti)
        {
            MarketDetaiedlMD obj = (MarketDetaiedlMD)hti.RowObject;
            frmMarketMD frmMktMd = new frmMarketMD(BOIDEnum.Market);
            frmMktMd.MdiParent = this.MdiParent;
            frmMktMd.FormMode = NanCrm.FormMode.Ok;
            frmMktMd.UpdateProc = MarketMDUpdateProc;
            //int id = ((MarketDetaiedlMD)hti.RowObject).ID;
            //frmMktMd.LoadDataById(id);
            frmMktMd.SetBOTable(((MarketDetaiedlMD)hti.RowObject).GetOrignalMD());
            frmMktMd.Show();
        }

        private void MarketMDUpdateProc(Form form, object data)
        {
            BOMarket mktBo = (BOMarket)data;
            MarketDetaiedlMD detailedMkt = new MarketDetaiedlMD((MarketMD)mktBo.GetBOTable());
            List<CountryMD> cty = mktBo.GetMktCountry();
            detailedMkt.Countries = mktBo.GetCountryString();
            if(objList.FocusedItem != null)
            {
                objList.GetItem(objList.FocusedItem.Index).RowObject = detailedMkt;
            }
            
            objList.RefreshSelectedObjects();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmMarketMD frmMktMd = new frmMarketMD(BOIDEnum.Market);
            frmMktMd.MdiParent = this.MdiParent;
            frmMktMd.FormMode = NanCrm.FormMode.Add;
            frmMktMd.ReturnProc = NewMarketRetProc;
            frmMktMd.Show();
        }

        private void NewMarketRetProc(Form form, object data)
        {
            BOMarket mktBo = (BOMarket)data;
            MarketDetaiedlMD detailedMkt = new MarketDetaiedlMD((MarketMD)mktBo.GetBOTable());
            List<CountryMD> cty = mktBo.GetMktCountry();
            detailedMkt.Countries = mktBo.GetCountryString();
            objList.AddObject(detailedMkt);
        }
    }

    
}
