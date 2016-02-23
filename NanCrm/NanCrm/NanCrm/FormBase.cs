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
using Nan.Controls;
using NanCrm.Global;

namespace NanCrm
{
    public partial class FormBase : Form
    {
        protected BOIDEnum m_boId;
        public BOIDEnum BOID
        {
            get { return m_boId; }
            set { m_boId = value; }
        }
        protected BusinessObject m_bo;
        public BusinessObject BO
        {
            get { return m_bo; }
            set { m_bo = value; }
        }

        private FormMode m_formMode;
        public FormMode FormMode
        {
            get { return m_formMode; }
            set 
            { 
                if (m_formMode != value)
                {
                    FormMode oldMode = m_formMode;
                    m_formMode = value;
                    ModeChange(oldMode, m_formMode);
                }
                
            }
        }

        protected FormExchangeParams m_exchParam;
        public FormExchangeParams ExchangeParam
        {
            get { return m_exchParam; }
            set { m_exchParam = value; }
        }

        private bool m_needCallRetProc;
        public DeleReturnProc UpdateProc;
        public DeleReturnProc ReturnProc;

        public FormBase()
        {
            InitializeComponent();
            m_boId = BOIDEnum.Invalid;
            m_bo = null;
            m_formMode = FormMode.Ok;
            m_needCallRetProc = true;
        }

        public FormBase(BOIDEnum boId)
        {
            InitializeComponent();
            m_boId = boId;
            m_bo = BOFactory.GetBO(m_boId);
            m_formMode = FormMode.Ok;
            m_needCallRetProc = true;
        }

        private string m_tableSource;
        public string TableSource
        {
            get { return m_tableSource; }
            set
            {
                m_tableSource = value;
                ChangeComponentSource();
            }
        }

