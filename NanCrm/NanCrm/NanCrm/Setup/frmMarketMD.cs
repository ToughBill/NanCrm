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
using NanCrm.Global;
using Nan.Controls;
using Newtonsoft.Json.Linq;

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
            m_ctyList = new List<CountryMD>();
            InitCountryGrid();
        }

        private void InitCountryGrid()
        {
            BOMarket mktBo = (BOMarket)m_bo;
            if (base.FormMode == NanCrm.FormMode.Add)
            {
                mktBo.Init();
            }
            UpdateData(false);
            objList.DataSourceType = typeof(CountryMD);
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
            MarketMD mkt = (MarketMD)mktBo.GetBOTable();
            foreach (int id in mkt.CountryIds)
            {
                BOCountry ctyBo = new BOCountry();
                ctyBo.GetById(id);
                m_ctyList.Add((CountryMD)ctyBo.GetBOTable());
            }
            CountryMD cty = new CountryMD();
            cty.ID = -1;
            m_ctyList.Add(cty);
            objList.SetObjects(m_ctyList);
        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            UpdateData(true);
            IList list = (IList)objList.Objects;
            List<int> cties = list.Cast<CountryMD>().Select(x=>x.ID).ToList();
            cties = cties.Where(x => x > 0).ToList();
            MarketMD mkt = (MarketMD)m_bo.GetBOTable();
            mkt.CountryIds = cties;

            return m_bo.Add();
        }

        private void objList_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.Column == null)
                return;

            if(e.HitTest.RowIndex == objList.Items.Count - 1 && e.ColumnIndex != 1 && e.ColumnIndex != 0)
            {
                CountryMD cty = (CountryMD)e.HitTest.RowObject;
                if (string.IsNullOrWhiteSpace(cty.Name))
                {
                    GetStatusBar().DisplayMessage(MessageType.Error, "国家名字不能为空！");
                    objList.EditSubItem(objList.GetItem(e.RowIndex), 1);
                    return;
                }
            }
            if(e.ColumnIndex==1 && e.HitTest.HitTestLocation == HitTestLocation.Image)
            {
                frmCFL cfl = new frmCFL(objList.BOID);
                cfl.ReturnProc = CountryRetProc;
                cfl.MdiParent = this.MdiParent;
                cfl.Show();
            }
            
        }

        private void CountryRetProc(Form form, object data)
        {
            IList list = (IList)data;
            if (list == null || list.Count <= 0)
                return;
            List<CountryMD> existList = objList.Objects.Cast<CountryMD>().ToList();
            List<CountryMD> validList = new List<CountryMD>();
            List<CountryMD> ctyList = Utilities.ConvertList<CountryMD>(list);
            foreach (var item in ctyList)
            {
                if (existList.Find(x => x.ID == item.ID) == null)
                {
                    validList.Add(item);
                }
            }
            if (validList.Count <= 0)
                return;
            if (objList.LastHitInfo.RowIndex == objList.Items.Count - 1)
            {
                objList.InsertObjects(objList.SelectedIndex, validList);
            }
            else
            {
                OLVListItem olv = objList.GetItem(objList.LastHitInfo.RowIndex);
                olv.RowObject = validList[0];
                objList.RefreshItem(olv);
                validList.RemoveAt(0);
                if(validList.Count > 0)
                {
                    objList.InsertObjects(objList.LastHitInfo.RowIndex, validList);
                }
            }
        }

        private void objList_CellEditValidating(object sender, CellEditEventArgs e)
        {
            if (e.ListViewItem.Index != objList.Items.Count - 1 && e.SubItemIndex ==1 && string.IsNullOrWhiteSpace(e.NewValue.ToString()))
            {
                GetStatusBar().DisplayMessage(MessageType.Error, "国家名字不能为空！");
                e.Cancel = true;
            }
            if(e.SubItemIndex == 1 && !string.IsNullOrWhiteSpace(e.NewValue.ToString()))
            {
                if (IsCountryNameExist(e.NewValue.ToString(), e.ListViewItem.Index))
                {
                    GetStatusBar().DisplayMessage(MessageType.Error, "国家 \"" + e.NewValue.ToString() + "\" 已存在！");
                    e.Cancel = true;
                }
                else if (!IsValidCountryName(e.NewValue.ToString()))
                {
                    GetStatusBar().DisplayMessage(MessageType.Error, "国家 \"" + e.NewValue.ToString() + "\" 不存在！");
                    e.Cancel = true;
                }
            }

            //if (e.ListViewItem.Index == objList.Items.Count - 1)
            //{
            //    if (!string.IsNullOrWhiteSpace(e.NewValue.ToString()))
            //    {
            //        if (IsCountryNameExist(e.NewValue.ToString(), e.ListViewItem.Index))
            //        {
            //            GetStatusBar().DisplayMessage(MessageType.Error, "国家 \"" + e.NewValue.ToString() + "\" 已存在！");
            //            e.Cancel = true;
            //        }
            //        else if (IsValidCountryName(e.NewValue.ToString()))
            //        {
            //            GetStatusBar().DisplayMessage(MessageType.Error, "国家 \"" + e.NewValue.ToString() + "\" 不存在！");
            //            e.Cancel = true;
            //        }
            //    }
            //}
            //else
            //{
            //    if (e.SubItemIndex == 1)
            //    {
            //        if (string.IsNullOrWhiteSpace(e.NewValue.ToString()))
            //        {
            //            GetStatusBar().DisplayMessage(MessageType.Error, "国家名字不能为空！");
            //            e.Cancel = true;
            //        }
            //        else if (IsCountryNameExist(e.NewValue.ToString(), e.ListViewItem.Index))
            //        {
            //            GetStatusBar().DisplayMessage(MessageType.Error, "国家 \"" + e.NewValue.ToString() + "\" 已存在！");
            //            e.Cancel = true;
            //        }
            //    }
            //}
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
        private bool IsValidCountryName(string name)
        {
            BOCountry ctyBo = new BOCountry();
            
            IList list = ctyBo.GetDataList();
            var find = list.Cast<JObject>().ToList().Find(x => x.ConvertToTarget<CountryMD>().Name == name);
            if(find == null)
            {
                return false;
            }
            return true;
        }
        private void objList_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.ListViewItem.Index == objList.Items.Count - 1)
            {
                if (e.Cancel || string.IsNullOrWhiteSpace(e.NewValue.ToString()))
                {
                    return;
                }
                BOCountry bo = new BOCountry();
                bo.GetByName(e.NewValue.ToString());
                //objList.GetItem(e.ListViewItem.Index).RowObject = bo.GetBOTable();
                //e.ListViewItem.RowObject = (CountryMD)bo.GetBOTable();
                CountryMD old = (CountryMD)e.ListViewItem.RowObject;
                old.CopyFrom(bo.GetBOTable());
                //objList.RefreshItem(e.ListViewItem);


                CountryMD obj = (CountryMD)objList.AddEmptyRow();
                int maxIdInDb = BusinessObject.GetBONextID(BOIDEnum.Country);
                int maxIdOfUi = objList.Objects.Cast<CountryMD>().ToList().Max(x => x.ID);
                obj.ID = Math.Max(maxIdInDb, maxIdOfUi) + 1;
            }
        }
    }
}
