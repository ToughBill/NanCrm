using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Nan.BusinessObjects.BO
{
    public class MarketMD
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }
    public class MarketDetaiedlMD
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Countries { get; set; }

        public MarketDetaiedlMD(MarketMD mkt)
        {
            this.ID = mkt.ID;
            this.Name = mkt.Name;
            this.Desc = mkt.Desc;
        }
    }
    public class BOMarket : BusinessObject
    {
        private MarketMD m_boMkt;
        public BOMarket()
        {
            base.m_boId = BOIDEnum.Market;
            m_boMkt = new MarketMD();
            m_relatedBO.Add(BOIDEnum.MarketDetail);
        }

        public override bool Init()
        {
            m_boMkt.ID = GetNextID();

            return base.Init();
        }

        public override bool OnIsValid()
        {
            bool isValid = true;
            List<MarketMD> list = new List<MarketMD>((IEnumerable<MarketMD>)m_newDataList);
            int i = 0;
            for (; i < list.Count; i++)
            {
                if (string.IsNullOrEmpty(list[i].Name))
                {
                    if (i < list.Count - 1)
                    {
                        isValid = false;
                        break;
                    }
                    else
                    {
                        m_newDataList.RemoveAt(i);
                    }
                    break;
                }
            }
            return isValid;
        }

        public List<MktDetailMD> GetMarketDetail(int mktID)
        {
            List<MktDetailMD> result = new List<MktDetailMD>();
            BOMarketDetail mktDetailBo = new BOMarketDetail();
            IEnumerator iter = mktDetailBo.GetDataList().GetEnumerator();
            while (iter.MoveNext())
            {
                MktDetailMD bo = ((Newtonsoft.Json.Linq.JObject)iter.Current).ConvertToTarget<MktDetailMD>();
                if (bo.MktId == mktID)
                {
                    result.Add(bo);
                }
            }

            return result;
        }
    }
}
