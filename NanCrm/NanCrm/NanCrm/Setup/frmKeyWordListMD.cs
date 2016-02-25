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
using BrightIdeasSoftware;
using System.Collections;
using NanCrm.Global;

namespace NanCrm.Setup
{
    public partial class frmKeyWordListMD : FormBase
    {
        private List<KeyWordMD> m_kwList;
        public frmKeyWordListMD(BOIDEnum boid):base(boid)
        {
            InitializeComponent();
        }

        private void frmKeyWordListMD_Load(object sender, EventArgs e)
        {
            m_kwList = new List<KeyWordMD>();
            InitData();
        }

        private void InitData()
        {
            objList.SmallImageList = imageList;
            this.olvcName.ImageGetter = delegate(object row)
            {
                return 0;
            };

            BOKWList kwlMd = (BOKWList)m_bo;
            if (ExchangeParam == null)
            {
                this.FormMode = NanCrm.FormMode.Add;
                kwlMd.Init();
            }
            else
            {
                this.FormMode = ExchangeParam.Mode;
                if (this.FormMode == NanCrm.FormMode.Add)
                {
                    kwlMd.Init();
                }
                if (ExchangeParam.Data is KWListDetailMD)
                {
                    KWListDetailMD inMd = (KWListDetailMD)ExchangeParam.Data;
                    KWListMD kwMd = inMd.GetOrignalMD();
                    foreach (int id in kwMd.KeyWrodIds)
                    {
                        BOKeyWord kwBo = new BOKeyWord();
                        kwBo.GetById(id);
                        m_kwList.Add((KeyWordMD)kwBo.GetBOTable());
                    }
                }
                objList.SetObjects(m_kwList);
                objList.DataSourceType = typeof(KeyWordMD);
                objList.AddEmptyRow();
            }
            UpdateData(false);
        }

        private void objList_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (e.Column == null || e.Column.AspectName != "Name")
            {
                return;
            }
            if (e.HitTest.HitTestLocation == HitTestLocation.Image)
            {
                frmCFL cfl = new frmCFL(objList.BOID);
                cfl.ReturnProc = KeyWordRetProc;
                cfl.MdiParent = this.MdiParent;
                cfl.Show();
            }
        }

        private void KeyWordRetProc(Form form, object data)
        {
            IList list = (IList)data;
            List<KeyWordMD> kwList = Utilities.ConvertList<KeyWordMD>(list);
            objList.InsertObjects(objList.SelectedIndex, kwList);
            this.Refresh();

        }
    }
}
