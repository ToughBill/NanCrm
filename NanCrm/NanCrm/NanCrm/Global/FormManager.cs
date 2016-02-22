﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nan.BusinessObjects;
using NanCrm.Setup;
using NanCrm.Product;
using System.Windows.Forms;
using Nan.Controls;
using Nan.BusinessObjects.BO;

namespace NanCrm.Global
{
    public class FormManager
    {
        public static bool DisplayForm(BOIDEnum boid, string key, FormMode formMode, bool isReport = false, DeleReturnProc retProc = null)
        {
            bool result = true;
            Form mainForm = FormManager.GetMainForm();
            switch (boid)
            {
                case BOIDEnum.Country:
                    frmCountry cty = new frmCountry(BOIDEnum.Country);
                    cty.MdiParent = mainForm;
                    cty.UpdateProc = retProc;
                    cty.Show();
                    break;
                case BOIDEnum.Market:
                    frmMarketList mkt = new frmMarketList();
                    mkt.MdiParent = mainForm;
                    mkt.UpdateProc = retProc;
                    mkt.Show();
                    break;
                case BOIDEnum.BP:
                    BPMD bpmd = new BPMD(BOIDEnum.BP);
                    bpmd.MdiParent = mainForm;
                    bpmd.UpdateProc = retProc;
                    bpmd.Show();
                    break;
                case BOIDEnum.ProductGroup:
                    frmProductGroup frmProGrp = new frmProductGroup();
                    frmProGrp.MdiParent = mainForm;
                    frmProGrp.Show();
                    break;
                case BOIDEnum.Product:
                    frmProduct frmPro = new frmProduct(BOIDEnum.Product);
                    frmPro.MdiParent = mainForm;
                    frmPro.UpdateProc = retProc;
                    frmPro.Show();
                    break;
                case BOIDEnum.Texture:
                    frmTexture frmTxt = new frmTexture(BOIDEnum.Texture);
                    frmTxt.MdiParent = mainForm;
                    frmTxt.UpdateProc = retProc;
                    frmTxt.Show();
                    break;
                default: break;
            }
            return result;
        }

        private static frmMain m_mainForm;
        public static frmMain GetMainForm()
        {
            return m_mainForm;
        }
        public static void SetMainForm(frmMain form)
        {
            m_mainForm = form;
        }
    }
}
