using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class MktDetailMD : BusinessObject
    {
        public int ID { get; set; }
        public int MktId { get; set; }
        public int CountryId { get; set; }
    }
    public class BOMarketDetail : BusinessObject
    {
        private MktDetailMD m_boMktDetail;
        public BOMarketDetail()
        {
            base.m_boId = BOIDEnum.MarketDetail;
            m_boMktDetail = new MktDetailMD();
            m_relatedBO.Add(BOIDEnum.Country);
        }

        public override bool Init()
        {
            m_boMktDetail.ID = GetNextID();

            return base.Init();
        }
    }
}
