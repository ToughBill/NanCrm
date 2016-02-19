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
using System.Collections;

namespace NanCrm.Setup
{
    public partial class frmTexture : FormBase
    {
        public frmTexture(BOIDEnum boId)
            : base(boId)
        {
            InitializeComponent();
        }

        private void frmTexture_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        public void LoadGridData()
        {
            IList textures = m_bo.GetDataList();
            List<TextureMD> textureList = Utilities.ConvertList<TextureMD>(textures);
            TextureMD newTexture = new TextureMD();
            newTexture.ID = BusinessObject.GetBONextID(m_boId);
            textureList.Add(newTexture);
            objList.SetObjects(textureList);
        }

        public static bool DisplayTextureBo(BOIDEnum boid, string key, bool isReport)
        {
            bool result = true;
            frmTexture frmCty = new frmTexture(boid);
            frmCty.MdiParent = FormManager.GetMainForm();
            frmCty.Show();

            return result;
        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            if (this.FormMode == FormMode.Ok)
            {
                return true;
            }
            IList obj = (IList)objList.Objects;
            BOTexture objTxt = (BOTexture)m_bo;
            objTxt.SetDataList(obj);
            return objTxt.Update();
        }

    }
}
