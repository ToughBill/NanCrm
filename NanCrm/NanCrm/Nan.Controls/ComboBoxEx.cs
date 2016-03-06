using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nan.BusinessObjects;
using Nan.BusinessObjects.BO;

namespace Nan.Controls
{
    public partial class ComboBoxEx : ComboBox
    {
        public ComboBoxEx()
        {
            InitializeComponent();
            m_vv = new List<ValidValue>();
        }

        public BOIDEnum BOID { get; set; }
        public string BOField { get; set; }

        public BOIDEnum DataSourceBO { get; set; }
        public string DesField { get; set; }
        public string KeyField { get; set; }

        public bool AddEmptyRow { get; set; }
        public bool AddDefineNew { get; set; }
        public DeleDefineNewProc DefineNewProc{get;set;}

        //public new string SelectedValue
        //{
        //    get
        //    {
        //        if(AddEmptyRow && base.SelectedIndex == 0)
        //        {
        //            return string.Empty;
        //        }
        //        else
        //        {
        //            return base.SelectedValue.ToString();
        //        }
        //    }
        //    set
        //    {
        //        if (AddEmptyRow && string.IsNullOrWhiteSpace(value))
        //        {
        //            base.SelectedValue = "-1";
        //        }
        //        else
        //        {
        //            base.SelectedValue = value;
        //        }
        //    }
        //}

        private List<ValidValue> m_vv;

        public void InitSource()
        {
            if (DataSourceBO == BOIDEnum.Invalid)
            {
                return;
            }
            BusinessObject bo = BOFactory.GetBO(DataSourceBO);
            m_vv = bo.GetValieValue(KeyField, DesField);
            if (AddEmptyRow)
            {
                m_vv.Insert(0, new ValidValue("-1", ""));
            }
            if (AddDefineNew)
            {
                m_vv.Insert(m_vv.Count, new ValidValue("999999", "---添加新项---"));
            }
            this.DataSource = m_vv;
            this.ValueMember = "Value";
            this.DisplayMember = "Description";
        }

        private int m_prevSelectedIndex = -1;
        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            if (!AddDefineNew)
            {
                return;
            }

            if (this.SelectedIndex == m_vv.Count - 1)
            {
                if (DefineNewProc != null)
                {
                    DefineNewProc(this, DefineNewReturnProc);
                }
                this.SelectedIndex = m_prevSelectedIndex;
            }
            m_prevSelectedIndex = this.SelectedIndex;
        }
//         protected override void OnSelectedIndexChanged(EventArgs e)
//         {
//             m_prevSelectedIndex = this.SelectedIndex;
//             if (!AddDefineNew)
//             {
//                 base.OnSelectedIndexChanged(e);
//                 return;
//             }
//             if (SelectedIndex == m_vv.Count-1)
//             {
//                 //BusinessObject.DisplayBo(DataSourceBO);
//                 if (DefineNewProc != null)
//                 {
//                     DefineNewProc(this, DefineNewReturnProc);
//                 }
//             }
//             base.OnSelectedIndexChanged(e);
//             
//         }

        protected virtual void DefineNewReturnProc(Form form, object data)
        {
            InitSource();
        }
    }
    public delegate void DeleReturnProc(Form form, object data);
    public delegate void DeleDefineNewProc(object sender, DeleReturnProc retProc);
}
