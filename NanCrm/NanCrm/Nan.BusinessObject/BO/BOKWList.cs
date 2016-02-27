using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace Nan.BusinessObjects.BO
{
    public class KWListMD
    {
        public int          ID { get; set; }
        public string       Name { get; set; }
        public string       Desc { get; set; }
        public List<int>    KeyWrodIds {get;set;}

        public KWListMD()
        {
            Name = Desc = string.Empty;
            KeyWrodIds = new List<int>();
        }
    }
    public class KWListDetailMD
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string KeyWords { get; set; }

        private KWListMD m_kwMd;
        public KWListDetailMD(KWListMD kwMd)
        {
            this.ID = kwMd.ID;
            this.Name = kwMd.Name;
            this.Desc = kwMd.Desc;
            m_kwMd = kwMd;
        }

        public KWListMD GetOrignalMD()
        {
            return m_kwMd;
        }
    }

    public class BOKWList : BusinessObject
    {
        public BOKWList()
        {
            base.m_boId = BOIDEnum.KeyWordList;
            m_boTable = new KWListMD();
        }
        public override bool Init()
        {
            KWListMD kwlMd = (KWListMD)m_boTable;
            kwlMd.ID = GetNextID();

            return base.Init();
        }

        public List<KWListDetailMD> GetDetialedMD()
        {
            List<KWListDetailMD> result = new List<KWListDetailMD>();
            IList list = GetDataList();
            IEnumerator iter = m_dataList.GetEnumerator();
            string kwTbName = GetTableName(BOIDEnum.KeyWord);
            while (iter.MoveNext())
            {
                KWListMD kwMd = ((JObject)iter.Current).ConvertToTarget<KWListMD>();
                KWListDetailMD bo = new KWListDetailMD(kwMd);
                string kwStr = string.Empty;
                foreach (int kwId in kwMd.KeyWrodIds)
                {
                    JObject jo = m_dbConn.GetTableData(kwTbName, kwId);
                    kwStr += jo.GetValue("Name").ToString() + ", ";
                }
                if (kwStr.Length > 0)
                {
                    kwStr = kwStr.Substring(0, kwStr.Length - 2);
                }
                bo.KeyWords = kwStr;

                result.Add(bo);
            }
            return result;
        }

        public string GetKetWordString()
        {
            string result = string.Empty;

            KWListMD tb = (KWListMD)m_boTable;
            foreach (int id in tb.KeyWrodIds)
            {
                BOKeyWord kwBo = (BOKeyWord)BOFactory.GetBO(BOIDEnum.KeyWord);
                kwBo.GetById(id);
                result += ((KeyWordMD)kwBo.GetBOTable()).Name + ", ";
            }
            if (result.Length > 0)
            {
                result = result.Substring(0, result.Length - 2);
            }

            return result;
        }
    }
}
