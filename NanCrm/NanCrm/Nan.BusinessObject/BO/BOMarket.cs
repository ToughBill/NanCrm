﻿using System;
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
            List<JObject> mktDataillist = BusinessObject.BODataPool[BOIDEnum.MarketDetail].Cast<JObject>().ToList();
            List<JObject> ctyList = BusinessObject.BODataPool[BOIDEnum.Country].Cast<JObject>().ToList();
            IEnumerator iterMkt = BusinessObject.BODataPool[BOIDEnum.Market].GetEnumerator();
            IEnumerator iterMktDel = BusinessObject.BODataPool[BOIDEnum.MarketDetail].GetEnumerator();
            while(iterMkt.MoveNext())
            {
                MarketMD mktMD = ((Newtonsoft.Json.Linq.JObject)iterMkt.Current).ConvertToTarget<MarketMD>();
                MarketDetaiedlMD bo = new MarketDetaiedlMD(mktMD);
                List<JObject> detail = mktDataillist.Where(x=>int.Parse(x.GetValue("MktId").ToString()) == mktMD.ID).ToList<JObject>();
                string counties=string.Empty;
                if (detail.Count > 0)
                {
                    List<int> ctyId = new List<int>();
                    detail.ForEach(x => ctyId.Add(int.Parse(x.GetValue("CountryId").ToString())));
                    ctyList.ForEach(new Action<JObject>(delegate(JObject jo)
                    {
                        if (ctyId.Contains(int.Parse(jo.GetValue("ID").ToString())))
                        {
                            counties += jo.GetValue("Name").ToString() + ", ";
                        }
                    }));
                    counties = counties.Substring(0, counties.Length - 2);
                }
                bo.Countries = counties;
            }


            return result;
        }
    }
}
