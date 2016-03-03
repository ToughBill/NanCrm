using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class ProductSearchPlanMD : ICopyFrom
    {
        public int          ID { get; set; }
        public DateTime?    SDate { get; set; }
        public DateTime?    EDate { get; set; }
        public string       Product { get; set; }
        public int          Status { get; set; }
        public int?         SerPlantf { get; set; }
        public string       KeyWord { get; set; }
        public int?         KWLst { get; set; }
        public string       Comment { get; set; }

        public ProductSearchPlanMD()
        {
            this.Product = this.KeyWord = this.Comment = string.Empty;
        }

        public object CopyFrom(object fromObj)
        {
            ProductSearchPlanMD source = (ProductSearchPlanMD)fromObj;
            if (source == null)
            {
                return this;
            }
            this.ID = source.ID;
            this.SDate = source.SDate;
            this.EDate = source.EDate;
            this.Product = source.Product;
            this.Status = source.Status;
            this.SerPlantf = source.SerPlantf;
            this.KeyWord = source.KeyWord;
            this.KWLst = source.KWLst;
            this.Comment = source.Comment;
            return this;
        }
    }

    public class BOProductSearchPlan : BusinessObject
    {
        public BOProductSearchPlan()
        {
            base.m_boId = BOIDEnum.PSearchPlan;
            m_boTable = new ProductSearchPlanMD();
        }

        public override bool Init()
        {
            base.Init();
            ProductSearchPlanMD boPro = (ProductSearchPlanMD)m_boTable;
            boPro.ID = GetNextID();

            return true;
        }
    }
}
