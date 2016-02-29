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
                    this.SetBOTable(inMd.GetOrignalMD());
                }
                if (ExchangeParam.ReturnProc != null)
                {
                    this.ReturnProc = ExchangeParam.ReturnProc;
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
                e.Handled = true;
            }
        }

        private void KeyWordRetProc(Form form, object data)
        {
            IList list = (IList)data;
            if(list == null || list.Count <= 0)
                return;
            List<KeyWordMD> existList = objList.Objects.Cast<KeyWordMD>().ToList();
            List<KeyWordMD> validList = new List<KeyWordMD>();
            List<KeyWordMD> kwList = Utilities.ConvertList<KeyWordMD>(list);
            foreach (var item in kwList)
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
                validList.RemoveAt(0);
                //objList.RemoveObject(objList.LastHitInfo.RowObject);
                objList.InsertObjects(objList.LastHitInfo.RowIndex, validList);
                //existList[objList.LastHitInfo.RowIndex] = validList[0];
                //existList.InsertRange(objList.SelectedIndex, validList);
                //objList.SetObjects(existList);
            }
        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            if (this.FormMode == NanCrm.FormMode.Ok)
                return true;
            if (!ValidateData())
                return false;
            UpdateData(true);
            BOKWList bo = (BOKWList)m_bo;
            KWListMD tb = (KWListMD)bo.GetBOTable();
            tb.KeyWrodIds = objList.Objects.Cast<KeyWordMD>().Select(x=>x.ID).Where(x=>x>0).ToList();
            return m_bo.Update();
        }
        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                return false;
            }
            IList list = (IList)objList.Objects;
            if (list.Count < 2)
                return false;

            return true;
        }

        private void objList_CellEditValidating(object sender, CellEditEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewValue.ToString()))
            {
                if (e.ListViewItem.Index == objList.Items.Count - 1)
                    return;
                if (e.ListViewItem.Index < objList.Items.Count - 1)
                {
                    GetStatusBar().DisplayMessage(MessageType.Error,"关键字不能为空！");
                    e.Cancel=true;
                    return;
                }
            }
            KeyWordMD md = objList.Objects.Cast<KeyWordMD>().ToList().Find(x=>x.Name == e.NewValue.ToString());
            if(md != null && e.ListViewItem.Index != objList.ModelToItem(md).Index)
            {
                GetStatusBar().DisplayMessage(MessageType.Warming,"关键字 \""+e.NewValue.ToString()+"\" 已存在！");
                e.Cancel=true;
                return;
            }
        }

        private void objList_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.ListViewItem.Index == objList.Items.Count - 1 && !string.IsNullOrWhiteSpace(e.NewValue.ToString()))
            {
                KeyWordMD obj = (KeyWordMD)objList.AddEmptyRow();
                int maxIdInDb = BusinessObject.GetBONextID(BOIDEnum.KeyWord);
                int maxIdOfUi = objList.Objects.Cast<KeyWordMD>().ToList().Max(x => x.ID);
                obj.ID = Math.Max(maxIdInDb, maxIdOfUi) + 1;
            }
            
        }
    }
}
