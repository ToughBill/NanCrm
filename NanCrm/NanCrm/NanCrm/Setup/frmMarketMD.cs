using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NanCrm;
using System.Collections;
using Nan.BusinessObjects.BO;
using BrightIdeasSoftware;
using NanCrm.Properties;
using Nan.BusinessObjects;

namespace NanCrm.Setup
{
    public partial class frmMarketMD : FormBase
    {
        List<CountryMD> m_ctyList;
        public frmMarketMD(BOIDEnum boId):base(boId)
        {
            InitializeComponent();
        }

        private void frmMarketMD_Load(object sender, EventArgs e)
        {
            this.FormMode = FormMode.Add;
            m_ctyList = new List<CountryMD>();
            InitCountryGrid();
        }

        private void InitCountryGrid()
        {
            BOMarket mktBo = (BOMarket)m_bo;
            mktBo.Init();
            UpdateData(false);

            //this.olvcName.AspectGetter = delegate(object row)
            //{
            //    return "cfl";
            //};
            //this.olvcName.Renderer = new MappedImageRenderer(new Object[] { "cfl", Resources.ButtonChoose });
            objList.SmallImageList = imageList;
            this.olvcName.ImageGetter = delegate(object row)
            {
                return 0;
            };

            CountryMD cty = new CountryMD();
            cty.ID = BusinessObject.GetBONextID(BOIDEnum.Country);
            m_ctyList.Add(cty);
            objList.SetObjects(m_ctyList);
        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            IList list = (IList)objList.Objects;
            List<int> cties = list.Cast<CountryMD>().Select(x=>x.ID).ToList();
            MarketMD mkt = (MarketMD)m_bo.GetBOTable();
            mkt.CountryIds = cties;

            return true;
        }

        private void objList_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.Column==null || e.Column.AspectName != "Name")
            {
                return;
            }
            if (e.HitTest.HitTestLocation != HitTestLocation.Image)
            {
                return;
            }
        }
    }
}
