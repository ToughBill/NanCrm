using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nan.Controls;
using Nan.BusinessObjects;

namespace NanCrm.Product
{
    public partial class frmProduct : FormEx
    {
        public frmProduct(BOIDEnum boId)
            : base(boId)
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadData()
        {

        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            return  SaveData();
        }
    }
}
