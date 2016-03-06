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
using System.Collections;
using NanCrm.Global;
using BrightIdeasSoftware;
using Nan.Controls;

namespace NanCrm.Setup
{
    public partial class frmProductGroup : FormBase
    {
        private BOProductGroup m_proGrpBo;
        public frmProductGroup()
        {
            InitializeComponent();
        }

        private void frmProductGroup_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void LoadGridData()
        {
            try
            {
                m_proGrpBo = (BOProductGroup)BOFactory.GetBO(BOIDEnum.ProductGroup);
                IList list = m_proGrpBo.GetDataList();
                List<ProductGroupMD> listObj = Utilities.ConvertList<ProductGroupMD>(list);

                //ProductGroupMD newBo = new ProductGroupMD();
                //newBo.ID = BusinessObject.GetBONextID(BOIDEnum.ProductGroup);
                //listObj.Add(newBo);
                objList.SetObjects(listObj);
                objList.DataSourceType = typeof(ProductGroupMD);
                ProductGroupMD newObj = (ProductGroupMD)objList.AddEmptyRow();
                newObj.ID = BusinessObject.GetBONextID(BOIDEnum.ProductGroup);
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
            if (!ValidateFormData())
            {
                return false;
            }
            IList listObj = (IList)objList.Objects;
            RemoveEmptyRows(listObj);
            m_proGrpBo.SetDataList(listObj, objList.RemovedObjects);

            return m_proGrpBo.UpdateBatch();
        }

        private bool ValidateFormData()
        {
            bool result = true;
            OLVListItem item = objList.GetNextItem(null);
            while (item != null)
            {
                ProductGroupMD pg = (ProductGroupMD)item.RowObject;
                if (string.IsNullOrEmpty(pg.Name) && !objList.IsEmptyRow(item.RowObject))
                {
                    GetStatusBar().DisplayMessage(MessageType.Error,"分组名称不能为空！");
                    result = false;
                    break;
                }
                item = objList.GetNextItem(item);
            }
            return result;
        }

        private void RemoveEmptyRows(IList list)
        {
            ProductGroupMD proGrp = (ProductGroupMD)list[list.Count - 1];
            if (string.IsNullOrEmpty(proGrp.Name) && objList.IsEmptyRow(list.Count - 1))
                list.RemoveAt(list.Count - 1);
        }

        private void objList_CellEditValidating(object sender, CellEditEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewValue.ToString()))
            {
                if (e.ListViewItem.Index != objList.Items.Count - 1)
                {
                    GetStatusBar().DisplayMessage(MessageType.Error, "分组名称不能为空！");
                    e.Cancel = true;
                }
            }
            else
            {
                var find = objList.Objects.Cast<ProductGroupMD>().ToList().Find(x => x.Name == e.NewValue.ToString());
                if (find != null && objList.ModelToItem(find).Index != e.ListViewItem.Index)
                {
                    GetStatusBar().DisplayMessage(MessageType.Error, "分组 \"" + e.NewValue.ToString() + "\" 已存在！");
                    e.Cancel = true;
                }
            }
        }

        private void objList_CellClick(object sender, CellClickEventArgs e)
        {
            ProductGroupMD pg = (ProductGroupMD)e.HitTest.RowObject;
            if (pg!=null && !(e.HitTest.ColumnIndex == 1 || e.HitTest.ColumnIndex == 0) && string.IsNullOrWhiteSpace(pg.Name))
            {
                GetStatusBar().DisplayMessage(MessageType.Error, "分组名称不能为空！");
                objList.EditSubItem(objList.GetItem(e.RowIndex), 1);
            }
        }
    }
}
