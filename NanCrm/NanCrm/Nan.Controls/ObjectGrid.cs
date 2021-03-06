﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Nan.BusinessObjects;
using System.Collections;

namespace Nan.Controls
{
    public partial class ObjectGrid : ObjectListView
    {

        private BOIDEnum m_boId;
        /// <summary>
        /// Business Object Id
        /// </summary>
        public BOIDEnum BOID
        {
            get { return m_boId; }
            set { m_boId = value; }
        }

        private bool m_showRowNumber;
        public bool ShowRowNumber
        {
            get { return m_showRowNumber; }
            set
            {
                if (m_showRowNumber != value)
                {
                    m_showRowNumber = value;
                    InitRowNumberColumn();
                }
            }
        }

        private ContextMenuStrip m_contxtMenu;
        public ContextMenuStrip SysContextMenu
        {
            get { return m_contxtMenu; }
            set
            {
                m_contxtMenu = value;
                
            }
        }
        ToolStripMenuItem m_tsmAddRow;
        ToolStripMenuItem m_tsmDelRow;
        private bool m_showSysMenu;
        public bool ShowSysMenu
        {
            get { return m_showSysMenu; }
            set 
            { 
                m_showSysMenu = value;
                if (m_showSysMenu)
                {
                    base.ContextMenuStrip = SysContextMenu;
                    m_tsmAddRow.Visible = ShowAddRowMenu;
                    m_tsmDelRow.Visible = ShowDeleteRowMenu;
                }
                else
                {
                    base.ContextMenuStrip = null;
                }
            }
        }
        private bool m_showAddRowMenu;
        public bool ShowAddRowMenu
        {
            get { return m_showAddRowMenu; }
            set
            {
                m_showAddRowMenu = value;
                m_tsmAddRow.Visible = value;
            }
        }
        private bool m_showDelRowMenu;
        public bool ShowDeleteRowMenu
        {
            get { return m_showDelRowMenu; }
            set
            {
                m_showDelRowMenu = value;
                m_tsmDelRow.Visible = value;
            }
        }

        public ObjectGrid()
        {
            InitializeComponent();
            this.FullRowSelect = true;
            this.GridLines = true;
            this.HideSelection = false;
            this.View = View.Details;
            this.UseAlternatingBackColors = true;
            this.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ShowGroups = false;
            
            ShowRowNumber = true;

            InitSysMenu();
        }

        private void InitSysMenu()
        {
            if (m_contxtMenu == null)
            {
                m_contxtMenu = new ContextMenuStrip();
            }
            m_tsmAddRow = new ToolStripMenuItem();
            m_tsmAddRow.Name = "sys_tsmAddRow";
            m_tsmAddRow.Text = "添加";
            m_tsmAddRow.Click += new System.EventHandler(this.sys_tsmAddRow_Click);
            m_contxtMenu.Items.Add(m_tsmAddRow);

            m_tsmDelRow = new ToolStripMenuItem();
            m_tsmDelRow.Name = "sys_tsmDelRow";
            m_tsmDelRow.Text = "删除";
            m_tsmDelRow.Click += new System.EventHandler(this.sys_tsmDelRow_Click);
            m_contxtMenu.Items.Add(m_tsmDelRow);
        }
        protected void InitRowNumberColumn()
        {
            if (m_showRowNumber)
            {
                OLVColumn olvCol = new OLVColumn();
                olvCol.Groupable = false;
                olvCol.Text = "#";
                olvCol.IsRowNumberColumn = true;
                olvCol.IsEditable = false;
                olvCol.Sortable = false;
                olvCol.Width = 40;
                this.AllColumns.Insert(0, olvCol);
                this.Columns.Insert(0, olvCol);
                this.RebuildColumns();
            }
            else
            {
                if (this.AllColumns.Count > 0)
                {
                    OLVColumn col = (OLVColumn)this.AllColumns[0];
                    if (col.IsRowNumberColumn)
                    {
                        this.AllColumns.RemoveAt(0);
                        this.Columns.RemoveAt(0);
                        this.RebuildColumns();
                    }
                }
            }
            this.Invalidate();
        }

