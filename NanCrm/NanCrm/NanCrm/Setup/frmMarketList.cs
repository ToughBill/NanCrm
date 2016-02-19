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
                //IList ctybos = m_bo.GetDataList();
                //List<MarketMD> mktList = Utilities.ConvertList <MarketMD> (ctybos);
                
                //mktList.Add(newMkt);
                m_mktBO = (BOMarket)BOFactory.GetBO(BOIDEnum.Market);
                //mktBO.GetDataList();
                List<MarketDetaiedlMD> listObj = m_mktBO.GetDetailedMarketMD();
                MarketMD newMkt = new MarketMD();
                newMkt.ID = BusinessObject.GetBONextID(m_boId);
                MarketDetaiedlMD newObj = new MarketDetaiedlMD(newMkt);
                listObj.Add(newObj);

                objList.SetObjects(listObj);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            IList obj = (IList)objList.Objects;
            //BOMarket objMkt = (BOMarket)m_bo;
            m_mktBO.SetDataList(obj);
            return m_mktBO.Update();
        }

        private void objList_RowNumberDblClick(BrightIdeasSoftware.OlvListViewHitTestInfo hti)
        {
            MarketDetaiedlMD obj = (MarketDetaiedlMD)hti.RowObject;
            frmMarketMD frmMktMd = new frmMarketMD(BOIDEnum.Market);
            frmMktMd.MdiParent = this.MdiParent;
            frmMktMd.FormMode = NanCrm.FormMode.Add;
            frmMktMd.UpdateProc = MarketMDRetProc;
            frmMktMd.Show();
        }

        private void MarketMDRetProc(Form form, object data)
        {

        }
    }

    
}
