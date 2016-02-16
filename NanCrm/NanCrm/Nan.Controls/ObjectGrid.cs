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

        public ObjectGrid()
        {
            InitializeComponent();
            this.FullRowSelect = true;
            this.GridLines = true;
            this.HideSelection = false;
            this.View = View.Details;
            this.UseAlternatingBackColors = true;

            ShowRowNumber = true;
        }

        protected void InitRowNumberColumn()
        {
            if (m_showRowNumber)
            {
                OLVColumn olvCol = new OLVColumn();
                olvCol.Groupable = false;
                olvCol.Text = "#";
                olvCol.IsRowNumberColumn = true;
                this.Columns.Insert(0, olvCol);
            }
            else
            {
                if (this.Columns.Count > 0)
                {
                    OLVColumn col = (OLVColumn)this.Columns[0];
                    if (col.IsRowNumberColumn)
                    {
                        this.Columns.RemoveAt(0);
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
    }
}
