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

namespace NanCrm.Setup
{
    public partial class frmMarketMD : FormBase
    {
        public frmMarketMD()
        {
            InitializeComponent();
        }

        private void frmMarketMD_Load(object sender, EventArgs e)
        {
            this.FormMode = FormMode.Add;
            InitCountryGrid();
        }

        private void InitCountryGrid()
        {
            this.olvcName.AspectGetter = delegate(object row)
            {
                return "cfl";
            };
            this.olvcName.Renderer = new MappedImageRenderer(new Object[] { "cfl", Resources.ButtonChoose });
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
            if (e.Column.Name != "olvcName")
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
