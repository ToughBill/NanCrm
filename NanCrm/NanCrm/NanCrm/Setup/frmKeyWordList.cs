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
    }
}
