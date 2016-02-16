﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nan.BusinessObjects;
using NanCrm.Setup;
using NanCrm.Product;
using System.Windows.Forms;
using Nan.Controls;

namespace NanCrm.Global
{
    class FormManager
    {
        public static bool DisplayForm(BOIDEnum boid, string key, FormMode formMode, bool isReport = false)
        {
            bool result = true;
            Form mainForm = FormManager.GetMainForm();
            switch (boid)
            {
                case BOIDEnum.Country:
                    frmCountry cty = new frmCountry(BOIDEnum.Country);
                    cty.MdiParent = mainForm;
                    cty.Show();
                    break;
                case BOIDEnum.Market:
                    frmMarket mkt = new frmMarket(BOIDEnum.Market);
                    mkt.MdiParent = mainForm;
                    mkt.Show();
                    break;
                case BOIDEnum.BP:
                    BPMD bpmd = new BPMD(BOIDEnum.BP);
                    bpmd.MdiParent = mainForm;
                    bpmd.Show();
                    break;
                case BOIDEnum.Product:
                    frmProduct frmPro = new frmProduct(BOIDEnum.Product);
                    frmPro.MdiParent = mainForm;
                    frmPro.Show();
                    break;
                default: break;
            }
            return result;
        }

        public static Form GetMainForm()
        {
            Form frm = Form.ActiveForm;
            while (!(frm != null && frm is frmMain))
            {
                frm = frm.MdiParent;
            }
            return frm;
        }
    }
}
