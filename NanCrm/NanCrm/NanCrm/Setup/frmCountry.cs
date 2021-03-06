﻿using System;
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
                objList.DataSourceType = typeof(CountryMD);
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
            objCty.SetDataList(obj.Cast<CountryMD>().Where(x=>x.ID>0 && !string.IsNullOrWhiteSpace(x.Name)).ToList(), objList.RemovedObjects);
            return objCty.UpdateBatch();
        }

        private void objList_CellEditValidating(object sender, CellEditEventArgs e)
        {
            if(e.ListViewItem.Index == objList.Items.Count - 1)
            {
                if(!string.IsNullOrWhiteSpace(e.NewValue.ToString()))
                {
                    if (IsCountryNameExist(e.NewValue.ToString(), e.ListViewItem.Index))
                    {
                        GetStatusBar().DisplayMessage(MessageType.Error, "国家 \"" + e.NewValue.ToString() + "\" 已存在！");
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                if(e.SubItemIndex == 1)
                {
                    if(string.IsNullOrWhiteSpace(e.NewValue.ToString()))
                    {
                        GetStatusBar().DisplayMessage(MessageType.Error, "国家名字不能为空！");
                        e.Cancel = true;
                    }
                    else if (IsCountryNameExist(e.NewValue.ToString(), e.ListViewItem.Index))
                    {
                        GetStatusBar().DisplayMessage(MessageType.Error, "国家 \"" + e.NewValue.ToString() + "\" 已存在！");
                        e.Cancel = true;
                    }
                }
            }
        }
        private bool IsCountryNameExist(string name, int curRowIndex)
        {
            var find = objList.Objects.Cast<CountryMD>().ToList().Find(x => x.Name == name);
            if (find != null && objList.ModelToItem(find).Index != curRowIndex)
            {
                return true;
            }
            return false;
        }
        public static bool DisplayCountryBo(BOIDEnum boid, string key, bool isReport)
        {
            bool result = true;
            frmCountry frmCty = new frmCountry(boid);
            frmCty.MdiParent = FormManager.GetMainForm();
            frmCty.Show();

            return result;
        }

        private void objList_CellClick(object sender, CellClickEventArgs e)
        {
            CountryMD cty = (CountryMD)e.HitTest.RowObject;
            if (cty != null && e.HitTest.ColumnIndex != 1 && string.IsNullOrWhiteSpace(cty.Name))
            {
                GetStatusBar().DisplayMessage(MessageType.Error, "国家名字不能为空！");
                objList.EditSubItem(objList.GetItem(e.RowIndex), 1);
            }
        }

        private void objList_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.ListViewItem.Index == objList.Items.Count - 1)
            {
                if (string.IsNullOrWhiteSpace(e.NewValue.ToString()))
                {
                    return;
                }
                CountryMD obj = (CountryMD)objList.AddEmptyRow();
                int maxIdInDb = BusinessObject.GetBONextID(BOIDEnum.Country);
                int maxIdOfUi = objList.Objects.Cast<CountryMD>().ToList().Max(x => x.ID);
                obj.ID = Math.Max(maxIdInDb, maxIdOfUi) + 1;
            }
        }
    }
}
