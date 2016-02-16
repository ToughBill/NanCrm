using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nan.Controls;
using Nan.BusinessObjects.BO;
using Nan.BusinessObjects;
using NanCrm.Global;

namespace NanCrm.Setup
{
    public partial class frmTexture : FormEx
    {
        public frmTexture(BOIDEnum boId)
            : base(boId)
        {
            InitializeComponent();
        }

        private void frmTexture_Load(object sender, EventArgs e)
        {
            BOTexture.DisplayFuncInit(DisplayTextureBo);
        }

        public bool DisplayTextureBo(BOIDEnum boid, string key, bool isReport)
        {
            bool result = true;
            frmTexture frmCty = new frmTexture(boid);
            frmCty.MdiParent = FormManager.GetMainForm();
            frmCty.Show();

            return result;
        }

    }
}
