using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class ProductSearchResultMD : ICopyFrom
    {
        public int      ID { get; set; }
        public int      PSPId { get; set; }
        public string   Product { get; set; }
        public string   Link { get; set; }
        public int?     Plantf { get; set; }
        public string   KeyWord { get; set; }
        public int?     KWLst { get; set; }

        public object CopyFrom(object fromObj)
        {
            ProductSearchResultMD source = (ProductSearchResultMD)fromObj;
            if (source == null || source == this)
            {
                return this;
            }
            this.ID = source.ID;
            this.PSPId = source.PSPId;
            this.Product = source.Product;
            this.Link = source.Link;
            this.Plantf = source.Plantf;
            this.KeyWord = source.KeyWord;
            this.KWLst = source.KWLst;

            return this;
        }
    }

    public class BOProductSearchResult : BusinessObject
    {
        public BOProductSearchResult()
        {
            base.m_boId = BOIDEnum.PSearchResult;
            m_boTable = new ProductSearchResultMD();
        }

        public override bool Init()
        {
            base.Init();
            ProductSearchResultMD boPro = (ProductSearchResultMD)m_boTable;
            boPro.ID = GetNextID();

            return true;
        }
    }
}