        public override void Sort(OLVColumn columnToSort, SortOrder order)
        {
            base.Sort(columnToSort, order);
            if (!m_showRowNumber)
            {
                return;
            }
//             for (int i = 0; i < this.Items.Count; i++)
//             {
//                 OLVListItem item = (OLVListItem)this.Items[i];
//                 
//                 //OLVListSubItem subItem = (OLVListSubItem)this.Items[0].SubItems[0];
//                 item.SubItems[0].Text = (i + 1).ToString();
//             }
        }
        public event DeleRowNoColumnClick RowNumberDblClick;
        protected override bool ProcessLButtonDoubleClick(OlvListViewHitTestInfo hti)
        {
            if (hti.HitTestLocation == HitTestLocation.CheckBox)
            {
                return true;
            }
            if (hti.Column == null || !hti.Column.IsRowNumberColumn || hti.Item == null || hti.Item.Index < 0)
            {
                return true;
            }
            if (RowNumberDblClick != null)
            {
                RowNumberDblClick(hti);
            }
            return true;
        }

        protected override Control GetCellEditor(OLVListItem item, int subItemIndex)
        {
            OLVColumn col = GetColumn(subItemIndex);
            if(!col.EditAsCombBox)
            {
                return base.GetCellEditor(item,subItemIndex);
            }
            ComboBoxEx cb = new ComboBoxEx();
            cb.DataSource = col.DataSource;
            cb.DisplayMember = "Description";
            cb.ValueMember = "Value";

            return cb;
        }
        public event DeleContextMenuClick AddRowMenuClick;
        public event DeleContextMenuClick DeleteRowMenuClick;
        private void sys_tsmDelRow_Click(object sender, EventArgs e)
        {
            if (LastHitInfo.RowObject == EmptyObject)
            {
                return;
            }

            if (base.SelectedObjects != null)
            {
                base.RemoveObjects(base.SelectedObjects);
            }
            else if (base.SelectedObject != null)
            {
                base.RemoveObject(base.SelectedObject);
            }
            else if (base.LastHitInfo.RowObject != null)
            {
                base.RemoveObject(base.LastHitInfo.RowObject);
            }
            

            if (DeleteRowMenuClick != null)
            {
                OLVContextMenuClickArgs args = new OLVContextMenuClickArgs(base.LastHitInfo);
                DeleteRowMenuClick(sender, args);
            }
        }
        private void sys_tsmAddRow_Click(object sender, EventArgs e)
        {
            if (AddRowMenuClick != null)
            {
                OLVContextMenuClickArgs args = new OLVContextMenuClickArgs(base.LastHitInfo);
                AddRowMenuClick(sender, args);
            }
        }
        //private Type m_dataSourceType;
        //public Type DataSourceType
        //{
        //    get { return m_dataSourceType; }
        //    set { m_dataSourceType = value; }
        //}
        //private Dictionary<object, bool> m_isEmptyRowMap;
        //public Dictionary<object, bool> EmptyRowMap
        //{
        //    get 
        //    {
        //        if (m_isEmptyRowMap == null)
        //        {
        //            m_isEmptyRowMap = new Dictionary<object, bool>();
        //        }
        //        return m_isEmptyRowMap;
        //    }
        //}
        //private object m_emptyObject;
        //public object EmptyObject
        //{
        //    get { return m_emptyObject; }
        //    set { m_emptyObject = value; }
        //}
        //public object AddEmptyRow()
        //{
        //    if (this.DataSourceType == null)
        //        return null;
        //    if (EmptyObject != null)
        //    {
        //        return EmptyObject;
        //    }
        //    object newObj = Activator.CreateInstance(this.DataSourceType);
        //    if (newObj == null)
        //        return null;
        //    base.AddObject(newObj);
        //    //var method = newObj.GetType().GetMethod("Init");
        //    //method.Invoke(newObj,null);
        //    EmptyObject = newObj;
        //    return newObj;

        //}
        public bool IsEmptyRow(int rowIndex)
        {
            IList list = (IList)base.Objects;
            return IsEmptyRow(list[rowIndex]);
        }
        public bool IsEmptyRow(object rowObject)
        {
            return EmptyObject == rowObject;
        }
    }

    public delegate void DeleRowNoColumnClick(OlvListViewHitTestInfo hti);
    public delegate void DeleContextMenuClick(object sender, OLVContextMenuClickArgs args);
    public class OLVContextMenuClickArgs : EventArgs
    {
        public OlvListViewHitTestInfo HitInfo { get; set; }
        public OLVContextMenuClickArgs(OlvListViewHitTestInfo hitInfo)
        {
            HitInfo = hitInfo;
        }
    }
}
