using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nan.BusinessObjects;
using Nan.BusinessObjects.BO;
using System.Collections;
using System.Reflection;
using NanCrm.Global;

namespace NanCrm
{
    public partial class frmCFL : FormBase
    {
        public frmCFL(BOIDEnum boid):base(boid)
        {
            InitializeComponent();
        }

        private void frmCFL_Load(object sender, EventArgs e)
        {
            LoadGrid();
            this.Text = BusinessObject.GetBOName(m_boId) + "列表";
        }

        private void LoadGrid()
        {
            FillGridColumns();
            IList list = m_bo.GetDataList();
            if (list.Count <= 0)
                return;
            objList.SetObjects(list);


        }
        private void FillGridColumns()
        {
            PropertyInfo[] properoties = m_bo.GetBOTable().GetType().GetProperties();
            int disIdx = 0;
            foreach (PropertyInfo info in properoties)
            {
                object[] attr = info.GetCustomAttributes(false);
                if (attr.Length <= 0)
                    continue;
                BOFieldAttribute fieldAttr = (BOFieldAttribute)attr[0];
                if (!fieldAttr.CFL)
                    continue;

                BrightIdeasSoftware.OLVColumn col = new BrightIdeasSoftware.OLVColumn();
                col.AspectName = info.Name;
                col.DisplayIndex = disIdx++;
                col.Groupable = false;
                col.IsRowNumberColumn = false;
                col.Text = fieldAttr.Desc;
                objList.AllColumns.Add(col);
            }

            objList.RebuildColumns();
        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            if (objList.SelectedObjects.Count <= 0)
            {
                return true;
            }
            //if(ReturnProc!=null)
            //{
            //    ReturnProc(this, objList.SelectedObjects);
            //}
            return true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormManager.DisplayForm(m_boId, "", FormMode.Add, true);
        }

        protected override object BuildReturnParams()
        {
            return objList.SelectedObjects;
        }
    }
}
