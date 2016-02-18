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
    public partial class frmMarket : FormEx
    {
        public frmMarket(BOIDEnum boid):base(boid)
        {
            InitializeComponent();
        }

        private void Market_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }
        public void LoadGridData()
        {
            try
            {
                //IList ctybos = m_bo.GetDataList();
                //List<MarketMD> mktList = Utilities.ConvertList <MarketMD> (ctybos);
                
                //mktList.Add(newMkt);
                BOMarket mktBO=(BOMarket)m_bo;
                mktBO.GetDataList();
                List<MarketDetaiedlMD> listObj = mktBO.GetDetailedMarketMD();
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
            BOMarket objMkt = (BOMarket)m_bo;
            objMkt.SetDataList(obj);
            return objMkt.Update();
        }
    }

    
}
