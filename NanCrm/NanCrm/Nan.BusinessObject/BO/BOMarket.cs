using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace Nan.BusinessObjects.BO
{
    public class MarketMD
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public List<int> CountryIds { get; set; }
        public MarketMD()
        {
            Name = string.Empty;
            Desc = string.Empty;
            CountryIds = new List<int>();
        }
    }
    public class MarketDetaiedlMD
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Countries { get; set; }
        private MarketMD m_mkt;

        public MarketDetaiedlMD(MarketMD mkt)
        {
            this.ID = mkt.ID;
            this.Name = mkt.Name;
            this.Desc = mkt.Desc;
            m_mkt = mkt;
        }
        public MarketMD GetOrignalMD()
        {
            return m_mkt;
        }
    }
    [BOAttribute(Name = "城市")]
    public class BOMarket : BusinessObject
    {
        public BOMarket()
        {
            base.m_boId = BOIDEnum.Market;
            m_boTable = new MarketMD();
            m_relatedBO.Add(BOIDEnum.Country);
        }

        public override bool Init()
        {
            MarketMD mktBo = (MarketMD)m_boTable;
            mktBo.ID = GetNextID();
            mktBo.Name = mktBo.Desc = string.Empty;


            return base.Init();
        }

        public override bool OnIsValid()
        {
            bool isValid = true;
            if (m_boTable != null)
            {
                MarketMD mktBo = (MarketMD)m_boTable;
                if (string.IsNullOrEmpty(mktBo.Name))
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        public List<CountryMD> GetMktCountry()
        {
            List<CountryMD> result = new List<CountryMD>();
            string ctyTbName = GetTableName(BOIDEnum.Country);
            string counties = string.Empty;
            MarketMD mkt = (MarketMD)m_boTable;
            foreach (int ctyId in mkt.CountryIds)
            {
                CountryMD cty = m_dbConn.GetTableData(ctyTbName, ctyId).ConvertToTarget<CountryMD>();
                result.Add(cty);
            }
            
            return result;
        }

        public string GetCountryString()
        {
            List<CountryMD> cty = GetMktCountry();
            string counties = string.Empty;
            cty.ForEach(x=>counties+=x.Name+", ");
            if(counties.Length > 0)
            {
                counties = counties.Substring(0, counties.Length - 2);
            }
            return counties;
        }

        public List<MarketDetaiedlMD> GetDetailedMarketMD()
        {
            List<MarketDetaiedlMD> result = new List<MarketDetaiedlMD>();
            if (m_dataList == null)
            {
                m_dataList = GetDataList();
            }
            /*List<JObject> ctyList = BusinessObject.BODataPool[BOIDEnum.Country].Cast<JObject>().ToList();*/
            IEnumerator iterMkt = m_dataList.GetEnumerator();
            string ctyTbName = GetTableName(BOIDEnum.Country);
            while (iterMkt.MoveNext())
            {
                MarketMD mktMD = ((Newtonsoft.Json.Linq.JObject)iterMkt.Current).ConvertToTarget<MarketMD>();
                MarketDetaiedlMD bo = new MarketDetaiedlMD(mktMD);
                string counties = string.Empty;
                foreach (int ctyId in mktMD.CountryIds)
                {
                    JObject jo = m_dbConn.GetTableData(ctyTbName, ctyId);
                    counties += jo.GetValue("Name").ToString() + ", ";
                }
                if (counties.Length > 0)
                {
                    counties = counties.Substring(0, counties.Length - 2);
                }
                bo.Countries = counties;

                result.Add(bo);
            }
            return result;
        }

        public override bool GetById(int id)
        {
            MarketMD mkt = m_dbConn.GetTableData(GetTableName(), id).ConvertToTarget<MarketMD>();
            m_boTable = mkt;

            return m_boTable == null;
        }
    }
}
