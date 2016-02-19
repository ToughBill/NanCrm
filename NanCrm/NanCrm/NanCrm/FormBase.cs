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

        public DeleReturnProc UpdateProc;

        public FormBase()
        {
            InitializeComponent();
            m_boId = BOIDEnum.Invalid;
            m_bo = null;
            m_formMode = FormMode.Ok;
        }

        public FormBase(BOIDEnum boId)
        {
            InitializeComponent();
            m_boId = boId;
            m_bo = BOFactory.GetBO(m_boId);
            m_formMode = FormMode.Ok;
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
            }
        }
        public event DeleFormModeChange OnModeChange;
        protected virtual void ModeChange(FormMode oldMode,FormMode newMode) 
        {
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
        }

        protected virtual void ComboBoxDefineNewProc(object sender, DeleReturnProc retProc)
        {
            ComboBoxEx comb = (ComboBoxEx)sender;
            FormManager.DisplayForm(comb.DataSourceBO, "", FormMode.Ok, false, retProc);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            m_formMode = FormMode.Update;
            btnOk.Text = "更新";
            base.OnKeyDown(e);
        }

        protected virtual bool btnCancel_Clicked(object sender, ClickedEventArgs e)
        {
            this.Close();
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
                    UpdateProc(this, null);
                }
            }
            else
            {

            }
            return true;
        }
        protected virtual bool SaveData()
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
                        result = SetFieldData(txtBox.BOField, txtBox.Text);
                    }
                }
                else if (ctrl is ComboBoxEx)
                {
                    ComboBoxEx cmb = (ComboBoxEx)ctrl;
                    if (cmb.BOID == m_boId)
                    {
                        result = SetFieldData(cmb.BOField, cmb.SelectedValue);
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
}
