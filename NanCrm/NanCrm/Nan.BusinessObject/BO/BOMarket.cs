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

        public MarketDetaiedlMD(MarketMD mkt)
        {
            this.ID = mkt.ID;
            this.Name = mkt.Name;
            this.Desc = mkt.Desc;
        }
    }
    public class BOMarket : BusinessObject
    {
        //private MarketMD m_bo;
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

            return base.Init();
        }
        //public override object GetBOTable()
        //{
        //    return m_bo;
        //}
        public override bool OnIsValid()
        {
            bool isValid = true;
            if (m_newDataList != null)
            {
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
            }
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

        public List<JObject> GetMktCountry(int mktId)
        {
            List<JObject> result = new List<JObject>();
            List<JObject> mktList = BusinessObject.BODataPool[BOIDEnum.Market].Cast<JObject>().ToList();
            JObject jo = mktList.Find(x => int.Parse(x.GetValue("ID").ToString()) == mktId);
            if (jo == null)
            {
                return result;
            }
            List<JObject> mktDataillist = BusinessObject.BODataPool[BOIDEnum.MarketDetail].Cast<JObject>().ToList();
            result = mktDataillist.Where(x => int.Parse(x.GetValue("MktId").ToString()) == mktId).ToList();
            return result;
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
    }
}
