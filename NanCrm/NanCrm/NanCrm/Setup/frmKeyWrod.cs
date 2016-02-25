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
            KeyWordMD newKw = (KeyWordMD)objList.AddEmptyRow();
            newKw.ID = BusinessObject.GetBONextID(BOIDEnum.KeyWord);
        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            if (this.FormMode == NanCrm.FormMode.Ok)
                return true;

            IList obj = (IList)objList.Objects;
            if (!ValidateData())
            {
                return false;
            }
            if (objList.EmptyObject != null)
            {
                KeyWordMD temp = (KeyWordMD)objList.EmptyObject;
                if (string.IsNullOrWhiteSpace(temp.Name))
                {
                    obj.Remove(objList.EmptyObject);
                }
            }
            m_kwBo.SetDataList(obj, objList.RemovedObjects);
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

        private void frmKeyWrod_OnModeChange(FormModeChangeArgs args)
        {
//             if (args.NewMode == NanCrm.FormMode.Ok)
//             {
//                 LoadGridData();
//             }
        }

        private void objList_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.ListViewItem.Index == objList.Items.Count - 1)
            {
                if (string.IsNullOrWhiteSpace(e.NewValue.ToString()))
                {
                    return;
                }
                KeyWordMD obj = (KeyWordMD)objList.AddEmptyRow();
                int maxIdInDb = BusinessObject.GetBONextID(BOIDEnum.KeyWord);
                int maxIdOfUi = objList.Objects.Cast<KeyWordMD>().ToList().Max(x=>x.ID);
                obj.ID = Math.Max(maxIdInDb,maxIdOfUi) + 1;
            }
        }

        private void objList_CellEditValidating(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.ListViewItem.Index == objList.Items.Count - 1)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(e.NewValue.ToString()))
            {
                GetStatusBar().DisplayMessage(MessageType.Error, "关键字名称不能为空！");
                e.Cancel = true;
            }
        }
    }
}
