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
using Nan.Controls;

namespace NanCrm.Setup
{
    public partial class frmKeyWrod : FormBase
    {
        private BOKeyWord m_kwBo;
        public frmKeyWrod()
        {
            InitializeComponent();
        }

        private void frmKeyWrod_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }
        private void LoadGridData()
        {
            m_kwBo = (BOKeyWord)BOFactory.GetBO(BOIDEnum.KeyWord);
            List<KeyWordMD> listObj = Utilities.ConvertList<KeyWordMD>(m_kwBo.GetDataList());
            objList.SetObjects(listObj);
            objList.DataSourceType = typeof(KeyWordMD);
            objList.AddEmptyRow();
        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            IList obj = (IList)objList.Objects;
            if (!ValidateData())
            {
                return false;
            }
            m_kwBo.SetDataList(obj);
            return m_kwBo.UpdateBatch();
        }
        private bool ValidateData()
        {
            bool result = true;
            IList objs = (IList)objList.Objects;
            IEnumerator iter = objs.GetEnumerator();
            while (iter.MoveNext())
            {
                KeyWordMD md = (KeyWordMD)iter.Current;
                if (!objList.IsEmptyRow(md) && string.IsNullOrWhiteSpace(md.Name))
                {
                    GetStatusBar().DisplayMessage(MessageType.Error, "名称不能为空！");
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}
