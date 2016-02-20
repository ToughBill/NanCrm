using System;
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
                    m_tsmAddRow.Visible = true;
                    m_tsmDelRow.Visible = true;
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
        public event DeleContextMenuClick AddRowMenuClick;
        public event DeleContextMenuClick DeleteRowMenuClick;
        private void sys_tsmDelRow_Click(object sender, EventArgs e)
        {
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