        protected void ChangeComponentSource()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ComboBoxEx)
                {
                    ComboBoxEx comb = (ComboBoxEx)ctrl;
                    comb.BOID = m_boId;
                }
                else if (ctrl is TextBoxEx)
                {
                    TextBoxEx txt = (TextBoxEx)ctrl;
                    txt.TableSource = m_tableSource;
                }
                else if (ctrl is RichTextBoxEx)
                {
                    RichTextBoxEx richTxt = (RichTextBoxEx)ctrl;
                    richTxt.BOID = m_boId;
                }
            }
        }
        public event DeleFormModeChange OnModeChange;
        protected virtual void ModeChange(FormMode oldMode,FormMode newMode) 
        {
            switch (newMode)
            {
                case NanCrm.FormMode.Add:
                    btnOk.Text = "添加";
                    break;
                case NanCrm.FormMode.Find:
                    btnOk.Text = "查找";
                    break;
                case NanCrm.FormMode.Ok:
                    btnOk.Text = "确定";
                    break;
                case NanCrm.FormMode.Update:
                    btnOk.Text = "更新";
                    break;
                default: break;
            }
            FormModeChangeArgs args = new FormModeChangeArgs(oldMode, newMode);
            if (OnModeChange != null)
            {
                OnModeChange(args);
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ComboBoxEx)
                {
                    ComboBoxEx comb = (ComboBoxEx)ctrl;
                    comb.DefineNewProc = new DeleDefineNewProc(ComboBoxDefineNewProc);
                    comb.InitSource();
                }
            }

            base.OnLoad(e);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ObjectGrid)
                {
                    ObjectGrid objGrid = (ObjectGrid)ctrl;
                    objGrid.ItemsChanged += new EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(objGrid_ItemsChanged);
                }
                else if (ctrl is ComboBoxEx)
                {
                    ComboBoxEx comb = (ComboBoxEx)ctrl;
                    comb.SelectedValueChanged += new EventHandler(comb_SelectedIndexChanged);
                }
                else if (ctrl is TextBoxEx)
                {
                    TextBoxEx txt = (TextBoxEx)ctrl;
                    txt.TextChanged += new EventHandler(txt_TextChanged);
                }
                else if (ctrl is RichTextBoxEx)
                {
                    RichTextBoxEx rtxt = (RichTextBoxEx)ctrl;
                    rtxt.TextChanged += new EventHandler(rtxt_TextChanged);
                }
            }
        }

        private void comb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeInternal();
        }
        private void txt_TextChanged(object sender, EventArgs e)
        {
            ChangeInternal();
        }
        private void rtxt_TextChanged(object sender, EventArgs e)
        {
            ChangeInternal();
        }
        private void ChangeInternal()
        {
            if (this.FormMode == FormMode.Ok)
            {
                ModeChange(this.FormMode, FormMode.Update);
            }
        }
        private void objGrid_ItemsChanged(object sender, BrightIdeasSoftware.ItemsChangedEventArgs e)
        {
            //this.FormMode = NanCrm.FormMode.Update;
            ChangeInternal();
        }

        protected virtual void ComboBoxDefineNewProc(object sender, DeleReturnProc retProc)
        {
            ComboBoxEx comb = (ComboBoxEx)sender;
            FormManager.DisplayForm(comb.DataSourceBO, "", FormMode.Ok, false, retProc);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
//             if (m_formMode == NanCrm.FormMode.Ok)
//             {
//                 m_formMode = FormMode.Update;
//                 btnOk.Text = "更新";
//             }
            
            base.OnKeyDown(e);
        }

        protected virtual bool btnCancel_Clicked(object sender, ClickedEventArgs e)
        {
            m_needCallRetProc = false;
            this.Close();
            m_needCallRetProc = true;
            return true;
        }

        private bool btnOk_Clicked(object sender, ClickedEventArgs e)
        {
            if (m_formMode == FormMode.Ok)
            {
                this.Close();
                return true;
            }
            if (e.Result)
            {
                m_formMode = FormMode.Ok;
                btnOk.Text = "确定";
                if (UpdateProc != null)
                {
                    UpdateProc(this, BuildUpdateParams());
                }
            }
            else
            {

            }
            return true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (ReturnProc != null && m_needCallRetProc)
            {
                ReturnProc(this, BuildReturnParams());
            }
            base.OnFormClosing(e); 
        }

        protected virtual object BuildReturnParams()
        {
            return m_bo;
        }
        protected virtual object BuildUpdateParams()
        {
            return m_bo;
        }

        public virtual bool LoadDataById(int id)
        {
            bool ret = m_bo.GetById(id);
            if (!ret)
                return ret;
            return UpdateData(false);
        }

        public virtual void SetBOTable(object bo)
        {
            m_bo.SetBOTable(bo);
        }

        /// <summary>
        /// 更新数据后刷新BO或者Form
        /// true:将界面数据保存至BO; false:根据BO中的值刷新界面
        /// </summary>
        /// <param name="toForm">true:将界面数据保存至BO; false:根据BO中的值刷新界面</param>
        /// <returns></returns>
        public virtual bool UpdateData(bool saveData = true)
        {
            if (m_boId == BOIDEnum.Invalid)
                return true;

            bool result = true;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBoxEx)
                {
                    TextBoxEx txtBox = (TextBoxEx)ctrl;
                    if (txtBox.BOID == m_boId)
                    {
                        if (saveData)
                        {
                            result = SetFieldData(txtBox.BOField, txtBox.Text);
                        }
                        else
                        {
                            txtBox.Text = GetFieldData(txtBox.BOField).ToString();
                        }
                    }
                }
                else if (ctrl is ComboBoxEx)
                {
                    ComboBoxEx cmb = (ComboBoxEx)ctrl;
                    if (cmb.BOID == m_boId)
                    {
                        if (saveData)
                        {
                            result = SetFieldData(cmb.BOField, cmb.SelectedValue);
                        }
                        else
                        {
                            cmb.SelectedValue = GetFieldData(cmb.BOField).ToString();
                        }
                    }
                }
                else if (ctrl is RichTextBoxEx)
                {
                    RichTextBoxEx richTxt = (RichTextBoxEx)ctrl;
                    if (richTxt.BOID == m_boId)
                    {
                        if (saveData)
                        {
                            result = SetFieldData(richTxt.BOField, richTxt.Text);
                        }
                        else
                        {
                            richTxt.Text = GetFieldData(richTxt.BOField).ToString();
                        }
                    }
                }
                if (!result)
                    break;
            }
            return result;
        }

        private bool SetFieldData(string fieldName, object value)
        {
            bool result = true;
            object boTable = m_bo.GetBOTable();
            var properties = boTable.GetType().GetProperties();
            int i = 0;
            for (; i < properties.Length; i++)
            {
                if (properties[i].Name == fieldName)
                {
                    var proType = Nullable.GetUnderlyingType(properties[i].PropertyType) ?? properties[i].PropertyType;
                    if (proType.Equals(typeof(int)))
                    {
                        properties[i].SetValue(boTable, int.Parse(value.ToString()), null);
                        break;
                    }
                    else if (proType.Equals(typeof(DateTime)))
                    {
                        properties[i].SetValue(boTable, DateTime.Parse(value.ToString()), null);
                        break;
                    }
                    else
                    {
                        properties[i].SetValue(boTable, value.ToString(), null);
                        break;
                    }
                }
            }
            if (i == properties.Length)
            {
                result = false;
            }

            return result;
        }

        private object GetFieldData(string fieldName)
        {
            object result = null;
            object boTable = m_bo.GetBOTable();
            var properties = boTable.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].Name == fieldName)
                {
                    result = properties[i].GetValue(boTable, null);
                    break;
                }
            }

            return result;
        }

        public void SetFormExchangeParams(FormExchangeParams param)
        {
            m_exchParam = param;
        }

        public StatusBarEx GetStatusBar()
        {
            return FormManager.GetMainForm().GetStatusBar();
        } 
    }

    public class FormModeChangeArgs:EventArgs
    {
        public FormMode OldMode;
        public FormMode NewMode;

        public FormModeChangeArgs(FormMode old, FormMode newMode)
        {
            OldMode = old;
            NewMode = newMode;
        }
    }
    public delegate void DeleFormModeChange(FormModeChangeArgs args);
    public enum FormMode
    {
        Ok,
        Add,
        Update,
        Find
    }
    public class FormExchangeParams
    {
        public FormMode Mode;
        public object Data;
        public DeleReturnProc ReturnProc;
    }
}
