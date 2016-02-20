using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nan.Controls;
using BrightIdeasSoftware;
using Nan.BusinessObjects;
using Nan.BusinessObjects.BO;
using System.Collections;
using Newtonsoft.Json.Linq;
using NanCrm.Global;

namespace NanCrm.Setup
{
    public partial class frmCountry : FormBase
    {
        public frmCountry(BOIDEnum boId)
            : base(boId)
        {
            InitializeComponent();
        }

        private void Country_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        public void LoadGridData()
        {
            try
            {
                IList ctybos = m_bo.GetDataList();
                List<CountryMD> ctyList = Utilities.ConvertList<CountryMD>(ctybos);
                CountryMD newCty = new CountryMD();
                newCty.ID = BusinessObject.GetBONextID(m_boId);
                ctyList.Add(newCty);
                objList.SetObjects(ctyList);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            if (this.FormMode == FormMode.Ok)
            {
                return true;
            }
            IList obj = (IList)objList.Objects;
            BOCountry objCty = (BOCountry)m_bo;
            objCty.SetDataList(obj);
            return objCty.UpdateBatch();
        }

        private void objList_CellEditValidating(object sender, CellEditEventArgs e)
        {
            if (e.SubItemIndex != 1 || e.ListViewItem.Index == e.ListViewItem.ListView.Items.Count-1)
            {
                return;
            }
            if (string.IsNullOrEmpty((string)e.NewValue))
            {
                e.Cancel = true;
                MessageBox.Show("input error!");
            }
        }

        public static bool DisplayCountryBo(BOIDEnum boid, string key, bool isReport)
        {
            bool result = true;
            frmCountry frmCty = new frmCountry(boid);
            frmCty.MdiParent = FormManager.GetMainForm();
            frmCty.Show();

            return result;
        }
    }
}
