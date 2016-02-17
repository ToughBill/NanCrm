using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class MktDetailMD : BusinessObject
    {
        public int      ID { get; set; }
        public int   MktId { get; set; }
        public string   Country { get; set; }
    }
    public class BOMarketDetail : BusinessObject
    {
        private MktDetailMD m_boMktDetail;
        public BOMarketDetail()
        {
            base.m_boId = BOIDEnum.Market;
            m_boMktDetail = new MktDetailMD();
        }

        public override bool Init()
        {
            m_boMktDetail.ID = GetNextID();

            return base.Init();
        }
    }
}
